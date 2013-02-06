using Code.SwfLib.Filters;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Asserts {
    public static class AssertFilters {

        public static void AreEqual(ConvolutionFilter expected, ConvolutionFilter actual) {
            Assert.AreEqual(expected.Divisor, actual.Divisor);
            Assert.AreEqual(expected.Bias, actual.Bias);

            Assert.AreEqual(expected.MatrixX, actual.MatrixX);
            Assert.AreEqual(expected.MatrixY, actual.MatrixY);
            for (var x = 0; x < actual.MatrixX; x++) {
                for (var y = 0; y < actual.MatrixX; y++) {
                    Assert.AreEqual(expected.Matrix[y, x], actual.Matrix[y, x]);
                }
            }

            AssertColors.AreEqual(expected.DefaultColor, actual.DefaultColor, "DefaultColor");
            Assert.AreEqual(expected.Reserved, actual.Reserved);
            Assert.AreEqual(expected.Clamp, actual.Clamp);
            Assert.AreEqual(expected.PreserveAlpha, actual.PreserveAlpha);
        }
    }
}
