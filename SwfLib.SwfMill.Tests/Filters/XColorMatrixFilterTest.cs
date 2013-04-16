using System.Xml.Linq;
using Code.SwfLib.SwfMill.Filters;
using Code.SwfLib.SwfMill.Tests;
using NUnit.Framework;
using SwfLib.Filters;
using SwfLib.Tests.Asserts;

namespace SwfLib.SwfMill.Tests.Filters {
    [TestFixture]
    public class XColorMatrixFilterTest {
        private const string ETALON = @"<ColorMatrix
    r0='10.1' r1='11.11' r2='12.12' r3='13.13' r4='14.14'
    g0='20.2' g1='21.21' g2='22.22' g3='23.23' g4='24.24'
    b0='30.3' b1='31.31' b2='32.32' b3='33.33' b4='34.34'
    a0='40.4' a1='41.41' a2='42.42' a3='43.43' a4='44.44' />";

        [Test]
        public void FromXmlTest() {
            var filter = XColorMatrixFilter.FromXml(XElement.Parse(ETALON));
            AssertFilters.AreEqual(GetSample(), filter, "ColorMatrix");
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
                R0 = 10.10,
                R1 = 11.11,
                R2 = 12.12,
                R3 = 13.13,
                R4 = 14.14,

                G0 = 20.20,
                G1 = 21.21,
                G2 = 22.22,
                G3 = 23.23,
                G4 = 24.24,

                B0 = 30.30,
                B1 = 31.31,
                B2 = 32.32,
                B3 = 33.33,
                B4 = 34.34,

                A0 = 40.40,
                A1 = 41.41,
                A2 = 42.42,
                A3 = 43.43,
                A4 = 44.44
            };
        }
    }
}
