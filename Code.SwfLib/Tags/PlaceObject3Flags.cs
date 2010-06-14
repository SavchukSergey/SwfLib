using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.SwfLib.Tags
{
    [Flags]
    public enum PlaceObject3Flags : byte
    {
        Reserved15 = 0x80,
        Reserved14 = 0x40,
        Reserved13 = 0x20,
        Reserved12 = 0x10,
        Reserved11 = 0x08,
        BitmapCaching = 0x04,
        BlendMode = 0x02,
        HasFilters = 0x01
    }

}
