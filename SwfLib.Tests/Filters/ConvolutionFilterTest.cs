using Code.SwfLib.Filters;
using Code.SwfLib.Tests.Asserts;
using NUnit.Framework;
using SwfLib.Tests.Asserts;

namespace SwfLib.Tests.Filters {
    [TestFixture]
    public class ConvolutionFilterTest : BaseFilterTest {

        private static readonly byte[] _etalon = new byte[] {5,
          2, //MatrixX
          3, //MatrixY
          51, 51, 19, 64, //Divisor
          0, 0, 196, 65, //Bias
          205, 204, 204, 63,
          41, 92, 135, 64,
          154, 153, 89, 64,
          154, 153, 25, 64,
          195, 245, 168, 192,
          154, 153, 185, 193,
          20, 5, 118, 224, //Default color,
          3
        };

        [Test]
        public void ReadTest() {
            var filter = ReadFilter<ConvolutionFilter>(_etalon);
            AssertFilters.AreEqual(GetFilter(), filter, "GradientGlow");
        }

        [Test]
        public void WriteTest() {
            WriteFilter(GetFilter(), _etalon);
        }

        private static ConvolutionFilter GetFilter() {
            return new ConvolutionFilter {
                Divisor = 2.3f,
                Bias = 24.5f,
                Clamp = true,
                DefaultColor = { Red = 20, Green = 5, Blue = 118, Alpha = 224 },
                PreserveAlpha = true,
                Reserved = 0,
                Matrix = new double[,] { { 1.6f, 2.4f }, { 4.23f, -5.28f }, {3.4f, -23.2f} }
            };
        }
    }
}
