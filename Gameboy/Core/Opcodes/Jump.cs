using Gameboy.Utils;

namespace Gameboy.Core;

public partial class CPU
{
    // ================== START JP OPCODES ==================

    // JP nn (unconditional)
    private ushort Opcode_C3()
    {
        return JumpAbsolute(JumpCondition.Always);
    }

    // JP NZ,nn
    private ushort Opcode_C2()
    {
        return JumpAbsolute(JumpCondition.NotZero);
    }

    // JP Z,nn
    private ushort Opcode_CA()
    {
        return JumpAbsolute(JumpCondition.Zero);
    }

    // JP NC,nn
    private ushort Opcode_D2()
    {
        return JumpAbsolute(JumpCondition.NotCarry);
    }

    // JP C,nn
    private ushort Opcode_DA()
    {
        return JumpAbsolute(JumpCondition.Carry);
    }

    // JP (HL)
    private ushort Opcode_E9()
    {
        return JumpHL();
    }

    // ================== END JP OPCODES ==================


    // ================== START JR OPCODES ==================

    // JR r8 (unconditional)
    private ushort Opcode_18()
    {
        return JumpRelative(JumpCondition.Always);
    }

    // JR NZ,r8
    private ushort Opcode_20()
    {
        return JumpRelative(JumpCondition.NotZero);
    }

    // JR Z,r8
    private ushort Opcode_28()
    {
        return JumpRelative(JumpCondition.Zero);
    }

    // JR NC,r8
    private ushort Opcode_30()
    {
        return JumpRelative(JumpCondition.NotCarry);
    }

    // JR C,r8
    private ushort Opcode_38()
    {
        return JumpRelative(JumpCondition.Carry);
    }

    // ================== END JR OPCODES ==================
}
