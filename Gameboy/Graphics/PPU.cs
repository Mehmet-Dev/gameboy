using Gameboy.Utils;

namespace Gameboy.Graphics;

public partial class PPU
{
    public byte[] VRAM;
    public Tile[] Tileset;

    public PPU()
    {
        VRAM = new byte[0x2000];
        Tileset = new Tile[384];

        for (int i = 0; i < 384; i++)
            Tileset[i] = new Tile();
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