using System.Collections.Generic;
using SwfLib.Shapes.FillStyles;
using SwfLib.Shapes.LineStyles;

namespace SwfLib.Shapes.Records {
    public class StyleChangeShapeRecordRGBA : StyleChangeShapeRecord, IShapeRecordRGBA {

        public readonly IList<FillStyleRGBA> FillStyles = new List<FillStyleRGBA>();

        public readonly IList<LineStyleRGBA> LineStyles = new List<LineStyleRGBA>();

        public override TResult AcceptVisitor<TArg, TResult>(IShapeRecordVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
