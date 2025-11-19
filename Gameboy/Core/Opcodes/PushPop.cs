namespace Gameboy.Core;

public partial class CPU
{
    // ================== START PUSH OPCODES ==================

    // PUSH BC
    private ushort Opcode_C5()
    {
        Push16(Reg.BC);
        return 0;
    }

    // PUSH DE
    private ushort Opcode_D5()
    {
        Push16(Reg.DE);
        return 0;
    }

    // PUSH HL
    private ushort Opcode_E5()
    {
        Push16(Reg.HL);
        return 0;
    }

    // PUSH AF
    private ushort Opcode_F5()
    {
        Push16(Reg.AF);
        return 0;
    }

    // ================== END PUSH OPCODES ==================


    // ================== START POP OPCODES ==================

    // POP BC
    private ushort Opcode_C1()
    {
        Reg.BC = Pop16();
        return 0;
    }

    // POP DE
    private ushort Opcode_D1()
    {
        Reg.DE = Pop16();
        return 0;
    }

    // POP HL
    private ushort Opcode_E1()
    {
        Reg.HL = Pop16();
        return 0;
    }

    // POP AF
    private ushort Opcode_F1()
    {
        // Note: F (lower byte) must always have its lower 4 bits zeroed.
        ushort value = Pop16();
        Reg.AF = (ushort)(value & 0xFFF0);
        return 0;
    }

    // ================== END POP OPCODES ==================
}
