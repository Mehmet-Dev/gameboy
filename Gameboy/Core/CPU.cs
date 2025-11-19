namespace Gameboy.Core;

/// <summary>
/// The Gameboy CPU is a custom chip called Sharp LR35902.
/// It's similar to the Intel 8080 and Zilog Z80.
/// </summary>
public class CPU
{
    private Registers Reg;

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
    private void BitTest(int bit)
    {
        
    }

    // ================== END HELPER ==================

    // ================== OPCODE METHODS ==================

    private void AddA(byte value)
        => Reg.A = Add(value);

    private void AddHL(ushort value)
        => Reg.HL = Add16(Reg.HL, value);

    private void Adc(byte value)
        => Reg.A = AddWithCarry(value);

    private void SubA(byte value)
        => Reg.A = Sub(value);

    private void Sbc(byte value)
        => Reg.A = SubWithCarry(value);

    private void And(byte value)
        => Reg.A = BitwiseAnd(value);

    private void Or(byte value)
        => Reg.A = BitwiseOr(value);

    private void Xor(byte value)
        => Reg.A = BitwiseXor(value);

    private void Cp(byte value)
        => Compare(value);

    private void Inc(byte value)
        => Increment(value);

    private void Dec(byte value)
        => Decrement(value);

    private void Ccf()
        => ComplementCarryFlag();

    private void Scf()
        => SetCarryFlag();

    private void Rra()
        => RotateRightARegister();

    private void Rla()
        => RotateLeftARegister();

    private void Rrca()
        => RotateRightARegisterNoCarry();

    private void Rrla()
        => RotateLeftARegisterNoCarry();
    
    private void Cpl()
        => Complement();

    // ================== END OPCODES ==================
}