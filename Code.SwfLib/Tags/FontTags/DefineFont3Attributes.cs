using System;

namespace Code.SwfLib.Tags.FontTags {
    [Flags]
    public enum DefineFont3Attributes : byte {

        HasLayout = 0x80,
        ShiftJIS = 0x40,
        SmallText = 0x20,
        ANSI = 0x10,
        WideOffsets = 0x08,
        WideCodes = 0x04,
        Italics = 0x02,
        Bold = 0x01

    }
}
