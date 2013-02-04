using System.IO;
using Code.SwfLib.Data;
using NUnit.Framework;

namespace Code.SwfLib.Tests.BasicTypes {
    public class MatrixTest : TestFixtureBase {

        [Test]
        public void ReadMatrixFromBitsTest() {
            var mem = new MemoryStream();
            WriteBits(mem,
                "1", "10011", "010.10000000.00000000", "001.11000000.00000000",
                "1", "10011", "011.01000000.00000000", "000.10000000.00000000",
                "00110", "010000", "011000");
            var reader = new SwfStreamReader(mem);
            SwfMatrix matrix = reader.ReadMatrix();
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
            Assert.AreEqual(matrix.ScaleX, 2.5);
            Assert.AreEqual(matrix.ScaleY, 1.75);
            Assert.AreEqual(matrix.RotateSkew0, 3.25);
            Assert.AreEqual(matrix.RotateSkew1, 0.5);
            Assert.AreEqual(matrix.TranslateX, 16);
            Assert.AreEqual(matrix.TranslateY, 24);
        }

        [Test]
        public void WriteMatrixFromBitsTest() {
            var mem = new MemoryStream();
            var matrix = new SwfMatrix {
                HasScale = true,
                ScaleX = 2.5,
                ScaleY = 1.75,
                HasRotate = true,
                RotateSkew0 = 3.25,
                RotateSkew1 = 0.5,
                TranslateX = 16,
                TranslateY = 24
            };
            var writer = new SwfStreamWriter(mem);
            writer.WriteMatrix(ref matrix);
            CheckBits(mem,
                "1", "10011", "010.10000000.00000000", "001.11000000.00000000",
                "1", "10011", "011.01000000.00000000", "000.10000000.00000000",
                "00110", "010000", "011000");
        }
    }
}
