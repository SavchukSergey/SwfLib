using System.Xml.Linq;
using Code.SwfLib.SwfMill.Filters;
using Code.SwfLib.Tests.Asserts;
using NUnit.Framework;
using SwfLib.Filters;
using SwfLib.Tests.Asserts;

namespace Code.SwfLib.SwfMill.Tests.Filters {
    [TestFixture]
    public class XDropShadowFilterTest {
        private const string ETALON = @"<DropShadow blurX='1.5' blurY='-2.4' strength='20.5' innerShadow='1' knockout='1' passes='2' angle='0.75' distance='2.9' compositeSource='1'>
    <color>
        <Color red='137' green='24' blue='87' alpha='20' />
    </color>
</DropShadow>
";

        [Test]
        public void FromXmlTest() {
            var filter = XDropShadowFilter.FromXml(XElement.Parse(ETALON));
            AssertFilters.AreEqual(GetSample(), filter, "DropShadow");
        }

        [Test]
        public void ToXmlTest() {
            var filter = GetSample();
            var xResult = XDropShadowFilter.ToXml(filter);

            var xOriginal = XElement.Parse(ETALON);
            new XmlComparision(Assert.Fail).Compare(xOriginal, xResult);
        }

        private DropShadowFilter GetSample() {
            return new DropShadowFilter {
                BlurX = 1.5,
                BlurY = -2.4,
                Color = {
                    Red = 137,
                    Green = 24,
                    Blue = 87,
                    Alpha = 20
                },
                Strength = 20.5,
                CompositeSource = true,
                InnerShadow = true,
                Knockout = true,
                Passes = 2,
                Angle = 0.75,
                Distance = 2.9
            };
        }
    }
}
