using System.Collections.Generic;
using Code.SwfLib.Data;
using Code.SwfLib.Data.Text;

namespace Code.SwfLib.Tags {
    public class DefineTextTag : SwfTagBase {

        public ushort CharacterID;

        public SwfRect TextBounds;

        public SwfMatrix TextMatrix;

        public readonly IList<TextRecord> TextRecords = new List<TextRecord>();

        public override SwfTagType TagType {
            get { return SwfTagType.DefineText; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
