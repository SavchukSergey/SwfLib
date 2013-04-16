using Code.SwfLib.Filters;
using Code.SwfLib.Tests.Asserts;
using NUnit.Framework;
using SwfLib.Filters;
using SwfLib.Tests.Asserts;
using SwfLib.Tests.Filters;

namespace Code.SwfLib.Tests.Filters {
    [TestFixture]
    public class BevelFilterTest : BaseFilterTest {

        private static readonly byte[] _etalon = new byte[] {3,
            188, 174, 240, 232, //Shadow Color
            200, 150, 100, 132, //Highlight color
            0, 128, 1, 0, //BlurX
            0, 192, 2, 0, //BlurY,
            0, 224, 4, 0, //Angle
            0, 128, 12, 0, //Distance
            192, 2, //Strength
            229
        };

        [Test]
        public void ReadTest() {
            var filter = ReadFilter<BevelFilter>(_etalon);
            AssertFilters.AreEqual(GetFilter(), filter, "BevelFilter");
        }

        [Test]
        public void WriteTest() {
            WriteFilter(GetFilter(), _etalon);
        }

        private static BevelFilter GetFilter() {
            return new BevelFilter {
                BlurX = 1.5,
                BlurY = 2.75,
                Passes = 5,
                Angle = 4.875,
                Distance = 12.5,
                CompositeSource = true,
                Knockout = true,
                Strength = 2.75,
                HighlightColor = { Red = 200, Green = 150, Blue = 100, Alpha = 132 },
                ShadowColor = { Red = 188, Green = 174, Blue = 240, Alpha = 232 },
                InnerShadow = true,
                OnTop = false
            };
        }
    }
}
