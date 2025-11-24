using Gameboy.Graphics;

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
    private int DivCounter = 0;
    private int TimerCounter = 0;

    public delegate ushort OpcodeHandler();
    private OpcodeHandler[] OpcodeTable = new OpcodeHandler[0x100];
    private OpcodeHandler[] CbOpcodeTable = new OpcodeHandler[0x100];

    private void Step()
    {
        // 1. HALT wake check BEFORE interrupt execution
        if (IsHalted)
        {
            if (InterruptsPending())
                IsHalted = false;
            else
                return; // still halted
        }

        // 2. STOP only wakes on input (not interrupts)
        if (IsStopped)
            return;

        // 3. Execute interrupt if IME = 1
        if (InterruptsEnabled)
            if (HandleInterruptExecution())
                return; // interrupt consumed cycle, stop here



        byte opcode = Bus.ReadByte(ProgramCounter);
        ProgramCounter++;

        if (opcode == 0xCB)
        {
            byte cb = Bus.ReadByte(ProgramCounter);
            ProgramCounter++;

            ushort cycles = CbOpcodeTable[cb]();
            UpdateTimers(cycles);

            if (EnableInterruptsAfterNextInstruction)
            {
                InterruptsEnabled = true;
                EnableInterruptsAfterNextInstruction = false;
            }
            return;
        }

        ushort cyclesReturned = OpcodeTable[opcode]();
        UpdateTimers(cyclesReturned);

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
    /// The magical (newer) version fo handling interrupts.
    /// They handle... stuff or whatever
    /// </summary>
    /// <returns></returns>
    private bool HandleInterruptExecution()
    {
        byte ie = Bus.ReadByte(0xFFFF);
        byte iff = Bus.ReadByte(0xFF0F);
        byte pending = (byte)(ie & iff);

        if (pending == 0)
            return false; // nothing to do

        InterruptsEnabled = false;   // hardware behavior
        IsHalted = false;            // HALT always ends

        if ((pending & 0x01) != 0) { TriggerInterrupt(0x40, 0x01); return true; }
        if ((pending & 0x02) != 0) { TriggerInterrupt(0x48, 0x02); return true; }
        if ((pending & 0x04) != 0) { TriggerInterrupt(0x50, 0x04); return true; }
        if ((pending & 0x08) != 0) { TriggerInterrupt(0x58, 0x08); return true; }
        if ((pending & 0x10) != 0) { TriggerInterrupt(0x60, 0x10); return true; }

        return false;
    }

    /// <summary>
    /// Pending interrupts whatever UGH
    /// </summary>
    /// <returns></returns>
    private bool InterruptsPending()
    {
        byte ie = Bus.ReadByte(0xFFFF);
        byte iff = Bus.ReadByte(0xFF0F);
        return (ie & iff) != 0;
    }

    /// <summary>
    /// The special holy methd
    /// </summary>
    /// <param name="cyclesElapsed"></param>
    /// <returns></returns>
    private void UpdateTimers(int cycles)
    {
        // updating div
        DivCounter += cycles;
        if (DivCounter >= 256)
        {
            while (DivCounter >= 256)
            {
                DivCounter -= 256;
                Bus.IncrementDIV();
            }
        }

        bool timerEnabled = (Bus.GetTAC() & 0b00000100) != 0;

        if (!timerEnabled)
        {
            TimerCounter = 0;
            return;
        }

        int mode = Bus.GetTAC() & 0b00000011;

        int threshold = mode switch
        {
            0 => 1024,
            1 => 16,
            2 => 64,
            3 => 256,
            _ => throw new NotImplementedException(),
        };

        // updating the timer counter
        TimerCounter += cycles;

        if (TimerCounter >= threshold)
        {
            while (TimerCounter >= threshold)
            {
                TimerCounter -= threshold;

                byte tima = Bus.GetTIMA();
                if (tima == 0xff)
                {
                    Bus.SetTIMA(Bus.GetTMA());
                    Bus.RequestTimerInterrupt();
                }
                else
                {
                    Bus.SetTIMA((byte)(tima + 1));
                }
            }
        }
    }
}