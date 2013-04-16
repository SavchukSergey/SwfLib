using System.Collections.Generic;
using SwfLib.Shapes.FillStyles;
using SwfLib.Shapes.LineStyles;
using SwfLib.Shapes.Records;

namespace SwfLib.Tags.ShapeTags {
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