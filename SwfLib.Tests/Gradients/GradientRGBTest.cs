using Code.SwfLib;
using Code.SwfLib.Gradients;
using Code.SwfLib.Tests.Asserts;
using NUnit.Framework;

namespace SwfLib.Tests.Gradients {
    [TestFixture]
    public class GradientRGBTest : BaseGradientTest<GradientRGB> {

        private readonly byte[] _etalon = new byte[] { 0x92,
            0, //Ratio 0 
            10, 150, 155, // Color 0,
            100, // Ratio 1,
            120, 50, 55 //Color 2
        };

        [Test]
        public void ReadTest() {
            var gradient = ReadGradient(_etalon);
            AssertGradients.AreEqual(GetGradient(), gradient, "Gradient");
        }

        [Test]
        public void WriteTest() {
            var gradient = GetGradient();
            WriteGradient(gradient, _etalon);
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

        protected override GradientRGB Read(ISwfStreamReader reader) {
            return reader.ReadGradientRGB();
        }

        protected override void Write(ISwfStreamWriter writer, GradientRGB gradient) {
            writer.WriteGradientRGB(gradient);
        }
    }
}
