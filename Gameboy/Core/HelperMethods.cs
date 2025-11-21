using Gameboy.Utils;

namespace Gameboy.Core;

public partial class CPU
{
    // ================== HELPER METHODS ==================

    /// <summary>
    /// Sums up value with register A
    /// </summary>
    /// <param name="value">Value to be summed</param>
    /// <returns>Sum of A + value</returns>
    private byte Add(byte value)
    {
        int sum = Reg.A + value;

        bool overflowed = sum > 255;

        Reg.ZeroFlag = (byte)sum == 0;
        Reg.SubtractFlag = false;
        Reg.CarryFlag = overflowed;
        Reg.HalfCarryFlag = ((Reg.A & 0xF) + (value & 0xF)) > 0xF;

        return (byte)sum;
    }

    /// <summary>
    /// Sum up two 16-bit integers together
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    private ushort Add16(ushort left, ushort right)
    {
        int sum = left + right;

        bool overflowed = sum > 0xffff;

        Reg.SubtractFlag = false;
        Reg.CarryFlag = overflowed;
        Reg.HalfCarryFlag = ((left & 0xfff) + (right & 0xfff)) > 0xfff;

        return (ushort)sum;
    }

    /// <summary>
    /// Sums up value with register A together with the carry
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private byte AddWithCarry(byte value)
    {
        int carryIn = Reg.CarryFlag ? 1 : 0;
        int sum = Reg.A + value + carryIn;

        bool overflowed = sum > 255;

        Reg.ZeroFlag = (byte)sum == 0;
        Reg.SubtractFlag = false;
        Reg.CarryFlag = overflowed;
        Reg.HalfCarryFlag = ((Reg.A & 0xF) + (value & 0xF) + carryIn) > 0xF;

        return (byte)sum;
    }

    /// <summary>
    /// Subtract value from register A
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private byte Sub(byte value)
    {
        int sub = Reg.A - value;

        bool underflowed = sub < 0;

        Reg.ZeroFlag = (byte)sub == 0;
        Reg.SubtractFlag = true;
        Reg.CarryFlag = underflowed;
        Reg.HalfCarryFlag = (Reg.A & 0xF) < (value & 0xf);

        return (byte)sub;
    }

    /// <summary>
    /// Subtracts value from register A with carry
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private byte SubWithCarry(byte value)
    {
        int carryIn = Reg.CarryFlag ? 1 : 0;

        int sub = Reg.A - value - carryIn;

        bool underflowed = sub < 0;

        Reg.ZeroFlag = (byte)sub == 0;
        Reg.SubtractFlag = true;
        Reg.CarryFlag = underflowed;
        Reg.HalfCarryFlag = (Reg.A & 0xf) < ((value & 0xf) + carryIn);

        return (byte)sub;
    }

    /// <summary>
    /// Perform a bitwise AND operation on a byte
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private byte BitwiseAnd(byte value)
    {
        int and = Reg.A & value;

        Reg.ZeroFlag = (byte)and == 0;
        Reg.SubtractFlag = false;
        Reg.CarryFlag = false;
        Reg.HalfCarryFlag = true;

        return (byte)and;
    }

    /// <summary>
    /// Do a bitwise OR on a byte
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private byte BitwiseOr(byte value)
    {
        int or = Reg.A | value;

        Reg.ZeroFlag = (byte)or == 0;
        Reg.SubtractFlag = false;
        Reg.CarryFlag = false;
        Reg.HalfCarryFlag = false;

        return (byte)or;
    }

    /// <summary>
    /// Do a bitwise XOR operation on a byte
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private byte BitwiseXor(byte value)
    {
        int xor = Reg.A ^ value;

        Reg.ZeroFlag = (byte)xor == 0;
        Reg.SubtractFlag = false;
        Reg.CarryFlag = false;
        Reg.HalfCarryFlag = false;

        return (byte)xor;
    }

    /// <summary>
    /// Compare a value to reg A
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private void Compare(byte value)
        => Sub(value);

    /// <summary>
    /// Increment a value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private byte Increment(byte value)
    {
        Reg.HalfCarryFlag = (value & 0xf) == 0xF;
        value++;

        Reg.ZeroFlag = value == 0;
        Reg.SubtractFlag = false;

        return value;
    }

    /// <summary>
    /// Decrement a value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private byte Decrement(byte value)
    {
        Reg.HalfCarryFlag = (value & 0xf) == 0x0;
        value--;

        Reg.ZeroFlag = value == 0;
        Reg.SubtractFlag = true;

        return value;
    }

    /// <summary>
    /// Toggle the status of the carry flagt
    /// </summary>
    private void ComplementCarryFlag()
    {
        Reg.CarryFlag = !Reg.CarryFlag;

        Reg.SubtractFlag = false;
        Reg.HalfCarryFlag = !Reg.HalfCarryFlag;
    }

    /// <summary>
    /// Sets the carry flag to true
    /// </summary>
    private void SetCarryFlag()
    {
        Reg.CarryFlag = true;

        Reg.SubtractFlag = false;
        Reg.HalfCarryFlag = false;
    }

    /// <summary>
    /// Bit rotate A register right through the carry flag
    /// </summary>
    private void RotateRightARegister()
    {
        int oldCarryBit = (Reg.CarryFlag ? 1 : 0) << 7;
        int carry = Reg.A & 0x01;

        Reg.A = (byte)(Reg.A >> 1);
        Reg.A = (byte)(Reg.A | oldCarryBit);

        Reg.CarryFlag = carry != 0;
        Reg.ZeroFlag = false;
        Reg.SubtractFlag = false;
        Reg.HalfCarryFlag = false;
    }

    /// <summary>
    /// Bit rotate A register left through the carry flag
    /// </summary>
    private void RotateLeftARegister()
    {
        int oldCarryBit = Reg.CarryFlag ? 1 : 0;
        int carry = (Reg.A >> 7) & 0x01;

        Reg.A = (byte)(Reg.A << 1);
        Reg.A = (byte)(Reg.A | oldCarryBit);

        Reg.CarryFlag = carry != 0;
        Reg.ZeroFlag = false;
        Reg.SubtractFlag = false;
        Reg.HalfCarryFlag = false;
    }

    /// <summary>
    /// Bit rotate A register right 
    /// </summary>
    private void RotateRightARegisterNoCarry()
    {
        int carryBit = Reg.A & 0x01;
        Reg.A = (byte)(Reg.A >> 1);

        int inject = carryBit << 7;
        Reg.A = (byte)(Reg.A | inject);

        Reg.CarryFlag = carryBit != 0;
        Reg.ZeroFlag = false;
        Reg.SubtractFlag = false;
        Reg.HalfCarryFlag = false;
    }

    /// <summary>
    /// Bit rotate A register left without carry
    /// </summary>
    private void RotateLeftARegisterNoCarry()
    {
        int carryBit = (Reg.A >> 7) & 0x01;
        Reg.A = (byte)(Reg.A << 1);

        Reg.A = (byte)(Reg.A | carryBit);

        Reg.CarryFlag = carryBit != 0;
        Reg.ZeroFlag = false;
        Reg.SubtractFlag = false;
        Reg.HalfCarryFlag = false;
    }

    /// <summary>
    /// Do a bitwise XOR on every bit in Registry A
    /// </summary>
    private void Complement()
    {
        Reg.A = (byte)(Reg.A ^ 0xff);

        Reg.SubtractFlag = true;
        Reg.HalfCarryFlag = true;
    }

    /// <summary>
    /// Test whether a bit is set ? gameboy emulators smell wtf
    /// </summary>
    /// <param name="bit"></param>
    private void BitTest(byte value, int bit)
    {
        Reg.SubtractFlag = false;
        Reg.HalfCarryFlag = true;
        Reg.ZeroFlag = (value & (1 << bit)) == 0;
    }

    /// <summary>
    /// Resets a certain bit of a registry
    /// </summary>
    /// <param name="value"></param>
    /// <param name="bit"></param>
    private byte ResetBit(byte value, int bit)
    {
        int mask = ~(1 << bit);
        return (byte)(value & mask);
    }

    /// <summary>
    /// Sets a bit of a registry to 1
    /// </summary>
    /// <param name="value"></param>
    /// <param name="bit"></param>
    /// <returns></returns>
    private byte SetBit(byte value, int bit)
    {
        int mask = 1 << bit;
        return (byte)(value | mask);
    }

    /// <summary>
    /// Bit shift a specific registry to 1
    /// </summary>
    /// <returns></returns>
    private byte ShiftRightLogical(byte value)
    {
        int carry = value & 0x01;
        value = (byte)(value >> 1);

        Reg.ZeroFlag = value == 0;
        Reg.SubtractFlag = false;
        Reg.HalfCarryFlag = false;
        Reg.CarryFlag = carry != 0;

        return value;
    }

    /// <summary>
    /// Rotate right a byte
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private byte RotateRight(byte value)
    {
        int oldCarryBit = (Reg.CarryFlag ? 1 : 0) << 7;
        int carry = value & 0x01;

        value = (byte)(value >> 1);
        value = (byte)(value | oldCarryBit);

        Reg.CarryFlag = carry != 0;
        Reg.ZeroFlag = value == 0;
        Reg.SubtractFlag = false;
        Reg.HalfCarryFlag = false;

        return value;
    }

    /// <summary>
    /// Rotate left a byte
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private byte RotateLeft(byte value)
    {
        int oldCarryBit = Reg.CarryFlag ? 1 : 0;
        int carry = (value >> 7) & 0x01;

        value = (byte)(value << 1);
        value = (byte)(value | oldCarryBit);

        Reg.CarryFlag = carry != 0;
        Reg.ZeroFlag = value == 0;
        Reg.SubtractFlag = false;
        Reg.HalfCarryFlag = false;

        return value;
    }

    /// <summary>
    /// Rotate right a value without carry
    /// </summary>
    /// <returns></returns>
    private byte RotateRightNoCarry(byte value)
    {
        int carryBit = value & 0x01;
        value = (byte)(value >> 1);

        int inject = carryBit << 7;
        value = (byte)(value | inject);

        Reg.CarryFlag = carryBit != 0;
        Reg.ZeroFlag = value == 0;
        Reg.SubtractFlag = false;
        Reg.HalfCarryFlag = false;

        return value;
    }

    /// <summary>
    /// Rotate left a value without carry
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private byte RotateLeftNoCarry(byte value)
    {
        int carryBit = (value >> 7) & 0x01;
        value = (byte)(value << 1);

        value = (byte)(value | carryBit);

        Reg.CarryFlag = carryBit != 0;
        Reg.ZeroFlag = value == 0;
        Reg.SubtractFlag = false;
        Reg.HalfCarryFlag = false;

        return value;
    }

    /// <summary>
    /// Shift right a bit arithmetically
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private byte ShiftRightArithmetic(byte value)
    {
        int carry = value & 0x01;
        int signBit = value & 0x80;

        value = (byte)(value >> 1);
        value = (byte)(value | signBit);

        Reg.ZeroFlag = value == 0;
        Reg.SubtractFlag = false;
        Reg.HalfCarryFlag = false;
        Reg.CarryFlag = carry != 0;

        return value;
    }

    /// <summary>
    /// Shift left a bit arithmetically
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private byte ShiftLeftArithmetic(byte value)
    {
        int carry = (value >> 7) & 0x01;
        value = (byte)(value << 1);

        Reg.ZeroFlag = value == 0;
        Reg.SubtractFlag = false;
        Reg.HalfCarryFlag = false;
        Reg.CarryFlag = carry != 0;

        return value;
    }

    /// <summary>
    /// Swap the top nibble with the lower nibble
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private byte SwapNibbles(byte value)
    {
        var highNibble = (value & 0xf0) >> 4;
        var lowNibble = (value & 0x0f) << 4;

        value = (byte)(highNibble | lowNibble);

        Reg.ZeroFlag = value == 0;
        Reg.SubtractFlag = false;
        Reg.HalfCarryFlag = false;
        Reg.CarryFlag = false;

        return value;
    }

    /// <summary>
    /// Read 16 bit little endian address
    /// </summary>
    /// <returns></returns>
    private ushort ReadWordAtPC()
    {
        byte low = Bus.ReadByte(ProgramCounter);
        byte high = Bus.ReadByte((ushort)(ProgramCounter + 1));
        return (ushort)((high << 8) | low);
    }

    /// <summary>
    /// Checking the jump condition
    /// </summary>
    /// <param name="cond"></param>
    /// <returns></returns>
    private bool CheckJumpCondition(JumpCondition cond)
    {
        return cond switch
        {
            JumpCondition.Always => true,
            JumpCondition.Zero => Reg.ZeroFlag,
            JumpCondition.NotZero => !Reg.ZeroFlag,
            JumpCondition.Carry => Reg.CarryFlag,
            JumpCondition.NotCarry => !Reg.CarryFlag,
            _ => false
        };
    }

    /// <summary>
    /// Make an absolute jump
    /// </summary>
    /// <param name="cond"></param>
    /// <returns></returns>
    private ushort JumpAbsolute(JumpCondition cond)
    {
        ushort target = ReadWordAtPC();
        bool shouldJump = CheckJumpCondition(cond);

        if (!shouldJump)
            return 2;

        int diff = target - ProgramCounter;
        return (ushort)diff;
    }

    /// <summary>
    /// Make a relative jump
    /// </summary>
    /// <param name="cond"></param>
    /// <returns></returns>
    private ushort JumpRelative(JumpCondition cond)
    {
        sbyte offset = (sbyte)Bus.ReadByte(ProgramCounter);
        bool shouldJump = CheckJumpCondition(cond);

        if (!shouldJump)
            return 1; // skip: JR is 2 bytes total

        // PC currently points to the offset byte.
        // We want: newPC = ProgramCounter + 1 + offset
        int target = ProgramCounter + 1 + offset;

        int diff = target - ProgramCounter;
        return (ushort)diff;
    }

    /// <summary>
    /// Stupid jump from HL for some reason
    /// </summary>
    /// <returns></returns>
    private ushort JumpHL()
    {
        ushort target = Reg.HL;  // where we’re going
        int diff = target - ProgramCounter;  // how far to move PC
        return (ushort)diff;
    }

    /// <summary>
    /// Reading some fuckass byte
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    private byte Read8(LoadByteSource source)
    {
        return source switch
        {
            LoadByteSource.A => Reg.A,
            LoadByteSource.B => Reg.B,
            LoadByteSource.C => Reg.C,
            LoadByteSource.D => Reg.D,
            LoadByteSource.E => Reg.E,
            LoadByteSource.H => Reg.H,
            LoadByteSource.L => Reg.L,
            LoadByteSource.D8 => Bus.ReadByte(ProgramCounter), // immediate
            LoadByteSource.HLI => Bus.ReadByte(Reg.HL),
            _ => 0
        };
    }

    /// <summary>
    /// Writing some fuckass byte
    /// </summary>
    /// <param name="target"></param>
    /// <param name="value"></param>
    private void Write8(LoadByteTarget target, byte value)
    {
        switch (target)
        {
            case LoadByteTarget.A: Reg.A = value; break;
            case LoadByteTarget.B: Reg.B = value; break;
            case LoadByteTarget.C: Reg.C = value; break;
            case LoadByteTarget.D: Reg.D = value; break;
            case LoadByteTarget.E: Reg.E = value; break;
            case LoadByteTarget.H: Reg.H = value; break;
            case LoadByteTarget.L: Reg.L = value; break;
            case LoadByteTarget.HLI: Bus.WriteByte(Reg.HL, value); break;
        }
    }

    /// <summary>
    /// Loading some fuckass byte
    /// </summary>
    /// <param name="target"></param>
    /// <param name="source"></param>
    /// <returns></returns>
    private ushort Load8(LoadByteTarget target, LoadByteSource source)
    {
        byte value = Read8(source);
        Write8(target, value);

        // If the source was an immediate byte (D8),
        // the instruction length is 2 bytes total.
        return source == LoadByteSource.D8 ? (ushort)1 : (ushort)0;
    }

    /// <summary>
    /// Push a 16 bit value to the downward growing stack cus this shit stinsk
    /// </summary>
    /// <param name="value"></param>
    private void Push16(ushort value)
    {
        // Write high byte first
        unchecked
        {
            ProgramCounter = ProgramCounter; // no-op, keeps analyzer quiet if needed
        }

        Reg.SP--;
        Bus.WriteByte(Reg.SP, (byte)(value >> 8));

        Reg.SP--;
        Bus.WriteByte(Reg.SP, (byte)(value & 0xFF));
    }

    /// <summary>
    /// Pop a 16 bit value and blow it up
    /// </summary>
    /// <returns></returns>
    private ushort Pop16()
    {
        byte low = Bus.ReadByte(Reg.SP);
        Reg.SP++;

        byte high = Bus.ReadByte(Reg.SP);
        Reg.SP++;

        return (ushort)((high << 8) | low);
    }

    /// <summary>
    /// Calls an address through a telephone line I think
    /// "hello?" "SHUT UP"
    /// </summary>
    /// <param name="cond"></param>
    /// <returns></returns>
    private ushort CallAbsolute(JumpCondition cond)
    {
        ushort target = ReadWordAtPC();
        bool shouldCall = CheckJumpCondition(cond);

        if (!shouldCall)
        {
            // CALL is 3 bytes total; Step already consumed 1
            return 2;
        }

        // Return address = PC after the two operand bytes
        ushort returnAddress = (ushort)(ProgramCounter + 2);
        Push16(returnAddress);

        int diff = target - ProgramCounter;
        return (ushort)diff;
    }

    /// <summary>
    /// Return from a spam call
    /// "ugh i need to work"
    /// </summary>
    /// <param name="cond"></param>
    /// <returns></returns>
    private ushort ReturnFromCall(JumpCondition cond)
    {
        bool shouldReturn = CheckJumpCondition(cond);

        if (!shouldReturn)
            return 0;

        ushort target = Pop16();
        int diff = target - ProgramCounter;
        return (ushort)diff;
    }

    /// <summary>
    /// Restart the app for some reason like Hello, world!
    /// </summary>
    /// <param name="vector"></param>
    /// <returns></returns>
    private ushort Restart(byte vector)
    {
        // Push current PC (already pointing to next instruction)
        Push16(ProgramCounter);

        // Jump to fixed vector
        int diff = vector - ProgramCounter;
        return (ushort)diff;
    }


    // ================== END HELPER ==================

    // ================== START UTILITY OPCODES ==================
    private ushort Opcode_07() { RotateLeftARegisterNoCarry(); return 4; }   // RLCA
    private ushort Opcode_17() { RotateLeftARegister(); return 4; }   // RLA
    private ushort Opcode_0F() { RotateRightARegisterNoCarry(); return 4; }  // RRCA
    private ushort Opcode_1F() { RotateRightARegister(); return 4; }  // RRA
    private ushort Opcode_2F() { Complement(); return 4; }
    private ushort Opcode_37() { SetCarryFlag(); return 4; }
    private ushort Opcode_3F() { ComplementCarryFlag(); return 4; }
    private ushort Opcode_00() { return 4; }

    private ushort Opcode_76() { IsHalted = true; return 0; }


}