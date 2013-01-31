﻿using System.Collections.Generic;

namespace Code.SwfLib.Fonts {
    public class ZoneRecord {

        public readonly IList<ZoneData> Data = new List<ZoneData>();

        public byte Reserved;

        public bool ZoneX;

        public bool ZoneY;

    }
}
