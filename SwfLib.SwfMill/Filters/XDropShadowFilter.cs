using System.Xml.Linq;
using Code.SwfLib.Filters;
using Code.SwfLib.SwfMill.Data;
using SwfLib.SwfMill.Data;
using SwfLib.SwfMill.Utils;

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
            var xCompositeSource = xFilter.Attribute("compositeSource");

            var xColor = xFilter.RequiredElement("color").Element("Color");

            return new DropShadowFilter {
                Angle = xFilter.RequiredDoubleAttribute("angle"),
                BlurX = xFilter.RequiredDoubleAttribute("blurX"),
                BlurY = xFilter.RequiredDoubleAttribute("blurY"),
                Distance = xFilter.RequiredDoubleAttribute("distance"),
                InnerShadow = xFilter.RequiredBoolAttribute("innerShadow"),
                Knockout = xFilter.RequiredBoolAttribute("knockout"),
                Passes = xFilter.RequiredUIntAttribute("passes"),
                Strength = xFilter.RequiredDoubleAttribute("strength"),
                CompositeSource = xCompositeSource == null || CommonFormatter.ParseBool(xCompositeSource.Value),
                Color = XColorRGBA.FromXml(xColor)
            };
        }
    }
}
