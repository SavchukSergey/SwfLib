namespace SwfLib.Avm2.Data {
    public enum AsMethodFlags : byte {
        NeedArguments = 0x01,
        NeedActivation = 0x02,
        NeedRest = 0x04,
        HasOptional = 0x08,
        SetDxns = 0x40,
        HasParamNames = 0x80,
    }
}
