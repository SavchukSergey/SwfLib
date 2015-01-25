using SwfLib.Avm2.Opcodes;
using SwfLib.Avm2.Opcodes.Arithmetics;
using SwfLib.Avm2.Opcodes.Branching;
using SwfLib.Avm2.Opcodes.Debug;
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
                case Avm2Opcode.Call: return new CallOpcode();
                case Avm2Opcode.CallMethod: return new CallMethodOpcode();
                case Avm2Opcode.CallProperty: return new CallPropertyOpcode();
                case Avm2Opcode.CallPropLex: return new CallPropLexOpcode();
                case Avm2Opcode.CallPropVoid: return new CallPropVoidOpcode();
                case Avm2Opcode.CallStatic: return new CallStaticOpcode();
                case Avm2Opcode.CallSuper: return new CallSuperOpcode();
                case Avm2Opcode.CallSuperVoid: return new CallSuperVoidOpcode();
                case Avm2Opcode.CheckFilter: return new CheckFilterOpcode();
                case Avm2Opcode.Coerce: return new CoerceOpcode();
                case Avm2Opcode.CoerceA: return new CoerceAOpcode();
                case Avm2Opcode.CoerceS: return new CoerceSOpcode();
                case Avm2Opcode.Construct: return new ConstructOpcode();
                case Avm2Opcode.ConstructProp: return new ConstructPropOpcode();
                case Avm2Opcode.ConstructSuper: return new ConstructSuperOpcode();
                case Avm2Opcode.ConvertB: return new ConvertBOpcode();
                case Avm2Opcode.ConvertI: return new ConvertIOpcode();
                case Avm2Opcode.ConvertD: return new ConvertDOpcode();
                case Avm2Opcode.ConvertO: return new ConvertOOpcode();
                case Avm2Opcode.ConvertU: return new ConvertUOpcode();
                case Avm2Opcode.ConvertS: return new ConvertSOpcode();
                case Avm2Opcode.Debug: return new DebugOpcode();
                case Avm2Opcode.DebugFile: return new DebugFileOpcode();
                case Avm2Opcode.DebugLine: return new DebugLineOpcode();
                default: return new UnknownOpcode();
            }
        }
    }
}
