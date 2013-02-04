using System.Collections.Generic;
using Code.SwfLib.Text;

namespace Code.SwfLib.Tags.TextTags {
    public class DefineTextTag : DefineTextBaseTag {

        public readonly IList<TextRecordRGB> TextRecords = new List<TextRecordRGB>();

        public override SwfTagType TagType {
            get { return SwfTagType.DefineText; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
