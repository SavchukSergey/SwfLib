using System;
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

        private readonly Func<uint, string> _labelFormatter;

        public XAbcOpcodeWriter(Func<uint, string> labelFormatter) {
            _labelFormatter = labelFormatter;
        }

        public XElement Visit(AddOpcode action, AbcMethodBodyInstruction arg) {
            return new XElement("add");
        }

        public XElement Visit(AddIOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("add_i");
        }

        public XElement Visit(AsTypeOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("astype").AddName(opcode.Name);
        }

        public XElement Visit(AsTypeLateOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("astypelate");
        }

        public XElement Visit(BitAndOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("bitand");
        }

        public XElement Visit(BitNotOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("bitnot");
        }

        public XElement Visit(BitOrOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("bitor");
        }

        public XElement Visit(BitXorOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("bitxor");
        }

        public XElement Visit(BreakpointOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("bkpt");
        }

        public XElement Visit(BreakpointLineOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new NotImplementedException();
        }

        public XElement Visit(CallOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("call").AddArgsCount(opcode.ArgCount);
        }

        public XElement Visit(CallMethodOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new NotImplementedException();
        }

        public XElement Visit(CallPropertyOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("callproperty").AddName(opcode.Name).AddArgsCount(opcode.ArgCount);
        }

        public XElement Visit(CallPropLexOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("callproplex").AddName(opcode.Name).AddArgsCount(opcode.ArgCount);
        }

        public XElement Visit(CallPropVoidOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("callpropvoid").AddName(opcode.Name).AddArgsCount(opcode.ArgCount);
        }

        public XElement Visit(CallStaticOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("callstatic").AddMethod(opcode.Method).AddArgsCount(opcode.ArgCount);
        }

        public XElement Visit(CallSuperOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("callsuper").AddName(opcode.Name).AddArgsCount(opcode.ArgCount);
        }

        public XElement Visit(CallSuperVoidOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("callsupervoid").AddName(opcode.Name).AddArgsCount(opcode.ArgCount);
        }

        public XElement Visit(CheckFilterOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("checkfilter");
        }

        public XElement Visit(CoerceOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("coerce", new XAttribute("type", opcode.Type.ToXml()));
        }

        public XElement Visit(CoerceAOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("coerce_a");
        }

        public XElement Visit(CoerceBOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("coerce_b");
        }

        public XElement Visit(CoerceDOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("coerce_d");
        }

        public XElement Visit(CoerceIOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("coerce_i");
        }

        public XElement Visit(CoerceOOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("coerce_o");
        }

        public XElement Visit(CoerceSOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("coerce_s");
        }

        public XElement Visit(CoerceUOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("coerce_u");
        }

        public XElement Visit(ConstructOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("construct").AddArgsCount(opcode.ArgCount);
        }

        public XElement Visit(ConstructPropOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("constructprop").AddName(opcode.Name).AddArgsCount(opcode.ArgCount);
        }

        public XElement Visit(ConstructSuperOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("constructsuper").AddArgsCount(opcode.ArgCount);
        }

        public XElement Visit(ConvertBOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("convert_b");
        }

        public XElement Visit(ConvertDOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("convert_d");
        }

        public XElement Visit(ConvertIOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("convert_i");
        }

        public XElement Visit(ConvertOOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new NotImplementedException();
        }

        public XElement Visit(ConvertSOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("convert_s");
        }

        public XElement Visit(ConvertUOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("convert_u");
        }

        public XElement Visit(DebugOpcode opcode, AbcMethodBodyInstruction arg) {
            var res = new XElement("debug",
                new XAttribute("type", opcode.DebugType),
                new XAttribute("name", opcode.Name)).AddRegister(opcode.Register);
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
            throw new NotImplementedException();
        }

        public XElement Visit(DecLocalIOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new NotImplementedException();
        }

        public XElement Visit(DecrementOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("decrement");
        }

        public XElement Visit(DecrementIOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("decrement_i");
        }

        public XElement Visit(DeletePropertyOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("deleteproperty").AddName(opcode.Name);
        }

        public XElement Visit(DivideOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("divide");
        }

        public XElement Visit(DupOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("dup");
        }

        public XElement Visit(DxnsOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new NotImplementedException();
        }

        public XElement Visit(DxnsLateOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("dxnslate");
        }

        public XElement Visit(EqualsOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("equals");
        }

        public XElement Visit(EscXAttrOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new NotImplementedException();
        }

        public XElement Visit(EscXElemOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new NotImplementedException();
        }

        public XElement Visit(FindDefinitionOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new NotImplementedException();
        }

        public XElement Visit(FindPropertyOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("findproperty").AddName(opcode.Name);
        }

        public XElement Visit(FindPropStrictOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("findpropstrict").AddName(opcode.Name);
        }

        public XElement Visit(GetDescendantsOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("getdescendants").AddName(opcode.Name);
        }

        public XElement Visit(GetGlobalScopeOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("getglobalscope");
        }

        public XElement Visit(GetGlobalSlotOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("getglobalslot").AddSlotIndex(opcode.SlotIndex);
        }

        public XElement Visit(GetLexOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("getlex").AddName(opcode.Name);
        }

        public XElement Visit(GetLocalOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("getlocal").AddRegister(opcode.Register);
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
            return new XElement("getproperty").AddName(opcode.Name);
        }

        public XElement Visit(GetScopeObjectOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("getscopeobject", new XAttribute("index", opcode.Index));
        }

        public XElement Visit(GetSlotOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("getslot").AddSlotIndex(opcode.SlotIndex);
        }

        public XElement Visit(GetSuperOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("getsuper").AddName(opcode.Name);
        }

        public XElement Visit(GreaterEqualsOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("greaterequals");
        }

        public XElement Visit(GreaterThanOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("greaterthan");
        }

        public XElement Visit(HasNextOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("hasnext");
        }

        public XElement Visit(HasNext2Opcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("hasnext2", new XAttribute("objectReg", opcode.ObjectReg), new XAttribute("indexReg", opcode.IndexReg));
        }

        public XElement Visit(IfeqOpcode opcode, AbcMethodBodyInstruction arg) {
            return Branch("ifeq", opcode, arg);
        }

        public XElement Visit(IfFalseOpcode opcode, AbcMethodBodyInstruction arg) {
            return Branch("iffalse", opcode, arg);
        }

        public XElement Visit(IfgeOpcode opcode, AbcMethodBodyInstruction arg) {
            return Branch("ifge", opcode, arg);
        }

        public XElement Visit(IfgtOpcode opcode, AbcMethodBodyInstruction arg) {
            return Branch("ifgt", opcode, arg);
        }

        public XElement Visit(IfleOpcode opcode, AbcMethodBodyInstruction arg) {
            return Branch("ifle", opcode, arg);
        }

        public XElement Visit(IfltOpcode opcode, AbcMethodBodyInstruction arg) {
            return Branch("iflt", opcode, arg);
        }

        public XElement Visit(IfneOpcode opcode, AbcMethodBodyInstruction arg) {
            return Branch("ifne", opcode, arg);
        }

        public XElement Visit(IfngeOpcode opcode, AbcMethodBodyInstruction arg) {
            return Branch("ifnge", opcode, arg);
        }

        public XElement Visit(IfngtOpcode opcode, AbcMethodBodyInstruction arg) {
            return Branch("ifngt", opcode, arg);
        }

        public XElement Visit(IfnleOpcode opcode, AbcMethodBodyInstruction arg) {
            return Branch("ifnle", opcode, arg);
        }

        public XElement Visit(IfnltOpcode opcode, AbcMethodBodyInstruction arg) {
            return Branch("ifnlt", opcode, arg);
        }

        public XElement Visit(IfStrictEqOpcode opcode, AbcMethodBodyInstruction arg) {
            return Branch("ifstricteq", opcode, arg);
        }

        public XElement Visit(IfStrictNeOpcode opcode, AbcMethodBodyInstruction arg) {
            return Branch("ifstrictne", opcode, arg);
        }

        public XElement Visit(IfTrueOpcode opcode, AbcMethodBodyInstruction arg) {
            return Branch("iftrue", opcode, arg);
        }

        public XElement Visit(InOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("in");
        }

        public XElement Visit(IncLocalOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("inclocal").AddRegister(opcode.Register);
        }

        public XElement Visit(IncLocalIOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("inclocal_i").AddRegister(opcode.Register);
        }

        public XElement Visit(IncrementOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("increment");
        }

        public XElement Visit(IncrementIOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("increment_i");
        }

        public XElement Visit(InitPropertyOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("initproperty").AddName(opcode.Name);
        }

        public XElement Visit(InstanceOfOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("instanceof");
        }

        public XElement Visit(IsTypeOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("istype").AddName(opcode.Name);
        }

        public XElement Visit(IsTypeLateOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("istypelate");
        }

        public XElement Visit(JumpOpcode opcode, AbcMethodBodyInstruction arg) {
            return Branch("jump", opcode, arg);
        }

        public XElement Visit(KillOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("kill").AddRegister(opcode.Register);
        }

        public XElement Visit(LabelOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("label");
        }

        public XElement Visit(LessEqualsOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("lessequals");
        }

        public XElement Visit(LessThanOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("lessthan");
        }

        public XElement Visit(Lf32Opcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("lf32");
        }

        public XElement Visit(Lf64Opcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("lf64");
        }

        public XElement Visit(Li8Opcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("li8");
        }

        public XElement Visit(Li16Opcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("li16");
        }

        public XElement Visit(Li32Opcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("li32");
        }

        public XElement Visit(LookupSwitchOpcode opcode, AbcMethodBodyInstruction arg) {
            var res = new XElement("lookupswitch");
            res.Add(new XAttribute("default", FormatRelativeOffset(opcode.DefaultRelativeOffset, arg)));
            for (var i = 0; i < opcode.CasesRelativeOffset.Count; i++) {
                res.Add(new XElement("case", new XAttribute("index", i), new XAttribute("target", FormatRelativeOffset(opcode.CasesRelativeOffset[i], arg))));
            }
            return res;
        }

        public XElement Visit(LShiftOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("lshift");
        }

        public XElement Visit(ModuloOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("modulo");
        }

        public XElement Visit(MultiplyOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("multiply");
        }

        public XElement Visit(MultiplyIOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("multiply_i");
        }

        public XElement Visit(NegateOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("negate");
        }

        public XElement Visit(NegateIOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("negate_i");
        }

        public XElement Visit(NewActivationOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("newactivation");
        }

        public XElement Visit(NewArrayOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("newarray").AddArgsCount(opcode.ArgCount);
        }

        public XElement Visit(NewCatchOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("newcatch", new XAttribute("exceptionBlock", opcode.ExceptionBlockIndex));
        }

        public XElement Visit(NewClassOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("newclass", new XAttribute("type", GetClassReference(opcode.BaseType)));
        }

        public XElement Visit(NewFunctionOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("newfunction").AddMethod(opcode.Method);
        }

        public XElement Visit(NewObjectOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("newobject").AddArgsCount(opcode.ArgCount);
        }

        public XElement Visit(NextNameOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("nextname");
        }

        public XElement Visit(NextValueOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("nextvalue");
        }

        public XElement Visit(NopOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("nop");
        }

        public XElement Visit(NotOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("not");
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
            return new XElement("pushdouble", new XAttribute("value", CommonFormatter.Format(opcode.Value)));
        }

        public XElement Visit(PushFalseOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("pushfalse");
        }

        public XElement Visit(PushIntOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("pushint", new XAttribute("value", opcode.Value));
        }

        public XElement Visit(PushNamespaceOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new NotImplementedException();
        }

        public XElement Visit(PushNanOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("pushnan");
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
            return new XElement("pushuint", new XAttribute("value", opcode.Value));
        }

        public XElement Visit(PushUndefinedOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("pushundefined");
        }

        public XElement Visit(PushWithOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("pushwith");
        }

        public XElement Visit(ReturnValueOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("returnvalue");
        }

        public XElement Visit(ReturnVoidOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("returnvoid");
        }

        public XElement Visit(RShiftOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("rshift");
        }

        public XElement Visit(SetGlobalSlotOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("setglobalslope").AddSlotIndex(opcode.SlotIndex);
        }

        public XElement Visit(SetLocalOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("setlocal").AddRegister(opcode.Register);
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
            return new XElement("setproperty").AddName(opcode.Name);
        }

        public XElement Visit(SetSlotOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("setslot").AddSlotIndex(opcode.SlotIndex);
        }

        public XElement Visit(SetSuperOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("setsuper").AddName(opcode.Name);
        }

        public XElement Visit(Sf32Opcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("sf32");
        }

        public XElement Visit(Sf64Opcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("sf64");
        }

        public XElement Visit(Si8Opcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("si8");
        }

        public XElement Visit(Si16Opcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("si16");
        }

        public XElement Visit(Si32Opcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("si32");
        }

        public XElement Visit(StrictEqualsOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("strictequals");
        }

        public XElement Visit(SubtractOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("subtract");
        }

        public XElement Visit(SubtractIOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("subtract_i");
        }

        public XElement Visit(SwapOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("swap");
        }

        public XElement Visit(ThrowOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("throw");
        }

        public XElement Visit(TimestampOpcode opcode, AbcMethodBodyInstruction arg) {
            throw new NotImplementedException();
        }

        public XElement Visit(TypeOfOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("typeof");
        }

        public XElement Visit(UrshiftOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("urshift");
        }

        public XElement Visit(UnknownOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement("unknown", new XAttribute("code", opcode.Code));
        }

        private XElement Branch(string name, BaseAvm2BranchOpcode opcode, AbcMethodBodyInstruction arg) {
            return new XElement(name, new XAttribute("target", FormatRelativeOffset(opcode.RelativeOffset + 4, arg)));
        }

        private string FormatRelativeOffset(int offset, AbcMethodBodyInstruction instruction) {
            var target = offset + instruction.Offset;
            return _labelFormatter((uint)target);
        }


        private string GetClassReference(AbcClass baseType) {
            return baseType.Instance.Name.ToXml();
        }

    }

}
