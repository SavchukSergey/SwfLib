using System.IO;
using Code.SwfLib.Data;
using NUnit.Framework;
using SwfLib.Data;

namespace Code.SwfLib.Tests.BasicTypes {
    [TestFixture]
    public class ColorRGBTest {

        [Test]
        public void WriteRGBTest() {
            var val = new SwfRGB(0x0a, 0xff, 0x83);
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteRGB(ref val);
            mem.Seek(0, SeekOrigin.Begin);

            Assert.AreEqual(0x0a, mem.ReadByte(), "Byte 0");
            Assert.AreEqual(0xff, mem.ReadByte(), "Byte 1");
            Assert.AreEqual(0x83, mem.ReadByte(), "Byte 2");

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
    }
}
