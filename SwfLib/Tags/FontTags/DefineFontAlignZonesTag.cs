using System.Collections.Generic;
using Code.SwfLib.Fonts;
using SwfLib.Tags;

namespace Code.SwfLib.Tags.FontTags {
    public class DefineFontAlignZonesTag : FontBaseTag {

        public byte Flags {
            get { return (byte)(((byte)CsmTableHint & 0x03) | (Reserved << 2)); }
            set {
                CsmTableHint = (CSMTableHint)(value & 0x3);
                Reserved = (byte)(value >> 2);
            }
        }

        public CSMTableHint CsmTableHint;

        public byte Reserved;

        public readonly IList<ZoneRecord> ZoneTable = new List<ZoneRecord>();

        public override SwfTagType TagType {
            get { return SwfTagType.DefineFontAlignZones; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}