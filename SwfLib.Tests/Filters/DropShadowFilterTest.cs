using Code.SwfLib.Filters;
using Code.SwfLib.Tests.Asserts;
using NUnit.Framework;
using SwfLib.Tests.Filters;

namespace Code.SwfLib.Tests.Filters {
    [TestFixture]
    public class DropShadowFilterTest : BaseFilterTest {

        private static readonly byte[] _etalon = new byte[] { 0,
            24, 175, 86, 64, //color
            0, 128, 1, 0, //BlurX
            0, 192, 2, 0, //BlurY
             0, 64, 0, 0, //Angle 
            0, 8, 7, 0, //Distance
            172, 10, //Strength
            165};

        [Test]
        public void ReadTest() {
            var filter = ReadFilter<DropShadowFilter>(_etalon);
            AssertFilters.AreEqual(GetFilter(), filter, "DropShadow");
        }

        [Test]
        public void WriteTest() {
            WriteFilter(GetFilter(), _etalon);
        }

        private static DropShadowFilter GetFilter() {
            return new DropShadowFilter {
                Angle = 0.25,
                BlurX = 1.5,
                BlurY = 2.75,
                Color = { Red = 24, Green = 175, Blue = 86, Alpha = 64 },
                CompositeSource = true,
                Distance = 7.03125,
                InnerShadow = true,
                Knockout = false,
                Passes = 5,
                Strength = 10.671875
            };
        }
    }
}
