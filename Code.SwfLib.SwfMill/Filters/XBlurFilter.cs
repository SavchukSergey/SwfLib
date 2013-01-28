using System.Xml.Linq;
using Code.SwfLib.Filters;
using Code.SwfLib.SwfMill.Data;

namespace Code.SwfLib.SwfMill.Filters {
    public static class XBlurFilter {

        public const string TAG_NAME = "Blur";

        public static XElement ToXml(BlurFilter filter) {
            var res = new XElement(TAG_NAME,
                new XAttribute("blurX", CommonFormatter.Format(filter.BlurX)),
                new XAttribute("blurY", CommonFormatter.Format(filter.BlurY)),
                new XAttribute("passes", filter.Passes)
            );
            if (filter.Reserved != 0) {
                res.Add(new XAttribute("reserved", filter.Reserved));
            }
            return res;
        }

        public static BlurFilter FromXml(XElement xFilter) {
            var xBlurX = xFilter.Attribute("blurX");
            var xBlurY = xFilter.Attribute("blurY");
            var xPasses = xFilter.Attribute("passes");
            var xReserved = xFilter.Attribute("passes");

            return new BlurFilter {
                BlurX = CommonFormatter.ParseDouble(xBlurX.Value),
                BlurY = CommonFormatter.ParseDouble(xBlurY.Value),
                Passes = uint.Parse(xPasses.Value),
                Reserved = xReserved != null ? uint.Parse(xReserved.Value) : 0
            };
        }
    }
}
