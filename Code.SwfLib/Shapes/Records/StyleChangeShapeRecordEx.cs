using System.Collections.Generic;
using Code.SwfLib.Shapes.FillStyles;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.Shapes.Records {
    public class StyleChangeShapeRecordEx : StyleChangeShapeRecord, IShapeRecordEx {

        public readonly IList<FillStyleRGBA> FillStyles = new List<FillStyleRGBA>();

        public readonly IList<LineStyleEx> LineStyles = new List<LineStyleEx>();

        public override TResult AcceptVisitor<TArg, TResult>(IShapeRecordVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
