using System.Collections.Generic;

namespace Code.SwfLib.Gradients {
    public class BaseGradientRGBA {

        public SpreadMode SpreadMode;

        public InterpolationMode InterpolationMode;

        private IList<GradientRecordRGBA> _gradientRecords;
        public IList<GradientRecordRGBA> GradientRecords {
            get {
                if (_gradientRecords == null) {
                    _gradientRecords = new List<GradientRecordRGBA>();
                }
                return _gradientRecords;
            }
        }

    }
}
