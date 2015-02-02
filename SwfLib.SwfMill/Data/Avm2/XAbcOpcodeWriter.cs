using System.Xml.Linq;
using SwfLib.Avm2;
using SwfLib.Avm2.Opcodes;
using SwfLib.Avm2.Opcodes.Arithmetics;
using SwfLib.Avm2.Opcodes.Branching;
using SwfLib.Avm2.Opcodes.ByteArray;
using SwfLib.Avm2.Opcodes.Debug;
using SwfLib.Avm2.Opcodes.Stack;
using SwfLib.Avm2.Opcodes.TypeCasting;
using SwfLib.Avm2.Opcodes.Xml;

namespace SwfLib.SwfMill.Data.Avm2 {
    public class XAbcOpcodeWriter : IAvm2OpcodeVisitor<AbcMethodBodyInstruction, XElement> {

        public XElement Visit(AddOpcode action, AbcMethodBodyInstruction arg) {
            return new XElement("add");
        }

        public XElement Visit(AddIOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(AsTypeOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(AsTypeLateOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(BitAndOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(BitNotOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(BitOrOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(BitXorOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(BreakpointOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(BreakpointLineOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(CallOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(CallMethodOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(CallPropertyOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("callproperty", new XAttribute("name", opcode.Name.ToXml()), new XAttribute("args", opcode.ArgCount));
        }

        public XElement Visit(CallPropLexOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(CallPropVoidOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(CallStaticOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(CallSuperOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(CallSuperVoidOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(CheckFilterOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(CoerceOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(CoerceAOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("coerce_a");
        }

        public XElement Visit(CoerceBOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(CoerceDOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(CoerceIOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(CoerceOOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(CoerceSOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(CoerceUOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(ConstructOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(ConstructPropOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("constructprop", new XAttribute("name", opcode.Name.ToXml()), new XAttribute("args", opcode.ArgCount));
        }

        public XElement Visit(ConstructSuperOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("constructsuper", new XAttribute("args", opcode.ArgCount));
        }

        public XElement Visit(ConvertBOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(ConvertDOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(ConvertIOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("convert_i");
        }

        public XElement Visit(ConvertOOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(ConvertSOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(ConvertUOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(DebugOpcode opcode, AbcMethodBodyInstruction arg) {
            var res = new XElement("debug",
                new XAttribute("type", opcode.DebugType),
                new XAttribute("name", opcode.Name),
                new XAttribute("reg", opcode.Register));
            if (opcode.Extra != 0) {
                res.Add(new XAttribute("extra", opcode.Extra));
            }
            return res;
        }

        public XElement Visit(DebugFileOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("debugfile", new XAttribute("fileName", opcode.FileName));
        }

        public XElement Visit(DebugLineOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("debugline", new XAttribute("lineNum", opcode.LineNum));
        }

        public XElement Visit(DecLocalOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(DecLocalIOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(DecrementOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(DecrementIOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(DeletePropertyOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(DivideOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(DupOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("dup");
        }

        public XElement Visit(DxnsOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(DxnsLateOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(EqualsOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(EscXAttrOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(EscXElemOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(FindDefinitionOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(FindPropertyOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("findproperty", new XAttribute("name", opcode.Name.ToXml()));
        }

        public XElement Visit(FindPropStrictOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("findpropstrict", new XAttribute("name", opcode.Name.ToXml()));
        }

        public XElement Visit(GetDescendantsOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(GetGlobalScopeOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(GetGlobalSlotOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(GetLexOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(GetLocalOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(GetLocal0Opcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("getlocal_0");
        }

        public XElement Visit(GetLocal1Opcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("getlocal_1");
        }

        public XElement Visit(GetLocal2Opcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("getlocal_2");
        }

        public XElement Visit(GetLocal3Opcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("getlocal_3");
        }

        public XElement Visit(GetPropertyOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("getproperty", new XAttribute("name", opcode.Name.ToXml()));
        }

        public XElement Visit(GetScopeObjectOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("getscopeobject", new XAttribute("index", opcode.Index));
        }

        public XElement Visit(GetSlotOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(GetSuperOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(GreaterEqualsOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(GreaterThanOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(HasNextOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(HasNext2Opcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(IfeqOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(IfFalseOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(IfgeOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(IfgtOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(IfleOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(IfltOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(IfneOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(IfngeOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(IfngtOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(IfnleOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(IfnltOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(IfStrictEqOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(IfStrictNeOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(IfTrueOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(InOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(IncLocalOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(IncLocalIOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(IncrementOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(IncrementIOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(InitPropertyOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("initproperty", new XAttribute("name", opcode.Name.ToXml()));
        }

        public XElement Visit(InstanceOfOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(IsTypeOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(IsTypeLateOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(JumpOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(KillOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(LabelOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(LessEqualsOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(LessThanOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(Lf32Opcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(Lf64Opcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(Li8Opcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(Li16Opcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(Li32Opcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(LookupSwitchOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(LShiftOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(ModuloOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(MultiplyOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(MultiplyIOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(NegateOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(NegateIOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(NewActivationOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("newactivation");
        }

        public XElement Visit(NewArrayOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(NewCatchOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(NewClassOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("newclass", new XAttribute("type", opcode.BaseType.Instance.Name)); //todo: class link?
        }

        public XElement Visit(NewFunctionOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(NewObjectOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(NextNameOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(NextValueOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(NopOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(NotOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(PopOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("pop");
        }

        public XElement Visit(PopScopeOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("popscope");
        }

        public XElement Visit(PushByteOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("pushbyte", new XAttribute("value", opcode.Value));
        }

        public XElement Visit(PushDoubleOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(PushFalseOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(PushIntOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(PushNamespaceOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(PushNanOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(PushNullOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("pushnull");
        }

        public XElement Visit(PushScopeOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("pushscope");
        }

        public XElement Visit(PushShortOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("pushshort", new XAttribute("value", opcode.Value));
        }

        public XElement Visit(PushStringOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("pushstring", new XAttribute("value", opcode.Value));
        }

        public XElement Visit(PushTrueOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("pushtrue");
        }

        public XElement Visit(PushUIntOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(PushUndefinedOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("pushundefined");
        }

        public XElement Visit(PushWithOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(ReturnValueOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(ReturnVoidOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("returnvoid");
        }

        public XElement Visit(RShiftOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(SetGlobalSlotOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(SetLocalOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(SetLocal0Opcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("setlocal_0");
        }

        public XElement Visit(SetLocal1Opcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("setlocal_1");
        }

        public XElement Visit(SetLocal2Opcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("setlocal_2");
        }

        public XElement Visit(SetLocal3Opcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("setlocal_3");
        }

        public XElement Visit(SetPropertyOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("setproperty", new XAttribute("name", opcode.Name.ToXml()));
        }

        public XElement Visit(SetSlotOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("setslot", new XAttribute("index", opcode.Index));
        }

        public XElement Visit(SetSuperOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(Sf32Opcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(Sf64Opcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(Si8Opcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(Si16Opcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(Si32Opcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(StrictEqualsOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(SubtractOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(SubtractIOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(SwapOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(ThrowOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(TimestampOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(TypeOfOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(UrshiftOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }

        public XElement Visit(UnknownOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new System.NotImplementedException();
        }
    }
}
