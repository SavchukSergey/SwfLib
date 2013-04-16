using System.Diagnostics;

namespace SwfLib.Data {
    [DebuggerDisplay("Red: {Red}, Green: {Green}, Blue:  {Blue}")]
    public struct SwfRGB {

        public SwfRGB(byte red, byte green, byte blue) {
            Red = red;
            Green = green;
            Blue = blue;
        }


        public byte Red;

        public byte Green;

        public byte Blue;

    }
}