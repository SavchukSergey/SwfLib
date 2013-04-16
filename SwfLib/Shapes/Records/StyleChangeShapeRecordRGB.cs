using System.Collections.Generic;
using Code.SwfLib.Shapes.FillStyles;
using Code.SwfLib.Shapes.LineStyles;
using Code.SwfLib.Shapes.Records;
using SwfLib.Shapes.FillStyles;
using SwfLib.Shapes.LineStyles;

namespace SwfLib.Shapes.Records {
    public class StyleChangeShapeRecordRGB : StyleChangeShapeRecord, IShapeRecordRGB {

        public readonly IList<FillStyleRGB> FillStyles = new List<FillStyleRGB>();

        public readonly IList<LineStyleRGB> LineStyles = new List<LineStyleRGB>();

        public override TResult AcceptVisitor<TArg, TResult>(IShapeRecordVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
