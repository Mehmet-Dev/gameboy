namespace Gameboy.Core;

public partial class MemoryBus
{
    // INPUT (FF00)
    private byte joyp;

    // TIMERS (FF04–FF07)
    private byte div;
    private byte tima;
    private byte tma;
    private byte tac;

    // INTERRUPTS
    private byte IF; // FF0F
    private byte IE; // FFFF

    // PPU registers
    private byte lcdc; // FF40
    private byte stat; // FF41
    private byte scy;  // FF42
    private byte scx;  // FF43
    private byte ly;   // FF44 (read-only)
    private byte lyc;  // FF45

    private byte bgp;  // FF47
    private byte obp0; // FF48
    private byte obp1; // FF49

    private byte wy;   // FF4A
    private byte wx;   // FF4B

    // ========== PUBLIC EXPOSED ACCESSORS (SAFE) ==========

    // ---- DIV ----
    public byte GetDIV() => div;
    public void ResetDIV() => div = 0;
    public void IncrementDIV() => div++;    // CPU calls this every 256 cycles

    // ---- TIMA ----
    public byte GetTIMA() => tima;
    public void SetTIMA(byte value) => tima = value;

    // ---- TMA ----
    public byte GetTMA() => tma;

    // ---- TAC ----
    public byte GetTAC() => tac;

    // ---- Interrupt Flags (IF / IE) ----
    public byte GetIF() => IF;
    public void SetIF(byte value) => IF = (byte)(value & 0x1F);
    public void RequestTimerInterrupt() => IF |= 0x04;

    public byte GetIE() => IE;
    public void SetIE(byte value) => IE = (byte)(value & 0x1F);

    // ---- LY (read-only except PPU update) ----
    public byte GetLY() => ly;
    public void SetLY(byte value) => ly = value;   // only the PPU should call this

    // ---- LYC ----
    public byte GetLYC() => lyc;
    public void SetLYC(byte value) => lyc = value;

    // ---- STAT / LCDC ----
    public byte GetSTAT() => stat;
    public void SetSTAT(byte value) =>
        stat = (byte)((value & 0b0111_1000) | (stat & 0b0000_0111));

    public byte GetLCDC() => lcdc;

    // ---- Scroll registers ----
    public byte GetSCY() => scy;
    public byte GetSCX() => scx;

    // ---- Palettes ----
    public byte GetBGP() => bgp;
    public byte GetOBP0() => obp0;
    public byte GetOBP1() => obp1;

    // ---- Window positions ----
    public byte GetWY() => wy;
    public byte GetWX() => wx;

    // ---- JOYP ----
    public byte GetJOYP() => joyp;
    public void SetJOYP(byte value) => joyp = (byte)(value | 0xC0);

    private byte ReadIO(ushort addr)
    {
        switch (addr)
        {
            case 0xFF00: return joyp;
            case 0xFF04: return div;
            case 0xFF05: return tima;
            case 0xFF06: return tma;
            case 0xFF07: return tac;

            case 0xFF0F: return (byte)(IF | 0xE0); // upper bits always 1

            case 0xFF40: return lcdc;
            case 0xFF41: return stat; // PPU will override mode bits later
            case 0xFF42: return scy;
            case 0xFF43: return scx;
            case 0xFF44: return ly;
            case 0xFF45: return lyc;

            case 0xFF47: return bgp;
            case 0xFF48: return obp0;
            case 0xFF49: return obp1;

            case 0xFF4A: return wy;
            case 0xFF4B: return wx;

            case 0xFF50: return (byte)(BootRomEnabled ? 0 : 1);

            case 0xFFFF: return IE;
        }

        return 0xFF;
    }

    private void WriteIO(ushort addr, byte val)
    {
        switch (addr)
        {
            case 0xFF00: joyp = (byte)(val | 0xC0); return;

            case 0xFF04: div = 0; return;
            case 0xFF05: tima = val; return;
            case 0xFF06: tma = val; return;
            case 0xFF07: tac = (byte)(val & 0b0000_0111); return;

            case 0xFF0F: IF = (byte)(val & 0x1F); return;

            case 0xFF40: lcdc = val; return;
            case 0xFF41: stat = (byte)((val & 0b0111_1000) | (stat & 0b0000_0111)); return;
            case 0xFF42: scy = val; return;
            case 0xFF43: scx = val; return;
            case 0xFF44: return; // LY is read-only
            case 0xFF45: lyc = val; return;

            case 0xFF47: bgp = val; return;
            case 0xFF48: obp0 = val; return;
            case 0xFF49: obp1 = val; return;

            case 0xFF4A: wy = val; return;
            case 0xFF4B: wx = val; return;

            case 0xFF50:
                if (val == 1) BootRomEnabled = false;
                return;

            case 0xFFFF: IE = (byte)(val & 0x1F); return;
        }
    }
}