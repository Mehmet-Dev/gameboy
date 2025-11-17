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
    
    

    // ================== END OPCODES ==================
}