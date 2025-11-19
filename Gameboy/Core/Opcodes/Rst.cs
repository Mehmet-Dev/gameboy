namespace Gameboy.Core;

public partial class CPU
{
    // ================== START RST OPCODES ==================

    private ushort Opcode_C7() { return Restart(0x00); }
    private ushort Opcode_CF() { return Restart(0x08); }
    private ushort Opcode_D7() { return Restart(0x10); }
    private ushort Opcode_DF() { return Restart(0x18); }
    private ushort Opcode_E7() { return Restart(0x20); }
    private ushort Opcode_EF() { return Restart(0x28); }
    private ushort Opcode_F7() { return Restart(0x30); }
    private ushort Opcode_FF() { return Restart(0x38); }

    // ================== END RST OPCODES ==================
}
