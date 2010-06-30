using System.Collections.Generic;
using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.FontTags
{
    public class DefineFontAlignZonesTag : SwfTagBase
    {

        public ushort FontID;

        public byte CSMTableHint;

        public byte Reserved;

        public readonly IList<ZoneRecord> ZoneTable = new List<ZoneRecord>();

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}