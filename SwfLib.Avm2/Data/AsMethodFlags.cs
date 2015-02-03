using System;

namespace SwfLib.Avm2.Data {
    [Flags]
    public enum AsMethodFlags : byte {
        NeedArguments = 0x01,
        NeedActivation = 0x02,
        NeedRest = 0x04,
        HasOptional = 0x08,
        IgnoreRest = 0x10,
        Native = 0x20,
        SetDxns = 0x40,
        HasParamNames = 0x80,
    }
}
