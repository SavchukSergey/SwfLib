using System.IO;
using Code.SwfLib.Data;
using NUnit.Framework;

namespace Code.SwfLib.Tests
{
    [TestFixture]
    public class SwfStreamReaderExtTest : TestFixtureBase
    {

        [Test]
        public void ReadSwfFileInfoTest()
        {
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
        public void ReadSwfHeaderTest()
        {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            var rect = new SwfRect
            {
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
        public void ReadRGBTest()
        {
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
        public void ReadRGBATest()
        {
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
        public void ReadARGBTest()
        {
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
        public void ReadMatrixFromBitsTest()
        {
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


    }
}