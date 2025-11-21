namespace Gameboy.Core;

public partial class CPU
{
    private void InitializeOpcodeTable()
    {
        // Fill everything with a default "not implemented" handler
        for (int i = 0; i < 0x100; i++)
            OpcodeTable[i] = Opcode_Unimplemented;

        // --------- Utility / Misc ---------
        OpcodeTable[0x00] = Opcode_00;   // NOP
        OpcodeTable[0x76] = Opcode_76;   // HALT

        // --------- Rotates / Flags (already implemented in CPU.cs) ---------
        OpcodeTable[0x07] = Opcode_07;   // RLCA
        OpcodeTable[0x17] = Opcode_17;   // RLA
        OpcodeTable[0x0F] = Opcode_0F;   // RRCA
        OpcodeTable[0x1F] = Opcode_1F;   // RRA
        OpcodeTable[0x2F] = Opcode_2F;   // CPL
        OpcodeTable[0x37] = Opcode_37;   // SCF
        OpcodeTable[0x3F] = Opcode_3F;   // CCF

        // --------- INC / DEC (from your IncDec.cs file) ---------
        OpcodeTable[0x04] = Opcode_04;
        OpcodeTable[0x0C] = Opcode_0C;
        OpcodeTable[0x14] = Opcode_14;
        OpcodeTable[0x1C] = Opcode_1C;
        OpcodeTable[0x24] = Opcode_24;
        OpcodeTable[0x2C] = Opcode_2C;
        OpcodeTable[0x34] = Opcode_34;
        OpcodeTable[0x3C] = Opcode_3C;

        OpcodeTable[0x05] = Opcode_05;
        OpcodeTable[0x0D] = Opcode_0D;
        OpcodeTable[0x15] = Opcode_15;
        OpcodeTable[0x1D] = Opcode_1D;
        OpcodeTable[0x25] = Opcode_25;
        OpcodeTable[0x2D] = Opcode_2D;
        OpcodeTable[0x35] = Opcode_35;
        OpcodeTable[0x3D] = Opcode_3D;

        // --------- Loads (from Load.cs) ---------
        // --- LD A, r ---
        OpcodeTable[0x7F] = Opcode_7F;
        OpcodeTable[0x78] = Opcode_78;
        OpcodeTable[0x79] = Opcode_79;
        OpcodeTable[0x7A] = Opcode_7A;
        OpcodeTable[0x7B] = Opcode_7B;
        OpcodeTable[0x7C] = Opcode_7C;
        OpcodeTable[0x7D] = Opcode_7D;

        // --- LD r, A ---
        OpcodeTable[0x47] = Opcode_47;
        OpcodeTable[0x4F] = Opcode_4F;
        OpcodeTable[0x57] = Opcode_57;
        OpcodeTable[0x5F] = Opcode_5F;
        OpcodeTable[0x67] = Opcode_67;
        OpcodeTable[0x6F] = Opcode_6F;

        // --- LD r, r ---
        OpcodeTable[0x40] = Opcode_40;
        OpcodeTable[0x41] = Opcode_41;
        OpcodeTable[0x42] = Opcode_42;
        OpcodeTable[0x43] = Opcode_43;
        OpcodeTable[0x44] = Opcode_44;
        OpcodeTable[0x45] = Opcode_45;

        OpcodeTable[0x48] = Opcode_48;
        OpcodeTable[0x49] = Opcode_49;
        OpcodeTable[0x4A] = Opcode_4A;
        OpcodeTable[0x4B] = Opcode_4B;
        OpcodeTable[0x4C] = Opcode_4C;
        OpcodeTable[0x4D] = Opcode_4D;

        // --- LD r, (HL) ---
        OpcodeTable[0x46] = Opcode_46;
        OpcodeTable[0x4E] = Opcode_4E;
        OpcodeTable[0x56] = Opcode_56;
        OpcodeTable[0x5E] = Opcode_5E;
        OpcodeTable[0x66] = Opcode_66;
        OpcodeTable[0x6E] = Opcode_6E;
        OpcodeTable[0x7E] = Opcode_7E;

        // --- LD (HL), r ---
        OpcodeTable[0x70] = Opcode_70;
        OpcodeTable[0x71] = Opcode_71;
        OpcodeTable[0x72] = Opcode_72;
        OpcodeTable[0x73] = Opcode_73;
        OpcodeTable[0x74] = Opcode_74;
        OpcodeTable[0x75] = Opcode_75;
        OpcodeTable[0x77] = Opcode_77;

        // --- LD r, d8 ---
        OpcodeTable[0x06] = Opcode_06;
        OpcodeTable[0x0E] = Opcode_0E;
        OpcodeTable[0x16] = Opcode_16;
        OpcodeTable[0x1E] = Opcode_1E;
        OpcodeTable[0x26] = Opcode_26;
        OpcodeTable[0x2E] = Opcode_2E;
        OpcodeTable[0x3E] = Opcode_3E;

        // --- LD (HL), d8 ---
        OpcodeTable[0x36] = Opcode_36;

        // --- LD A, (BC/DE) ---
        OpcodeTable[0x0A] = Opcode_0A;
        OpcodeTable[0x1A] = Opcode_1A;

        // --- LD (BC/DE), A ---
        OpcodeTable[0x02] = Opcode_02;
        OpcodeTable[0x12] = Opcode_12;


        // --------- Jumps (from Jump.cs) ---------
        // ================== JP ==================
        OpcodeTable[0xC3] = Opcode_C3; // JP nn
        OpcodeTable[0xC2] = Opcode_C2; // JP NZ,nn
        OpcodeTable[0xCA] = Opcode_CA; // JP Z,nn
        OpcodeTable[0xD2] = Opcode_D2; // JP NC,nn
        OpcodeTable[0xDA] = Opcode_DA; // JP C,nn
        OpcodeTable[0xE9] = Opcode_E9; // JP (HL)

        // ================== JR ==================
        OpcodeTable[0x18] = Opcode_18; // JR r8
        OpcodeTable[0x20] = Opcode_20; // JR NZ,r8
        OpcodeTable[0x28] = Opcode_28; // JR Z,r8
        OpcodeTable[0x30] = Opcode_30; // JR NC,r8
        OpcodeTable[0x38] = Opcode_38; // JR C,r8


        // --------- Calls / Returns / Restarts ---------
        // ================== CALL ==================
        OpcodeTable[0xCD] = Opcode_CD; // CALL nn
        OpcodeTable[0xC4] = Opcode_C4; // CALL NZ,nn
        OpcodeTable[0xCC] = Opcode_CC; // CALL Z,nn
        OpcodeTable[0xD4] = Opcode_D4; // CALL NC,nn
        OpcodeTable[0xDC] = Opcode_DC; // CALL C,nn

        // ================== RET ==================
        OpcodeTable[0xC9] = Opcode_C9; // RET
        OpcodeTable[0xC0] = Opcode_C0; // RET NZ
        OpcodeTable[0xC8] = Opcode_C8; // RET Z
        OpcodeTable[0xD0] = Opcode_D0; // RET NC
        OpcodeTable[0xD8] = Opcode_D8; // RET C

        // ================== RETI ==================
        OpcodeTable[0xD9] = Opcode_D9; // RETI

        // ================== RST ==================
        OpcodeTable[0xC7] = Opcode_C7; // RST 00H
        OpcodeTable[0xCF] = Opcode_CF; // RST 08H
        OpcodeTable[0xD7] = Opcode_D7; // RST 10H
        OpcodeTable[0xDF] = Opcode_DF; // RST 18H
        OpcodeTable[0xE7] = Opcode_E7; // RST 20H
        OpcodeTable[0xEF] = Opcode_EF; // RST 28H
        OpcodeTable[0xF7] = Opcode_F7; // RST 30H
        OpcodeTable[0xFF] = Opcode_FF; // RST 38H

        // add methods
        OpcodeTable[0x80] = Opcode_80;
        OpcodeTable[0x81] = Opcode_81;
        OpcodeTable[0x82] = Opcode_82;
        OpcodeTable[0x83] = Opcode_83;
        OpcodeTable[0x84] = Opcode_84;
        OpcodeTable[0x85] = Opcode_85;
        OpcodeTable[0x86] = Opcode_86;
        OpcodeTable[0x87] = Opcode_87;

        OpcodeTable[0xC6] = Opcode_C6; // ADD A,d8

        // add hl rr
        OpcodeTable[0x09] = Opcode_09;
        OpcodeTable[0x19] = Opcode_19;
        OpcodeTable[0x29] = Opcode_29;
        OpcodeTable[0x39] = Opcode_39;

        // sub
        OpcodeTable[0x90] = Opcode_90;
        OpcodeTable[0x91] = Opcode_91;
        OpcodeTable[0x92] = Opcode_92;
        OpcodeTable[0x93] = Opcode_93;
        OpcodeTable[0x94] = Opcode_94;
        OpcodeTable[0x95] = Opcode_95;
        OpcodeTable[0x96] = Opcode_96;
        OpcodeTable[0x97] = Opcode_97;

        OpcodeTable[0xD6] = Opcode_D6; // SUB d8

        //sbc 
        OpcodeTable[0x98] = Opcode_98;
        OpcodeTable[0x99] = Opcode_99;
        OpcodeTable[0x9A] = Opcode_9A;
        OpcodeTable[0x9B] = Opcode_9B;
        OpcodeTable[0x9C] = Opcode_9C;
        OpcodeTable[0x9D] = Opcode_9D;
        OpcodeTable[0x9E] = Opcode_9E;
        OpcodeTable[0x9F] = Opcode_9F;

        // adc
        OpcodeTable[0x88] = Opcode_88;
        OpcodeTable[0x89] = Opcode_89;
        OpcodeTable[0x8A] = Opcode_8A;
        OpcodeTable[0x8B] = Opcode_8B;
        OpcodeTable[0x8C] = Opcode_8C;
        OpcodeTable[0x8D] = Opcode_8D;
        OpcodeTable[0x8E] = Opcode_8E;
        OpcodeTable[0x8F] = Opcode_8F;

        OpcodeTable[0xCE] = Opcode_CE;

        // interrupts
        OpcodeTable[0xF3] = Opcode_F3; // DI
        OpcodeTable[0xFB] = Opcode_FB; // EI

        // logic
        OpcodeTable[0xB0] = Opcode_B0;
        OpcodeTable[0xB1] = Opcode_B1;
        OpcodeTable[0xB2] = Opcode_B2;
        OpcodeTable[0xB3] = Opcode_B3;
        OpcodeTable[0xB4] = Opcode_B4;
        OpcodeTable[0xB5] = Opcode_B5;
        OpcodeTable[0xB6] = Opcode_B6;
        OpcodeTable[0xB7] = Opcode_B7;
        OpcodeTable[0xF6] = Opcode_F6;

        OpcodeTable[0xA8] = Opcode_A8;
        OpcodeTable[0xA9] = Opcode_A9;
        OpcodeTable[0xAA] = Opcode_AA;
        OpcodeTable[0xAB] = Opcode_AB;
        OpcodeTable[0xAC] = Opcode_AC;
        OpcodeTable[0xAD] = Opcode_AD;
        OpcodeTable[0xAE] = Opcode_AE;
        OpcodeTable[0xAF] = Opcode_AF;
        OpcodeTable[0xEE] = Opcode_EE;

        OpcodeTable[0xA0] = Opcode_A0;
        OpcodeTable[0xA1] = Opcode_A1;
        OpcodeTable[0xA2] = Opcode_A2;
        OpcodeTable[0xA3] = Opcode_A3;
        OpcodeTable[0xA4] = Opcode_A4;
        OpcodeTable[0xA5] = Opcode_A5;
        OpcodeTable[0xA6] = Opcode_A6;
        OpcodeTable[0xA7] = Opcode_A7;
        OpcodeTable[0xE6] = Opcode_E6;

        OpcodeTable[0xB8] = Opcode_B8;
        OpcodeTable[0xB9] = Opcode_B9;
        OpcodeTable[0xBA] = Opcode_BA;
        OpcodeTable[0xBB] = Opcode_BB;
        OpcodeTable[0xBC] = Opcode_BC;
        OpcodeTable[0xBD] = Opcode_BD;
        OpcodeTable[0xBE] = Opcode_BE;
        OpcodeTable[0xBF] = Opcode_BF;
        OpcodeTable[0xFE] = Opcode_FE;

        // push
        OpcodeTable[0xC5] = Opcode_C5;   // PUSH BC
        OpcodeTable[0xD5] = Opcode_D5;   // PUSH DE
        OpcodeTable[0xE5] = Opcode_E5;   // PUSH HL
        OpcodeTable[0xF5] = Opcode_F5;   // PUSH AF

        // pop
        OpcodeTable[0xC1] = Opcode_C1;   // POP BC
        OpcodeTable[0xD1] = Opcode_D1;   // POP DE
        OpcodeTable[0xE1] = Opcode_E1;   // POP HL
        OpcodeTable[0xF1] = Opcode_F1;   // POP AF

    }

}