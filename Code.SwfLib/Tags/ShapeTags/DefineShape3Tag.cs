using System.Collections.Generic;
using Code.SwfLib.Shapes.FillStyles;
using Code.SwfLib.Shapes.LineStyles;
using Code.SwfLib.Shapes.Records;

namespace Code.SwfLib.Tags.ShapeTags {
    public class DefineShape3Tag : ShapeBaseTag {

        public readonly IList<FillStyleRGBA> FillStyles = new List<FillStyleRGBA>();

        public readonly IList<LineStyleRGBA> LineStyles = new List<LineStyleRGBA>();

        public readonly IList<IShapeRecordRGBA> ShapeRecords = new List<IShapeRecordRGBA>();

        public override SwfTagType TagType {
            get { return SwfTagType.DefineShape3; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}