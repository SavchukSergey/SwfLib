using System.IO;
using Code.SwfLib.Data;
using NUnit.Framework;

namespace Code.SwfLib.Tests {
    [TestFixture]
    public class SwfStreamReaderExtTest : TestFixtureBase {

        [Test]
        public void ReadSwfFileInfoTest() {
            var mem = new MemoryStream();
            mem.WriteByte((byte)'C');
            mem.WriteByte((byte)'W');
            mem.WriteByte((byte)'S');
            mem.WriteByte(10);
            mem.WriteByte(0x78);
            mem.WriteByte(0x56);
            mem.WriteByte(0x34);
            mem.WriteByte(0x12);
            mem.Seek(0, SeekOrigin.Begin);

            var reader = new SwfStreamReader(mem);
            var fileInfo = reader.ReadSwfFileInfo();
            Assert.AreEqual("CWS", fileInfo.Format);
            Assert.AreEqual(10, fileInfo.Version);
            Assert.AreEqual(0x12345678, fileInfo.FileLength);

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");

        }

        [Test]
        public void ReadSwfHeaderTest() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            var rect = new SwfRect {
                XMin = 0x004,
                XMax = 0x48f,
                YMin = 0x008,
                YMax = 0x0ee
            };
            writer.WriteRect(ref rect);
            writer.WriteFixedPoint8(23.75);
            writer.WriteUInt16(20);
            mem.Seek(0, SeekOrigin.Begin);

            var reader = new SwfStreamReader(mem);
            var hdr = reader.ReadSwfHeader();
            Assert.AreEqual(rect, hdr.FrameSize);
            Assert.AreEqual(23.75, hdr.FrameRate);
            Assert.AreEqual(20, hdr.FrameCount);

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadRGBTest() {
            var mem = new MemoryStream();
            mem.WriteByte(0x0a);
            mem.WriteByte(0xff);
            mem.WriteByte(0x83);
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);
            SwfRGB val;
            reader.ReadRGB(out val);
            Assert.AreEqual(0x0a, val.Red, "Red");
            Assert.AreEqual(0xff, val.Green, "Green");
            Assert.AreEqual(0x83, val.Blue, "Blue");

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadRGBATest() {
            var mem = new MemoryStream();
            mem.WriteByte(0x0a);
            mem.WriteByte(0xff);
            mem.WriteByte(0x83);
            mem.WriteByte(0x12);
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);
            SwfRGBA val;
            reader.ReadRGBA(out val);
            Assert.AreEqual(0x0a, val.Red, "Red");
            Assert.AreEqual(0xff, val.Green, "Green");
            Assert.AreEqual(0x83, val.Blue, "Blue");
            Assert.AreEqual(0x12, val.Alpha, "Alpha");

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadARGBTest() {
            var mem = new MemoryStream();
            mem.WriteByte(0x12);
            mem.WriteByte(0x0a);
            mem.WriteByte(0xff);
            mem.WriteByte(0x83);
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);
            var val = reader.ReadARGB();
            Assert.AreEqual(0x12, val.Alpha, "Alpha");
            Assert.AreEqual(0x0a, val.Red, "Red");
            Assert.AreEqual(0xff, val.Green, "Green");
            Assert.AreEqual(0x83, val.Blue, "Blue");

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadRectTest() {
            var mem = new MemoryStream();
            WriteBits(mem, "01100", "0000.00000100", "0100.10001111", "0000.00001000", "0000.11101110");
            var reader = new SwfStreamReader(mem);
            SwfRect rect;
            reader.ReadRect(out rect);
            Assert.AreEqual(0x004, rect.XMin, "Left");
            Assert.AreEqual(0x48f, rect.XMax, "Right");
            Assert.AreEqual(0x008, rect.YMin, "Top");
            Assert.AreEqual(0x0ee, rect.YMax, "Bottom");

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");

        }

        [Test]
        public void ReadMatrixFromBitsTest() {
            var mem = new MemoryStream();
            WriteBits(mem,
                "1", "10011", "010.10000000.00000000", "001.11000000.00000000",
                "1", "10011", "011.01000000.00000000", "000.10000000.00000000",
                "00110", "010000", "011000");
            var reader = new SwfStreamReader(mem);
            SwfMatrix matrix;
            reader.ReadMatrix(out matrix);
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
            Assert.AreEqual(matrix.ScaleX, 2.5);
            Assert.AreEqual(matrix.ScaleY, 1.75);
            Assert.AreEqual(matrix.RotateSkew0, 3.25);
            Assert.AreEqual(matrix.RotateSkew1, 0.5);
            Assert.AreEqual(matrix.TranslateX, 16);
            Assert.AreEqual(matrix.TranslateY, 24);
        }

        [Test]
        public void ReadColorTransformRGBFromBitsMultTest() {
            var mem = new MemoryStream();
            WriteBits(mem,
                "0", "1", "1001", "0.00001010", "0.11100000", "1.11110110");
            var reader = new SwfStreamReader(mem);
            var color = reader.ReadColorTransformRGB();
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
            Assert.AreEqual(10, color.RedMultTerm);
            Assert.AreEqual(224, color.GreenMultTerm);
            Assert.AreEqual(-10, color.BlueMultTerm);

            Assert.IsFalse(color.RedAddTerm.HasValue);
            Assert.IsFalse(color.GreenAddTerm.HasValue);
            Assert.IsFalse(color.BlueAddTerm.HasValue);

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadColorTransformRGBFromBitsAddTest() {
            var mem = new MemoryStream();
            WriteBits(mem,
                "1", "0", "1001", "0.00001010", "1.11110110", "0.11100000");
            var reader = new SwfStreamReader(mem);
            var color = reader.ReadColorTransformRGB();
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
            Assert.AreEqual(10, color.RedAddTerm);
            Assert.AreEqual(-10, color.GreenAddTerm);
            Assert.AreEqual(224, color.BlueAddTerm);

            Assert.IsFalse(color.RedMultTerm.HasValue);
            Assert.IsFalse(color.GreenMultTerm.HasValue);
            Assert.IsFalse(color.BlueMultTerm.HasValue);

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadColorTransformRGBFromBitsMultAddTest() {
            var mem = new MemoryStream();
            WriteBits(mem,
                "1", "1", "1001", "0.00001010", "1.11110110", "0.11100000", "1.11110111", "0.10000001", "0.00010000");
            var reader = new SwfStreamReader(mem);
            var color = reader.ReadColorTransformRGB();
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
            Assert.AreEqual(10, color.RedMultTerm);
            Assert.AreEqual(-10, color.GreenMultTerm);
            Assert.AreEqual(224, color.BlueMultTerm);

            Assert.AreEqual(-9, color.RedAddTerm);
            Assert.AreEqual(129, color.GreenAddTerm);
            Assert.AreEqual(16, color.BlueAddTerm);

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadColorTransformRGBAFromBitsMultTest() {
            var mem = new MemoryStream();
            WriteBits(mem,
                "0", "1", "1001", "0.00001010", "0.11100000", "1.11110110", "0.00010001");
            var reader = new SwfStreamReader(mem);
            var color = reader.ReadColorTransformRGBA();
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
            Assert.AreEqual(10, color.RedMultTerm);
            Assert.AreEqual(224, color.GreenMultTerm);
            Assert.AreEqual(-10, color.BlueMultTerm);
            Assert.AreEqual(17, color.AlphaMultTerm);

            Assert.IsFalse(color.RedAddTerm.HasValue);
            Assert.IsFalse(color.GreenAddTerm.HasValue);
            Assert.IsFalse(color.BlueAddTerm.HasValue);
            Assert.IsFalse(color.AlphaAddTerm.HasValue);

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadColorTransformRGBAFromBitsAddTest() {
            var mem = new MemoryStream();
            WriteBits(mem,
                "1", "0", "1001", "0.00001010", "1.11110110", "0.11100000", "0.11000000");
            var reader = new SwfStreamReader(mem);
            var color = reader.ReadColorTransformRGBA();
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
            Assert.AreEqual(10, color.RedAddTerm);
            Assert.AreEqual(-10, color.GreenAddTerm);
            Assert.AreEqual(224, color.BlueAddTerm);
            Assert.AreEqual(192, color.AlphaAddTerm);

            Assert.IsFalse(color.RedMultTerm.HasValue);
            Assert.IsFalse(color.GreenMultTerm.HasValue);
            Assert.IsFalse(color.BlueMultTerm.HasValue);
            Assert.IsFalse(color.AlphaMultTerm.HasValue);

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadColorTransformRGBAFromBitsMultAddTest() {
            var mem = new MemoryStream();
            WriteBits(mem,
                "1", "1", "1001", "0.00001010", "1.11110110", "0.11100000", "0.10110000",
                                  "1.11110111", "0.10000001", "0.00010000", "0.00001111");
            var reader = new SwfStreamReader(mem);
            var color = reader.ReadColorTransformRGBA();
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
            Assert.AreEqual(10, color.RedMultTerm);
            Assert.AreEqual(-10, color.GreenMultTerm);
            Assert.AreEqual(224, color.BlueMultTerm);
            Assert.AreEqual(176, color.AlphaMultTerm);

            Assert.AreEqual(-9, color.RedAddTerm);
            Assert.AreEqual(129, color.GreenAddTerm);
            Assert.AreEqual(16, color.BlueAddTerm);
            Assert.AreEqual(15, color.AlphaAddTerm);

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }


    }
}