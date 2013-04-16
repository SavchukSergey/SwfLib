using System.Xml.Linq;
using SwfLib.Filters;
using SwfLib.SwfMill.Data;
using SwfLib.SwfMill.Gradients;
using SwfLib.SwfMill.Utils;

namespace SwfLib.SwfMill.Filters {
    public static class XGradientGlowFilter {

        public const string TAG_NAME = "GradientGlow";

        public static XElement ToXml(GradientGlowFilter filter) {
            var res = new XElement(TAG_NAME,
                new XAttribute("blurX", CommonFormatter.Format(filter.BlurX)),
                new XAttribute("blurY", CommonFormatter.Format(filter.BlurY)),
                new XAttribute("angle", CommonFormatter.Format(filter.Angle)),
                new XAttribute("distance", CommonFormatter.Format(filter.Distance)),
                new XAttribute("strength", CommonFormatter.Format(filter.Strength)),
                new XAttribute("innerGlow", CommonFormatter.Format(filter.InnerGlow)),
                new XAttribute("knockout", CommonFormatter.Format(filter.Knockout)),
                new XAttribute("compositeSource", CommonFormatter.Format(filter.CompositeSource)),
                new XAttribute("onTop", CommonFormatter.Format(filter.OnTop)),
                new XAttribute("passes", filter.Passes)
            );
            res.Add(XGradientRecords.ToXml(filter.GradientColors));
            return res;
        }

        public static GradientGlowFilter FromXml(XElement xFilter) {
            var xCompositeSource = xFilter.Attribute("compositeSource");

            var filter = new GradientGlowFilter {
                BlurX = xFilter.RequiredDoubleAttribute("blurX"),
                BlurY = xFilter.RequiredDoubleAttribute("blurY"),
                Angle = xFilter.RequiredDoubleAttribute("angle"),
                Distance = xFilter.RequiredDoubleAttribute("distance"),
                Strength = xFilter.RequiredDoubleAttribute("strength"),
                InnerGlow = xFilter.RequiredBoolAttribute("innerGlow"),
                Knockout = xFilter.RequiredBoolAttribute("knockout"),
                CompositeSource = xCompositeSource == null || CommonFormatter.ParseBool(xCompositeSource.Value),
                OnTop = xFilter.RequiredBoolAttribute("onTop"),
                Passes = xFilter.RequiredUIntAttribute("passes"),
            };

            XGradientRecords.FromXml(xFilter.Element("gradientColors"), filter.GradientColors);
            return filter;
        }
    }
}
