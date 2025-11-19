using Gameboy.Graphics;

namespace Gameboy.Core;

public class MemoryBus
{
    private const int RAMSIZE = 0xFFFF + 1;
    public PPU Ppu = new();

    public byte[] Memory = new byte[RAMSIZE];

    public byte ReadByte(ushort address)
    {
        if(address >= 0x8000 && address <= 0x9fff)
            return Ppu.ReadVRAM(address - 0x8000);
        
        return Memory[address];
    }
        
    public void WriteByte(ushort address, byte value)
    {
        if(address >= 0x8000 && address <= 0x9fff)
        {
            Ppu.WriteVRAM(address - 0x8000, value);
            return;
        }
            
        Memory[address] = value;
    }
}