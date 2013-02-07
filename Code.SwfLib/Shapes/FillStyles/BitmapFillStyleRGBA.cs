using System;
using Code.SwfLib.Data;

namespace Code.SwfLib.Shapes.FillStyles {
    public class BitmapFillStyleRGBA : FillStyleRGBA {

        public bool Smoothing { get; set; }

        public BitmapMode Mode { get; set; }

        public ushort BitmapID;

        public SwfMatrix BitmapMatrix;

        public override FillStyleType Type {
            get {
                switch (Mode) {
                    case BitmapMode.Clip:
                        return Smoothing ? FillStyleType.ClippedBitmap : FillStyleType.NonSmoothedClippedBitmap;
                    case BitmapMode.Repeat:
                        return Smoothing ? FillStyleType.RepeatingBitmap : FillStyleType.NonSmoothedRepeatingBitmap;
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        public override TResult AcceptVisitor<TArg, TResult>(IFillStyleRGBAVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}
