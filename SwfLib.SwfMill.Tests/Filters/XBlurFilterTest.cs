using System.Xml.Linq;
using Code.SwfLib.SwfMill.Filters;
using Code.SwfLib.SwfMill.Tests;
using NUnit.Framework;
using SwfLib.Filters;
using SwfLib.SwfMill.Filters;
using SwfLib.Tests.Asserts;

namespace SwfLib.SwfMill.Tests.Filters {
    [TestFixture]
    public class XBlurFilterTest {
        private const string ETALON = @"<Blur blurX='1.5' blurY='-2.4' passes='2' reserved='12' />";

        [Test]
        public void FromXmlTest() {
            var filter = XBlurFilter.FromXml(XElement.Parse(ETALON));
            AssertFilters.AreEqual(GetSample(), filter, "Blur");
        }

        [Test]
        public void ToXmlTest() {
            var filter = GetSample();
            var xResult = XBlurFilter.ToXml(filter);

            var xOriginal = XElement.Parse(ETALON);
            new XmlComparision(Assert.Fail).Compare(xOriginal, xResult);
        }

        private BlurFilter GetSample() {
            return new BlurFilter {
                BlurX = 1.5,
                BlurY = -2.4,
                Passes = 2,
                Reserved = 12
            };
        }
    }
}
