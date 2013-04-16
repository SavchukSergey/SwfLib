using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using SwfLib.Filters;
using SwfLib.SwfMill.Data;
using SwfLib.SwfMill.Utils;

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
            var xReserved = xFilter.Attribute("reserved");

            return new BlurFilter {
                BlurX = xFilter.RequiredDoubleAttribute("blurX"),
                BlurY = xFilter.RequiredDoubleAttribute("blurY"),
                Passes = xFilter.RequiredUIntAttribute("passes"),
                Reserved = xReserved != null ? uint.Parse(xReserved.Value) : 0
            };
        }
    }
}
