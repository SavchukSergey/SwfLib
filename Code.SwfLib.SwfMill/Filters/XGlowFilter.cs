using System.Xml.Linq;
using Code.SwfLib.Filters;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Utils;

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
                new XElement("color", XColorRGBA.ToXml(filter.Color)),
                new XAttribute("compositeSource", CommonFormatter.Format(filter.CompositeSource))
            );
            return res;
        }

        public static GlowFilter FromXml(XElement xFilter) {
            const string NODE = "Glow";
            var xBlurX = xFilter.RequiredAttribute("blurX", NODE);
            var xBlurY = xFilter.RequiredAttribute("blurY", NODE);
            var xInnerGlow = xFilter.RequiredAttribute("innerGlow", NODE);
            var xKnockout = xFilter.RequiredAttribute("knockout", NODE);
            var xPasses = xFilter.RequiredAttribute("passes", NODE);
            var xStrength = xFilter.RequiredAttribute("strength", NODE);
            var xCompositeSource = xFilter.Attribute("compositeSource");

            var xColor = xFilter.Element("color").Element("Color");

            return new GlowFilter {
                BlurX = CommonFormatter.ParseDouble(xBlurX),
                BlurY = CommonFormatter.ParseDouble(xBlurY),
                InnerGlow = CommonFormatter.ParseBool(xInnerGlow),
                Knockout = CommonFormatter.ParseBool(xKnockout),
                Passes = uint.Parse(xPasses),
                Strength = CommonFormatter.ParseDouble(xStrength),
                CompositeSource = xCompositeSource == null || CommonFormatter.ParseBool(xCompositeSource.Value),
                Color = XColorRGBA.FromXml(xColor)
            };
        }
    }
}
