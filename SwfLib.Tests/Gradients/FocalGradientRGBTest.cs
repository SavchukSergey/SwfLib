using NUnit.Framework;
using SwfLib.Data;
using SwfLib.Gradients;
using SwfLib.Tests.Asserts;

namespace SwfLib.Tests.Gradients {
    [TestFixture]
    public class FocalGradientRGBTest : BaseGradientTest<FocalGradientRGB> {

        private readonly byte[] _etalon = new byte[] { 0x92,
            0, //Ratio 0 
            10, 150, 155, // Color 0,
            100, // Ratio 1,
            120, 50, 55, //Color 2,
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

        private static FocalGradientRGB GetGradient() {
            return new FocalGradientRGB {
                InterpolationMode = InterpolationMode.Linear,
                SpreadMode = SpreadMode.Repeat,
                FocalPoint = (int)(0.2 * 256) / 256.0,
                GradientRecords = {
                    new GradientRecordRGB {Ratio = 0, Color = new SwfRGB{Red = 10, Green = 150, Blue = 155}},
                    new GradientRecordRGB {Ratio = 100, Color = new SwfRGB {Red = 120, Green = 50, Blue = 55}},
                }
            };
        }

        protected override FocalGradientRGB Read(ISwfStreamReader reader) {
            return reader.ReadFocalGradientRGB();
        }

        protected override void Write(ISwfStreamWriter writer, FocalGradientRGB gradient) {
            writer.WriteFocalGradientRGB(gradient);
        }
    }
}
