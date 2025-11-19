namespace Gameboy.Core;

public partial class CPU
{
    // ================== CB: BIT 0, r ==================
    private ushort CbOpcode_40() { BitTest(Reg.B, 0); return 8; }
    private ushort CbOpcode_41() { BitTest(Reg.C, 0); return 8; }
    private ushort CbOpcode_42() { BitTest(Reg.D, 0); return 8; }
    private ushort CbOpcode_43() { BitTest(Reg.E, 0); return 8; }
    private ushort CbOpcode_44() { BitTest(Reg.H, 0); return 8; }
    private ushort CbOpcode_45() { BitTest(Reg.L, 0); return 8; }

    private ushort CbOpcode_46()
    {
        byte v = Bus.ReadByte(Reg.HL);
        BitTest(v, 0);
        return 12;
    }

    private ushort CbOpcode_47() { BitTest(Reg.A, 0); return 8; }

    // ================== CB: BIT 1, r ==================
    private ushort CbOpcode_48() { BitTest(Reg.B, 1); return 8; }
    private ushort CbOpcode_49() { BitTest(Reg.C, 1); return 8; }
    private ushort CbOpcode_4A() { BitTest(Reg.D, 1); return 8; }
    private ushort CbOpcode_4B() { BitTest(Reg.E, 1); return 8; }
    private ushort CbOpcode_4C() { BitTest(Reg.H, 1); return 8; }
    private ushort CbOpcode_4D() { BitTest(Reg.L, 1); return 8; }

    private ushort CbOpcode_4E()
    {
        byte v = Bus.ReadByte(Reg.HL);
        BitTest(v, 1);
        return 12;
    }

    private ushort CbOpcode_4F() { BitTest(Reg.A, 1); return 8; }

    // ================== CB: BIT 2, r ==================
    private ushort CbOpcode_50() { BitTest(Reg.B, 2); return 8; }
    private ushort CbOpcode_51() { BitTest(Reg.C, 2); return 8; }
    private ushort CbOpcode_52() { BitTest(Reg.D, 2); return 8; }
    private ushort CbOpcode_53() { BitTest(Reg.E, 2); return 8; }
    private ushort CbOpcode_54() { BitTest(Reg.H, 2); return 8; }
    private ushort CbOpcode_55() { BitTest(Reg.L, 2); return 8; }

    private ushort CbOpcode_56()
    {
        byte v = Bus.ReadByte(Reg.HL);
        BitTest(v, 2);
        return 12;
    }

    private ushort CbOpcode_57() { BitTest(Reg.A, 2); return 8; }

    // ================== CB: BIT 3 ==================
    private ushort CbOpcode_58() { BitTest(Reg.B, 3); return 8; }
    private ushort CbOpcode_59() { BitTest(Reg.C, 3); return 8; }
    private ushort CbOpcode_5A() { BitTest(Reg.D, 3); return 8; }
    private ushort CbOpcode_5B() { BitTest(Reg.E, 3); return 8; }
    private ushort CbOpcode_5C() { BitTest(Reg.H, 3); return 8; }
    private ushort CbOpcode_5D() { BitTest(Reg.L, 3); return 8; }
    private ushort CbOpcode_5E()
    {
        BitTest(Bus.ReadByte(Reg.HL), 3);
        return 12;
    }
    private ushort CbOpcode_5F() { BitTest(Reg.A, 3); return 8; }

    // ================== CB: BIT 4 ==================
    private ushort CbOpcode_60() { BitTest(Reg.B, 4); return 8; }
    private ushort CbOpcode_61() { BitTest(Reg.C, 4); return 8; }
    private ushort CbOpcode_62() { BitTest(Reg.D, 4); return 8; }
    private ushort CbOpcode_63() { BitTest(Reg.E, 4); return 8; }
    private ushort CbOpcode_64() { BitTest(Reg.H, 4); return 8; }
    private ushort CbOpcode_65() { BitTest(Reg.L, 4); return 8; }
    private ushort CbOpcode_66()
    {
        BitTest(Bus.ReadByte(Reg.HL), 4);
        return 12;
    }
    private ushort CbOpcode_67() { BitTest(Reg.A, 4); return 8; }

    // ================== CB: BIT 5 ==================
    private ushort CbOpcode_68() { BitTest(Reg.B, 5); return 8; }
    private ushort CbOpcode_69() { BitTest(Reg.C, 5); return 8; }
    private ushort CbOpcode_6A() { BitTest(Reg.D, 5); return 8; }
    private ushort CbOpcode_6B() { BitTest(Reg.E, 5); return 8; }
    private ushort CbOpcode_6C() { BitTest(Reg.H, 5); return 8; }
    private ushort CbOpcode_6D() { BitTest(Reg.L, 5); return 8; }
    private ushort CbOpcode_6E()
    {
        BitTest(Bus.ReadByte(Reg.HL), 5);
        return 12;
    }
    private ushort CbOpcode_6F() { BitTest(Reg.A, 5); return 8; }

    // ================== CB: BIT 6 ==================
    private ushort CbOpcode_70() { BitTest(Reg.B, 6); return 8; }
    private ushort CbOpcode_71() { BitTest(Reg.C, 6); return 8; }
    private ushort CbOpcode_72() { BitTest(Reg.D, 6); return 8; }
    private ushort CbOpcode_73() { BitTest(Reg.E, 6); return 8; }
    private ushort CbOpcode_74() { BitTest(Reg.H, 6); return 8; }
    private ushort CbOpcode_75() { BitTest(Reg.L, 6); return 8; }
    private ushort CbOpcode_76()
    {
        BitTest(Bus.ReadByte(Reg.HL), 6);
        return 12;
    }
    private ushort CbOpcode_77() { BitTest(Reg.A, 6); return 8; }

    // ================== CB: BIT 7 ==================
    private ushort CbOpcode_78() { BitTest(Reg.B, 7); return 8; }
    private ushort CbOpcode_79() { BitTest(Reg.C, 7); return 8; }
    private ushort CbOpcode_7A() { BitTest(Reg.D, 7); return 8; }
    private ushort CbOpcode_7B() { BitTest(Reg.E, 7); return 8; }
    private ushort CbOpcode_7C() { BitTest(Reg.H, 7); return 8; }
    private ushort CbOpcode_7D() { BitTest(Reg.L, 7); return 8; }
    private ushort CbOpcode_7E()
    {
        BitTest(Bus.ReadByte(Reg.HL), 7);
        return 12;
    }
    private ushort CbOpcode_7F() { BitTest(Reg.A, 7); return 8; }
}
