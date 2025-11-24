using Gameboy.Graphics;

namespace Gameboy.Core;

public partial class MemoryBus
{
    private byte[] Rom;       // 0x0000–0x7FFF (MBC0 for now)
    private byte[] ERam;      // 0xA000–0xBFFF (external RAM for cartridges, MBC0 = none)
    private byte[] WRam = new byte[0x2000]; // 8 KB work RAM
    private byte[] HRam = new byte[0x7F];   // 0xFF80–0xFFFE high RAM
    private byte[] Oam = new byte[0xA0];    // Sprite attribute table
    private byte[] Io = new byte[0x80];     // 0xFF00–0xFF7F

    public PPU Ppu { get; private set; }

    private bool BootRomEnabled = true;
    private byte[] BootRom;   // 256-byte DMG boot rom

    public MemoryBus()
    {
        Ppu = new(this);
    }

    // ---------------------------------------------------------
    // LOAD ROM
    // ---------------------------------------------------------
    public void LoadRom(byte[] romData)
    {
        Rom = romData;
        ERam = new byte[0x2000]; // Only for MBC0 right now
    }

    public void LoadBootRom(byte[] boot)
    {
        BootRom = boot;
    }

    // ---------------------------------------------------------
    // MEMORY READ
    // ---------------------------------------------------------
    public byte ReadByte(ushort addr)
    {
        // 0. Boot ROM
        if (BootRomEnabled && addr < 0x0100)
            return BootRom[addr];

        // 1. ROM
        if (addr < 0x8000)
            return Rom[addr];

        // 2. VRAM
        if (addr >= 0x8000 && addr <= 0x9FFF)
            return Ppu.ReadVRAM(addr - 0x8000);

        // 3. External RAM
        if (addr >= 0xA000 && addr <= 0xBFFF)
            return ERam[addr - 0xA000];

        // 4. Work RAM
        if (addr >= 0xC000 && addr <= 0xDFFF)
            return WRam[addr - 0xC000];

        // 5. Echo RAM
        if (addr >= 0xE000 && addr <= 0xFDFF)
            return WRam[addr - 0xE000];

        // 6. OAM
        if (addr >= 0xFE00 && addr <= 0xFE9F)
            return Oam[addr - 0xFE00];

        // 7. Unusable memory
        if (addr >= 0xFEA0 && addr <= 0xFEFF)
            return 0xFF;

        // 8. I/O registers
        if (addr >= 0xFF00 && addr <= 0xFF7F)
            return ReadIO(addr);

        // 9. High RAM
        if (addr >= 0xFF80 && addr <= 0xFFFE)
            return HRam[addr - 0xFF80];

        // 10. Interrupt Enable (IE)
        if (addr == 0xFFFF)
            return Io[0x7F];

        return 0xFF;
    }

    // ---------------------------------------------------------
    // MEMORY WRITE
    // ---------------------------------------------------------
    public void WriteByte(ushort addr, byte val)
    {
        // 0. ROM area (ignored for MBC0)
        if (addr < 0x8000)
            return;

        // 1. VRAM
        if (addr >= 0x8000 && addr <= 0x9FFF)
        {
            Ppu.WriteVRAM(addr - 0x8000, val);
            return;
        }

        // 2. Ext RAM
        if (addr >= 0xA000 && addr <= 0xBFFF)
        {
            ERam[addr - 0xA000] = val;
            return;
        }

        // 3. Work RAM
        if (addr >= 0xC000 && addr <= 0xDFFF)
        {
            WRam[addr - 0xC000] = val;
            return;
        }

        // 4. Echo RAM
        if (addr >= 0xE000 && addr <= 0xFDFF)
        {
            WRam[addr - 0xE000] = val;
            return;
        }

        // 5. OAM
        if (addr >= 0xFE00 && addr <= 0xFE9F)
        {
            Oam[addr - 0xFE00] = val;
            return;
        }

        // 6. Unusable region
        if (addr >= 0xFEA0 && addr <= 0xFEFF)
            return;

        // 7. IO
        if (addr >= 0xFF00 && addr <= 0xFF7F)
        {
            WriteIO(addr, val);
            return;
        }

        // 8. HRAM
        if (addr >= 0xFF80 && addr <= 0xFFFE)
        {
            HRam[addr - 0xFF80] = val;
            return;
        }

        // 9. IE
        if (addr == 0xFFFF)
        {
            Io[0x7F] = val;
        }
    }
}