using Code.SwfLib.Gradients;
using Code.SwfLib.Tests.Asserts;
using NUnit.Framework;
using SwfLib.Tests.Gradients;

namespace Code.SwfLib.Tests.Gradients {
    [TestFixture]
    public class GradientRGBATest : BaseGradientTest<GradientRGBA> {

        private readonly byte[] _etalon = new byte[] { 0x92,
            0, //Ratio 0 
            10, 150, 155, 128,// Color 0,
            100, // Ratio 1,
            120, 50, 55, 192 //Color 2
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

        private static GradientRGBA GetGradient() {
            return new GradientRGBA {
                InterpolationMode = InterpolationMode.Linear,
                SpreadMode = SpreadMode.Repeat,
                GradientRecords = {
                    new GradientRecordRGBA {Ratio = 0, Color = {Red = 10, Green = 150, Blue = 155, Alpha = 128}},
                    new GradientRecordRGBA {Ratio = 100, Color = {Red = 120, Green = 50, Blue = 55, Alpha = 192}},
                }
            };
        }

        protected override GradientRGBA Read(ISwfStreamReader reader) {
            return reader.ReadGradientRGBA();
        }

        protected override void Write(ISwfStreamWriter writer, GradientRGBA gradient) {
            writer.WriteGradientRGBA(gradient);
        }
    }
}
