using System.Xml.Linq;
using Code.SwfLib.Filters;
using Code.SwfLib.SwfMill.Data;
using SwfLib.SwfMill.Data;
using SwfLib.SwfMill.Utils;

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
            var xCompositeSource = xFilter.Attribute("compositeSource");

            var xColor = xFilter.RequiredElement("color").Element("Color");

            return new GlowFilter {
                BlurX = xFilter.RequiredDoubleAttribute("blurX"),
                BlurY = xFilter.RequiredDoubleAttribute("blurY"),
                InnerGlow = xFilter.RequiredBoolAttribute("innerGlow"),
                Knockout = xFilter.RequiredBoolAttribute("knockout"),
                Passes = xFilter.RequiredUIntAttribute("passes"),
                Strength = xFilter.RequiredDoubleAttribute("strength"),
                CompositeSource = xCompositeSource == null || CommonFormatter.ParseBool(xCompositeSource.Value),
                Color = XColorRGBA.FromXml(xColor)
            };
        }
    }
}
