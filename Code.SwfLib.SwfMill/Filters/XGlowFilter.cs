using System.Xml.Linq;
using Code.SwfLib.Filters;
using Code.SwfLib.SwfMill.Data;

namespace Code.SwfLib.SwfMill.Filters {
    public static class XGlowFilter {

        public const string TAG_NAME = "Glow";

        public static XElement ToXml(GlowFilter filter) {
            var res = new XElement(TAG_NAME,
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

        public static GlowFilter FromXml(XElement xFilter) {
            var xBlurX = xFilter.Attribute("blurX");
            var xBlurY = xFilter.Attribute("blurY");
            var xInnerGlow = xFilter.Attribute("innerGlow");
            var xKnockout = xFilter.Attribute("knockout");
            var xPasses = xFilter.Attribute("passes");
            var xStrength = xFilter.Attribute("strength");
            var xCompositeSource = xFilter.Attribute("compositeSource");

            var xColor = xFilter.Element("color").Element("Color");

            return new GlowFilter {
                BlurX = CommonFormatter.ParseDouble(xBlurX.Value),
                BlurY = CommonFormatter.ParseDouble(xBlurY.Value),
                InnerGlow = CommonFormatter.ParseBool(xInnerGlow.Value),
                Knockout = CommonFormatter.ParseBool(xKnockout.Value),
                Passes = uint.Parse(xPasses.Value),
                Strength = CommonFormatter.ParseDouble(xStrength.Value),
                CompositeSource = xCompositeSource == null || CommonFormatter.ParseBool(xCompositeSource.Value),
                Color = XColorRGBA.FromXml(xColor)
            };
        }
    }
}
