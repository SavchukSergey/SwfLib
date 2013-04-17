using System.Diagnostics;

namespace SwfLib.Data {
    [DebuggerDisplay("X: ({XMin}, {XMax}), Y: ({YMin}, {YMax})")]
    public struct SwfRect {

        public SwfRect(int xMin, int yMin, int xMax, int yMax) {
            XMin = xMin;
            XMax = xMax;
            YMin = yMin;
            YMax = yMax;
        }

        /// <summary>
        /// Gets or sets minimal X;
        /// </summary>
        public int XMin;

        /// <summary>
        /// Gets or sets minimal Y.
        /// </summary>
        public int YMin;

        /// <summary>
        /// Gets or sets maximal X;
        /// </summary>
        public int XMax;

        /// <summary>
        /// Gets or sets maximal Y.
        /// </summary>
        public int YMax;

    }
}