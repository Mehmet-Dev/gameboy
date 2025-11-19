namespace Gameboy.Core;

public partial class CPU
{
    // ================== INTERRUPT CONTROL OPCODES ==================

    // DI — Disable interrupts immediately
    private ushort Opcode_F3()
    {
        InterruptsEnabled = false;
        return 0;
    }

    // EI — Enable interrupts after the next instruction
    private ushort Opcode_FB()
    {
        EnableInterruptsAfterNextInstruction = true;
        return 0;
    }
}
