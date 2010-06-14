using System.Diagnostics;

namespace Code.SwfLib.Data {
    [DebuggerDisplay("X: ({XMin}, {XMax}), Y: ({YMin}, {YMax})")]
    public struct SwfRect {

        public SwfRect(int xMin, int yMin, int xMax, int yMax) {
            this.XMin = xMin;
            this.XMax = xMax;
            this.YMin = yMin;
            this.YMax = yMax;
        }

        public int XMin;
        public int YMin;
        public int XMax;
        public int YMax;

    }
}