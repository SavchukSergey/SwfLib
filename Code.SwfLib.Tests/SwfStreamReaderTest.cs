using System.IO;
using Code.SwfLib.Tags;
using NUnit.Framework;

namespace Code.SwfLib.Tests {
    [TestFixture]
    public class SwfStreamReaderTest {

        [Test]
        public void ReadFixedPoint8Test() {
            var mem = new MemoryStream();
            const int val = 0xc3aa;
            const byte hi = val >> 8;
            const byte low = val & 0xff;
            const double expected = hi + low / 256.0;
            mem.WriteByte(low);
            mem.WriteByte(hi);
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);
            double actual = reader.ReadFixedPoint8();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReadFixedPoint16FromBitsTest()
        {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            const int val = 0x03aa4523;
            const ushort hi = val >> 16;
            const ushort low = val & 0xffff;
            const double expected = hi + low / 65536.0;
            var bits = new BitsCount(hi).GetUnsignedBits();
            writer.WriteUnsignedBits(hi, bits);
            writer.WriteUnsignedBits(low, 16);
            writer.FlushBits();
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);
            double actual = reader.ReadFixedPoint16(bits + 16);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReadBitTest() {
            var mem = new MemoryStream();
            mem.WriteByte(0xaa);
            mem.WriteByte(0xc3);
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

            Assert.AreEqual(true, reader.ReadBit(), "Bit 8");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 9");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 10");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 11");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 12");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 13");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 14");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 15");

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadUnsignedBitsTest() {
            var mem = new MemoryStream();
            mem.WriteByte(0xaa);
            mem.WriteByte(0xc3);
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);

            var bits = 10;

            Assert.AreEqual(0xaac3 >> (16 - bits), reader.ReadUnsignedBits((uint)bits), "Value");

            Assert.AreEqual(false, reader.ReadBit(), "Bit 10");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 11");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 12");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 13");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 14");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 15");

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadSignedBitsPositiveTest() {
            var mem = new MemoryStream();
            mem.WriteByte(0x2a);
            mem.WriteByte(0xc3);
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);

            Assert.AreEqual(171, reader.ReadSignedBits(10), "Value");

            Assert.AreEqual(false, reader.ReadBit(), "Bit 10");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 11");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 12");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 13");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 14");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 15");

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadSignedBitsNegativeTest() {
            var mem = new MemoryStream();
            mem.WriteByte(0xaa);
            mem.WriteByte(0xc3);
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);

            Assert.AreEqual(-341, reader.ReadSignedBits(10), "Value");

            Assert.AreEqual(false, reader.ReadBit(), "Bit 10");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 11");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 12");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 13");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 14");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 15");

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadUInt32Test() {
            var mem = new MemoryStream();
            mem.WriteByte(0x20);
            mem.WriteByte(0x71);
            mem.WriteByte(0x6e);
            mem.WriteByte(0x45);
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);

            Assert.AreEqual(0x456e7120, reader.ReadUInt32(), "Value");

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadUInt16Test() {
            var mem = new MemoryStream();
            mem.WriteByte(0x12);
            mem.WriteByte(0xe7);
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);
            Assert.AreEqual(0xe712, reader.ReadUInt16(), "Value");

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void AlignToByteTest() {
            var mem = new MemoryStream();
            mem.WriteByte(0xaa);
            mem.WriteByte(0xc3);
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);

            Assert.AreEqual(true, reader.ReadBit(), "Bit 0");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 1");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 2");
            reader.AlignToByte();

            Assert.AreEqual(true, reader.ReadBit(), "Bit 8");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 9");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 10");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 11");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 12");
            Assert.AreEqual(false, reader.ReadBit(), "Bit 13");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 14");
            Assert.AreEqual(true, reader.ReadBit(), "Bit 15");

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadShortTagDataTest() {
            const SwfTagType tagType = SwfTagType.Export;
            var data = new byte[10];
            for (var i = 0; i < data.Length; i++) {
                data[i] = (byte)(i & 0xff);
            }
            var header = ((int)tagType << 6) | data.Length;
            var mem = new MemoryStream();
            mem.WriteByte((byte)(header & 0xff));
            mem.WriteByte((byte)(header >> 8));
            mem.Write(data, 0, data.Length);
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);
            var tagData = reader.ReadTagData();
            Assert.IsNotNull(tagData);
            Assert.AreEqual(tagType, tagData.Type);
            Assert.IsNotNull(tagData.Data);
            AssertExt.AreEqual(data, tagData.Data, "Data should be equal");
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void ReadLongTagDataTest() {
            const SwfTagType tagType = SwfTagType.Export;
            var data = new byte[4096];
            for (var i = 0; i < data.Length; i++) {
                data[i] = (byte)(i & 0xff);
            }
            const int header = ((int)tagType << 6) | 0x3f;
            var mem = new MemoryStream();
            mem.WriteByte(header & 0xff);
            mem.WriteByte(header >> 8);
            var tagLength = data.Length;
            mem.WriteByte((byte)((tagLength >> 0) & 0xff));
            mem.WriteByte((byte)((tagLength >> 8) & 0xff));
            mem.WriteByte((byte)((tagLength >> 16) & 0xff));
            mem.WriteByte((byte)((tagLength >> 24) & 0xff));

            mem.Write(data, 0, data.Length);
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);
            var tagData = reader.ReadTagData();
            Assert.IsNotNull(tagData);
            Assert.AreEqual(tagType, tagData.Type);
            Assert.IsNotNull(tagData.Data);
            AssertExt.AreEqual(data, tagData.Data, "Data should be equal");
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }
    }
}
