using Code.SwfLib.Gradients;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Gradients {
    [TestFixture]
    public class GradientRGBTest {

        private byte[] _etalon = new byte[] {};
        
        public void ReadTest() {
        }

        private static GradientRGB GetGradient() {
            return new GradientRGB {
                InterpolationMode = InterpolationMode.Linear,
                SpreadMode = SpreadMode.Repeat,
                GradientRecords = {
                    new GradientRecordRGB {Ratio = 0, Color = {Red = 10, Green = 150, Blue = 155}},
                    new GradientRecordRGB {Ratio = 100, Color = {Red = 120, Green = 50, Blue = 55}},
                }
            };
        }
    }
}
