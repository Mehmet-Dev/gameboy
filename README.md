# **Game Boy Emulator (C#)**

This project is my long-term attempt to build a complete, accurate, and maintainable emulator for the original Game Boy (DMG-01) using C#.

The aim is simple:
understand the hardware, recreate it cleanly, and produce something that behaves like the real machine instead of a quick hack that only runs Tetris. The emulator grows one subsystem at a time, each implemented in-depth and documented along the way.

---

## **Objectives**

* Understand the internal architecture of the Game Boy
* Recreate hardware behavior in clear, idiomatic C#
* Build a stable emulator core designed to last
* Support commercial ROMs accurately
* Document decisions and hardware behavior
* Favor correctness and maintainability over shortcuts

---

## **Project Structure**

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
    APU.cs

Program.cs
README.md
```

This layout will expand as new subsystems are added (timers, MBC controllers, debugging tools, etc.)

---

## **Progress Overview**

A high-level summary of the emulator’s current state:

| Chapter | Description                    | Status                              |
| ------- | ------------------------------ | ----------------------------------- |
| 1       | Project Setup                  | ✔                                   |
| 2       | CPU Fundamentals               | ✔ (Core complete; needs validation) |
| 3       | Memory & MMU                   | ☐                                   |
| 4       | Instruction Set Implementation | ✔ (All opcodes implemented)         |
| 5       | Timers & Interrupts            | ☐                                   |
| 6       | Graphics (PPU)                 | ☐                                   |
| 7       | Input                          | ☐                                   |
| 8       | Cartridge Mappers              | ☐                                   |
| 9       | Audio (APU)                    | ☐                                   |
| 10      | Debugging & Testing            | ☐                                   |

---

## **Development Roadmap**

The planned order of subsystem implementation.
Each piece will be built, tested, and refined before moving on.

### **1. Project Setup**

* Folder structure
* Build rules
* Initial documentation

### **2. CPU Fundamentals**

* Registers, flags, and fetch-decode-execute loop
* Opcode tables
* Core helpers
* Early behavior testing

### **3. Memory & MMU**

* Full DMG memory map
* Read/write rules
* Cartridge loading
* Initial MBC0 implementation

### **4. Instruction Set**

* All arithmetic and logic
* Loads/stores
* Jumps, calls, returns
* CB-prefixed instructions
* Verified CPU behavior

### **5. Timers & Interrupts**

* DIV, TIMA, TMA, TAC
* Interrupt enable/flag registers
* Full interrupt dispatch
* Cycle-accurate timer behavior

### **6. Graphics (PPU)**

* VRAM and OAM
* LCDC/STAT behavior
* Mode 0/1/2/3 pipeline
* Background/tile rendering
* First frame output

### **7. Input**

* Joypad register
* Button edge behavior
* Keyboard/controller mapping

### **8. Cartridge Mappers**

* MBC1
* MBC3 (RTC optional)
* MBC5
* Save RAM persistence

### **9. Audio (APU)**

* Square channels
* Wave channel
* Noise channel
* Mixer and timing

### **10. Debugging & Polish**

* Breakpoints
* Logging
* CPU/PPU inspectors
* Cleanup and refinement

---

## **Requirements**

* .NET 8 or newer
* Any C# IDE (VS Code, Rider, Visual Studio)
* (Optional) Raylib-CS or SDL2-CS for display/audio

---

## **Current Status**

The CPU core is complete, including all documented Game Boy opcodes, stack operations, control flow, CB instructions, and the DAA edge case. What remains is wiring the MMU correctly, finishing the interrupt system, and building the graphics/timer subsystems.

The project is early-stage, but the foundation is solid and ready for the more complex hardware components.