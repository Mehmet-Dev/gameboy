namespace Gameboy.Core;

public partial class CPU
{
    // ================== START OR OPCODES ==================

    private ushort Opcode_B0() { Reg.A = BitwiseOr(Reg.B); return 4; }
    private ushort Opcode_B1() { Reg.A = BitwiseOr(Reg.C); return 4; }
    private ushort Opcode_B2() { Reg.A = BitwiseOr(Reg.D); return 4; }
    private ushort Opcode_B3() { Reg.A = BitwiseOr(Reg.E); return 4; }
    private ushort Opcode_B4() { Reg.A = BitwiseOr(Reg.H); return 4; }
    private ushort Opcode_B5() { Reg.A = BitwiseOr(Reg.L); return 4; }
    private ushort Opcode_B6() { Reg.A = BitwiseOr(Bus.ReadByte(Reg.HL)); return 8; }
    private ushort Opcode_B7() { Reg.A = BitwiseOr(Reg.A); return 4; }

    private ushort Opcode_F6()
    {
        byte v = Bus.ReadByte(ProgramCounter);
        ProgramCounter++;
        Reg.A = BitwiseOr(v);
        return 8;
    }

    // ================== END OR OPCODES ==================
    // ================== START XOR OPCODES ==================

    private ushort Opcode_A8() { Reg.A = BitwiseXor(Reg.B); return 4; }
    private ushort Opcode_A9() { Reg.A = BitwiseXor(Reg.C); return 4; }
    private ushort Opcode_AA() { Reg.A = BitwiseXor(Reg.D); return 4; }
    private ushort Opcode_AB() { Reg.A = BitwiseXor(Reg.E); return 4; }
    private ushort Opcode_AC() { Reg.A = BitwiseXor(Reg.H); return 4; }
    private ushort Opcode_AD() { Reg.A = BitwiseXor(Reg.L); return 4; }
    private ushort Opcode_AE() { Reg.A = BitwiseXor(Bus.ReadByte(Reg.HL)); return 8; }
    private ushort Opcode_AF() { Reg.A = BitwiseXor(Reg.A); return 4; }

    private ushort Opcode_EE()
    {
        byte v = Bus.ReadByte(ProgramCounter);
        ProgramCounter++;
        Reg.A = BitwiseXor(v);
        return 8;
    }

    // ================== END XOR OPCODES ==================
    // ================== START AND OPCODES ==================

    private ushort Opcode_A0() { Reg.A = BitwiseAnd(Reg.B); return 4; }
    private ushort Opcode_A1() { Reg.A = BitwiseAnd(Reg.C); return 4; }
    private ushort Opcode_A2() { Reg.A = BitwiseAnd(Reg.D); return 4; }
    private ushort Opcode_A3() { Reg.A = BitwiseAnd(Reg.E); return 4; }
    private ushort Opcode_A4() { Reg.A = BitwiseAnd(Reg.H); return 4; }
    private ushort Opcode_A5() { Reg.A = BitwiseAnd(Reg.L); return 4; }
    private ushort Opcode_A6() { Reg.A = BitwiseAnd(Bus.ReadByte(Reg.HL)); return 8; }
    private ushort Opcode_A7() { Reg.A = BitwiseAnd(Reg.A); return 4; }

    private ushort Opcode_E6()
    {
        byte v = Bus.ReadByte(ProgramCounter);
        ProgramCounter++;
        Reg.A = BitwiseAnd(v);
        return 8;
    }


    // ================== END AND OPCODES ==================
    // ================== START CP OPCODES ==================

    private ushort Opcode_B8() { Compare(Reg.B); return 4; }
    private ushort Opcode_B9() { Compare(Reg.C); return 4; }
    private ushort Opcode_BA() { Compare(Reg.D); return 4; }
    private ushort Opcode_BB() { Compare(Reg.E); return 4; }
    private ushort Opcode_BC() { Compare(Reg.H); return 4; }
    private ushort Opcode_BD() { Compare(Reg.L); return 4; }
    private ushort Opcode_BE()
    {
        Compare(Bus.ReadByte(Reg.HL));
        return 8;
    }
    private ushort Opcode_BF() { Compare(Reg.A); return 4; }
    private ushort Opcode_FE()
    {
        byte v = Bus.ReadByte(ProgramCounter);
        ProgramCounter++;
        Compare(v);
        return 8;
    }
    // ================== END CP OPCODES ==================
}