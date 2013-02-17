using System.Xml.Linq;
using Code.SwfLib.Filters;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Utils;

namespace Code.SwfLib.SwfMill.Filters {
    public static class XDropShadowFilter {

        public const string TAG_NAME = "DropShadow";

        public static XElement ToXml(DropShadowFilter filter) {
            return new XElement(TAG_NAME,
                new XAttribute("angle", CommonFormatter.Format(filter.Angle)),
                new XAttribute("blurX", CommonFormatter.Format(filter.BlurX)),
                new XAttribute("blurY", CommonFormatter.Format(filter.BlurY)),
                new XAttribute("distance", CommonFormatter.Format(filter.Distance)),
                new XAttribute("innerShadow", CommonFormatter.Format(filter.InnerShadow)),
                new XAttribute("knockout", CommonFormatter.Format(filter.Knockout)),
                new XAttribute("compositeSource", CommonFormatter.Format(filter.CompositeSource)),
                new XAttribute("passes", filter.Passes),
                new XAttribute("strength", CommonFormatter.Format(filter.Strength)),
                new XElement("color", XColorRGBA.ToXml(filter.Color))
            );
        }

        public static DropShadowFilter FromXml(XElement xFilter) {
            const string node = "DropShadow";
            var xInnerShadow = xFilter.Attribute("innerShadow");
            var xKnockout = xFilter.Attribute("knockout");
            var xPasses = xFilter.Attribute("passes");
            var xCompositeSource = xFilter.Attribute("compositeSource");

            var xColor = xFilter.Element("color").Element("Color");

            return new DropShadowFilter {
                Angle = xFilter.RequiredDoubleAttribute("angle", node),
                BlurX = xFilter.RequiredDoubleAttribute("blurX", node),
                BlurY = xFilter.RequiredDoubleAttribute("blurY", node),
                Distance = xFilter.RequiredDoubleAttribute("distance", node),
                InnerShadow = CommonFormatter.ParseBool(xInnerShadow.Value),
                Knockout = CommonFormatter.ParseBool(xKnockout.Value),
                Passes = uint.Parse(xPasses.Value),
                Strength = xFilter.RequiredDoubleAttribute("strength", node),
                CompositeSource = xCompositeSource == null || CommonFormatter.ParseBool(xCompositeSource.Value),
                Color = XColorRGBA.FromXml(xColor)
            };
        }
    }
}
