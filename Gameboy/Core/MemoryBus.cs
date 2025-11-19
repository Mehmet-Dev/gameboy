namespace Gameboy.Core;

public class MemoryBus
{
    private const int RAMSIZE = 0xFFFF + 1;

    public byte[] Memory = new byte[RAMSIZE];

    public byte ReadByte(ushort address)
        => Memory[address];
    public void WriteByte(ushort addr, byte value)
        => Memory[addr] = value;
}