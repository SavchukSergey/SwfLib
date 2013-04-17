using System.Diagnostics;

namespace SwfLib.Data {
    //TODO: Find usage. Make non - nullable. Set Scales to default values
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

        public bool HasScale;

        public bool HasRotate;

    }
}