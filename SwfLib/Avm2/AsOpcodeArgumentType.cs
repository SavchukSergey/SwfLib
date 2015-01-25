namespace SwfLib.Avm2 {
    public enum AsOpcodeArgumentType {
        Unknown,

        ByteLiteral,
        UByteLiteral,
        IntLiteral,
        UIntLiteral,

        Int,
        UInt,
        Double,
        String,
        Namespace,
        Multiname,
        Class,
        Method,

        JumpTarget,
        SwitchDefaultTarget,
        SwitchTargets,
    }
}
