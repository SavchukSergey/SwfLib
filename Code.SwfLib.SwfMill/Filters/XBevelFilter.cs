using System.Xml.Linq;
using Code.SwfLib.Filters;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Utils;

namespace Code.SwfLib.SwfMill.Filters {
    public static class XBevelFilter {

        public const string TAG_NAME = "Bevel";

        public static XElement ToXml(BevelFilter filter) {
            return new XElement(TAG_NAME,
              new XAttribute("angle", CommonFormatter.Format(filter.Angle)),
              new XAttribute("blurX", CommonFormatter.Format(filter.BlurX)),
              new XAttribute("blurY", CommonFormatter.Format(filter.BlurY)),
              new XAttribute("distance", CommonFormatter.Format(filter.Distance)),
              new XAttribute("innerShadow", CommonFormatter.Format(filter.InnerShadow)),
              new XAttribute("knockout", CommonFormatter.Format(filter.Knockout)),
              new XAttribute("compositeSource", CommonFormatter.Format(filter.CompositeSource)),
              new XAttribute("onTop", CommonFormatter.Format(filter.OnTop)),
              new XAttribute("passes", filter.Passes),
              new XAttribute("strength", CommonFormatter.Format(filter.Strength)),
              new XElement("shadowColor", XColorRGBA.ToXml(filter.ShadowColor)),
              new XElement("highlightColor", XColorRGBA.ToXml(filter.HighlightColor))
          );
        }

        public static BevelFilter FromXml(XElement xFilter) {
            var xCompositeSource = xFilter.Attribute("compositeSource");

            var xShadowColor = xFilter.RequiredElement("shadowColor").Element("Color");
            var xHighlightColor = xFilter.RequiredElement("highlightColor").Element("Color");

            return new BevelFilter {
                Angle = xFilter.RequiredDoubleAttribute("angle"),
                BlurX = xFilter.RequiredDoubleAttribute("blurX"),
                BlurY = xFilter.RequiredDoubleAttribute("blurY"),
                Distance = xFilter.RequiredDoubleAttribute("distance"),
                InnerShadow = xFilter.RequiredBoolAttribute("innerShadow"),
                Knockout = xFilter.RequiredBoolAttribute("knockout"),
                Passes = xFilter.RequiredUIntAttribute("passes"),
                Strength = xFilter.RequiredDoubleAttribute("strength"),
                CompositeSource = xCompositeSource == null || CommonFormatter.ParseBool(xCompositeSource.Value),
                OnTop = xFilter.RequiredBoolAttribute("onTop"),
                ShadowColor = XColorRGBA.FromXml(xShadowColor),
                HighlightColor = XColorRGBA.FromXml(xHighlightColor)
            };
        }
    }
}
