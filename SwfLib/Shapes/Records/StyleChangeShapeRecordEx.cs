using System.Collections.Generic;
using SwfLib.Shapes.FillStyles;
using SwfLib.Shapes.LineStyles;

namespace SwfLib.Shapes.Records {
    public class StyleChangeShapeRecordEx : StyleChangeShapeRecord, IShapeRecordEx {

        public readonly IList<FillStyleRGBA> FillStyles = new List<FillStyleRGBA>();

        public readonly IList<LineStyleEx> LineStyles = new List<LineStyleEx>();

        public override TResult AcceptVisitor<TArg, TResult>(IShapeRecordVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
