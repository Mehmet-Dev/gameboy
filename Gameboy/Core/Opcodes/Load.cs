using Gameboy.Utils;

namespace Gameboy.Core;

public partial class CPU
{
    // ================== START 8-BIT LOAD OPCODES ==================

    // LD A, r
    private ushort Opcode_7F() { return Load8(LoadByteTarget.A, LoadByteSource.A); }
    private ushort Opcode_78() { return Load8(LoadByteTarget.A, LoadByteSource.B); }
    private ushort Opcode_79() { return Load8(LoadByteTarget.A, LoadByteSource.C); }
    private ushort Opcode_7A() { return Load8(LoadByteTarget.A, LoadByteSource.D); }
    private ushort Opcode_7B() { return Load8(LoadByteTarget.A, LoadByteSource.E); }
    private ushort Opcode_7C() { return Load8(LoadByteTarget.A, LoadByteSource.H); }
    private ushort Opcode_7D() { return Load8(LoadByteTarget.A, LoadByteSource.L); }

    // LD r, A
    private ushort Opcode_47() { return Load8(LoadByteTarget.B, LoadByteSource.A); }
    private ushort Opcode_4F() { return Load8(LoadByteTarget.C, LoadByteSource.A); }
    private ushort Opcode_57() { return Load8(LoadByteTarget.D, LoadByteSource.A); }
    private ushort Opcode_5F() { return Load8(LoadByteTarget.E, LoadByteSource.A); }
    private ushort Opcode_67() { return Load8(LoadByteTarget.H, LoadByteSource.A); }
    private ushort Opcode_6F() { return Load8(LoadByteTarget.L, LoadByteSource.A); }

    // LD r, r
    private ushort Opcode_40() { return Load8(LoadByteTarget.B, LoadByteSource.B); }
    private ushort Opcode_41() { return Load8(LoadByteTarget.B, LoadByteSource.C); }
    private ushort Opcode_42() { return Load8(LoadByteTarget.B, LoadByteSource.D); }
    private ushort Opcode_43() { return Load8(LoadByteTarget.B, LoadByteSource.E); }
    private ushort Opcode_44() { return Load8(LoadByteTarget.B, LoadByteSource.H); }
    private ushort Opcode_45() { return Load8(LoadByteTarget.B, LoadByteSource.L); }

    private ushort Opcode_48() { return Load8(LoadByteTarget.C, LoadByteSource.B); }
    private ushort Opcode_49() { return Load8(LoadByteTarget.C, LoadByteSource.C); }
    private ushort Opcode_4A() { return Load8(LoadByteTarget.C, LoadByteSource.D); }
    private ushort Opcode_4B() { return Load8(LoadByteTarget.C, LoadByteSource.E); }
    private ushort Opcode_4C() { return Load8(LoadByteTarget.C, LoadByteSource.H); }
    private ushort Opcode_4D() { return Load8(LoadByteTarget.C, LoadByteSource.L); }

    // LD r, (HL)
    private ushort Opcode_46() { return Load8(LoadByteTarget.B, LoadByteSource.HLI); }
    private ushort Opcode_4E() { return Load8(LoadByteTarget.C, LoadByteSource.HLI); }
    private ushort Opcode_56() { return Load8(LoadByteTarget.D, LoadByteSource.HLI); }
    private ushort Opcode_5E() { return Load8(LoadByteTarget.E, LoadByteSource.HLI); }
    private ushort Opcode_66() { return Load8(LoadByteTarget.H, LoadByteSource.HLI); }
    private ushort Opcode_6E() { return Load8(LoadByteTarget.L, LoadByteSource.HLI); }
    private ushort Opcode_7E() { return Load8(LoadByteTarget.A, LoadByteSource.HLI); }

    // LD (HL), r
    private ushort Opcode_70() { return Load8(LoadByteTarget.HLI, LoadByteSource.B); }
    private ushort Opcode_71() { return Load8(LoadByteTarget.HLI, LoadByteSource.C); }
    private ushort Opcode_72() { return Load8(LoadByteTarget.HLI, LoadByteSource.D); }
    private ushort Opcode_73() { return Load8(LoadByteTarget.HLI, LoadByteSource.E); }
    private ushort Opcode_74() { return Load8(LoadByteTarget.HLI, LoadByteSource.H); }
    private ushort Opcode_75() { return Load8(LoadByteTarget.HLI, LoadByteSource.L); }
    private ushort Opcode_77() { return Load8(LoadByteTarget.HLI, LoadByteSource.A); }

    // LD r, d8
    private ushort Opcode_06() { return Load8(LoadByteTarget.B, LoadByteSource.D8); }
    private ushort Opcode_0E() { return Load8(LoadByteTarget.C, LoadByteSource.D8); }
    private ushort Opcode_16() { return Load8(LoadByteTarget.D, LoadByteSource.D8); }
    private ushort Opcode_1E() { return Load8(LoadByteTarget.E, LoadByteSource.D8); }
    private ushort Opcode_26() { return Load8(LoadByteTarget.H, LoadByteSource.D8); }
    private ushort Opcode_2E() { return Load8(LoadByteTarget.L, LoadByteSource.D8); }
    private ushort Opcode_3E() { return Load8(LoadByteTarget.A, LoadByteSource.D8); }

    // LD (HL), d8
    private ushort Opcode_36() { return Load8(LoadByteTarget.HLI, LoadByteSource.D8); }

    // Special indirect loads
    private ushort Opcode_0A()  // LD A, (BC)
    {
        byte v = Bus.ReadByte(Reg.BC);
        Reg.A = v;
        return 0;
    }

    private ushort Opcode_1A()  // LD A, (DE)
    {
        byte v = Bus.ReadByte(Reg.DE);
        Reg.A = v;
        return 0;
    }

    private ushort Opcode_02()  // LD (BC), A
    {
        Bus.WriteByte(Reg.BC, Reg.A);
        return 0;
    }

    private ushort Opcode_12()  // LD (DE), A
    {
        Bus.WriteByte(Reg.DE, Reg.A);
        return 0;
    }

    private ushort Opcode_F2()
    {
        byte value = Bus.ReadByte((ushort)(0xFF00 + Reg.C));
        Reg.A = value;
        return 0;
    }

    private ushort Opcode_E2() { Bus.WriteByte((ushort)(0xFF00 + Reg.C), Reg.A); return 0; }

    private ushort Opcode_F0()
    {
        byte source = Read8(LoadByteSource.D8);
        Reg.A = Bus.ReadByte((ushort)(0xff00 + source));
        return 1;
    }

    private ushort Opcode_E0()
    {
        byte offset = Bus.ReadByte(ProgramCounter);   // read d8
        ushort addr = (ushort)(0xFF00 + offset);      // compute FF00 + d8
        Bus.WriteByte(addr, Reg.A);                   // store A into memory
        return 1;                                     // consume the immediate byte
    }


    // ================== END 8-BIT LOAD OPCODES ==================
}
