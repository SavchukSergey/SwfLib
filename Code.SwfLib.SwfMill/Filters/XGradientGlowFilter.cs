using System.Xml.Linq;
using Code.SwfLib.Filters;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Gradients;
using Code.SwfLib.SwfMill.Utils;

namespace Code.SwfLib.SwfMill.Filters {
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
            const string node = "GradientGlow";
            var xCompositeSource = xFilter.Attribute("compositeSource");
            var xPasses = xFilter.Attribute("passes");

            var filter = new GradientGlowFilter {
                BlurX = xFilter.RequiredDoubleAttribute("blurX", node),
                BlurY = xFilter.RequiredDoubleAttribute("blurY", node),
                Angle = xFilter.RequiredDoubleAttribute("angle", node),
                Distance = xFilter.RequiredDoubleAttribute("distance", node),
                Strength = xFilter.RequiredDoubleAttribute("strength", node),
                InnerGlow = xFilter.RequiredBoolAttribute("innerGlow", node),
                Knockout = xFilter.RequiredBoolAttribute("knockout", node),
                CompositeSource = xCompositeSource == null || CommonFormatter.ParseBool(xCompositeSource.Value),
                OnTop = xFilter.RequiredBoolAttribute("onTop", node),
                Passes = uint.Parse(xPasses.Value),
            };

            XGradientRecords.FromXml(xFilter.Element("gradientColors"), filter.GradientColors);
            return filter;
        }
    }
}
