# Game Boy Emulator (C#)

This project is my attempt to build a complete, accurate, and maintainable emulator for the original Game Boy (DMG-01) using C#.
It serves both as a learning project and as a long-term effort to recreate the hardware as faithfully as possible.

The goal is not just to get games running, but to understand and implement the underlying systems properly: CPU behavior, memory architecture, graphics timing, interrupts, cartridges, and more.

This project will evolve slowly but steadily as each subsystem is built, tested, and refined.

---

## Objectives

* Understand the inner workings of the original Game Boy
* Recreate hardware behavior in clean, idiomatic C#
* Build a long-lasting, maintainable emulator architecture
* Support commercial ROMs accurately
* Document the process and the system thoroughly
* Produce a stable, accurate emulator rather than a quick one

---

## Project Structure

```
/src
  /Core
    CPU.cs
    Registers.cs
    MemoryBus.cs
    InstructionTable.cs
    Cartridge.cs

  /Graphics
    PPU.cs
    ScreenBuffer.cs

  /Input
    Joypad.cs

  /Audio
    APU.cs       (farther in development)

Program.cs
README.md
```

---

## Progress Overview

A high-level checklist of major components and their status.

| Chapter | Description                    | Status                            |
| ------- | ------------------------------ | --------------------------------- |
| 1       | Project Setup                  | ☐                                 |
| 2       | CPU Fundamentals               | ✔ (Core complete; needs testing)  |
| 3       | Memory & MMU                   | ☐                                 |
| 4       | Instruction Set Implementation | ✔ (All major opcodes implemented) |
| 5       | Timers & Interrupts            | ☐                                 |
| 6       | Graphics (PPU)                 | ☐                                 |
| 7       | Input                          | ☐                                 |
| 8       | Cartridge Mappers              | ☐                                 |
| 9       | Audio (APU)                    | ☐                                 |
| 10      | Polish, Debugging, Testing     | ☐                                 |

---

## Development Roadmap

This is the planned order in which the emulator’s components will be built.
Some stages may overlap as subsystems interact.

### 1. Project Setup

* Folder organization
* `.gitignore`
* Initial README
* Base project settings

### 2. CPU Fundamentals

* Registers and flags
* Instruction tables
* Fetch–decode–execute loop
* Basic debugging helpers

### 3. Memory & MMU

* Full memory map
* Read/write behavior
* Cartridge loading
* MBC0 fixed banking

### 4. Instruction Set

* Arithmetic and logic
* Load/store instructions
* Jumps, calls, returns
* 16-bit instructions
* CB-prefixed instructions
* Full CPU behavioral coverage
* Early test ROMs for validation

### 5. Timers & Interrupts

* DIV, TIMA, TMA, TAC
* IF/IE registers
* Interrupt dispatching
* Cycle-accurate timing

### 6. Graphics (PPU)

* VRAM and OAM
* LCD controller state machine
* Tile/background rendering
* Scanline pipeline
* First graphical output

### 7. Input

* Joypad register behavior
* Keyboard mapping

### 8. Cartridge Mappers

* MBC1
* MBC3 (with optional RTC)
* MBC5
* Save RAM

### 9. Audio (APU)

* Square channels
* Wave channel
* Noise channel
* Mixing and timing

### 10. Debugging & Polish

* Step/run execution controls
* Memory viewers
* Breakpoints
* Logging
* Compatibility testing
* Cleanup and documentation

---

## Requirements

* .NET 8 or newer
* Visual Studio Code or any C#-compatible IDE
* (Optional) SDL2-CS or Raylib-CS for graphics/audio output later

---

## Current Status

The CPU core and nearly all instructions have been implemented, including stack behavior, calls, returns, jumps, CB opcodes, and control flow.
Memory mapping, interrupts, and graphics subsystems are the next major tasks.

This emulator is still in its early lifecycle, but the foundation is solid and designed to grow cleanly as more hardware components are added.