using System.Collections.Generic;

namespace Code.SwfLib.Gradients {
    public class BaseGradientRGBA {

        public SpreadMode SpreadMode;

        public InterpolationMode InterpolationMode;

        public readonly IList<GradientRecordRGBA> GradientRecords = new List<GradientRecordRGBA>();


    }
}
