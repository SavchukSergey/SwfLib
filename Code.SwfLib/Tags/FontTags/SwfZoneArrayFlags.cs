using System;

namespace Code.SwfLib.Tags.FontTags {
    [Flags]
    public enum SwfZoneArrayFlags : byte {

        ZoneY = 0x40,
        ZoneX = 0x80,

    }
}
