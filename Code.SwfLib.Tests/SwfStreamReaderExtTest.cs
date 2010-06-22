using System;
using System.IO;
using System.Linq;
using System.Text;
using Code.SwfLib.Data;
using Code.SwfLib.Tags;
using NUnit.Framework;

namespace Code.SwfLib.Tests {
    [TestFixture]
    public class SwfStreamReaderExtTest : TestFixtureBase {


        [Test]
        public void ReadMatrixTest() {
            var reader = new SwfTagReader(10);
            var tags =
                GetTagBinariesFromSwfResource("Matrix-compiled.swf")
                .Where(item => item.Type == SwfTagType.PlaceObject2);
            var tagData = tags.First();
            var tag = reader.ReadPlaceObject2Tag(tagData);
            Assert.AreEqual(20.5, tag.Matrix.Value.ScaleX);
            Assert.AreEqual(17.25, tag.Matrix.Value.ScaleY);

            tagData = tags.Skip(1).First();
            tag = reader.ReadPlaceObject2Tag(tagData);
            Assert.AreEqual(0.5, tag.Matrix.Value.ScaleX);
            Assert.AreEqual(1.25, tag.Matrix.Value.ScaleY);

            tagData = tags.Skip(2).First();
            tag = reader.ReadPlaceObject2Tag(tagData);
            Assert.AreEqual(0.5, tag.Matrix.Value.ScaleX);
            Assert.AreEqual(-1.25, tag.Matrix.Value.ScaleY);
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
            var matrix = reader.ReadMatrix();
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
            Assert.AreEqual(matrix.ScaleX, 2.5);
            Assert.AreEqual(matrix.ScaleY, 1.75);
            Assert.AreEqual(matrix.RotateSkew0, 3.25);
            Assert.AreEqual(matrix.RotateSkew1, 0.5);
            Assert.AreEqual(matrix.TranslateX, 16);
            Assert.AreEqual(matrix.TranslateY, 24);
        }

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
            writer.WriteRect(rect);
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
        public void ReadRectTest() {
            var mem = new MemoryStream();
            WriteBits(mem, "01100", "0000.00000100", "0100.10001111", "0000.00001000", "0000.11101110");
            var reader = new SwfStreamReader(mem);
            var rect = reader.ReadRect();
            Assert.AreEqual(0x004, rect.XMin, "Left");
            Assert.AreEqual(0x48f, rect.XMax, "Right");
            Assert.AreEqual(0x008, rect.YMin, "Top");
            Assert.AreEqual(0x0ee, rect.YMax, "Bottom");

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
            var val = reader.ReadRGB();
            Assert.AreEqual(0x0a, val.Red, "Red");
            Assert.AreEqual(0xff, val.Green, "Green");
            Assert.AreEqual(0x83, val.Blue, "Blue");

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }
    }
}