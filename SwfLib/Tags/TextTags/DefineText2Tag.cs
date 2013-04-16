using System.Collections.Generic;
using Code.SwfLib.Text;
using SwfLib.Tags;
using SwfLib.Text;

namespace Code.SwfLib.Tags.TextTags {
    public class DefineText2Tag : DefineTextBaseTag {

        public readonly IList<TextRecordRGBA> TextRecords = new List<TextRecordRGBA>();

        public override SwfTagType TagType {
            get { return SwfTagType.DefineText2; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
