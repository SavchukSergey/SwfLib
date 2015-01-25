using SwfLib.Actions3;

namespace SwfLib.Avm2 {
    public class AbcInstructionDecoder {

        public AsInstruction[] Decode(AsMethodBody methodBody) {
            //    enum TraceState : ubyte
            //    {
            //        unexplored,
            //        pending,
            //        instruction,
            //        instructionBody,
            //        error,
            //    }

            //    auto traceState = new TraceState[len];
            //    auto instructions = new ABCFile.Instruction[len];

            //    @property size_t offset() { return pos - start; }

            //    bool havePending;

            //    void queue(size_t traceOffset)
            //    {
            //        if (traceOffset < len && traceState[traceOffset] == TraceState.unexplored)
            //        {
            //            traceState[traceOffset] = TraceState.pending;
            //            havePending = true;
            //        }
            //    }

            //    queue(0);

            //    foreach (ref value; r.Exceptions)
            //        queue(value.target.absoluteOffset);

            //    while (havePending)
            //    {
            //        havePending = false;
            //        pos = start;
            //        while (pos < end)
            //        {
            //            if (traceState[offset] == TraceState.pending)
            //            {
            //                size_t instructionOffset;

            //                try
            //                {
            //                    while (pos < end)
            //                    {
            //                        instructionOffset = offset;

            //                        enforce(traceState[instructionOffset] != TraceState.instructionBody, "Overlapping instruction");
            //                        if (traceState[instructionOffset] == TraceState.instruction)
            //                            break; // already decoded

            //                        ABCFile.Instruction instruction;
            //                        instruction.opcode = cast(Opcode)readU8();
            //                        enforce(instruction.opcode != Opcode.OP_raw, "Null opcode");
            //                        instruction.arguments.length = opcodeInfo[instruction.opcode].argumentTypes.length;
            //                        foreach (i, type; opcodeInfo[instruction.opcode].argumentTypes)
            //                            final switch (type)
            //                            {
            //                                case OpcodeArgumentType.Unknown:
            //                                    throw new Exception("Don't know how to decode OP_" ~ opcodeInfo[instruction.opcode].name);

            //                                case OpcodeArgumentType.ByteLiteral:
            //                                    instruction.arguments[i].bytev = readU8();
            //                                    break;
            //                                case OpcodeArgumentType.UByteLiteral:
            //                                    instruction.arguments[i].ubytev = readU8();
            //                                    break;
            //                                case OpcodeArgumentType.IntLiteral:
            //                                    instruction.arguments[i].intv = readS32();
            //                                    break;
            //                                case OpcodeArgumentType.UIntLiteral:
            //                                    instruction.arguments[i].uintv = readU32();
            //                                    break;

            //                                case OpcodeArgumentType.Int:
            //                                case OpcodeArgumentType.UInt:
            //                                case OpcodeArgumentType.Double:
            //                                case OpcodeArgumentType.String:
            //                                case OpcodeArgumentType.Namespace:
            //                                case OpcodeArgumentType.Multiname:
            //                                case OpcodeArgumentType.Class:
            //                                case OpcodeArgumentType.Method:
            //                                {
            //                                    auto index = ReadU30();
            //                                    size_t length;
            //                                    switch (type)
            //                                    {
            //                                        case OpcodeArgumentType.Int:       length = abc.Integers      .length; break;
            //                                        case OpcodeArgumentType.UInt:      length = abc.UnsignedIntegers     .length; break;
            //                                        case OpcodeArgumentType.Double:    length = abc.Doubles   .length; break;
            //                                        case OpcodeArgumentType.String:    length = abc.Strings   .length; break;
            //                                        case OpcodeArgumentType.Namespace: length = abc.Namespaces.length; break;
            //                                        case OpcodeArgumentType.Multiname: length = abc.Multinames.length; break;
            //                                        case OpcodeArgumentType.Class:     length = abc.Classes   .length; break;
            //                                        case OpcodeArgumentType.Method:    length = abc.Methods   .length; break;
            //                                        default: assert(false);
            //                                    }
            //                                    enforce(index < length, "Out-of-bounds constant index");
            //                                    instruction.arguments[i].index = index;
            //                                    break;
            //                                }

            //                                case OpcodeArgumentType.JumpTarget:
            //                                {
            //                                    auto delta = readS24();
            //                                    auto target = offset + delta;
            //                                    instruction.arguments[i].jumpTarget.absoluteOffset = target;
            //                                    queue(target);
            //                                    break;
            //                                }

            //                                case OpcodeArgumentType.SwitchDefaultTarget:
            //                                {
            //                                    auto target = instructionOffset + readS24();
            //                                    instruction.arguments[i].jumpTarget.absoluteOffset = target;
            //                                    queue(target);
            //                                    break;
            //                                }

            //                                case OpcodeArgumentType.SwitchTargets:
            //                                    instruction.arguments[i].switchTargets.length = ReadU30()+1;
            //                                    foreach (ref label; instruction.arguments[i].switchTargets)
            //                                    {
            //                                        label.absoluteOffset = instructionOffset + readS24();
            //                                        queue(label.absoluteOffset);
            //                                    }
            //                                    break;
            //                            }

            //                        enforce(offset <= len, "Out-of-bounds Code read error");

            //                        instructions[instructionOffset] = instruction;
            //                        traceState[instructionOffset] = TraceState.instruction;
            //                        traceState[instructionOffset+1..offset] = TraceState.instructionBody;

            //                        if (stopsExecution[instruction.opcode])
            //                            break;
            //                    }
            //                }
            //                catch (Exception e)
            //                {
            //                    traceState[instructionOffset] = TraceState.error;
            //                    ABCFile.Label loc;
            //                    loc.absoluteOffset = instructionOffset;
            //                    r.errors ~= ABCFile.Error(loc, e.msg);

            //                    pos = start + instructionOffset + 1;
            //                }
            //            }
            //            else
            //                pos++;
            //        }
            //    }

            //    size_t[] instructionOffsets;
            //    auto instructionAtOffset = new uint[len];
            //    instructionAtOffset[] = uint.max;

            //    void addInstruction(ref ABCFile.Instruction i, size_t offset)
            //    {
            //        instructionAtOffset[offset] = to!uint(r.instructions.length);
            //        r.instructions ~= i;
            //        instructionOffsets ~= offset;
            //    }

            //    foreach (o, state; traceState)
            //    {
            //        assert(state != TraceState.pending);
            //        if (state == TraceState.instruction)
            //            addInstruction(instructions[o], o);
            //        else
            //        if (state == TraceState.unexplored || state == TraceState.error)
            //        {
            //            ABCFile.Instruction instruction;
            //            instruction.opcode = Opcode.OP_raw;
            //            instruction.arguments.length = 1;
            //            instruction.arguments[0].ubytev = buf[start + o];
            //            addInstruction(instruction, o);
            //        }
            //        else
            //            assert(state == TraceState.instructionBody);
            //    }

            //    void translateLabel(ref ABCFile.Label label)
            //    {
            //        auto absoluteOffset = label.absoluteOffset;
            //        auto instructionOffset = absoluteOffset;
            //        while (true)
            //        {
            //            if (instructionOffset >= len)
            //            {
            //                label.index = to!uint(r.instructions.length);
            //                instructionOffset = len;
            //                break;
            //            }
            //            if (instructionOffset <= 0)
            //            {
            //                label.index = 0;
            //                instructionOffset = 0;
            //                break;
            //            }
            //            if (instructionAtOffset[instructionOffset] != uint.max)
            //            {
            //                label.index = instructionAtOffset[instructionOffset];
            //                break;
            //            }
            //            instructionOffset--;
            //        }
            //        label.offset = to!int(absoluteOffset-instructionOffset);
            //    }

            //    // convert jump target offsets to instruction indices
            //    foreach (ii, ref instruction; r.instructions)
            //        foreach (i, type; opcodeInfo[instruction.opcode].argumentTypes)
            //            switch (type)
            //            {
            //                case OpcodeArgumentType.JumpTarget:
            //                case OpcodeArgumentType.SwitchDefaultTarget:
            //                    translateLabel(instruction.arguments[i].jumpTarget);
            //                    break;
            //                case OpcodeArgumentType.SwitchTargets:
            //                    foreach (ref x; instruction.arguments[i].switchTargets)
            //                        translateLabel(x);
            //                    break;
            //                default:
            //                    break;
            //            }

            //    // convert error offsets to instruction indices
            //    foreach (ref e; r.errors)
            //        translateLabel(e.loc);

            //    // convert exception offsets to instruction indices
            //    foreach (ref value; r.Exceptions)
            //    {
            //        translateLabel(value.from);
            //        translateLabel(value.to);
            //        translateLabel(value.target);
            //    }

            return null;
        }
    }
}
