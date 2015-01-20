namespace SwfLib.Avm2 {
    public enum AsMethodFlags : byte {
        NEED_ARGUMENTS = 0x01,
        NEED_ACTIVATION = 0x02,
        NEED_REST = 0x04,
        HAS_OPTIONAL = 0x08,
        SET_DXNS = 0x40,
        HAS_PARAM_NAMES = 0x80,
    }
}
