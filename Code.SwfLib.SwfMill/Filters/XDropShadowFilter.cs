using System.Xml.Linq;
using Code.SwfLib.Filters;
using Code.SwfLib.SwfMill.Data;

namespace Code.SwfLib.SwfMill.Filters {
    public static class XDropShadowFilter {

        public static XElement ToXml(DropShadowFilter filter) {
            var res = new XElement("DropShadow",
                new XAttribute("angle", CommonFormatter.Format(filter.Angle)),
                new XAttribute("blurX", CommonFormatter.Format(filter.BlurX)),
                new XAttribute("blurY", CommonFormatter.Format(filter.BlurY)),
                new XAttribute("distance", CommonFormatter.Format(filter.Distance)),
                new XAttribute("innerShadow", CommonFormatter.Format(filter.InnerShadow)),
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
