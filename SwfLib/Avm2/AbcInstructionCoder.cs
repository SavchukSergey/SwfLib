using SwfLib.Actions3;

namespace SwfLib.Avm2 {
    public class AbcInstructionCoder {

        public byte[] Encode(AsInstruction[] instructions, AsMethodBody body) {
            //    auto instructionOffsets = new size_t[v.instructions.length+1];

            //    ptrdiff_t resolveLabel(ref ABCFile.Label label) { return instructionOffsets[label.index]+label.offset; }

            //    {
            //        // we don't know the length before writing all the instructions - swap buffer with a temporary one
            //        auto globalBuf = buf;
            //        auto globalPos = pos;
            //        static ubyte[1024*16] methodBuf;
            //        buf = methodBuf[];
            //        pos = 0;

            //        struct Fixup { ABCFile.Label target; size_t pos, base; }
            //        Fixup[] fixups;

            //        foreach (ii, ref instruction; v.instructions)
            //        {
            //            auto instructionOffset = pos;
            //            instructionOffsets[ii] = instructionOffset;

            //            WriteU8(instruction.opcode);

            //            if (instruction.arguments.length != opcodeInfo[instruction.opcode].argumentTypes.length)
            //                throw new Exception("Mismatching number of arguments");

            //            foreach (i, type; opcodeInfo[instruction.opcode].argumentTypes)
            //                final switch (type)
            //                {
            //                    case AsOpcodeArgumentType.Unknown:
            //                        throw new Exception("Don't know how to encode OP_" ~ opcodeInfo[instruction.opcode].name);

            //                    case AsOpcodeArgumentType.ByteLiteral:
            //                        WriteU8(instruction.arguments[i].bytev);
            //                        break;
            //                    case AsOpcodeArgumentType.UByteLiteral:
            //                        WriteU8(instruction.arguments[i].ubytev);
            //                        break;
            //                    case AsOpcodeArgumentType.IntLiteral:
            //                        writeS32(instruction.arguments[i].intv);
            //                        break;
            //                    case AsOpcodeArgumentType.UIntLiteral:
            //                        writeU32(instruction.arguments[i].uintv);
            //                        break;

            //                    case AsOpcodeArgumentType.Int:
            //                    case AsOpcodeArgumentType.UInt:
            //                    case AsOpcodeArgumentType.Double:
            //                    case AsOpcodeArgumentType.String:
            //                    case AsOpcodeArgumentType.Namespace:
            //                    case AsOpcodeArgumentType.Multiname:
            //                    case AsOpcodeArgumentType.Class:
            //                    case AsOpcodeArgumentType.Method:
            //                        writeU30(instruction.arguments[i].index);
            //                        break;

            //                    case AsOpcodeArgumentType.JumpTarget:
            //                        fixups ~= Fixup(instruction.arguments[i].jumpTarget, pos, pos+3);
            //                        writeS24(0);
            //                        break;

            //                    case AsOpcodeArgumentType.SwitchDefaultTarget:
            //                        fixups ~= Fixup(instruction.arguments[i].jumpTarget, pos, instructionOffset);
            //                        writeS24(0);
            //                        break;

            //                    case AsOpcodeArgumentType.SwitchTargets:
            //                        if (instruction.arguments[i].switchTargets.length < 1)
            //                            throw new Exception("Too few switch cases");
            //                        writeU30(instruction.arguments[i].switchTargets.length-1);
            //                        foreach (off; instruction.arguments[i].switchTargets)
            //                        {
            //                            fixups ~= Fixup(off, pos, instructionOffset);
            //                            writeS24(0);
            //                        }
            //                        break;
            //                }
            //        }

            //        buf.length = pos;
            //        instructionOffsets[v.instructions.length] = pos;

            //        foreach (ref fixup; fixups)
            //        {
            //            pos = fixup.pos;
            //            writeS24(to!int(cast(ptrdiff_t)(resolveLabel(fixup.target)-fixup.base)));
            //        }

            //        auto Code = buf;
            //        // restore global buffer
            //        buf = globalBuf;
            //        pos = globalPos;

            //        writeBytes(Code);
            //    }
            return null;
        }
    }
}
