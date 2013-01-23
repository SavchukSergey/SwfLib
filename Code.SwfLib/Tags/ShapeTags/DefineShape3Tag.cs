using System.Collections.Generic;
using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.ShapeTags {
    public class DefineShape3Tag : ShapeBaseTag {

        public readonly ShapeWithStyle1 Shapes = new ShapeWithStyle1();

        public readonly IList<FillStyleRGBA> FillStyles = new List<FillStyleRGBA>();

        public readonly IList<LineStyleRGBA> LineStyles = new List<LineStyleRGBA>();

        public override SwfTagType TagType {
            get { return SwfTagType.DefineShape3; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}