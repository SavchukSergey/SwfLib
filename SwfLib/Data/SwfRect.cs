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

        public SwfVector TopLeft {
            get { return new SwfVector { X = XMin, Y = YMin }; }
        }

        public SwfVector TopRight {
            get { return new SwfVector { X = XMax, Y = YMin }; }
        }

        public SwfVector BottomLeft {
            get { return new SwfVector { X = XMin, Y = YMax }; }
        }

        public SwfVector BottomRight {
            get { return new SwfVector { X = XMax, Y = YMax }; }
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