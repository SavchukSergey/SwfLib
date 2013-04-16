using System.Xml.Linq;
using Code.SwfLib.Filters;
using Code.SwfLib.Gradients;
using Code.SwfLib.SwfMill.Filters;
using Code.SwfLib.Tests.Asserts;
using NUnit.Framework;

namespace Code.SwfLib.SwfMill.Tests.Filters {
    [TestFixture]
    public class XGradientGlowFilterTest {
        private const string ETALON = @"<GradientGlow blurX='1.5' blurY='-2.4' strength='20.5' angle='3.45' distance='29.7' innerGlow='1' knockout='1' passes='2' compositeSource='1' onTop='1'>
    <gradientColors>
        <GradientItem position='0'>
            <color>
                <Color red='1' green='2' blue='3' alpha='4' />
            </color>
        </GradientItem>
        <GradientItem position='10'>
            <color>
                <Color red='5' green='6' blue='7' alpha='8' />
            </color>
        </GradientItem>
    </gradientColors>
</GradientGlow>
";

        [Test]
        public void FromXmlTest() {
            var filter = XGradientGlowFilter.FromXml(XElement.Parse(ETALON));
            AssertFilters.AreEqual(GetSample(), filter, "GradientGlow");
        }

        [Test]
        public void ToXmlTest() {
            var filter = GetSample();
            var xResult = XGradientGlowFilter.ToXml(filter);

            var xOriginal = XElement.Parse(ETALON);
            new XmlComparision(Assert.Fail).Compare(xOriginal, xResult);
        }

        private GradientGlowFilter GetSample() {
            return new GradientGlowFilter {
                BlurX = 1.5,
                BlurY = -2.4,
                GradientColors = {
                    new GradientRecordRGBA { Ratio = 0, Color = {Red = 1, Green = 2, Blue = 3, Alpha = 4}},
                    new GradientRecordRGBA { Ratio = 10, Color = {Red = 5, Green = 6, Blue = 7, Alpha = 8}}
                },
                Strength = 20.5,
                CompositeSource = true,
                InnerGlow = true,
                Knockout = true,
                Passes = 2,
                Angle = 3.45,
                Distance = 29.7,
                OnTop = true
            };
        }
    }
}
