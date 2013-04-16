using System.IO;
using System.Linq;
using NUnit.Framework;
using SwfLib.Tags;
using SwfLib.Utils;

namespace SwfLib.Tests {
    [TestFixture]
    public class SwfStreamWriterTest : TestFixtureBase {

        [Test]
        public void WriteFixedPoint16FromBitsTest() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            const int val = 0x03aa4523;
            const ushort hi = val >> 16;
            const ushort low = val & 0xffff;
            const double expected = hi + low / 65536.0;
            var bits = new SignedBitsCount(hi).GetBits() + 16;
            writer.WriteFixedPoint16(expected, bits);
            writer.FlushBits();
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);
            double actual = reader.ReadFixedPoint16(bits);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WriteNegativeFixedPoint16FromBitsTest() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            var bits = new SignedBitsCount(-81920).GetBits();
            writer.WriteFixedPoint16(-1.25, bits);
            writer.FlushBits();
            mem.Seek(0, SeekOrigin.Begin);
            var reader = new SwfStreamReader(mem);
            int actual = reader.ReadSignedBits(bits);
            Assert.AreEqual(-81920, actual);
        }

        [Test]
        public void WriteFixedPoint8Test() {
            var mem = new MemoryStream();
            const int val = 0xc3aa;
            const byte hi = val >> 8;
            const byte low = val & 0xff;
            const double expected = hi + low / 256.0;
            var writer = new SwfStreamWriter(mem);
            writer.WriteFixedPoint8(expected);
            mem.Seek(0, SeekOrigin.Begin);
            Assert.AreEqual(low, mem.ReadByte());
            Assert.AreEqual(hi, mem.ReadByte());
        }

        
        [Test]
        public void WriteByteAfterBitsTest() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);

            writer.WriteBit(true);
            writer.WriteBit(false);
            writer.WriteBit(true);
            writer.WriteBit(false);
            writer.WriteBit(true);
            writer.WriteBit(false);

            writer.WriteByte(0xc3);

            mem.Seek(0, SeekOrigin.Begin);

            Assert.AreEqual(0xa8, mem.ReadByte(), "Byte 0");
            Assert.AreEqual(0xc3, mem.ReadByte(), "Byte 1");

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

       

        [Test]
        public void FlushBitsTest() {
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

            writer.WriteBit(true);
            writer.WriteBit(true);
            writer.WriteBit(false);
            writer.WriteBit(false);
            writer.WriteBit(false);
            writer.WriteBit(false);

            writer.FlushBits();

            mem.Seek(0, SeekOrigin.Begin);

            Assert.AreEqual(0xaa, mem.ReadByte(), "Byte 0");
            Assert.AreEqual(0xc0, mem.ReadByte(), "Byte 1");

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void WriteUInt16Test() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16(0xe712);
            mem.Seek(0, SeekOrigin.Begin);

            Assert.AreEqual(0x12, mem.ReadByte());
            Assert.AreEqual(0xe7, mem.ReadByte());

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void WriteUInt32Test() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt32(0x456e7120);
            mem.Seek(0, SeekOrigin.Begin);

            Assert.AreEqual(0x20, mem.ReadByte());
            Assert.AreEqual(0x71, mem.ReadByte());
            Assert.AreEqual(0x6e, mem.ReadByte());
            Assert.AreEqual(0x45, mem.ReadByte());

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void WriteShortFloatTest() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteShortFloat(3.43359375f);
            mem.Seek(0, SeekOrigin.Begin);

            Assert.AreEqual(0xde, mem.ReadByte());
            Assert.AreEqual(0x42, mem.ReadByte());

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void WriteShortTagDataTest() {
            const SwfTagType tagType = SwfTagType.ExportAssets;
            var data = new byte[10];
            for (var i = 0; i < data.Length; i++) {
                data[i] = (byte)(i & 0xff);
            }
            var tagData = new SwfTagData { Type = tagType, Data = data };
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteTagData(tagData);

            var array = mem.ToArray();
            var header = ((int)tagType << 6) | data.Length;
            Assert.AreEqual((byte)(header & 0xff), array[0]);
            Assert.AreEqual((byte)(header >> 8), array[1]);
            array = array.Skip(2).ToArray();
            AssertExt.AreEqual(data, array, "Data should be equal");
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        [Test]
        public void WriteLongTagDataTest() {
            const SwfTagType tagType = SwfTagType.ExportAssets;
            var data = new byte[4096];
            for (var i = 0; i < data.Length; i++) {
                data[i] = (byte)(i & 0xff);
            }
            var tagData = new SwfTagData { Type = tagType, Data = data };
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteTagData(tagData);

            var array = mem.ToArray();
            const int header = ((int)tagType << 6) | 0x3f;
            Assert.AreEqual(header & 0xff, array[0]);
            Assert.AreEqual(header >> 8, array[1]);
            var len = data.Length;
            Assert.AreEqual((byte)((len >> 0) & 0xff), array[2]);
            Assert.AreEqual((byte)((len >> 8) & 0xff), array[3]);
            Assert.AreEqual((byte)((len >> 16) & 0xff), array[4]);
            Assert.AreEqual((byte)((len >> 24) & 0xff), array[5]);
            array = array.Skip(6).ToArray();
            AssertExt.AreEqual(data, array, "Data should be equal");
            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        }

        //[Test]
        //public void AlignToByteTest() {
        //    var mem = new MemoryStream();
        //    mem.WriteByte(0xaa);
        //    mem.WriteByte(0xc3);
        //    mem.Seek(0, SeekOrigin.Begin);
        //    var reader = new SwfStreamReader(mem);

        //    Assert.AreEqual(true, reader.ReadBit(), "Bit 0");
        //    Assert.AreEqual(false, reader.ReadBit(), "Bit 1");
        //    Assert.AreEqual(true, reader.ReadBit(), "Bit 2");
        //    reader.AlignToByte();

        //    Assert.AreEqual(true, reader.ReadBit(), "Bit 8");
        //    Assert.AreEqual(true, reader.ReadBit(), "Bit 9");
        //    Assert.AreEqual(false, reader.ReadBit(), "Bit 10");
        //    Assert.AreEqual(false, reader.ReadBit(), "Bit 11");
        //    Assert.AreEqual(false, reader.ReadBit(), "Bit 12");
        //    Assert.AreEqual(false, reader.ReadBit(), "Bit 13");
        //    Assert.AreEqual(true, reader.ReadBit(), "Bit 14");
        //    Assert.AreEqual(true, reader.ReadBit(), "Bit 15");

        //    Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");
        //}

        [Test]
        public void WriteEncodedU32Byte1Test() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteEncodedU32(0x28);
            Assert.AreEqual(1, mem.Length);
            CheckBits(mem, "00101000");
        }

        [Test]
        public void WriteEncodedU32Bytes2Test() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteEncodedU32(0x3aa8);
            Assert.AreEqual(2, mem.Length);
            CheckBits(mem, "10101000", "01110101");
        }

        [Test]
        public void WriteEncodedU32Bytes3Test() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteEncodedU32(0x013aa8);
            Assert.AreEqual(3, mem.Length);
            CheckBits(mem, "10101000", "11110101", "00000100");
        }

        [Test]
        public void WriteEncodedU32Bytes4Test() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteEncodedU32(0x08013aa8);
            Assert.AreEqual(4, mem.Length);
            CheckBits(mem, "10101000", "11110101", "10000100", "01000000");
        }

        [Test]
        public void WriteEncodedU32Bytes5Test() {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteEncodedU32(0xa8013aa8);
            Assert.AreEqual(5, mem.Length);
            CheckBits(mem, "10101000", "11110101", "10000100", "11000000", "00001010");
        }
    }
}
