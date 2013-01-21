using System.Collections.Generic;
using Code.SwfLib.Data;
using Code.SwfLib.Data.Text;

namespace Code.SwfLib.Tags.TextTags {
    public class DefineTextTag : TextBaseTag {

        public ushort CharacterID;

        public SwfRect TextBounds;

        public SwfMatrix TextMatrix;

        public readonly IList<TextRecord> TextRecords = new List<TextRecord>();

        public override SwfTagType TagType {
            get { return SwfTagType.DefineText; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
