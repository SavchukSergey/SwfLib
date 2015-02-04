using SwfLib.Avm2.Data;
using SwfLib.Avm2.Opcodes;
using SwfLib.Avm2.Opcodes.Arithmetics;
using SwfLib.Avm2.Opcodes.Branching;
using SwfLib.Avm2.Opcodes.ByteArray;
using SwfLib.Avm2.Opcodes.Debug;
using SwfLib.Avm2.Opcodes.Stack;
using SwfLib.Avm2.Opcodes.TypeCasting;
using SwfLib.Avm2.Opcodes.Xml;

namespace SwfLib.Avm2 {
    public class Avm2OpcodeReader : IAvm2OpcodeVisitor<AbcDataReader, BaseAvm2Opcode> {
        private readonly AbcFileLoader _context;

        public Avm2OpcodeReader(AbcFileLoader context) {
            _context = context;
        }

        public BaseAvm2Opcode Visit(AddOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(AddIOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(AsTypeOpcode opcode, AbcDataReader arg) {
            opcode.Name = _context.GetMultiname(arg.ReadU30(), AbcMultiname.Any);
            return opcode;
        }

        public BaseAvm2Opcode Visit(AsTypeLateOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(BitAndOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(BitNotOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(BitOrOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(BitXorOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(BreakpointOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(BreakpointLineOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(CallOpcode opcode, AbcDataReader arg) {
            opcode.ArgCount = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(CallMethodOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(CallPropertyOpcode opcode, AbcDataReader arg) {
            opcode.Name = _context.GetMultiname(arg.ReadU30(), null);
            opcode.ArgCount = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(CallPropLexOpcode opcode, AbcDataReader arg) {
            opcode.Name = _context.GetMultiname(arg.ReadU30(), null);
            opcode.ArgCount = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(CallPropVoidOpcode opcode, AbcDataReader arg) {
            opcode.Name = _context.GetMultiname(arg.ReadU30(), null);
            opcode.ArgCount = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(CallStaticOpcode opcode, AbcDataReader arg) {
            opcode.Method = _context.GetMethod(arg.ReadU30());
            opcode.ArgCount = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(CallSuperOpcode opcode, AbcDataReader arg) {
            opcode.Name = _context.GetMultiname(arg.ReadU30(), null);
            opcode.ArgCount = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(CallSuperVoidOpcode opcode, AbcDataReader arg) {
            opcode.Name = _context.GetMultiname(arg.ReadU30(), null);
            opcode.ArgCount = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(CheckFilterOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(CoerceOpcode opcode, AbcDataReader arg) {
            opcode.Type = _context.GetMultiname(arg.ReadU30(), AbcMultiname.Any);
            return opcode;
        }

        public BaseAvm2Opcode Visit(CoerceAOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(CoerceBOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(CoerceDOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(CoerceIOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(CoerceOOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(CoerceSOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(CoerceUOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(ConstructOpcode opcode, AbcDataReader arg) {
            opcode.ArgCount = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(ConstructPropOpcode opcode, AbcDataReader arg) {
            opcode.Name = _context.GetMultiname(arg.ReadU30(), null);
            opcode.ArgCount = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(ConstructSuperOpcode opcode, AbcDataReader arg) {
            opcode.ArgCount = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(ConvertBOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(ConvertDOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(ConvertIOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(ConvertOOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(ConvertSOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(ConvertUOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(DebugOpcode opcode, AbcDataReader arg) {
            opcode.DebugType = arg.ReadU8();
            opcode.Name = _context.GetString(arg.ReadU30());
            opcode.Register = arg.ReadU8();
            opcode.Extra = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(DebugFileOpcode opcode, AbcDataReader arg) {
            opcode.FileName = _context.GetString(arg.ReadU30());
            return opcode;
        }

        public BaseAvm2Opcode Visit(DebugLineOpcode opcode, AbcDataReader arg) {
            opcode.LineNum = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(DecLocalOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(DecLocalIOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(DecrementOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(DecrementIOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(DeletePropertyOpcode opcode, AbcDataReader arg) {
            opcode.Name = _context.GetMultiname(arg.ReadU30(), null);
            return opcode;
        }

        public BaseAvm2Opcode Visit(DivideOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(DupOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(DxnsOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(DxnsLateOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(EqualsOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(EscXAttrOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(EscXElemOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(FindDefinitionOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(FindPropertyOpcode opcode, AbcDataReader arg) {
            opcode.Name = _context.GetMultiname(arg.ReadU30(), null);
            return opcode;
        }

        public BaseAvm2Opcode Visit(FindPropStrictOpcode opcode, AbcDataReader arg) {
            opcode.Name = _context.GetMultiname(arg.ReadU30(), null);
            return opcode;
        }

        public BaseAvm2Opcode Visit(GetDescendantsOpcode opcode, AbcDataReader arg) {
            opcode.Name = _context.GetMultiname(arg.ReadU30(), null);
            return opcode;
        }

        public BaseAvm2Opcode Visit(GetGlobalScopeOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(GetGlobalSlotOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(GetLexOpcode opcode, AbcDataReader arg) {
            opcode.Name = _context.GetMultiname(arg.ReadU30(), null);
            return opcode;
        }

        public BaseAvm2Opcode Visit(GetLocalOpcode opcode, AbcDataReader arg) {
            opcode.Register = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(GetLocal0Opcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(GetLocal1Opcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(GetLocal2Opcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(GetLocal3Opcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(GetPropertyOpcode opcode, AbcDataReader arg) {
            opcode.Name = _context.GetMultiname(arg.ReadU30(), null);
            return opcode;
        }

        public BaseAvm2Opcode Visit(GetScopeObjectOpcode opcode, AbcDataReader arg) {
            opcode.Index = arg.ReadU8();
            return opcode;
        }

        public BaseAvm2Opcode Visit(GetSlotOpcode opcode, AbcDataReader arg) {
            opcode.Index = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(GetSuperOpcode opcode, AbcDataReader arg) {
            opcode.Name = _context.GetMultiname(arg.ReadU30(), null);
            return opcode;
        }

        public BaseAvm2Opcode Visit(GreaterEqualsOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(GreaterThanOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(HasNextOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(HasNext2Opcode opcode, AbcDataReader arg) {
            opcode.ObjectReg = arg.ReadU30();
            opcode.IndexReg = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(IfeqOpcode opcode, AbcDataReader arg) {
            return Branch(opcode, arg);
        }

        public BaseAvm2Opcode Visit(IfFalseOpcode opcode, AbcDataReader arg) {
            return Branch(opcode, arg);
        }

        public BaseAvm2Opcode Visit(IfgeOpcode opcode, AbcDataReader arg) {
            return Branch(opcode, arg);
        }

        public BaseAvm2Opcode Visit(IfgtOpcode opcode, AbcDataReader arg) {
            return Branch(opcode, arg);
        }

        public BaseAvm2Opcode Visit(IfleOpcode opcode, AbcDataReader arg) {
            return Branch(opcode, arg);
        }

        public BaseAvm2Opcode Visit(IfltOpcode opcode, AbcDataReader arg) {
            return Branch(opcode, arg);
        }

        public BaseAvm2Opcode Visit(IfneOpcode opcode, AbcDataReader arg) {
            return Branch(opcode, arg);
        }

        public BaseAvm2Opcode Visit(IfngeOpcode opcode, AbcDataReader arg) {
            return Branch(opcode, arg);
        }

        public BaseAvm2Opcode Visit(IfngtOpcode opcode, AbcDataReader arg) {
            return Branch(opcode, arg);
        }

        public BaseAvm2Opcode Visit(IfnleOpcode opcode, AbcDataReader arg) {
            return Branch(opcode, arg);
        }

        public BaseAvm2Opcode Visit(IfnltOpcode opcode, AbcDataReader arg) {
            return Branch(opcode, arg);
        }

        public BaseAvm2Opcode Visit(IfStrictEqOpcode opcode, AbcDataReader arg) {
            return Branch(opcode, arg);
        }

        public BaseAvm2Opcode Visit(IfStrictNeOpcode opcode, AbcDataReader arg) {
            return Branch(opcode, arg);
        }

        public BaseAvm2Opcode Visit(IfTrueOpcode opcode, AbcDataReader arg) {
            return Branch(opcode, arg);
        }

        public BaseAvm2Opcode Visit(InOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(IncLocalOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(IncLocalIOpcode opcode, AbcDataReader arg) {
            opcode.Register = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(IncrementOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(IncrementIOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(InitPropertyOpcode opcode, AbcDataReader arg) {
            opcode.Name = _context.GetMultiname(arg.ReadU30(), null);
            return opcode;
        }

        public BaseAvm2Opcode Visit(InstanceOfOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(IsTypeOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(IsTypeLateOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(JumpOpcode opcode, AbcDataReader arg) {
            return Branch(opcode, arg);
        }

        public BaseAvm2Opcode Visit(KillOpcode opcode, AbcDataReader arg) {
            opcode.Register = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(LabelOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(LessEqualsOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(LessThanOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(Lf32Opcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(Lf64Opcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(Li8Opcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(Li16Opcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(Li32Opcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(LookupSwitchOpcode opcode, AbcDataReader arg) {
            opcode.DefaultRelativeOffset = arg.ReadS24();
            var cases = arg.ReadU30();
            for (var i = 0; i <= cases; i++) {
                opcode.CasesRelativeOffset.Add(arg.ReadS24());
            }
            return opcode;
        }

        public BaseAvm2Opcode Visit(LShiftOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(ModuloOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(MultiplyOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(MultiplyIOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(NegateOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(NegateIOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(NewActivationOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(NewArrayOpcode opcode, AbcDataReader arg) {
            opcode.ArgCount = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(NewCatchOpcode opcode, AbcDataReader arg) {
            opcode.ExceptionBlockIndex = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(NewClassOpcode opcode, AbcDataReader arg) {
            opcode.BaseType = _context.GetClass(arg.ReadU30());
            return opcode;
        }

        public BaseAvm2Opcode Visit(NewFunctionOpcode opcode, AbcDataReader arg) {
            opcode.Method = _context.GetMethod(arg.ReadU30());
            return opcode;
        }

        public BaseAvm2Opcode Visit(NewObjectOpcode opcode, AbcDataReader arg) {
            opcode.ArgCount = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(NextNameOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(NextValueOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(NopOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(NotOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(PopOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(PopScopeOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(PushByteOpcode opcode, AbcDataReader arg) {
            opcode.Value = arg.ReadU8();
            return opcode;
        }

        public BaseAvm2Opcode Visit(PushDoubleOpcode opcode, AbcDataReader arg) {
            opcode.Value = _context.GetDouble(arg.ReadU30());
            return opcode;
        }

        public BaseAvm2Opcode Visit(PushFalseOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(PushIntOpcode opcode, AbcDataReader arg) {
            opcode.Value = _context.GetInteger(arg.ReadU30());
            return opcode;
        }

        public BaseAvm2Opcode Visit(PushNamespaceOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(PushNanOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(PushNullOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(PushScopeOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(PushShortOpcode opcode, AbcDataReader arg) {
            opcode.Value = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(PushStringOpcode opcode, AbcDataReader arg) {
            opcode.Value = _context.GetString(arg.ReadU30());
            return opcode;
        }

        public BaseAvm2Opcode Visit(PushTrueOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(PushUIntOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(PushUndefinedOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(PushWithOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(ReturnValueOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(ReturnVoidOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(RShiftOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(SetGlobalSlotOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(SetLocalOpcode opcode, AbcDataReader arg) {
            opcode.Register = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(SetLocal0Opcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(SetLocal1Opcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(SetLocal2Opcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(SetLocal3Opcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(SetPropertyOpcode opcode, AbcDataReader arg) {
            opcode.Name = _context.GetMultiname(arg.ReadU30(), null);
            return opcode;
        }

        public BaseAvm2Opcode Visit(SetSlotOpcode opcode, AbcDataReader arg) {
            opcode.Index = arg.ReadU30();
            return opcode;
        }

        public BaseAvm2Opcode Visit(SetSuperOpcode opcode, AbcDataReader arg) {
            opcode.Name = _context.GetMultiname(arg.ReadU30(), null);
            return opcode;
        }

        public BaseAvm2Opcode Visit(Sf32Opcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(Sf64Opcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(Si8Opcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(Si16Opcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(Si32Opcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(StrictEqualsOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(SubtractOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(SubtractIOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(SwapOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(ThrowOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(TimestampOpcode opcode, AbcDataReader arg) {
            throw new System.NotImplementedException();
        }

        public BaseAvm2Opcode Visit(TypeOfOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(UrshiftOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        public BaseAvm2Opcode Visit(UnknownOpcode opcode, AbcDataReader arg) {
            return opcode;
        }

        private BaseAvm2BranchOpcode Branch(BaseAvm2BranchOpcode opcode, AbcDataReader arg) {
            opcode.RelativeOffset = arg.ReadS24();
            return opcode;
        }

    }
}
