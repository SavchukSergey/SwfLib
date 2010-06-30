using System.Collections.Generic;

namespace Code.SwfLib.Data
{
    public struct ZoneRecord
    {

        private IList<ZoneData> _zoneData;

        public IList<ZoneData> ZoneData
        {
            get
            {
                if (_zoneData == null)
                {
                    _zoneData = new List<ZoneData>();
                }
                return _zoneData;
            }
        }

        public byte Reserved;

        public bool ZoneMaskY;

        public bool ZoneMaskX;

    }
}
