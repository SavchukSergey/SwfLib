using System.Collections.Generic;

namespace Code.SwfLib.Tags.ShapeTags {
    public class DefineShape2Tag : ShapeBaseTag {

        public readonly IList<LineStyleRGB> LineStyles = new List<LineStyleRGB>();

        public readonly IList<FillStyleRGB> FillStyles = new List<FillStyleRGB>();

        public override SwfTagType TagType {
            get { return SwfTagType.DefineShape2; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}