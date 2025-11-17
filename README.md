# Game Boy Emulator (C#)

This is my attempt at building a Game Boy (DMG-01) emulator in C#.  
The goal is to make it as accurate and clean as I possibly can while learning a lot about low-level systems, CPU architecture, memory, graphics timing, cartridge behavior, and all the weird details the hardware hides.

This is a long-term project. I want to treat it seriously, take my time with it, and slowly turn it into something I’m proud of. If things go well, I’d like to keep improving it over time and maybe even reach a level where it’s good enough for real use.

---

## Goals

- Understand how the original Game Boy works internally  
- Implement every major subsystem step by step  
- Translate hardware behavior into solid C# code  
- Build something accurate, maintainable, and long-lasting  
- Eventually support commercial ROMs properly  
- Push for “as perfect as I can make it”  

---

## Project Structure

```

/src
/Core
CPU.cs
Registers.cs
MMU.cs
InstructionTable.cs
Cartridge.cs

/Graphics
PPU.cs
ScreenBuffer.cs

/Input
Joypad.cs

/Audio
APU.cs   (much later)

Program.cs

```

---

## Progress Checklist

A simple overview so I can track what’s done and what isn’t yet.

| Chapter | Description | Status |
|--------|-------------|--------|
| 1 | Project Setup | ☐ |
| 2 | CPU Fundamentals | ☐ |
| 3 | Memory & MMU | ☐ |
| 4 | Instruction Set Implementation | ☐ |
| 5 | Timers & Interrupts | ☐ |
| 6 | Graphics (PPU) | ☐ |
| 7 | Input | ☐ |
| 8 | Cartridge Mappers (MBC1/3/5) | ☐ |
| 9 | Audio (APU) | ☐ |
| 10 | Polish, Debug Tools, Testing | ☐ |

I’ll mark these off as I finish them.

---

## Development Timeline

This is the rough order I’m following. Just a roadmap so the project doesn’t turn into chaos.

### Chapter 1: Project Setup
- Create console project  
- Set up folders  
- Add `.gitignore` and README  
- Add a ROM-loading stub

### Chapter 2: CPU Fundamentals
- All CPU registers  
- Flags  
- Stack pointer / program counter  
- Opcode table  
- Fetch-decode-execute loop

### Chapter 3: Memory & MMU
- Full memory map  
- Read/write logic  
- Cartridge header parsing  
- Basic MBC0 support

### Chapter 4: Instruction Set
- Arithmetic + logic  
- Load/store  
- Jumps, calls, returns  
- CB-prefixed instructions  
- Test ROM validation

### Chapter 5: Timers & Interrupts
- DIV / TIMA / TMA / TAC  
- Interrupts, IME, IF/IE  
- Cycle timing

### Chapter 6: Graphics (PPU)
- VRAM / OAM  
- PPU modes  
- Tile decoding  
- Scanline rendering  
- First on-screen output

### Chapter 7: Input
- Joypad register  
- Keyboard → button mapping

### Chapter 8: Cartridge Mappers
- MBC1  
- MBC3 (RTC optional)  
- MBC5  
- Save RAM support

### Chapter 9: Audio (APU)
- Square 1  
- Square 2  
- Wave channel  
- Noise channel  
- Mixing and timing

### Chapter 10: Polish & Testing
- Debugger tools  
- Step/run/inspect features  
- Settings  
- Testing ROMs and commercial games  
- Documenting everything

---

## Requirements

- .NET 8+  
- VS Code  
- (Optional) SDL2-CS or Raylib-CS for graphics/audio later  

---

## License

MIT (or whatever I decide)

---

## Status

Project is in its very early stages. Taking my time with it so each part is done properly.