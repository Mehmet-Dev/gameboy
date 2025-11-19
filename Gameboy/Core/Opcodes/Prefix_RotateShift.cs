namespace Gameboy.Core;

public partial class CPU
{
    // ================== CB: RLC r ==================

    private ushort CbOpcode_00() { Reg.B = RotateLeftNoCarry(Reg.B); return 8; }
    private ushort CbOpcode_01() { Reg.C = RotateLeftNoCarry(Reg.C); return 8; }
    private ushort CbOpcode_02() { Reg.D = RotateLeftNoCarry(Reg.D); return 8; }
    private ushort CbOpcode_03() { Reg.E = RotateLeftNoCarry(Reg.E); return 8; }
    private ushort CbOpcode_04() { Reg.H = RotateLeftNoCarry(Reg.H); return 8; }
    private ushort CbOpcode_05() { Reg.L = RotateLeftNoCarry(Reg.L); return 8; }

    private ushort CbOpcode_06()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = RotateLeftNoCarry(v);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }

    private ushort CbOpcode_07() { Reg.A = RotateLeftNoCarry(Reg.A); return 8; }

    // ================== CB: RRC r ==================

    private ushort CbOpcode_08() { Reg.B = RotateRightNoCarry(Reg.B); return 8; }
    private ushort CbOpcode_09() { Reg.C = RotateRightNoCarry(Reg.C); return 8; }
    private ushort CbOpcode_0A() { Reg.D = RotateRightNoCarry(Reg.D); return 8; }
    private ushort CbOpcode_0B() { Reg.E = RotateRightNoCarry(Reg.E); return 8; }
    private ushort CbOpcode_0C() { Reg.H = RotateRightNoCarry(Reg.H); return 8; }
    private ushort CbOpcode_0D() { Reg.L = RotateRightNoCarry(Reg.L); return 8; }

    private ushort CbOpcode_0E()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = RotateRightNoCarry(v);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }

    private ushort CbOpcode_0F() { Reg.A = RotateRightNoCarry(Reg.A); return 8; }

    // ================== CB: RL r ==================

    private ushort CbOpcode_10() { Reg.B = RotateLeft(Reg.B); return 8; }
    private ushort CbOpcode_11() { Reg.C = RotateLeft(Reg.C); return 8; }
    private ushort CbOpcode_12() { Reg.D = RotateLeft(Reg.D); return 8; }
    private ushort CbOpcode_13() { Reg.E = RotateLeft(Reg.E); return 8; }
    private ushort CbOpcode_14() { Reg.H = RotateLeft(Reg.H); return 8; }
    private ushort CbOpcode_15() { Reg.L = RotateLeft(Reg.L); return 8; }

    private ushort CbOpcode_16()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = RotateLeft(v);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }

    private ushort CbOpcode_17() { Reg.A = RotateLeft(Reg.A); return 8; }

    // ================== CB: RR r ==================

    private ushort CbOpcode_18() { Reg.B = RotateRight(Reg.B); return 8; }
    private ushort CbOpcode_19() { Reg.C = RotateRight(Reg.C); return 8; }
    private ushort CbOpcode_1A() { Reg.D = RotateRight(Reg.D); return 8; }
    private ushort CbOpcode_1B() { Reg.E = RotateRight(Reg.E); return 8; }
    private ushort CbOpcode_1C() { Reg.H = RotateRight(Reg.H); return 8; }
    private ushort CbOpcode_1D() { Reg.L = RotateRight(Reg.L); return 8; }

    private ushort CbOpcode_1E()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = RotateRight(v);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }

    private ushort CbOpcode_1F() { Reg.A = RotateRight(Reg.A); return 8; }

    // ================== CB: SLA r ==================

    private ushort CbOpcode_20() { Reg.B = ShiftLeftArithmetic(Reg.B); return 8; }
    private ushort CbOpcode_21() { Reg.C = ShiftLeftArithmetic(Reg.C); return 8; }
    private ushort CbOpcode_22() { Reg.D = ShiftLeftArithmetic(Reg.D); return 8; }
    private ushort CbOpcode_23() { Reg.E = ShiftLeftArithmetic(Reg.E); return 8; }
    private ushort CbOpcode_24() { Reg.H = ShiftLeftArithmetic(Reg.H); return 8; }
    private ushort CbOpcode_25() { Reg.L = ShiftLeftArithmetic(Reg.L); return 8; }

    private ushort CbOpcode_26()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = ShiftLeftArithmetic(v);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }

    private ushort CbOpcode_27() { Reg.A = ShiftLeftArithmetic(Reg.A); return 8; }

    // ================== CB: SRA r ==================

    private ushort CbOpcode_28() { Reg.B = ShiftRightArithmetic(Reg.B); return 8; }
    private ushort CbOpcode_29() { Reg.C = ShiftRightArithmetic(Reg.C); return 8; }
    private ushort CbOpcode_2A() { Reg.D = ShiftRightArithmetic(Reg.D); return 8; }
    private ushort CbOpcode_2B() { Reg.E = ShiftRightArithmetic(Reg.E); return 8; }
    private ushort CbOpcode_2C() { Reg.H = ShiftRightArithmetic(Reg.H); return 8; }
    private ushort CbOpcode_2D() { Reg.L = ShiftRightArithmetic(Reg.L); return 8; }

    private ushort CbOpcode_2E()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = ShiftRightArithmetic(v);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }

    private ushort CbOpcode_2F() { Reg.A = ShiftRightArithmetic(Reg.A); return 8; }

    // ================== CB: SWAP r ==================

    private ushort CbOpcode_30() { Reg.B = SwapNibbles(Reg.B); return 8; }
    private ushort CbOpcode_31() { Reg.C = SwapNibbles(Reg.C); return 8; }
    private ushort CbOpcode_32() { Reg.D = SwapNibbles(Reg.D); return 8; }
    private ushort CbOpcode_33() { Reg.E = SwapNibbles(Reg.E); return 8; }
    private ushort CbOpcode_34() { Reg.H = SwapNibbles(Reg.H); return 8; }
    private ushort CbOpcode_35() { Reg.L = SwapNibbles(Reg.L); return 8; }

    private ushort CbOpcode_36()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = SwapNibbles(v);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }

    private ushort CbOpcode_37() { Reg.A = SwapNibbles(Reg.A); return 8; }

    // ================== CB: SRL r ==================

    private ushort CbOpcode_38() { Reg.B = ShiftRightLogical(Reg.B); return 8; }
    private ushort CbOpcode_39() { Reg.C = ShiftRightLogical(Reg.C); return 8; }
    private ushort CbOpcode_3A() { Reg.D = ShiftRightLogical(Reg.D); return 8; }
    private ushort CbOpcode_3B() { Reg.E = ShiftRightLogical(Reg.E); return 8; }
    private ushort CbOpcode_3C() { Reg.H = ShiftRightLogical(Reg.H); return 8; }
    private ushort CbOpcode_3D() { Reg.L = ShiftRightLogical(Reg.L); return 8; }

    private ushort CbOpcode_3E()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = ShiftRightLogical(v);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }

    private ushort CbOpcode_3F() { Reg.A = ShiftRightLogical(Reg.A); return 8; }

}