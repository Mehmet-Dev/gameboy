namespace Gameboy.Core;

public partial class CPU
{
    // ================== START PUSH OPCODES ==================

    private ushort Opcode_C5() { Push16(Reg.BC); return 16; }
    private ushort Opcode_D5() { Push16(Reg.DE); return 16; }
    private ushort Opcode_E5() { Push16(Reg.HL); return 16; }
    private ushort Opcode_F5() { Push16(Reg.AF); return 16; }

    // ================== END PUSH OPCODES ==================


    // ================== START POP OPCODES ==================

    private ushort Opcode_C1() { Reg.BC = Pop16(); return 12; }
    private ushort Opcode_D1() { Reg.DE = Pop16(); return 12; }
    private ushort Opcode_E1() { Reg.HL = Pop16(); return 12; }
    private ushort Opcode_F1()
    {
        ushort value = Pop16();
        Reg.AF = (ushort)(value & 0xFFF0);
        return 12;
    }

    // ================== END POP OPCODES ==================
}
