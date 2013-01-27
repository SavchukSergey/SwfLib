using System.Xml.Linq;
using Code.SwfLib.Filters;
using Code.SwfLib.SwfMill.Data;

namespace Code.SwfLib.SwfMill.Filters {
    public static class XGlowFilter {

        public static XElement ToXml(GlowFilter filter) {
            var res = new XElement("Glow",
                new XAttribute("blurX", CommonFormatter.Format(filter.BlurX)),
                new XAttribute("blurY", CommonFormatter.Format(filter.BlurY)),
                new XAttribute("innerGlow", CommonFormatter.Format(filter.InnerGlow)),
                new XAttribute("knockout", CommonFormatter.Format(filter.Knockout)),
                new XAttribute("passes", filter.Passes),
                new XAttribute("strength", CommonFormatter.Format(filter.Strength)),
                new XElement("color", XColorRGBA.ToXml(filter.Color))
            );
            if (!filter.CompositeSource) {
                res.Add(new XAttribute("compositeSource", CommonFormatter.Format(filter.CompositeSource)));
            }
            return res;
        }
    }
}
