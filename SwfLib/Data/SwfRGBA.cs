namespace SwfLib.Data {
    /// <summary>
    /// Represents RGBA color.
    /// </summary>
    public struct SwfRGBA {

        public SwfRGBA(byte red, byte green, byte blue, byte alpha) {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }


        public byte Red;

        public byte Green;

        public byte Blue;

        public byte Alpha;

    }
}
