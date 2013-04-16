using System.Xml.Linq;
using Code.SwfLib.SwfMill.Filters;
using NUnit.Framework;
using SwfLib.Filters;
using SwfLib.SwfMill.Filters;
using SwfLib.Tests.Asserts;

namespace SwfLib.SwfMill.Tests.Filters {
    [TestFixture]
    public class XBevelFilterTest {
        private const string ETALON = @"<Bevel blurX='1.5' blurY='-2.4' strength='20.5' innerShadow='1' knockout='1' onTop='1' passes='2' angle='0.75' distance='2.9' compositeSource='1'>
    <shadowColor>
        <Color red='137' green='24' blue='87' alpha='20' />
    </shadowColor>
    <highlightColor>
        <Color red='237' green='84' blue='217' alpha='192' />
    </highlightColor>
</Bevel>
";

        [Test]
        public void FromXmlTest() {
            var filter = XBevelFilter.FromXml(XElement.Parse(ETALON));
            AssertFilters.AreEqual(GetSample(), filter, "Bevel");
        }

        [Test]
        public void ToXmlTest() {
            var filter = GetSample();
            var xResult = XBevelFilter.ToXml(filter);

            var xOriginal = XElement.Parse(ETALON);
            new XmlComparision(Assert.Fail).Compare(xOriginal, xResult);
        }

        private BevelFilter GetSample() {
            return new BevelFilter {
                BlurX = 1.5,
                BlurY = -2.4,
                ShadowColor = {
                    Red = 137,
                    Green = 24,
                    Blue = 87,
                    Alpha = 20
                },
                HighlightColor = {
                    Red = 237,
                    Green = 84,
                    Blue = 217,
                    Alpha = 192
                },
                Strength = 20.5,
                CompositeSource = true,
                InnerShadow = true,
                Knockout = true,
                OnTop = true,
                Passes = 2,
                Angle = 0.75,
                Distance = 2.9
            };
        }
    }
}
