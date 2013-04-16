using System.IO;
using Code.SwfLib.Data;
using NUnit.Framework;

namespace Code.SwfLib.Tests.BasicTypes {
    [TestFixture]
    public class ColorRGBATest {

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
        public void WriteRGBATest() {
            var val = new SwfRGBA(0x0a, 0xff, 0x83, 0x12);
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteRGBA(ref val);
            mem.Seek(0, SeekOrigin.Begin);

            Assert.AreEqual(0x0a, mem.ReadByte(), "Byte 0");
            Assert.AreEqual(0xff, mem.ReadByte(), "Byte 1");
            Assert.AreEqual(0x83, mem.ReadByte(), "Byte 2");
            Assert.AreEqual(0x12, mem.ReadByte(), "Byte 3");

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
        public void WriteARGBTest() {
            var val = new SwfRGBA(0x0a, 0xff, 0x83, 0x12);
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteARGB(val);
            mem.Seek(0, SeekOrigin.Begin);

            Assert.AreEqual(0x12, mem.ReadByte(), "Byte 0");
            Assert.AreEqual(0x0a, mem.ReadByte(), "Byte 1");
            Assert.AreEqual(0xff, mem.ReadByte(), "Byte 2");
            Assert.AreEqual(0x83, mem.ReadByte(), "Byte 3");

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

    }
}
