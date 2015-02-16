using System;
using SwfLib.Data;

namespace SwfLib.Shapes.FillStyles {
    public class BitmapFillStyleRGBA : FillStyleRGBA {

        public bool Smoothing { get; set; }

        public BitmapMode Mode { get; set; }

        public ushort BitmapID { get; set; }

        public SwfMatrix BitmapMatrix = SwfMatrix.Identity;

        /// <summary>
        /// Gets type of fill style.
        /// </summary>
        /// <exception cref="System.NotSupportedException"></exception>
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
