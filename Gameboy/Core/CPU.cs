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
    private bool IsStopped;

    public delegate ushort OpcodeHandler();
    private OpcodeHandler[] OpcodeTable = new OpcodeHandler[0x100];
    private OpcodeHandler[] CbOpcodeTable = new OpcodeHandler[0x100];

    private void Step()
    {
        HandleInterrupts();
        if (IsStopped)
        {
            // STOP waits for input, not interrupts
            // if (Bus.Input.AnyKeyPressed())
            //     IsStopped = false;

            return;
        }

        if (IsHalted)
        {
            // HALT wakes on interrupt
            // if (InterruptTriggered())
            //     IsHalted = false;

            return;
        }


        byte opcode = Bus.ReadByte(ProgramCounter);
        ProgramCounter++;

        if (opcode == 0xCB)
        {
            byte cb = Bus.ReadByte(ProgramCounter);
            ProgramCounter++;

            ushort cycles = CbOpcodeTable[cb]();

            if (EnableInterruptsAfterNextInstruction)
            {
                InterruptsEnabled = true;
                EnableInterruptsAfterNextInstruction = false;
            }
            return;
        }

        ushort cyclesReturned = OpcodeTable[opcode]();

        if (EnableInterruptsAfterNextInstruction)
        {
            InterruptsEnabled = true;
            EnableInterruptsAfterNextInstruction = false;
        }
    }

    private ushort Cb_Unimplemented()
    {
        throw new NotImplementedException("Unimplemented CB opcode");
    }

    private ushort Opcode_Unimplemented()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Explode an interrupt for whatever reason
    /// </summary>
    /// <param name="vector"></param>
    /// <param name="mask"></param>
    private void TriggerInterrupt(ushort vector, byte mask)
    {
        // Clear the IF bit
        byte iff = Bus.ReadByte(0xFF0F);
        Bus.WriteByte(0xFF0F, (byte)(iff & ~mask));

        // Push current PC on stack
        Push16(ProgramCounter);

        // Jump to interrupt vector
        ProgramCounter = vector;

        // This costs 20 cycles, return it if needed
    }

    /// <summary>
    /// A magical method that handles interrupts
    /// Checks for every serious thing i think
    /// </summary>
    private void HandleInterrupts()
    {
        if (!InterruptsEnabled)
            return;

        byte ie = Bus.ReadByte(0xFFFF);
        byte iff = Bus.ReadByte(0xFF0F);

        byte pending = (byte)(ie & iff);
        if (pending == 0)
            return;

        // Disable interrupts immediately
        InterruptsEnabled = false;

        // Exit HALT if we were in HALT
        IsHalted = false;

        // Check each interrupt in priority order
        if ((pending & 0x01) != 0) { TriggerInterrupt(0x40, 0x01); return; } // VBlank
        if ((pending & 0x02) != 0) { TriggerInterrupt(0x48, 0x02); return; } // LCD STAT
        if ((pending & 0x04) != 0) { TriggerInterrupt(0x50, 0x04); return; } // Timer
        if ((pending & 0x08) != 0) { TriggerInterrupt(0x58, 0x08); return; } // Serial
        if ((pending & 0x10) != 0) { TriggerInterrupt(0x60, 0x10); return; } // Joypad
    }

}