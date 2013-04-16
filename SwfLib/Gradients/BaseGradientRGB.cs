using System.Collections.Generic;
using Code.SwfLib.Gradients;

namespace SwfLib.Gradients {
    public class BaseGradientRGB {

        public SpreadMode SpreadMode;

        public InterpolationMode InterpolationMode;

        public readonly IList<GradientRecordRGB> GradientRecords = new List<GradientRecordRGB>();

    }
}
