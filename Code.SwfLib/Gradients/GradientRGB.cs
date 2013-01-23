using System.Collections.Generic;

namespace Code.SwfLib.Gradients {
    public struct GradientRGB {

        public SpreadMode SpreadMode;

        public InterpolationMode InterpolationMode;

        private IList<GradientRecordRGB> _gradientRecords;
        public IList<GradientRecordRGB> GradientRecords {
            get {
                if (_gradientRecords == null) {
                    _gradientRecords = new List<GradientRecordRGB>();
                }
                return _gradientRecords;
            }
        }

    }
}