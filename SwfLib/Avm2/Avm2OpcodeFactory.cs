using SwfLib.Avm2.Opcodes;
using SwfLib.Avm2.Opcodes.Arithmetics;
using SwfLib.Avm2.Opcodes.Branching;
using SwfLib.Avm2.Opcodes.Debug;
using SwfLib.Avm2.Opcodes.Stack;
using SwfLib.Avm2.Opcodes.TypeCasting;
using SwfLib.Avm2.Opcodes.Xml;

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
                case Avm2Opcode.ConvertD: return new ConvertDOpcode();
                case Avm2Opcode.ConvertI: return new ConvertIOpcode();
                case Avm2Opcode.ConvertO: return new ConvertOOpcode();
                case Avm2Opcode.ConvertS: return new ConvertSOpcode();
                case Avm2Opcode.ConvertU: return new ConvertUOpcode();
                case Avm2Opcode.Debug: return new DebugOpcode();
                case Avm2Opcode.DebugFile: return new DebugFileOpcode();
                case Avm2Opcode.DebugLine: return new DebugLineOpcode();
                case Avm2Opcode.DecLocal: return new DecLocalOpcode();
                case Avm2Opcode.DecLocalI: return new DecLocalIOpcode();
                case Avm2Opcode.Decrement: return new DecrementOpcode();
                case Avm2Opcode.DecrementI: return new DecrementIOpcode();
                case Avm2Opcode.DeleteProperty: return new DeletePropertyOpcode();
                case Avm2Opcode.Divide: return new DivideOpcode();
                case Avm2Opcode.Dup: return new DupOpcode();
                case Avm2Opcode.Dxns: return new DxnsOpcode();
                case Avm2Opcode.DxnsLate: return new DxnsLateOpcode();
                case Avm2Opcode.Equal: return new EqualsOpcode();
                case Avm2Opcode.EscXAttr: return new EscXAttrOpcode();
                case Avm2Opcode.EscXElem: return new EscXElemOpcode();
                case Avm2Opcode.FindProperty: return new FindPropertyOpcode();
                case Avm2Opcode.FindPropStrict: return new FindPropStrictOpcode();
                case Avm2Opcode.GetDescendants: return new GetDescendantsOpcode();
                case Avm2Opcode.GetGlobalScope: return new GetGlobalScopeOpcode();
                case Avm2Opcode.GetGlobalSlot: return new GetGlobalSlotOpcode();
                case Avm2Opcode.GetLex: return new GetLexOpcode();
                case Avm2Opcode.GetLocal: return new GetLocalOpcode();
                case Avm2Opcode.GetLocal0: return new GetLocal0Opcode();
                case Avm2Opcode.GteLocal1: return new GetLocal1Opcode();
                case Avm2Opcode.GetLocal2: return new GetLocal2Opcode();
                case Avm2Opcode.GetLocal3: return new GetLocal3Opcode();
                case Avm2Opcode.GetProperty: return new GetPropertyOpcode();
                case Avm2Opcode.GetScopeObject: return new GetScopeObjectOpcode();
                case Avm2Opcode.GetSlot: return new GetSlotOpcode();
                case Avm2Opcode.GetSuper: return new GetSuperOpcode();
                case Avm2Opcode.GreaterEquals: return new GreaterEqualsOpcode();
                case Avm2Opcode.GreaterThan: return new GreaterThanOpcode();
                case Avm2Opcode.HasNext: return new HasNextOpcode();
                case Avm2Opcode.HasNext2: return new HasNext2Opcode();
                case Avm2Opcode.IfEq: return new IfeqOpcode();
                case Avm2Opcode.IfFalse: return new IfFalseOpcode();
                case Avm2Opcode.IfGe: return new IfgeOpcode();
                case Avm2Opcode.IfGt: return new IfgtOpcode();

                /*
ifle
iflt
ifne
ifnge
ifngt
ifnle
ifnlt
ifstricteq
ifstrictne
iftrue
in
inclocal
inclocal_i
increment
increment_i
initproperty
instanceof
istype
istypelate
jump
kill
label
lessequals
lessthan
lf32
lf64
li8
li16
li32
lookupswitch
lshift
modulo
multiply
multiply_i
negate
negate_i
newactivation
newarray
newcatch
newclass
newfunction
newobject
nextname
nextvalue
nop
not
pop
popscope
pushbyte
pushdouble
pushfalse
pushint
pushnamespace
pushnan
pushnull
pushscope
pushshort
pushstring
pushtrue
pushuint
pushundefined
pushwith
returnvalue
returnvoid
rshift
setglobalslot
setlocal
setlocal_n
setproperty
setslot
setsuper
sf32
sf64
si8
si16
si32
strictequals
subtract
subtract_i
swap
sxi_1
sxi_8
sxi_16
throw
typeof
urshift
                 */
                default: return new UnknownOpcode();
            }
        }
    }
}
