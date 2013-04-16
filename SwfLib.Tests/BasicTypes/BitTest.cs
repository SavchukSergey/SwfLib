using System.IO;
using Code.SwfLib;
using NUnit.Framework;

namespace SwfLib.Tests.BasicTypes {
    [TestFixture]
    public class BitTest {

        [Test]
        public void ReadBitTest() {
            var mem = new MemoryStream();
            mem.WriteByte(0xaa);
            mem.WriteByte(0x73);
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);

            Assert.AreEqual(true, reader.ReadBit(), "Bit 0");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 1");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 2");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 3");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 4");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 5");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 6");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 7");

            Assert.AreEqual(false, reader.ReadBit(), "Bit 8");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 9");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 10");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 11");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 12");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 13");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 14");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 15");

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void WriteBitTest() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);

            writer.WriteBit(true);
            writer.WriteBit(false);
            writer.WriteBit(true);
            writer.WriteBit(false);
            writer.WriteBit(true);
            writer.WriteBit(false);
            writer.WriteBit(true);
            writer.WriteBit(false);

            writer.WriteBit(false);
            writer.WriteBit(true);
            writer.WriteBit(true);
            writer.WriteBit(true);
            writer.WriteBit(false);
            writer.WriteBit(false);
            writer.WriteBit(true);
            writer.WriteBit(true);

            mem.Seek(0, SeekOrigin.Begin);

            Assert.AreEqual(0xaa, mem.ReadByte(), "Byte 0");
            Assert.AreEqual(0x73, mem.ReadByte(), "Byte 1");

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadUnsignedBits2Test() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);

            writer.WriteBit(false);
            writer.WriteBit(false);
            writer.WriteBit(false);
            writer.WriteBit(false);
            writer.WriteBit(true);
            writer.WriteBit(false);
            writer.WriteBit(true);
            writer.WriteBit(false);

            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);

            Assert.AreEqual(false, reader.ReadBit());
            Assert.AreEqual(false, reader.ReadBit());
            Assert.AreEqual(false, reader.ReadBit());
            Assert.AreEqual(false, reader.ReadBit());

            Assert.AreEqual(true, reader.ReadBit());
            Assert.AreEqual(false, reader.ReadBit());
            Assert.AreEqual(true, reader.ReadBit());
            Assert.AreEqual(false, reader.ReadBit());
        }

        [Test]
        public void ReadUnsignedBitsTest() {
            var mem = new MemoryStream();
            mem.WriteByte(0xaa);
            mem.WriteByte(0xc3);
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);

            const int bits = 10;

            Assert.AreEqual(0x2ab, reader.ReadUnsignedBits(bits), "Value");

            Assert.AreEqual(false, reader.ReadBit(), "Bit 10");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 11");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 12");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 13");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 14");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 15");

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void WriteUnsignedBitsTest() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUnsignedBits(0x2ab, 10);
            writer.WriteBit(false);
            writer.WriteBit(false);
            writer.WriteBit(false);
            writer.WriteBit(false);
            writer.WriteBit(true);
            writer.WriteBit(true);

            mem.Seek(0, SeekOrigin.Begin);
            Assert.AreEqual(0xaa, mem.ReadByte());
            Assert.AreEqual(0xc3, mem.ReadByte());

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadSignedBitsPositiveTest() {
            var mem = new MemoryStream();
            mem.WriteByte(0x2a);
            mem.WriteByte(0xc3);
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);

            Assert.AreEqual(0x0ab, reader.ReadSignedBits(10), "Value");

            Assert.AreEqual(false, reader.ReadBit(), "Bit 10");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 11");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 12");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 13");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 14");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 15");

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void WriteSignedBitsPositiveTest() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteSignedBits(0x0ab, 10);
            writer.WriteBit(false);
            writer.WriteBit(false);
            writer.WriteBit(false);
            writer.WriteBit(false);
            writer.WriteBit(true);
            writer.WriteBit(true);

            mem.Seek(0, SeekOrigin.Begin);

            Assert.AreEqual(0x2a, mem.ReadByte());
            Assert.AreEqual(0xc3, mem.ReadByte());

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadSignedBitsNegativeTest() {
            var mem = new MemoryStream();
            mem.WriteByte(0xaa);
            mem.WriteByte(0xc3);
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);

            Assert.AreEqual(-0x155, reader.ReadSignedBits(10), "Value");

            Assert.AreEqual(false, reader.ReadBit(), "Bit 10");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 11");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 12");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 13");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 14");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 15");

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void WriteSignedBitsNegativeTest() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteSignedBits(-0x155, 10);
            writer.WriteBit(false);
            writer.WriteBit(false);
            writer.WriteBit(false);
            writer.WriteBit(false);
            writer.WriteBit(true);
            writer.WriteBit(true);

            mem.Seek(0, SeekOrigin.Begin);

            Assert.AreEqual(0xaa, mem.ReadByte());
            Assert.AreEqual(0xc3, mem.ReadByte());

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }
    }
}
