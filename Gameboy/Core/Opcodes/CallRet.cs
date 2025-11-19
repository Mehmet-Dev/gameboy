using Gameboy.Utils;

namespace Gameboy.Core;

public partial class CPU
{
    // ================== START CALL OPCODES ==================

    // CALL nn (unconditional)
    private ushort Opcode_CD()
    {
        return CallAbsolute(JumpCondition.Always);
    }

    // CALL NZ, nn
    private ushort Opcode_C4()
    {
        return CallAbsolute(JumpCondition.NotZero);
    }

    // CALL Z, nn
    private ushort Opcode_CC()
    {
        return CallAbsolute(JumpCondition.Zero);
    }

    // CALL NC, nn
    private ushort Opcode_D4()
    {
        return CallAbsolute(JumpCondition.NotCarry);
    }

    // CALL C, nn
    private ushort Opcode_DC()
    {
        return CallAbsolute(JumpCondition.Carry);
    }

    // ================== END CALL OPCODES ==================



    // ================== START RETURN OPCODES ==================

    // RET (unconditional)
    private ushort Opcode_C9()
    {
        return ReturnFromCall(JumpCondition.Always);
    }

    // RET NZ
    private ushort Opcode_C0()
    {
        return ReturnFromCall(JumpCondition.NotZero);
    }

    // RET Z
    private ushort Opcode_C8()
    {
        return ReturnFromCall(JumpCondition.Zero);
    }

    // RET NC
    private ushort Opcode_D0()
    {
        return ReturnFromCall(JumpCondition.NotCarry);
    }

    // RET C
    private ushort Opcode_D8()
    {
        return ReturnFromCall(JumpCondition.Carry);
    }

    // ================== END RETURN OPCODES ==================



    // ================== START SPECIAL RETURN OPCODES ==================

    // RETI (Return and enable interrupts)
    private ushort Opcode_D9()
    {
        ushort diff = ReturnFromCall(JumpCondition.Always);
        InterruptsEnabled = true;    // or IME = true if you use that name
        return diff;
    }

    // ================== END SPECIAL RETURN OPCODES ==================
}