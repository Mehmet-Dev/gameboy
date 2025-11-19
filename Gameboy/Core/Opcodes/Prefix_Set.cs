namespace Gameboy.Core;

public partial class CPU
{
    // ================== CB: SET 0, r ==================
    private ushort CbOpcode_C0() { Reg.B = SetBit(Reg.B, 0); return 8; }
    private ushort CbOpcode_C1() { Reg.C = SetBit(Reg.C, 0); return 8; }
    private ushort CbOpcode_C2() { Reg.D = SetBit(Reg.D, 0); return 8; }
    private ushort CbOpcode_C3() { Reg.E = SetBit(Reg.E, 0); return 8; }
    private ushort CbOpcode_C4() { Reg.H = SetBit(Reg.H, 0); return 8; }
    private ushort CbOpcode_C5() { Reg.L = SetBit(Reg.L, 0); return 8; }
    private ushort CbOpcode_C6()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = SetBit(v, 0);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }
    private ushort CbOpcode_C7() { Reg.A = SetBit(Reg.A, 0); return 8; }

    // ================== CB: SET 1, r ==================
    private ushort CbOpcode_C8() { Reg.B = SetBit(Reg.B, 1); return 8; }
    private ushort CbOpcode_C9() { Reg.C = SetBit(Reg.C, 1); return 8; }
    private ushort CbOpcode_CA() { Reg.D = SetBit(Reg.D, 1); return 8; }
    private ushort CbOpcode_CB() { Reg.E = SetBit(Reg.E, 1); return 8; }
    private ushort CbOpcode_CC() { Reg.H = SetBit(Reg.H, 1); return 8; }
    private ushort CbOpcode_CD() { Reg.L = SetBit(Reg.L, 1); return 8; }
    private ushort CbOpcode_CE()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = SetBit(v, 1);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }
    private ushort CbOpcode_CF() { Reg.A = SetBit(Reg.A, 1); return 8; }

    // ================== CB: SET 2, r ==================
    private ushort CbOpcode_D0() { Reg.B = SetBit(Reg.B, 2); return 8; }
    private ushort CbOpcode_D1() { Reg.C = SetBit(Reg.C, 2); return 8; }
    private ushort CbOpcode_D2() { Reg.D = SetBit(Reg.D, 2); return 8; }
    private ushort CbOpcode_D3() { Reg.E = SetBit(Reg.E, 2); return 8; }
    private ushort CbOpcode_D4() { Reg.H = SetBit(Reg.H, 2); return 8; }
    private ushort CbOpcode_D5() { Reg.L = SetBit(Reg.L, 2); return 8; }
    private ushort CbOpcode_D6()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = SetBit(v, 2);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }
    private ushort CbOpcode_D7() { Reg.A = SetBit(Reg.A, 2); return 8; }

    // ================== CB: SET 3, r ==================
    private ushort CbOpcode_D8() { Reg.B = SetBit(Reg.B, 3); return 8; }
    private ushort CbOpcode_D9() { Reg.C = SetBit(Reg.C, 3); return 8; }
    private ushort CbOpcode_DA() { Reg.D = SetBit(Reg.D, 3); return 8; }
    private ushort CbOpcode_DB() { Reg.E = SetBit(Reg.E, 3); return 8; }
    private ushort CbOpcode_DC() { Reg.H = SetBit(Reg.H, 3); return 8; }
    private ushort CbOpcode_DD() { Reg.L = SetBit(Reg.L, 3); return 8; }
    private ushort CbOpcode_DE()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = SetBit(v, 3);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }
    private ushort CbOpcode_DF() { Reg.A = SetBit(Reg.A, 3); return 8; }

    // ================== CB: SET 4, r ==================
    private ushort CbOpcode_E0() { Reg.B = SetBit(Reg.B, 4); return 8; }
    private ushort CbOpcode_E1() { Reg.C = SetBit(Reg.C, 4); return 8; }
    private ushort CbOpcode_E2() { Reg.D = SetBit(Reg.D, 4); return 8; }
    private ushort CbOpcode_E3() { Reg.E = SetBit(Reg.E, 4); return 8; }
    private ushort CbOpcode_E4() { Reg.H = SetBit(Reg.H, 4); return 8; }
    private ushort CbOpcode_E5() { Reg.L = SetBit(Reg.L, 4); return 8; }
    private ushort CbOpcode_E6()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = SetBit(v, 4);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }
    private ushort CbOpcode_E7() { Reg.A = SetBit(Reg.A, 4); return 8; }

    // ================== CB: SET 5, r ==================
    private ushort CbOpcode_E8() { Reg.B = SetBit(Reg.B, 5); return 8; }
    private ushort CbOpcode_E9() { Reg.C = SetBit(Reg.C, 5); return 8; }
    private ushort CbOpcode_EA() { Reg.D = SetBit(Reg.D, 5); return 8; }
    private ushort CbOpcode_EB() { Reg.E = SetBit(Reg.E, 5); return 8; }
    private ushort CbOpcode_EC() { Reg.H = SetBit(Reg.H, 5); return 8; }
    private ushort CbOpcode_ED() { Reg.L = SetBit(Reg.L, 5); return 8; }
    private ushort CbOpcode_EE()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = SetBit(v, 5);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }
    private ushort CbOpcode_EF() { Reg.A = SetBit(Reg.A, 5); return 8; }

    // ================== CB: SET 6, r ==================
    private ushort CbOpcode_F0() { Reg.B = SetBit(Reg.B, 6); return 8; }
    private ushort CbOpcode_F1() { Reg.C = SetBit(Reg.C, 6); return 8; }
    private ushort CbOpcode_F2() { Reg.D = SetBit(Reg.D, 6); return 8; }
    private ushort CbOpcode_F3() { Reg.E = SetBit(Reg.E, 6); return 8; }
    private ushort CbOpcode_F4() { Reg.H = SetBit(Reg.H, 6); return 8; }
    private ushort CbOpcode_F5() { Reg.L = SetBit(Reg.L, 6); return 8; }
    private ushort CbOpcode_F6()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = SetBit(v, 6);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }
    private ushort CbOpcode_F7() { Reg.A = SetBit(Reg.A, 6); return 8; }

    // ================== CB: SET 7, r ==================
    private ushort CbOpcode_F8() { Reg.B = SetBit(Reg.B, 7); return 8; }
    private ushort CbOpcode_F9() { Reg.C = SetBit(Reg.C, 7); return 8; }
    private ushort CbOpcode_FA() { Reg.D = SetBit(Reg.D, 7); return 8; }
    private ushort CbOpcode_FB() { Reg.E = SetBit(Reg.E, 7); return 8; }
    private ushort CbOpcode_FC() { Reg.H = SetBit(Reg.H, 7); return 8; }
    private ushort CbOpcode_FD() { Reg.L = SetBit(Reg.L, 7); return 8; }
    private ushort CbOpcode_FE()
    {
        byte v = Bus.ReadByte(Reg.HL);
        v = SetBit(v, 7);
        Bus.WriteByte(Reg.HL, v);
        return 16;
    }
    private ushort CbOpcode_FF() { Reg.A = SetBit(Reg.A, 7); return 8; }
}
