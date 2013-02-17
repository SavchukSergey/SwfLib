using System.Xml.Linq;
using Code.SwfLib.Filters;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Utils;

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
            const string node = "Blur";
            var xPasses = xFilter.Attribute("passes");
            var xReserved = xFilter.Attribute("reserved");

            return new BlurFilter {
                BlurX = xFilter.RequiredDoubleAttribute("blurX", node),
                BlurY = xFilter.RequiredDoubleAttribute("blurY", node),
                Passes = uint.Parse(xPasses.Value),
                Reserved = xReserved != null ? uint.Parse(xReserved.Value) : 0
            };
        }
    }
}
