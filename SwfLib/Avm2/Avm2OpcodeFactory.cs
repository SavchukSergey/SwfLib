using SwfLib.Avm2.Opcodes;
using SwfLib.Avm2.Opcodes.Arithmetics;
using SwfLib.Avm2.Opcodes.TypeCasting;

namespace SwfLib.Avm2 {
    public class Avm2OpcodeFactory {

        public BaseAvm2Opcode CreateOpcode(Avm2Opcode opcode) {
            switch (opcode) {
                case Avm2Opcode.Add: return new AddOpcode();
                case Avm2Opcode.AddI: return new AddIOpcode();
                case Avm2Opcode.AsType: return new AsTypeOpcode();
                case Avm2Opcode.AsTypeLate: return new AsTypeLateOpcode();
                case Avm2Opcode.BitAnd: return new BitAndOpcode();
                case Avm2Opcode.BitNot: return new BitNotOpcode();
                case Avm2Opcode.BitOr: return new BitOrOpcode();
                case Avm2Opcode.BitXor: return new BitXorOpcode();
                default: return new UnknownOpcode();
            }
        }
    }
}
