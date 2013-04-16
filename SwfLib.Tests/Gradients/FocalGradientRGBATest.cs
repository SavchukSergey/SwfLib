using Code.SwfLib.Gradients;
using Code.SwfLib.Tests.Asserts;
using NUnit.Framework;
using SwfLib.Tests.Gradients;

namespace Code.SwfLib.Tests.Gradients {
    [TestFixture]
    public class FocalGradientRGBATest : BaseGradientTest<FocalGradientRGBA> {

        private readonly byte[] _etalon = new byte[] { 0x92,
            0, //Ratio 0 
            10, 150, 155, 128,// Color 0,
            100, // Ratio 1,
            120, 50, 55, 192, //Color 2,
            51, 0 //Focal point
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

        private static FocalGradientRGBA GetGradient() {
            return new FocalGradientRGBA {
                InterpolationMode = InterpolationMode.Linear,
                SpreadMode = SpreadMode.Repeat,
                FocalPoint = (int)(0.2 * 256) / 256.0,
                GradientRecords = {
                    new GradientRecordRGBA {Ratio = 0, Color = {Red = 10, Green = 150, Blue = 155, Alpha = 128}},
                    new GradientRecordRGBA {Ratio = 100, Color = {Red = 120, Green = 50, Blue = 55, Alpha = 192}},
                }
            };
        }

        protected override FocalGradientRGBA Read(ISwfStreamReader reader) {
            return reader.ReadFocalGradientRGBA();
        }

        protected override void Write(ISwfStreamWriter writer, FocalGradientRGBA gradient) {
            writer.WriteFocalGradientRGBA(gradient);
        }
    }
}
