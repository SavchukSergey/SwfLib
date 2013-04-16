using System.IO;
using NUnit.Framework;
using SwfLib.Data;

namespace SwfLib.Tests.BasicTypes {
    [TestFixture]
    public class RectTest : TestFixtureBase {

        [Test]
        public void ReadRectTest() {
            var etalon = new SwfRect {
                XMin = 0,
                XMax = 11000,
                YMin = 0,
                YMax = 8000
            };
            var mem = new MemoryStream(new byte[] { 0x78, 0x00, 0x05, 0x5f, 0x00, 0x00, 0x0f, 0xa0, 0x00 });
            var reader = new SwfStreamReader(mem);
            SwfRect rect = reader.ReadRect();
            Assert.IsTrue(AreEqual(etalon, rect));
            Assert.AreEqual(mem.Length, mem.Position);
        }

        [Test]
        public void WriteRectTest() {
            var rect = new SwfRect {
                XMin = 0,
                XMax = 11000,
                YMin = 0,
                YMax = 8000
            };
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteRect(ref rect);
            Assert.AreEqual(new byte[] { 0x78, 0x00, 0x05, 0x5f, 0x00, 0x00, 0x0f, 0xa0, 0x00 }, mem.ToArray());
        }

        [Test]
        public void ReadRectMustBeByteAlignedTest() {
            var etalon = new SwfRect {
                XMin = 0,
                XMax = 11000,
                YMin = 0,
                YMax = 8000
            };
            var mem = new MemoryStream(new byte[] { 0x78, 0x00, 0x05, 0x5f, 0x00, 0x00, 0x0f, 0xa0, 0x00, 0xb3 });
            var reader = new SwfStreamReader(mem);
            SwfRect rect = reader.ReadRect();
            Assert.IsTrue(AreEqual(etalon, rect));
            var tail = reader.ReadUnsignedBits(8);
            Assert.AreEqual(0xb3, tail);
            Assert.AreEqual(mem.Length, mem.Position);
        }

        [Test]
        public void WriteRectMustbeByteAlignedTest() {
            var rect = new SwfRect {
                XMin = 0,
                XMax = 11000,
                YMin = 0,
                YMax = 8000
            };
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteRect(ref rect);
            writer.WriteUnsignedBits(0xb3, 8);
            Assert.AreEqual(new byte[] { 0x78, 0x00, 0x05, 0x5f, 0x00, 0x00, 0x0f, 0xa0, 0x00, 0xb3 }, mem.ToArray());
        }

        [Test]
        public void ReadRectTest2() {
            var etalon = new SwfRect {
                XMin = 0x004,
                XMax = 0x48f,
                YMin = 0x008,
                YMax = 0x0ee
            };
            var mem = new MemoryStream();
            WriteBits(mem, "01100", "0000.00000100", "0100.10001111", "0000.00001000", "0000.11101110");
            var reader = new SwfStreamReader(mem);
            SwfRect rect = reader.ReadRect();
            Assert.IsTrue(AreEqual(etalon, rect));
            Assert.AreEqual(mem.Length, mem.Position);
        }


        [Test]
        public void WriteRectTest2() {
            var rect = new SwfRect {
                XMin = 0x004,
                XMax = 0x48f,
                YMin = 0x008,
                YMax = 0x0ee
            };
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteRect(ref rect);
            writer.FlushBits();
            CheckBits(mem, "01100", "0000.00000100", "0100.10001111", "0000.00001000", "0000.11101110");
            mem.Seek(0, SeekOrigin.Begin);
        }

        private static bool AreEqual(SwfRect a, SwfRect b) {
            if (a.XMin != b.XMin) return false;
            if (a.XMax != b.XMax) return false;
            if (a.YMin != b.YMin) return false;
            if (a.YMax != b.YMax) return false;
            return true;
        }
    }
}
