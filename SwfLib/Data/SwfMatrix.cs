using System.Diagnostics;

namespace SwfLib.Data {
    /// <summary>
    /// Represents 2D transformation matrix.
    /// </summary>
    [DebuggerDisplay("Scale ({ScaleX}, {ScaleY}), RotateSkew({RotateSkew0}, {RotateSkew1}), Translate({TranslateX}, {TranslateY})")]
    public struct SwfMatrix {

        /// <summary>
        /// Gets or sets X Scale.
        /// </summary>
        public double ScaleX;

        /// <summary>
        /// Gets or sets Y Scale.
        /// </summary>
        public double ScaleY;

        public double RotateSkew0;

        public double RotateSkew1;

        public int TranslateX;

        public int TranslateY;

        public bool HasScale {
            get { return ScaleX != 1 || ScaleY != 1; }
        }

        public bool HasRotate {
            get { return RotateSkew0 != 0 || RotateSkew1 != 0; }
        }

        public static SwfMatrix Identity {
            get {
                return new SwfMatrix {
                    ScaleX = 1,
                    ScaleY = 1,
                    RotateSkew0 = 0,
                    RotateSkew1 = 0,
                    TranslateX = 0,
                    TranslateY = 0
                };
            }
        }

        public SwfVector Transform(SwfVector vector) {
            return new SwfVector {
                X = (int)(vector.X * (HasScale ? ScaleX : 1) + vector.Y * (HasRotate ? RotateSkew1 : 0) + TranslateX),
                Y = (int)(vector.Y * (HasScale ? ScaleY : 1) + vector.X * (HasRotate ? RotateSkew0 : 0) + TranslateY)
            };
        }

    }
}