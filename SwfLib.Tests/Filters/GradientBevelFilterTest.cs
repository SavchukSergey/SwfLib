using Code.SwfLib.Filters;
using Code.SwfLib.Gradients;
using Code.SwfLib.Tests.Asserts;
using NUnit.Framework;
using SwfLib.Tests.Filters;

namespace Code.SwfLib.Tests.Filters {
    [TestFixture]
    public class GradientBevelFilterTest : BaseFilterTest {

        private static readonly byte[] _etalon = new byte[] {7,
            2,
            25, 168, 128, 132, //Gradient color 1
            125, 16, 228, 232, //Gradient color 2
            10, //Gradient ratio 1,
            50, //Gradient ratio 2
            0, 128, 1, 0, //BlurX
            0, 192, 2, 0, //BlurY,
            0, 128, 45, 0, //Angle
            205, 204, 65, 0, //Distance,
            192, 2, //Strength,
            117
        };

        [Test]
        public void ReadTest() {
            var filter = ReadFilter<GradientBevelFilter>(_etalon);
            AssertFilters.AreEqual(GetFilter(), filter, "GradientGlow");
        }

        [Test]
        public void WriteTest() {
            WriteFilter(GetFilter(), _etalon);
        }

        private static GradientBevelFilter GetFilter() {
            return new GradientBevelFilter {
                BlurX = 1.5,
                BlurY = 2.75,
                Passes = 5,
                Angle = 45.5,
                Distance = 65.8f,
                Strength = 2.75,
                CompositeSource = true,
                InnerGlow = false,
                Knockout = true,
                OnTop = true,
                GradientColors = {
                    new GradientRecordRGBA {Ratio = 10, Color = {Red = 25, Green = 168, Blue = 128, Alpha = 132}},
                    new GradientRecordRGBA {Ratio = 50, Color = {Red = 125, Green = 16, Blue = 228, Alpha = 232}},
                },
            };
        }
    }
}
