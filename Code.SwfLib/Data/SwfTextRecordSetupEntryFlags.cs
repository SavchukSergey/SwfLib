using System;

namespace Code.SwfLib.Data
{
    [Flags]
    public enum SwfTextRecordSetupEntryFlags : byte
    {

        IsSetup = 0x80,
        Reserved6 = 0x40,
        Reserved5 = 0x20,
        Reserved4 = 0x10,
        HasFont = 0x08,
        HasColor = 0x04,
        HasMoveY = 0x02,
        HasMoveX = 0x01
    }
}
