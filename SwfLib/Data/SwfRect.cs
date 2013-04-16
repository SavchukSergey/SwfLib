using System.Diagnostics;

namespace Code.SwfLib.Data {
    [DebuggerDisplay("X: ({XMin}, {XMax}), Y: ({YMin}, {YMax})")]
    public struct SwfRect {

        public SwfRect(int xMin, int yMin, int xMax, int yMax) {
            XMin = xMin;
            XMax = xMax;
            YMin = yMin;
            YMax = yMax;
        }

        public int XMin;
        public int YMin;
        public int XMax;
        public int YMax;

    }
}