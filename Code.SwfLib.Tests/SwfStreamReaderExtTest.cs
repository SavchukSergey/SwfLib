using System;
using System.IO;
using System.Text;
using Code.SwfLib.Data;
using NUnit.Framework;

namespace Code.SwfLib.Tests {
    [TestFixture]
    public class SwfStreamReaderExtTest {

        [Test]
        public void ReadSwfFileInfoTest() {
            var mem = new MemoryStream();
            mem.WriteByte((byte) 'C');
            mem.WriteByte((byte) 'W');
            mem.WriteByte((byte) 'S');
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
            writer.WriteFixedPoint16(23.75);
            writer.WriteUInt16(20);
            mem.Seek(0, SeekOrigin.Begin);

            var reader = new SwfStreamReader(mem);
            var hdr = reader.ReadSwfHeader();
            Assert.AreEqual(rect,  hdr.FrameSize);
            Assert.AreEqual(23.75, hdr.FrameRate);
            Assert.AreEqual(20, hdr.FrameCount);

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadRectTest() {
            var mem = new MemoryStream();
            mem.WriteByte(0x60);
            mem.WriteByte(0x02);
            mem.WriteByte(0x24);
            mem.WriteByte(0x78);
            mem.WriteByte(0x04);
            mem.WriteByte(0x07);
            mem.WriteByte(0x70);
            mem.Seek(0, SeekOrigin.Begin);
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