using SwfLib.Data;

namespace SwfLib.Gradients {
    /// <summary>
    /// Represents gradient RGB record.
    /// </summary>
    public class GradientRecordRGB {

        /// <summary>
        /// Gets or sets ration.
        /// </summary>
        public byte Ratio { get; set; }

        /// <summary>
        /// Gets or sets color.
        /// </summary>
        public SwfRGB Color { get; set; }

    }
}
