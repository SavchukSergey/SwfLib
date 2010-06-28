using System.Diagnostics;

namespace Code.SwfLib.Data {
    //TODO: Find usage. Make non - nullable. Set Scales to default values
    [DebuggerDisplay("Scale ({ScaleX}, {ScaleY}), RotateSkew({RotateSkew0}, {RotateSkew1}), Translate({TranslateX}, {TranslateY})")]
    public struct SwfMatrix {

        public double ScaleX;

        public double ScaleY;

        public double RotateSkew0;

        public double RotateSkew1;

        public int TranslateX;

        public int TranslateY;

        public bool HasScale {
            get { return ScaleX != 1.0 || ScaleY != 1.0; }
        }

        public bool HasRotate {
            get { return RotateSkew0 != 0.0 || RotateSkew1 != 0.0; }
        }

    }
}