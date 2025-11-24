# **Game Boy Emulator (C#)**

This project is my attempt to build a complete, accurate, and maintainable emulator for the original Game Boy (DMG-01) using C#.
The goal is to truly understand the hardware and recreate it cleanly, subsystem by subsystem, without shortcuts or hacks.

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

  /Input
    Joypad.cs

  /Audio
    APU.cs

Program.cs
README.md
```

---

## **Progress Overview**

| Chapter | Description                    | Status                                  |
| ------- | ------------------------------ | --------------------------------------- |
| 1       | Project Setup                  | ✔                                       |
| 2       | CPU Fundamentals               | ✔ (complete; pending test ROMs)         |
| 3       | Memory & MMU                   | ✔ (DMG map fully implemented)           |
| 4       | Instruction Set Implementation | ✔ (all opcodes implemented)             |
| 5       | Timers & Interrupts            | ≈ (implemented; needs validation)       |
| 6       | Graphics (PPU)                 | ≈ (pipeline implemented; needs display) |
| 7       | Input                          | ☐                                       |
| 8       | Cartridge Mappers              | ☐                                       |
| 9       | Audio (APU)                    | ☐                                       |
| 10      | Debugging & Testing            | ☐                                       |

---