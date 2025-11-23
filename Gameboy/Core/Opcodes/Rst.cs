namespace Gameboy.Core;

public partial class CPU
{
    // ================== START RST OPCODES ==================

    private ushort Opcode_C7() { ushort diff = Restart(0x00); return 16; }
    private ushort Opcode_CF() { ushort diff = Restart(0x08); return 16; }
    private ushort Opcode_D7() { ushort diff = Restart(0x10); return 16; }
    private ushort Opcode_DF() { ushort diff = Restart(0x18); return 16; }
    private ushort Opcode_E7() { ushort diff = Restart(0x20); return 16; }
    private ushort Opcode_EF() { ushort diff = Restart(0x28); return 16; }
    private ushort Opcode_F7() { ushort diff = Restart(0x30); return 16; }
    private ushort Opcode_FF() { ushort diff = Restart(0x38); return 16; }

    // ================== END RST OPCODES ==================
}
