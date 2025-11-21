namespace Gameboy.Core;

public partial class CPU
{
    private void InitializeCbOpcodeTable()
    {
        for (int i = 0; i < 0x100; i++)
            CbOpcodeTable[i] = Cb_Unimplemented;

        // ================== CB BIT INSTRUCTIONS ==================

        // BIT 0 (0x40–0x47)
        CbOpcodeTable[0x40] = CbOpcode_40;
        CbOpcodeTable[0x41] = CbOpcode_41;
        CbOpcodeTable[0x42] = CbOpcode_42;
        CbOpcodeTable[0x43] = CbOpcode_43;
        CbOpcodeTable[0x44] = CbOpcode_44;
        CbOpcodeTable[0x45] = CbOpcode_45;
        CbOpcodeTable[0x46] = CbOpcode_46;
        CbOpcodeTable[0x47] = CbOpcode_47;

        // BIT 1 (0x48–0x4F)
        CbOpcodeTable[0x48] = CbOpcode_48;
        CbOpcodeTable[0x49] = CbOpcode_49;
        CbOpcodeTable[0x4A] = CbOpcode_4A;
        CbOpcodeTable[0x4B] = CbOpcode_4B;
        CbOpcodeTable[0x4C] = CbOpcode_4C;
        CbOpcodeTable[0x4D] = CbOpcode_4D;
        CbOpcodeTable[0x4E] = CbOpcode_4E;
        CbOpcodeTable[0x4F] = CbOpcode_4F;

        // BIT 2 (0x50–0x57)
        CbOpcodeTable[0x50] = CbOpcode_50;
        CbOpcodeTable[0x51] = CbOpcode_51;
        CbOpcodeTable[0x52] = CbOpcode_52;
        CbOpcodeTable[0x53] = CbOpcode_53;
        CbOpcodeTable[0x54] = CbOpcode_54;
        CbOpcodeTable[0x55] = CbOpcode_55;
        CbOpcodeTable[0x56] = CbOpcode_56;
        CbOpcodeTable[0x57] = CbOpcode_57;

        // BIT 3 (0x58–0x5F)
        CbOpcodeTable[0x58] = CbOpcode_58;
        CbOpcodeTable[0x59] = CbOpcode_59;
        CbOpcodeTable[0x5A] = CbOpcode_5A;
        CbOpcodeTable[0x5B] = CbOpcode_5B;
        CbOpcodeTable[0x5C] = CbOpcode_5C;
        CbOpcodeTable[0x5D] = CbOpcode_5D;
        CbOpcodeTable[0x5E] = CbOpcode_5E;
        CbOpcodeTable[0x5F] = CbOpcode_5F;

        // BIT 4 (0x60–0x67)
        CbOpcodeTable[0x60] = CbOpcode_60;
        CbOpcodeTable[0x61] = CbOpcode_61;
        CbOpcodeTable[0x62] = CbOpcode_62;
        CbOpcodeTable[0x63] = CbOpcode_63;
        CbOpcodeTable[0x64] = CbOpcode_64;
        CbOpcodeTable[0x65] = CbOpcode_65;
        CbOpcodeTable[0x66] = CbOpcode_66;
        CbOpcodeTable[0x67] = CbOpcode_67;

        // BIT 5 (0x68–0x6F)
        CbOpcodeTable[0x68] = CbOpcode_68;
        CbOpcodeTable[0x69] = CbOpcode_69;
        CbOpcodeTable[0x6A] = CbOpcode_6A;
        CbOpcodeTable[0x6B] = CbOpcode_6B;
        CbOpcodeTable[0x6C] = CbOpcode_6C;
        CbOpcodeTable[0x6D] = CbOpcode_6D;
        CbOpcodeTable[0x6E] = CbOpcode_6E;
        CbOpcodeTable[0x6F] = CbOpcode_6F;

        // BIT 6 (0x70–0x77)
        CbOpcodeTable[0x70] = CbOpcode_70;
        CbOpcodeTable[0x71] = CbOpcode_71;
        CbOpcodeTable[0x72] = CbOpcode_72;
        CbOpcodeTable[0x73] = CbOpcode_73;
        CbOpcodeTable[0x74] = CbOpcode_74;
        CbOpcodeTable[0x75] = CbOpcode_75;
        CbOpcodeTable[0x76] = CbOpcode_76;
        CbOpcodeTable[0x77] = CbOpcode_77;

        // BIT 7 (0x78–0x7F)
        CbOpcodeTable[0x78] = CbOpcode_78;
        CbOpcodeTable[0x79] = CbOpcode_79;
        CbOpcodeTable[0x7A] = CbOpcode_7A;
        CbOpcodeTable[0x7B] = CbOpcode_7B;
        CbOpcodeTable[0x7C] = CbOpcode_7C;
        CbOpcodeTable[0x7D] = CbOpcode_7D;
        CbOpcodeTable[0x7E] = CbOpcode_7E;
        CbOpcodeTable[0x7F] = CbOpcode_7F;

        // ================== CB RES INSTRUCTIONS ==================

        // RES 0 (0x80–0x87)
        CbOpcodeTable[0x80] = CbOpcode_80;
        CbOpcodeTable[0x81] = CbOpcode_81;
        CbOpcodeTable[0x82] = CbOpcode_82;
        CbOpcodeTable[0x83] = CbOpcode_83;
        CbOpcodeTable[0x84] = CbOpcode_84;
        CbOpcodeTable[0x85] = CbOpcode_85;
        CbOpcodeTable[0x86] = CbOpcode_86;
        CbOpcodeTable[0x87] = CbOpcode_87;

        // RES 1 (0x88–0x8F)
        CbOpcodeTable[0x88] = CbOpcode_88;
        CbOpcodeTable[0x89] = CbOpcode_89;
        CbOpcodeTable[0x8A] = CbOpcode_8A;
        CbOpcodeTable[0x8B] = CbOpcode_8B;
        CbOpcodeTable[0x8C] = CbOpcode_8C;
        CbOpcodeTable[0x8D] = CbOpcode_8D;
        CbOpcodeTable[0x8E] = CbOpcode_8E;
        CbOpcodeTable[0x8F] = CbOpcode_8F;

        // RES 2 (0x90–0x97)
        CbOpcodeTable[0x90] = CbOpcode_90;
        CbOpcodeTable[0x91] = CbOpcode_91;
        CbOpcodeTable[0x92] = CbOpcode_92;
        CbOpcodeTable[0x93] = CbOpcode_93;
        CbOpcodeTable[0x94] = CbOpcode_94;
        CbOpcodeTable[0x95] = CbOpcode_95;
        CbOpcodeTable[0x96] = CbOpcode_96;
        CbOpcodeTable[0x97] = CbOpcode_97;

        // RES 3 (0x98–0x9F)
        CbOpcodeTable[0x98] = CbOpcode_98;
        CbOpcodeTable[0x99] = CbOpcode_99;
        CbOpcodeTable[0x9A] = CbOpcode_9A;
        CbOpcodeTable[0x9B] = CbOpcode_9B;
        CbOpcodeTable[0x9C] = CbOpcode_9C;
        CbOpcodeTable[0x9D] = CbOpcode_9D;
        CbOpcodeTable[0x9E] = CbOpcode_9E;
        CbOpcodeTable[0x9F] = CbOpcode_9F;

        // RES 4 (0xA0–0xA7)
        CbOpcodeTable[0xA0] = CbOpcode_A0;
        CbOpcodeTable[0xA1] = CbOpcode_A1;
        CbOpcodeTable[0xA2] = CbOpcode_A2;
        CbOpcodeTable[0xA3] = CbOpcode_A3;
        CbOpcodeTable[0xA4] = CbOpcode_A4;
        CbOpcodeTable[0xA5] = CbOpcode_A5;
        CbOpcodeTable[0xA6] = CbOpcode_A6;
        CbOpcodeTable[0xA7] = CbOpcode_A7;

        // RES 5 (0xA8–0xAF)
        CbOpcodeTable[0xA8] = CbOpcode_A8;
        CbOpcodeTable[0xA9] = CbOpcode_A9;
        CbOpcodeTable[0xAA] = CbOpcode_AA;
        CbOpcodeTable[0xAB] = CbOpcode_AB;
        CbOpcodeTable[0xAC] = CbOpcode_AC;
        CbOpcodeTable[0xAD] = CbOpcode_AD;
        CbOpcodeTable[0xAE] = CbOpcode_AE;
        CbOpcodeTable[0xAF] = CbOpcode_AF;

        // RES 6 (0xB0–0xB7)
        CbOpcodeTable[0xB0] = CbOpcode_B0;
        CbOpcodeTable[0xB1] = CbOpcode_B1;
        CbOpcodeTable[0xB2] = CbOpcode_B2;
        CbOpcodeTable[0xB3] = CbOpcode_B3;
        CbOpcodeTable[0xB4] = CbOpcode_B4;
        CbOpcodeTable[0xB5] = CbOpcode_B5;
        CbOpcodeTable[0xB6] = CbOpcode_B6;
        CbOpcodeTable[0xB7] = CbOpcode_B7;

        // RES 7 (0xB8–0xBF)
        CbOpcodeTable[0xB8] = CbOpcode_B8;
        CbOpcodeTable[0xB9] = CbOpcode_B9;
        CbOpcodeTable[0xBA] = CbOpcode_BA;
        CbOpcodeTable[0xBB] = CbOpcode_BB;
        CbOpcodeTable[0xBC] = CbOpcode_BC;
        CbOpcodeTable[0xBD] = CbOpcode_BD;
        CbOpcodeTable[0xBE] = CbOpcode_BE;
        CbOpcodeTable[0xBF] = CbOpcode_BF;

        // ================== CB RLC (00–07) ==================
        CbOpcodeTable[0x00] = CbOpcode_00;
        CbOpcodeTable[0x01] = CbOpcode_01;
        CbOpcodeTable[0x02] = CbOpcode_02;
        CbOpcodeTable[0x03] = CbOpcode_03;
        CbOpcodeTable[0x04] = CbOpcode_04;
        CbOpcodeTable[0x05] = CbOpcode_05;
        CbOpcodeTable[0x06] = CbOpcode_06;
        CbOpcodeTable[0x07] = CbOpcode_07;

        // ================== CB RRC (08–0F) ==================
        CbOpcodeTable[0x08] = CbOpcode_08;
        CbOpcodeTable[0x09] = CbOpcode_09;
        CbOpcodeTable[0x0A] = CbOpcode_0A;
        CbOpcodeTable[0x0B] = CbOpcode_0B;
        CbOpcodeTable[0x0C] = CbOpcode_0C;
        CbOpcodeTable[0x0D] = CbOpcode_0D;
        CbOpcodeTable[0x0E] = CbOpcode_0E;
        CbOpcodeTable[0x0F] = CbOpcode_0F;

        // ================== CB RL (10–17) ==================
        CbOpcodeTable[0x10] = CbOpcode_10;
        CbOpcodeTable[0x11] = CbOpcode_11;
        CbOpcodeTable[0x12] = CbOpcode_12;
        CbOpcodeTable[0x13] = CbOpcode_13;
        CbOpcodeTable[0x14] = CbOpcode_14;
        CbOpcodeTable[0x15] = CbOpcode_15;
        CbOpcodeTable[0x16] = CbOpcode_16;
        CbOpcodeTable[0x17] = CbOpcode_17;

        // ================== CB RR (18–1F) ==================
        CbOpcodeTable[0x18] = CbOpcode_18;
        CbOpcodeTable[0x19] = CbOpcode_19;
        CbOpcodeTable[0x1A] = CbOpcode_1A;
        CbOpcodeTable[0x1B] = CbOpcode_1B;
        CbOpcodeTable[0x1C] = CbOpcode_1C;
        CbOpcodeTable[0x1D] = CbOpcode_1D;
        CbOpcodeTable[0x1E] = CbOpcode_1E;
        CbOpcodeTable[0x1F] = CbOpcode_1F;

        // ================== CB SLA (20–27) ==================
        CbOpcodeTable[0x20] = CbOpcode_20;
        CbOpcodeTable[0x21] = CbOpcode_21;
        CbOpcodeTable[0x22] = CbOpcode_22;
        CbOpcodeTable[0x23] = CbOpcode_23;
        CbOpcodeTable[0x24] = CbOpcode_24;
        CbOpcodeTable[0x25] = CbOpcode_25;
        CbOpcodeTable[0x26] = CbOpcode_26;
        CbOpcodeTable[0x27] = CbOpcode_27;

        // ================== CB SRA (28–2F) ==================
        CbOpcodeTable[0x28] = CbOpcode_28;
        CbOpcodeTable[0x29] = CbOpcode_29;
        CbOpcodeTable[0x2A] = CbOpcode_2A;
        CbOpcodeTable[0x2B] = CbOpcode_2B;
        CbOpcodeTable[0x2C] = CbOpcode_2C;
        CbOpcodeTable[0x2D] = CbOpcode_2D;
        CbOpcodeTable[0x2E] = CbOpcode_2E;
        CbOpcodeTable[0x2F] = CbOpcode_2F;

        // ================== CB SWAP (30–37) ==================
        CbOpcodeTable[0x30] = CbOpcode_30;
        CbOpcodeTable[0x31] = CbOpcode_31;
        CbOpcodeTable[0x32] = CbOpcode_32;
        CbOpcodeTable[0x33] = CbOpcode_33;
        CbOpcodeTable[0x34] = CbOpcode_34;
        CbOpcodeTable[0x35] = CbOpcode_35;
        CbOpcodeTable[0x36] = CbOpcode_36;
        CbOpcodeTable[0x37] = CbOpcode_37;

        // ================== CB SRL (38–3F) ==================
        CbOpcodeTable[0x38] = CbOpcode_38;
        CbOpcodeTable[0x39] = CbOpcode_39;
        CbOpcodeTable[0x3A] = CbOpcode_3A;
        CbOpcodeTable[0x3B] = CbOpcode_3B;
        CbOpcodeTable[0x3C] = CbOpcode_3C;
        CbOpcodeTable[0x3D] = CbOpcode_3D;
        CbOpcodeTable[0x3E] = CbOpcode_3E;
        CbOpcodeTable[0x3F] = CbOpcode_3F;

        // ================== CB SET 0 (C0–C7) ==================
        CbOpcodeTable[0xC0] = CbOpcode_C0;
        CbOpcodeTable[0xC1] = CbOpcode_C1;
        CbOpcodeTable[0xC2] = CbOpcode_C2;
        CbOpcodeTable[0xC3] = CbOpcode_C3;
        CbOpcodeTable[0xC4] = CbOpcode_C4;
        CbOpcodeTable[0xC5] = CbOpcode_C5;
        CbOpcodeTable[0xC6] = CbOpcode_C6;
        CbOpcodeTable[0xC7] = CbOpcode_C7;

        // ================== CB SET 1 (C8–CF) ==================
        CbOpcodeTable[0xC8] = CbOpcode_C8;
        CbOpcodeTable[0xC9] = CbOpcode_C9;
        CbOpcodeTable[0xCA] = CbOpcode_CA;
        CbOpcodeTable[0xCB] = CbOpcode_CB;
        CbOpcodeTable[0xCC] = CbOpcode_CC;
        CbOpcodeTable[0xCD] = CbOpcode_CD;
        CbOpcodeTable[0xCE] = CbOpcode_CE;
        CbOpcodeTable[0xCF] = CbOpcode_CF;

        // ================== CB SET 2 (D0–D7) ==================
        CbOpcodeTable[0xD0] = CbOpcode_D0;
        CbOpcodeTable[0xD1] = CbOpcode_D1;
        CbOpcodeTable[0xD2] = CbOpcode_D2;
        CbOpcodeTable[0xD3] = CbOpcode_D3;
        CbOpcodeTable[0xD4] = CbOpcode_D4;
        CbOpcodeTable[0xD5] = CbOpcode_D5;
        CbOpcodeTable[0xD6] = CbOpcode_D6;
        CbOpcodeTable[0xD7] = CbOpcode_D7;

        // ================== CB SET 3 (D8–DF) ==================
        CbOpcodeTable[0xD8] = CbOpcode_D8;
        CbOpcodeTable[0xD9] = CbOpcode_D9;
        CbOpcodeTable[0xDA] = CbOpcode_DA;
        CbOpcodeTable[0xDB] = CbOpcode_DB;
        CbOpcodeTable[0xDC] = CbOpcode_DC;
        CbOpcodeTable[0xDD] = CbOpcode_DD;
        CbOpcodeTable[0xDE] = CbOpcode_DE;
        CbOpcodeTable[0xDF] = CbOpcode_DF;

        // ================== CB SET 4 (E0–E7) ==================
        CbOpcodeTable[0xE0] = CbOpcode_E0;
        CbOpcodeTable[0xE1] = CbOpcode_E1;
        CbOpcodeTable[0xE2] = CbOpcode_E2;
        CbOpcodeTable[0xE3] = CbOpcode_E3;
        CbOpcodeTable[0xE4] = CbOpcode_E4;
        CbOpcodeTable[0xE5] = CbOpcode_E5;
        CbOpcodeTable[0xE6] = CbOpcode_E6;
        CbOpcodeTable[0xE7] = CbOpcode_E7;

        // ================== CB SET 5 (E8–EF) ==================
        CbOpcodeTable[0xE8] = CbOpcode_E8;
        CbOpcodeTable[0xE9] = CbOpcode_E9;
        CbOpcodeTable[0xEA] = CbOpcode_EA;
        CbOpcodeTable[0xEB] = CbOpcode_EB;
        CbOpcodeTable[0xEC] = CbOpcode_EC;
        CbOpcodeTable[0xED] = CbOpcode_ED;
        CbOpcodeTable[0xEE] = CbOpcode_EE;
        CbOpcodeTable[0xEF] = CbOpcode_EF;

        // ================== CB SET 6 (F0–F7) ==================
        CbOpcodeTable[0xF0] = CbOpcode_F0;
        CbOpcodeTable[0xF1] = CbOpcode_F1;
        CbOpcodeTable[0xF2] = CbOpcode_F2;
        CbOpcodeTable[0xF3] = CbOpcode_F3;
        CbOpcodeTable[0xF4] = CbOpcode_F4;
        CbOpcodeTable[0xF5] = CbOpcode_F5;
        CbOpcodeTable[0xF6] = CbOpcode_F6;
        CbOpcodeTable[0xF7] = CbOpcode_F7;

        // ================== CB SET 7 (F8–FF) ==================
        CbOpcodeTable[0xF8] = CbOpcode_F8;
        CbOpcodeTable[0xF9] = CbOpcode_F9;
        CbOpcodeTable[0xFA] = CbOpcode_FA;
        CbOpcodeTable[0xFB] = CbOpcode_FB;
        CbOpcodeTable[0xFC] = CbOpcode_FC;
        CbOpcodeTable[0xFD] = CbOpcode_FD;
        CbOpcodeTable[0xFE] = CbOpcode_FE;
        CbOpcodeTable[0xFF] = CbOpcode_FF;

    }
}