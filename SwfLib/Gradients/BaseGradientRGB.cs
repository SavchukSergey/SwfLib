using System.Collections.Generic;

namespace Code.SwfLib.Gradients {
    public class BaseGradientRGB {

        public SpreadMode SpreadMode;

        public InterpolationMode InterpolationMode;

        public readonly IList<GradientRecordRGB> GradientRecords = new List<GradientRecordRGB>();

    }
}
