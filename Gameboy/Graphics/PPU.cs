using Gameboy.Core;
using Gameboy.Utils;

namespace Gameboy.Graphics;

public partial class PPU
{
    private MemoryBus _bus;

    public byte[] VRAM;
    public Tile[] Tileset;
    private readonly byte[] _framebuffer = new byte[160 * 144];
    private Sprite[] _lineSprites = new Sprite[10];

    // The 4 PPU modes
    private const int MODE_HBLANK = 0;    // 204 cycles
    private const int MODE_VBLANK = 1;    // 4560 cycles (10 lines)
    private const int MODE_OAM = 2;       // 80 cycles
    private const int MODE_VRAM = 3;      // 172 cycles

    private int _modeClock = 0; // cycles spent in current mode
    private int _currentMode = MODE_OAM;
    private byte ly = 0;

    public PPU(MemoryBus bus)
    {
        VRAM = new byte[0x2000];
        Tileset = new Tile[384];
        _bus = bus;

        for (int i = 0; i < 384; i++)
            Tileset[i] = new Tile();
    }

    /// <summary>
    /// Actually making shit work or whatever
    /// </summary>
    /// <param name="cyclesElapsed"></param>
    public void Step(int cyclesElapsed)
    {
        _modeClock += cyclesElapsed;

        switch (_currentMode)
        {
            case MODE_OAM:
                {
                    if (_modeClock >= 80)
                    {
                        _modeClock -= 80;
                        _currentMode = MODE_VRAM;
                        UpdateSTAT();
                    }
                    break;
                }
            case MODE_VRAM:
                {
                    if (_modeClock >= 172)
                    {
                        _modeClock -= 172;
                        RenderScanline();
                        _currentMode = MODE_HBLANK;
                        UpdateSTAT();
                    }
                    break;
                }
            case MODE_HBLANK:
                {
                    if (_modeClock >= 204)
                    {
                        _modeClock -= 204;
                        ly++;
                        _bus.SetLY(ly);

                        if (ly == 144)
                        {
                            _currentMode = MODE_VBLANK;
                            _bus.SetIF((byte)(_bus.GetIF() | 0x01));
                            UpdateSTAT();
                        }
                        else
                        {
                            _currentMode = MODE_OAM;
                            UpdateSTAT();
                        }
                    }
                    break;
                }
            case MODE_VBLANK:
                {
                    if (_modeClock >= 456)
                    {
                        _modeClock -= 456;
                        ly++;
                        _bus.SetLY(ly);
                        UpdateSTAT();

                        if (ly > 153)
                        {
                            ly = 0;
                            _bus.SetLY(ly);
                            _currentMode = MODE_OAM;
                            UpdateSTAT();
                        }
                    }
                    break;
                }
        }
    }

    private void UpdateSTAT()
    {
        byte stat = _bus.GetSTAT();

        // updating coincidence flag sounds so fucking funny
        bool coincidence = ly == _bus.GetLYC();
        if (coincidence) stat |= 0b0000_0100;
        else stat &= 0b1111_1011;

        // ----- 2. Write current mode into bits 0–1 -----
        stat = (byte)((stat & 0b1111_1100) | (_currentMode & 0b11));

        // ----- 3. Check LY == LYC interrupt -----
        if (coincidence && (stat & 0b0100_0000) != 0)
            _bus.SetIF((byte)(_bus.GetIF() | 0x02)); // STAT interrupt bit

        // ----- 4. Mode interrupt handling -----
        bool request = false;
        switch (_currentMode)
        {
            case MODE_HBLANK:
                if ((stat & 0b0000_1000) != 0) request = true;
                break;

            case MODE_VBLANK:
                if ((stat & 0b0001_0000) != 0) request = true;
                break;

            case MODE_OAM:
                if ((stat & 0b0010_0000) != 0) request = true;
                break;

            case MODE_VRAM:
                // mode 3 has no interrupt
                break;
        }

        if (request)
            _bus.SetIF((byte)(_bus.GetIF() | 0x02)); // STAT interrupt

        _bus.SetSTAT(stat);
    }

    private void RenderScanline()
    {
        byte lcdc = _bus.GetLCDC();

        bool bgEnabled = (lcdc & 0b0000_0001) != 0;
        bool windowEnabled = (lcdc & 0b0010_0000) != 0;
        bool spritesEnabled = (lcdc & 0b0000_0010) != 0;

        // Order:
        // 1. Background
        // 2. Window
        // 3. Sprites
        if (bgEnabled) RenderBackground();
        if (windowEnabled) RenderWindow();
        if (spritesEnabled) RenderSprites();
    }

    private void RenderBackground()
    {
        byte scx = _bus.GetSCX();
        byte scy = _bus.GetSCY();
        byte lcdc = _bus.GetLCDC();
        byte currentLine = ly;

        // Which background tilemap?
        ushort mapBase = (lcdc & 0b0000_1000) != 0 ? (ushort)0x9C00 : (ushort)0x9800;

        // Which tile data region?
        bool signedIndexing = (lcdc & 0b0001_0000) == 0;

        for (int x = 0; x < 160; x++)
        {
            // Absolute position inside 256x256 BG
            int pixelX = (x + scx) & 0xFF;
            int pixelY = (currentLine + scy) & 0xFF;

            int tileX = pixelX / 8;
            int tileY = pixelY / 8;

            int tileIndexAddress = mapBase + tileY * 32 + tileX;

            byte tileIndex = _bus.ReadByte((ushort)tileIndexAddress);

            // Convert signed indexing if needed
            int actualTile = signedIndexing ? (sbyte)tileIndex + 256 : tileIndex;

            Tile tile = Tileset[actualTile];

            int tilePixelX = pixelX % 8;
            int tilePixelY = pixelY % 8;

            byte color = (byte)tile.Pixels[tilePixelY, tilePixelX];

            _framebuffer[currentLine * 160 + x] = color;
        }
    }

    private int FetchSpritesForScanline()
    {
        int count = 0;
        byte lcdc = _bus.GetLCDC();
        bool tall = (lcdc & 0b0000_0100) != 0; // 8x16 mode

        for (int i = 0; i < 40; i++)
        {
            int oamAddr = 0xFE00 + i * 4;

            int y = _bus.ReadByte((ushort)(oamAddr)) - 16;
            int x = _bus.ReadByte((ushort)(oamAddr + 1)) - 8;
            byte tile = _bus.ReadByte((ushort)(oamAddr + 2));
            byte flags = _bus.ReadByte((ushort)(oamAddr + 3));

            if (ly < y || ly >= y + (tall ? 16 : 8))
                continue; // Not on this scanline

            if (count < 10)
            {
                _lineSprites[count++] = new Sprite()
                {
                    x = x,
                    y = y,
                    tile = tile,
                    flags = flags
                };
            }
        }
        return count;
    }

    private void RenderSprites()
    {
        int count = FetchSpritesForScanline();
        byte lcdc = _bus.GetLCDC();
        bool tall = (lcdc & 0b0000_0100) != 0;

        for (int i = 0; i < count; i++)
        {
            Sprite s = _lineSprites[i];

            int lineInSprite = ly - s.y;

            bool yFlip = (s.flags & 0b01000000) != 0;
            bool xFlip = (s.flags & 0b00100000) != 0;
            bool priority = (s.flags & 0b10000000) != 0;
            bool useOBP1 = (s.flags & 0b00010000) != 0;

            if (yFlip)
                lineInSprite = (tall ? 15 : 7) - lineInSprite;

            // 8x16 mode auto-forces even tile index
            int tileIndex = s.tile;
            if (tall)
                tileIndex &= 0xFE;

            Tile tile = Tileset[tileIndex + (lineInSprite >= 8 ? 1 : 0)];
            int pixelY = lineInSprite % 8;

            for (int px = 0; px < 8; px++)
            {
                int x = s.x + px;
                if (x < 0 || x >= 160)
                    continue;

                int pixelX = xFlip ? 7 - px : px;

                byte color = (byte)tile.Pixels[pixelY, pixelX];
                if (color == 0)
                    continue; // Transparent

                if (priority && _framebuffer[ly * 160 + x] != 0)
                    continue; // Behind BG

                byte palette = useOBP1 ? _bus.GetOBP1() : _bus.GetOBP0();
                byte finalColor = MapPalette(color, palette);

                _framebuffer[ly * 160 + x] = finalColor;
            }
        }
    }

    private byte MapPalette(byte color, byte palette)
    {
        int shift = color * 2;
        return (byte)((palette >> shift) & 0b11);
    }


    private void RenderWindow()
    {
        byte lcdc = _bus.GetLCDC();
        byte wy = _bus.GetWY();
        byte wx = _bus.GetWX();

        // Window disabled if not on this line yet
        if (ly < wy)
            return;

        // WX is weird: real window X = WX - 7
        int windowXStart = wx - 7;
        if (windowXStart < 0) windowXStart = 0;

        // Pick tilemap (LCDC bit 6)
        ushort mapBase = (lcdc & 0b0100_0000) != 0 ? (ushort)0x9C00 : (ushort)0x9800;

        bool signedIndexing = (lcdc & 0b0001_0000) == 0;

        int windowLine = ly - wy; // Y inside the window

        for (int x = 0; x < 160; x++)
        {
            if (x < windowXStart)
                continue; // Window doesn't cover this pixel

            int windowX = x - windowXStart;

            // Determine tile index inside window tilemap
            int tileX = windowX / 8;
            int tileY = windowLine / 8;

            ushort tileIndexAddr = (ushort)(mapBase + tileY * 32 + tileX);
            byte tileIndex = _bus.ReadByte(tileIndexAddr);

            int actualTile = signedIndexing ? (sbyte)tileIndex + 256 : tileIndex;

            Tile tile = Tileset[actualTile];

            int tilePixelX = windowX % 8;
            int tilePixelY = windowLine % 8;

            byte color = (byte)tile.Pixels[tilePixelY, tilePixelX];

            // Overwrite BG pixel
            _framebuffer[ly * 160 + x] = color;
        }
    }



    /// <summary>
    /// Writing into VRAM then decoding the pixels THEN STORING THEM IN [8,8] FORMAT WOW
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    public void WriteVRAM(int index, byte value)
    {
        VRAM[index] = value;

        if (index >= 0x1800)
            return;

        int normalizedIndex = index & 0xfffe;

        byte part1 = VRAM[normalizedIndex];
        byte part2 = VRAM[normalizedIndex + 1];

        int tileIndex = normalizedIndex / 16;
        int rowIndex = normalizedIndex % 16 / 2;

        for (int pixelIndex = 0; pixelIndex < 8; pixelIndex++)
        {
            int mask = 1 << (7 - pixelIndex);

            int lsb = (part1 & mask) != 0 ? 1 : 0;
            int msb = (part2 & mask) != 0 ? 1 : 0;

            int val = (msb << 1) | lsb;

            Tileset[tileIndex].Pixels[rowIndex, pixelIndex] = (TilePixelValue)val;
        }
    }

    /// <summary>
    /// Read the vram yea thas it
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public byte ReadVRAM(int index)
        => VRAM[index];
}