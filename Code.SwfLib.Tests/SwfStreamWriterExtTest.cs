using System;
using System.IO;
using Code.SwfLib.Data;
using NUnit.Framework;

namespace Code.SwfLib.Tests {
    [TestFixture]
    public class SwfStreamWriterExtTest : TestFixtureBase {

        [Test]
        public void WriteSwfFileInfoTest() {
            var fileInfo = new SwfFileInfo {
                Format = "CWS",
                Version = 10,
                FileLength = 0x12345678
            };
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteSwfFileInfo(fileInfo);

            mem.Seek(0, SeekOrigin.Begin);

            Assert.AreEqual((byte)'C', mem.ReadByte());
            Assert.AreEqual((byte)'W', mem.ReadByte());
            Assert.AreEqual((byte)'S', mem.ReadByte());

            Assert.AreEqual(10, mem.ReadByte());

            Assert.AreEqual(0x78, mem.ReadByte());
            Assert.AreEqual(0x56, mem.ReadByte());
            Assert.AreEqual(0x34, mem.ReadByte());
            Assert.AreEqual(0x12, mem.ReadByte());

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");

        }

        [Test]
        public void WriteSwfHeaderTest() {
            var hdr = new SwfHeader {
                FrameSize = new SwfRect {
                    XMin = 0x004,
                    XMax = 0x48f,
                    YMin = 0x008,
                    YMax = 0x0ee
                },
                FrameCount = 10,
                FrameRate = 12.25
            };
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteSwfHeader(hdr);

            mem.Seek(0, SeekOrigin.Begin);

            Assert.AreEqual(0x60, mem.ReadByte(), "Byte 0");
            Assert.AreEqual(0x02, mem.ReadByte(), "Byte 1");
            Assert.AreEqual(0x24, mem.ReadByte(), "Byte 2");
            Assert.AreEqual(0x78, mem.ReadByte(), "Byte 3");
            Assert.AreEqual(0x04, mem.ReadByte(), "Byte 4");
            Assert.AreEqual(0x07, mem.ReadByte(), "Byte 5");
            Assert.AreEqual(0x70, mem.ReadByte(), "Byte 6");


            Assert.AreEqual(64, mem.ReadByte(), "Byte 7");
            Assert.AreEqual(12, mem.ReadByte(), "Byte 8");

            Assert.AreEqual(10, mem.ReadByte(), "Byte 9");
            Assert.AreEqual(0, mem.ReadByte(), "Byte 10");

            Assert.AreEqual(mem.Length, mem.Position, "Should reach end of the stream");

        }

        //TODO: Write Test LanguageCode

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
        public void WriteRGBATest()
        {
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
        public void WriteARGBTest()
        {
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

        [Test]
        public void WriteRectTest() {
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

        [Test]
        public void WriteMatrixFromBitsTest() {
            var mem = new MemoryStream();
            var matrix = new SwfMatrix {
                HasScale = true,
                ScaleX = 2.5,
                ScaleY = 1.75,
                HasRotate = true,
                RotateSkew0 = 3.25,
                RotateSkew1 = 0.5,
                TranslateX = 16,
                TranslateY = 24
            };
            var writer = new SwfStreamWriter(mem);
            writer.WriteMatrix(ref matrix);
            CheckBits(mem,
                "1", "10011", "010.10000000.00000000", "001.11000000.00000000",
                "1", "10011", "011.01000000.00000000", "000.10000000.00000000",
                "00110", "010000", "011000");
        }

    }
}
