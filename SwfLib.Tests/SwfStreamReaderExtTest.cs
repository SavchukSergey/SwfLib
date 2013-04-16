using System.IO;
using Code.SwfLib.Data;
using NUnit.Framework;
using SwfLib;
using SwfLib.Data;

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

    }
}