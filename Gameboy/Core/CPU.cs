using Gameboy.Utils;

namespace Gameboy.Core;

/// <summary>
/// The Gameboy CPU is a custom chip called Sharp LR35902.
/// It's similar to the Intel 8080 and Zilog Z80.
/// </summary>
public partial class CPU
{
    private Registers Reg;
    private ushort ProgramCounter;
    private MemoryBus Bus = new();
    private bool InterruptsEnabled;
    private bool EnableInterruptsAfterNextInstruction;
    private bool IsHalted;

    public delegate ushort OpcodeHandler();
    private OpcodeHandler[] OpcodeTable = new OpcodeHandler[0x100];
    private OpcodeHandler[] CbOpcodeTable = new OpcodeHandler[0x100];

    private void Step()
    {
        if (IsHalted)
        {
            // Eventually you will add cycle timing here.
            return;
        }

        byte opcode = Bus.ReadByte(ProgramCounter);
        ProgramCounter++;

        if (opcode == 0xCB)
        {
            byte cb = Bus.ReadByte(ProgramCounter);
            ProgramCounter++;

            ushort cycles = CbOpcodeTable[cb]();
            return;
        }

        ushort cyclesReturned = OpcodeTable[opcode]();
    }



    private ushort Cb_Unimplemented()
    {
        throw new NotImplementedException("Unimplemented CB opcode");
    }

    private ushort Opcode_Unimplemented()
    {
        throw new NotImplementedException();
    }

}