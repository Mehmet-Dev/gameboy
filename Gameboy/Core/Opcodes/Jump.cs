using Gameboy.Utils;

namespace Gameboy.Core;

public partial class CPU
{
    // ================== START JP OPCODES ==================

    // JP nn (unconditional)
    private ushort Opcode_C3()
    {
        ushort diff = JumpAbsolute(JumpCondition.Always);
        ProgramCounter += diff;
        return 16; // JP nn always 16 cycles
    }

    // JP NZ,nn
    private ushort Opcode_C2()
    {
        ushort diff = JumpAbsolute(JumpCondition.NotZero);
        ProgramCounter += diff;
        // not taken: diff == 2 (just skip immediate)
        return diff == 2 ? (ushort)12 : (ushort)16;
    }

    // JP Z,nn
    private ushort Opcode_CA()
    {
        ushort diff = JumpAbsolute(JumpCondition.Zero);
        ProgramCounter += diff;
        return diff == 2 ? (ushort)12 : (ushort)16;
    }

    // JP NC,nn
    private ushort Opcode_D2()
    {
        ushort diff = JumpAbsolute(JumpCondition.NotCarry);
        ProgramCounter += diff;
        return diff == 2 ? (ushort)12 : (ushort)16;
    }

    // JP C,nn
    private ushort Opcode_DA()
    {
        ushort diff = JumpAbsolute(JumpCondition.Carry);
        ProgramCounter += diff;
        return diff == 2 ? (ushort)12 : (ushort)16;
    }

    // JP (HL)
    private ushort Opcode_E9()
    {
        ushort diff = JumpHL();
        ProgramCounter += diff;
        return 4; // JP (HL) is 4 cycles
    }


    // ================== END JP OPCODES ==================


    // ================== START JR OPCODES ==================

    // JR r8 (unconditional)
    private ushort Opcode_18()
    {
        ushort diff = JumpRelative(JumpCondition.Always);
        ProgramCounter += diff;
        return 12; // always taken
    }

    // JR NZ,r8
    private ushort Opcode_20()
    {
        ushort diff = JumpRelative(JumpCondition.NotZero);
        ProgramCounter += diff;
        // not taken: diff == 1 (skip offset only)
        return diff == 1 ? (ushort)8 : (ushort)12;
    }

    // JR Z,r8
    private ushort Opcode_28()
    {
        ushort diff = JumpRelative(JumpCondition.Zero);
        ProgramCounter += diff;
        return diff == 1 ? (ushort)8 : (ushort)12;
    }

    // JR NC,r8
    private ushort Opcode_30()
    {
        ushort diff = JumpRelative(JumpCondition.NotCarry);
        ProgramCounter += diff;
        return diff == 1 ? (ushort)8 : (ushort)12;
    }

    // JR C,r8
    private ushort Opcode_38()
    {
        ushort diff = JumpRelative(JumpCondition.Carry);
        ProgramCounter += diff;
        return diff == 1 ? (ushort)8 : (ushort)12;
    }


    // ================== END JR OPCODES ==================
}
