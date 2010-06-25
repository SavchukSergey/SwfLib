using System.Collections.Generic;

namespace Code.SwfLib.Data.Gradients
{
    public class GradientRGB
    {

        public SpreadMode SpreadMode;

        public InterpolationMode InterpolationMode;

        public readonly IList<GradientRecordRGB> GradientRecords = new List<GradientRecordRGB>();

    }
}