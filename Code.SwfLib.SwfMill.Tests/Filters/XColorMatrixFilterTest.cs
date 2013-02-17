using System.Xml.Linq;
using Code.SwfLib.Filters;
using Code.SwfLib.SwfMill.Filters;
using Code.SwfLib.Tests.Asserts;
using NUnit.Framework;

namespace Code.SwfLib.SwfMill.Tests.Filters {
    [TestFixture]
    public class XColorMatrixFilterTest {
        private const string ETALON = @"<ColorMatrix r0='10' r1='11' r2='12' r3='13' r4='14' g0='20' g1='21' g2='22' g3='23' g4='24' b0='30' b1='31' b2='32' b3='33' b4='34' a0='40' a1='41' a2='42' a3='43' a4='44' />";

        [Test]
        public void FromXmlTest() {
            var filter = XColorMatrixFilter.FromXml(XElement.Parse(ETALON));
            AssertFilters.AreEqual(GetSample(), filter);
        }

        [Test]
        public void ToXmlTest() {
            var filter = GetSample();
            var xResult = XColorMatrixFilter.ToXml(filter);

            var xOriginal = XElement.Parse(ETALON);
            new XmlComparision(Assert.Fail).Compare(xOriginal, xResult);
        }

        private ColorMatrixFilter GetSample() {
            return new ColorMatrixFilter {
                R0 = 10,
                R1 = 11,
                R2 = 12,
                R3 = 13,
                R4 = 14,

                G0 = 20,
                G1 = 21,
                G2 = 22,
                G3 = 23,
                G4 = 24,

                B0 = 30,
                B1 = 31,
                B2 = 32,
                B3 = 33,
                B4 = 34,

                A0 = 40,
                A1 = 41,
                A2 = 42,
                A3 = 43,
                A4 = 44
            };
        }
    }
}
