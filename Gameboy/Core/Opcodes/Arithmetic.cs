namespace Gameboy.Core;

public partial class CPU
{
    // ================== ADD OPCODE METHODS ==================

    private ushort Opcode_80() { Reg.A = Add(Reg.B); return 4; }
    private ushort Opcode_81() { Reg.A = Add(Reg.C); return 4; }
    private ushort Opcode_82() { Reg.A = Add(Reg.D); return 4; }
    private ushort Opcode_83() { Reg.A = Add(Reg.E); return 4; }
    private ushort Opcode_84() { Reg.A = Add(Reg.H); return 4; }
    private ushort Opcode_85() { Reg.A = Add(Reg.L); return 4; }
    private ushort Opcode_86() { Reg.A = Add(Bus.ReadByte(Reg.HL)); return 8; }
    private ushort Opcode_87() { Reg.A = Add(Reg.A); return 4; }

    private ushort Opcode_C6()
    {
        byte v = Bus.ReadByte(ProgramCounter);
        ProgramCounter++;
        Reg.A = Add(v);
        return 8;
    }

    private ushort Opcode_09() { Reg.HL = Add16(Reg.HL, Reg.BC); return 8; }
    private ushort Opcode_19() { Reg.HL = Add16(Reg.HL, Reg.DE); return 8; }
    private ushort Opcode_29() { Reg.HL = Add16(Reg.HL, Reg.HL); return 8; }
    private ushort Opcode_39() { Reg.HL = Add16(Reg.HL, Reg.SP); return 8; }

    // ================== END ADD OPCODES ==================
    
    // ================== START SUB OPCODES ==================
    private ushort Opcode_90() { Reg.A = Sub(Reg.B); return 4; }
    private ushort Opcode_91() { Reg.A = Sub(Reg.C); return 4; }
    private ushort Opcode_92() { Reg.A = Sub(Reg.D); return 4; }
    private ushort Opcode_93() { Reg.A = Sub(Reg.E); return 4; }
    private ushort Opcode_94() { Reg.A = Sub(Reg.H); return 4; }
    private ushort Opcode_95() { Reg.A = Sub(Reg.L); return 4; }
    private ushort Opcode_96() { Reg.A = Sub(Bus.ReadByte(Reg.HL)); return 8; }
    private ushort Opcode_97() { Reg.A = Sub(Reg.A); return 4; }

    private ushort Opcode_D6()
    {
        byte v = Bus.ReadByte(ProgramCounter);
        ProgramCounter++;
        Reg.A = Sub(v);
        return 8;
    }

    // ================== END SUB OPCODES ==================
    // ================== START SBC OPCODES ==================

    private ushort Opcode_98() { Reg.A = SubWithCarry(Reg.B); return 4; }
    private ushort Opcode_99() { Reg.A = SubWithCarry(Reg.C); return 4; }
    private ushort Opcode_9A() { Reg.A = SubWithCarry(Reg.D); return 4; }
    private ushort Opcode_9B() { Reg.A = SubWithCarry(Reg.E); return 4; }
    private ushort Opcode_9C() { Reg.A = SubWithCarry(Reg.H); return 4; }
    private ushort Opcode_9D() { Reg.A = SubWithCarry(Reg.L); return 4; }
    private ushort Opcode_9E() { Reg.A = SubWithCarry(Bus.ReadByte(Reg.HL)); return 8; }
    private ushort Opcode_9F() { Reg.A = SubWithCarry(Reg.A); return 4; }

    // ================== END SBC OPCODES ==================
    // ================== START ADC OPCODES ==================

    private ushort Opcode_88() { Reg.A = AddWithCarry(Reg.B); return 4; }
    private ushort Opcode_89() { Reg.A = AddWithCarry(Reg.C); return 4; }
    private ushort Opcode_8A() { Reg.A = AddWithCarry(Reg.D); return 4; }
    private ushort Opcode_8B() { Reg.A = AddWithCarry(Reg.E); return 4; }
    private ushort Opcode_8C() { Reg.A = AddWithCarry(Reg.H); return 4; }
    private ushort Opcode_8D() { Reg.A = AddWithCarry(Reg.L); return 4; }
    private ushort Opcode_8E() { Reg.A = AddWithCarry(Bus.ReadByte(Reg.HL)); return 8; }
    private ushort Opcode_8F() { Reg.A = AddWithCarry(Reg.A); return 4; }

    private ushort Opcode_CE()
    {
        byte v = Bus.ReadByte(ProgramCounter);
        ProgramCounter++;
        Reg.A = AddWithCarry(v);
        return 8;
    }
    // ================== END ADC OPCODES ==================
    
    
}