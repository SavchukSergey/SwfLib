using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.Fonts {
    public class ZoneRecord {

        public ZoneData[] Data;

        public ZoneRecordFlags Flags;

        public byte Reserved;

        public bool ZoneX {
            get {
                return (Flags & ZoneRecordFlags.ZoneX) != 0;
            }
            set {
                if (value) Flags |= ZoneRecordFlags.ZoneX;
                else Flags &= ~ZoneRecordFlags.ZoneX;
            }
        }

        public bool ZoneY {
            get {
                return (Flags & ZoneRecordFlags.ZoneY) != 0;
            }
            set {
                if (value) Flags |= ZoneRecordFlags.ZoneY;
                else Flags &= ~ZoneRecordFlags.ZoneY;
            }
        }

    }
}
