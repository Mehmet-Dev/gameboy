namespace Gameboy.Core;

public struct Registers
{
    // 8 bit registers
    public byte A;
    public byte F; // lower 4 bits are flags

    public byte B;
    public byte C;

    public byte D;
    public byte E;

    public byte H;
    public byte L;

    
    public ushort AF
    {
        get => (ushort)((A << 8) | F);
        set { A = (byte)(value >> 8); F = (byte)(value & 0xFF); }
    }

    public ushort BC
    {
        get => (ushort)((B << 8) | C);
        set { B = (byte)(value >> 8); C = (byte)(value & 0xFF); }
    }

    public ushort DE
    {
        get => (ushort)((D << 8) | E);
        set { D = (byte)(value >> 8); E = (byte)(value & 0xFF); }
    }

    public ushort HL
    {
        get => (ushort)((H << 8) | L);
        set { H = (byte)(value >> 8); L = (byte)(value & 0xFF); }
    }

    // Easy flag helpers
    public bool ZeroFlag
    {
        get => (F & 0x80) != 0;
        set => F = value ? (byte)(F | 0x80) : (byte)(F & ~0x80);
    }

    public bool SubtractFlag
    {
        get => (F & 0x40) != 0;
        set => F = value ? (byte)(F | 0x40) : (byte)(F & ~0x40);
    }

    public bool HalfCarryFlag
    {
        get => (F & 0x20) != 0;
        set => F = value ? (byte)(F | 0x20) : (byte)(F & ~0x20);
    }

    public bool CarryFlag
    {
        get => (F & 0x10) != 0;
        set => F = value ? (byte)(F | 0x10) : (byte)(F & ~0x10);
    }
}