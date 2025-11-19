namespace Gameboy.Utils;

public enum LoadByteSource
{
    A,
    B,
    C,
    D,
    E,
    H,
    L,
    D8,    // immediate 8-bit value
    HLI    // memory at address HL
}
