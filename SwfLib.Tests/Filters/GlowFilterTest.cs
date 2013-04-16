using Code.SwfLib.Filters;
using Code.SwfLib.Tests.Asserts;
using NUnit.Framework;
using SwfLib.Tests.Filters;

namespace Code.SwfLib.Tests.Filters {
    [TestFixture]
    public class GlowFilterTest : BaseFilterTest {

        private static readonly byte[] _etalon = new byte[] {2,
            18, 2, 8, 250, //Color
            0, 128, 1, 0, //BlurX
            0, 192, 2, 0, //BlurY,
            192, 2, 101
        };

        [Test]
        public void ReadTest() {
            var filter = ReadFilter<GlowFilter>(_etalon);
            AssertFilters.AreEqual(GetFilter(), filter, "GlowFilter");
        }

        [Test]
        public void WriteTest() {
            WriteFilter(GetFilter(), _etalon);
        }

        private static GlowFilter GetFilter() {
            return new GlowFilter {
                BlurX = 1.5,
                BlurY = 2.75,
                Passes = 5,
                Color = { Red = 18, Green = 2, Blue = 8, Alpha = 250 },
                CompositeSource = true,
                InnerGlow = false,
                Knockout = true,
                Strength = 2.75
            };
        }
    }
}
