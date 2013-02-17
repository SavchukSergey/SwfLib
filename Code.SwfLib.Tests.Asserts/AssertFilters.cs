using System;
using System.Collections.Generic;
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

        public static void AreEqual(BlurFilter expected, BlurFilter actual) {
            Assert.AreEqual(expected.BlurX, actual.BlurX);
            Assert.AreEqual(expected.BlurY, actual.BlurY);
            Assert.AreEqual(expected.Passes, actual.Passes);
            Assert.AreEqual(expected.Reserved, actual.Reserved);
        }

        public static void AreEqual(BaseFilter expected, BaseFilter actual) {
            Assert.AreEqual(expected.Type, actual.Type);
            switch (expected.Type) {
                case FilterType.Blur:
                    AreEqual((BlurFilter)expected, (BlurFilter)actual);
                    break;
                case FilterType.Convolution:
                    AreEqual((ConvolutionFilter)expected, (ConvolutionFilter)actual);
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        public static void AreEqual(IList<BaseFilter> expected, IList<BaseFilter> actual) {
            Assert.AreEqual(expected.Count, actual.Count);
            for (var i = 0; i < expected.Count; i++) {
                AreEqual(expected[i], actual[i]);
            }
        }
    }
}
