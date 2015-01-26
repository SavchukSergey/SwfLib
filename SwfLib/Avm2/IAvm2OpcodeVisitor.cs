using SwfLib.Avm2.Opcodes;

namespace SwfLib.Avm2 {
    public interface IAvm2OpcodeVisitor<TArg, TResult> {

        TResult Visit(BaseAvm2Opcode action, TArg arg);

    }
}
