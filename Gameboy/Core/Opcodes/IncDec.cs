namespace Gameboy.Core;

public partial class CPU
{
    // ================== START INC OPCODES ==================
    private ushort Opcode_04() { Reg.B = Increment(Reg.B); return 4; }
    private ushort Opcode_0C() { Reg.C = Increment(Reg.C); return 4; }
    private ushort Opcode_14() { Reg.D = Increment(Reg.D); return 4; }
    private ushort Opcode_1C() { Reg.E = Increment(Reg.E); return 4; }
    private ushort Opcode_24() { Reg.H = Increment(Reg.H); return 4; }
    private ushort Opcode_2C() { Reg.L = Increment(Reg.L); return 4; }
    private ushort Opcode_34()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = Increment(v);
        Bus.WriteByte(Reg.HL, v);
        return 12;
    }
    private ushort Opcode_3C() { Reg.A = Increment(Reg.A); return 4; }

    // ================== END INC OPCODES ==================
    // ================== START DEC OPCODES ==================
    private ushort Opcode_05() { Reg.B = Decrement(Reg.B); return 4; }
    private ushort Opcode_0D() { Reg.C = Decrement(Reg.C); return 4; }
    private ushort Opcode_15() { Reg.D = Decrement(Reg.D); return 4; }
    private ushort Opcode_1D() { Reg.E = Decrement(Reg.E); return 4; }
    private ushort Opcode_25() { Reg.H = Decrement(Reg.H); return 4; }
    private ushort Opcode_2D() { Reg.L = Decrement(Reg.L); return 4; }
    private ushort Opcode_35()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = Decrement(v);
        Bus.WriteByte(Reg.HL, v);
        return 12;
    }
    private ushort Opcode_3D() { Reg.A = Decrement(Reg.A); return 4; }
    // ================== END DEC OPCODES ==================
}