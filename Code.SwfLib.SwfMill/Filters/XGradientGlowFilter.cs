using System.Xml.Linq;
using Code.SwfLib.Filters;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Gradients;

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
            var xBlurX = xFilter.Attribute("blurX");
            var xBlurY = xFilter.Attribute("blurY");
            var xAngle = xFilter.Attribute("angle");
            var xDistance = xFilter.Attribute("distance");
            var xStrength = xFilter.Attribute("strength");
            var xInnerGlow = xFilter.Attribute("innerGlow");
            var xKnockout = xFilter.Attribute("knockout");
            var xCompositeSource = xFilter.Attribute("compositeSource");
            var xOnTop = xFilter.Attribute("onTop");
            var xPasses = xFilter.Attribute("passes");

            var filter = new GradientGlowFilter {
                BlurX = CommonFormatter.ParseDouble(xBlurX.Value),
                BlurY = CommonFormatter.ParseDouble(xBlurY.Value),
                Angle = CommonFormatter.ParseDouble(xAngle.Value),
                Distance = CommonFormatter.ParseDouble(xDistance.Value),
                Strength = CommonFormatter.ParseDouble(xStrength.Value),
                InnerGlow = CommonFormatter.ParseBool(xInnerGlow.Value),
                Knockout = CommonFormatter.ParseBool(xKnockout.Value),
                CompositeSource = xCompositeSource == null || CommonFormatter.ParseBool(xCompositeSource.Value),
                OnTop = CommonFormatter.ParseBool(xOnTop.Value),
                Passes = uint.Parse(xPasses.Value),
            };

            XGradientRecords.FromXml(xFilter.Element("gradientColors"), filter.GradientColors);
            return filter;
        }
    }
}
