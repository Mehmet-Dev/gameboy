namespace Gameboy.Core;

public partial class CPU
{
    // ================== CB: RES 0, r ==================
    private ushort CbOpcode_80() { Reg.B = ResetBit(Reg.B, 0); return 8; }
    private ushort CbOpcode_81() { Reg.C = ResetBit(Reg.C, 0); return 8; }
    private ushort CbOpcode_82() { Reg.D = ResetBit(Reg.D, 0); return 8; }
    private ushort CbOpcode_83() { Reg.E = ResetBit(Reg.E, 0); return 8; }
    private ushort CbOpcode_84() { Reg.H = ResetBit(Reg.H, 0); return 8; }
    private ushort CbOpcode_85() { Reg.L = ResetBit(Reg.L, 0); return 8; }
    private ushort CbOpcode_86()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = ResetBit(v, 0);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }
    private ushort CbOpcode_87() { Reg.A = ResetBit(Reg.A, 0); return 8; }

    // ================== CB: RES 1, r ==================
    private ushort CbOpcode_88() { Reg.B = ResetBit(Reg.B, 1); return 8; }
    private ushort CbOpcode_89() { Reg.C = ResetBit(Reg.C, 1); return 8; }
    private ushort CbOpcode_8A() { Reg.D = ResetBit(Reg.D, 1); return 8; }
    private ushort CbOpcode_8B() { Reg.E = ResetBit(Reg.E, 1); return 8; }
    private ushort CbOpcode_8C() { Reg.H = ResetBit(Reg.H, 1); return 8; }
    private ushort CbOpcode_8D() { Reg.L = ResetBit(Reg.L, 1); return 8; }
    private ushort CbOpcode_8E()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = ResetBit(v, 1);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }
    private ushort CbOpcode_8F() { Reg.A = ResetBit(Reg.A, 1); return 8; }

    // ================== CB: RES 2, r ==================
    private ushort CbOpcode_90() { Reg.B = ResetBit(Reg.B, 2); return 8; }
    private ushort CbOpcode_91() { Reg.C = ResetBit(Reg.C, 2); return 8; }
    private ushort CbOpcode_92() { Reg.D = ResetBit(Reg.D, 2); return 8; }
    private ushort CbOpcode_93() { Reg.E = ResetBit(Reg.E, 2); return 8; }
    private ushort CbOpcode_94() { Reg.H = ResetBit(Reg.H, 2); return 8; }
    private ushort CbOpcode_95() { Reg.L = ResetBit(Reg.L, 2); return 8; }
    private ushort CbOpcode_96()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = ResetBit(v, 2);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }
    private ushort CbOpcode_97() { Reg.A = ResetBit(Reg.A, 2); return 8; }

    // ================== CB: RES 3, r ==================
    private ushort CbOpcode_98() { Reg.B = ResetBit(Reg.B, 3); return 8; }
    private ushort CbOpcode_99() { Reg.C = ResetBit(Reg.C, 3); return 8; }
    private ushort CbOpcode_9A() { Reg.D = ResetBit(Reg.D, 3); return 8; }
    private ushort CbOpcode_9B() { Reg.E = ResetBit(Reg.E, 3); return 8; }
    private ushort CbOpcode_9C() { Reg.H = ResetBit(Reg.H, 3); return 8; }
    private ushort CbOpcode_9D() { Reg.L = ResetBit(Reg.L, 3); return 8; }
    private ushort CbOpcode_9E()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = ResetBit(v, 3);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }
    private ushort CbOpcode_9F() { Reg.A = ResetBit(Reg.A, 3); return 8; }

    // ================== CB: RES 4, r ==================
    private ushort CbOpcode_A0() { Reg.B = ResetBit(Reg.B, 4); return 8; }
    private ushort CbOpcode_A1() { Reg.C = ResetBit(Reg.C, 4); return 8; }
    private ushort CbOpcode_A2() { Reg.D = ResetBit(Reg.D, 4); return 8; }
    private ushort CbOpcode_A3() { Reg.E = ResetBit(Reg.E, 4); return 8; }
    private ushort CbOpcode_A4() { Reg.H = ResetBit(Reg.H, 4); return 8; }
    private ushort CbOpcode_A5() { Reg.L = ResetBit(Reg.L, 4); return 8; }
    private ushort CbOpcode_A6()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = ResetBit(v, 4);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }
    private ushort CbOpcode_A7() { Reg.A = ResetBit(Reg.A, 4); return 8; }

    // ================== CB: RES 5, r ==================
    private ushort CbOpcode_A8() { Reg.B = ResetBit(Reg.B, 5); return 8; }
    private ushort CbOpcode_A9() { Reg.C = ResetBit(Reg.C, 5); return 8; }
    private ushort CbOpcode_AA() { Reg.D = ResetBit(Reg.D, 5); return 8; }
    private ushort CbOpcode_AB() { Reg.E = ResetBit(Reg.E, 5); return 8; }
    private ushort CbOpcode_AC() { Reg.H = ResetBit(Reg.H, 5); return 8; }
    private ushort CbOpcode_AD() { Reg.L = ResetBit(Reg.L, 5); return 8; }
    private ushort CbOpcode_AE()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = ResetBit(v, 5);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }
    private ushort CbOpcode_AF() { Reg.A = ResetBit(Reg.A, 5); return 8; }

    // ================== CB: RES 6, r ==================
    private ushort CbOpcode_B0() { Reg.B = ResetBit(Reg.B, 6); return 8; }
    private ushort CbOpcode_B1() { Reg.C = ResetBit(Reg.C, 6); return 8; }
    private ushort CbOpcode_B2() { Reg.D = ResetBit(Reg.D, 6); return 8; }
    private ushort CbOpcode_B3() { Reg.E = ResetBit(Reg.E, 6); return 8; }
    private ushort CbOpcode_B4() { Reg.H = ResetBit(Reg.H, 6); return 8; }
    private ushort CbOpcode_B5() { Reg.L = ResetBit(Reg.L, 6); return 8; }
    private ushort CbOpcode_B6()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = ResetBit(v, 6);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }
    private ushort CbOpcode_B7() { Reg.A = ResetBit(Reg.A, 6); return 8; }

    // ================== CB: RES 7, r ==================
    private ushort CbOpcode_B8() { Reg.B = ResetBit(Reg.B, 7); return 8; }
    private ushort CbOpcode_B9() { Reg.C = ResetBit(Reg.C, 7); return 8; }
    private ushort CbOpcode_BA() { Reg.D = ResetBit(Reg.D, 7); return 8; }
    private ushort CbOpcode_BB() { Reg.E = ResetBit(Reg.E, 7); return 8; }
    private ushort CbOpcode_BC() { Reg.H = ResetBit(Reg.H, 7); return 8; }
    private ushort CbOpcode_BD() { Reg.L = ResetBit(Reg.L, 7); return 8; }
    private ushort CbOpcode_BE()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = ResetBit(v, 7);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }
    private ushort CbOpcode_BF() { Reg.A = ResetBit(Reg.A, 7); return 8; }
}
