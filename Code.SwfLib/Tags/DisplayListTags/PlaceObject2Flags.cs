using System;

namespace Code.SwfLib.Tags.DisplayListTags
{
    [Flags]
    public enum PlaceObject2Flags : byte
    {
        HasActions = 0x80,
        HasClippingDepth = 0x40,
        HasName = 0x20,
        HasMorphPosition = 0x10,
        HasColorTransform = 0x08,
        HasMatrix = 0x04,
        HasIdRef = 0x02,
        HasMove = 0x01
    }
}