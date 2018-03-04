using System;
using System.IO;
using NUnit.Framework;
using SwfLib.Data;
using SwfLib.Tags.ControlTags;
using SwfLib.Tags.DisplayListTags;

namespace SwfLib.Tests {
    [TestFixture]
    public class SwfFileTest {

        [Test]
        public void ReadWriteTest() {

            var file = new SwfFile {
                FileInfo = { Format = SwfFormat.FWS, Version = 8 },
                Header = { FrameSize = new SwfRect(0, 0, 100, 100), FrameRate = 20.0, FrameCount = 1 },
                Tags = {
                    new FileAttributesTag { UseNetwork = true },
                    new SetBackgroundColorTag { Color = new SwfRGB(10, 224, 224) },
                    new PlaceObject3Tag { BackgroundColor = new SwfRGBA(255,255,255, 1), HasVisible = true},
                    new ShowFrameTag(),
                    new EndTag()
                }
            };
            var mem = new MemoryStream();
            file.WriteTo(mem);
            mem.Seek(0, SeekOrigin.Begin);

            var other = SwfFile.ReadFrom(mem);
            Assert.AreEqual(file.Tags.Count, other.Tags.Count);
        }

        [Test]
        public void CompressZlibTest() {
            var source = new byte[] {
                0x46, 0x57, 0x53, 0x09, 0x20, 0x00, 0x00, 0x00,
                0x78, 0x00, 0x07, 0x08, 0x00, 0x00, 0x11, 0xf8,
                0x00, 0x00, 0x14, 0x01, 0x00, 0x44, 0x11, 0x08,
                0x00, 0x00, 0x00, 0x43, 0x02, 0xff, 0x00, 0x00};
            var target = new MemoryStream();
            SwfFile.Compress(new MemoryStream(source), target, SwfFormat.CWS);

            var res = target.ToArray();
            Assert.AreEqual(0x09, res[3]);
            Assert.AreEqual(0x20, res[4]);
            Assert.AreEqual(0x00, res[5]);
            Assert.AreEqual(0x00, res[6]);
            Assert.AreEqual(0x00, res[7]);
        }

        [Test]
        public void CompressLzmaTest() {
            var source = new byte[]
            {
                0x46, 0x57, 0x53, 0x14, 0x5A, 0xB3, 0xB2, 0x00,
                0x78, 0x00, 0x07, 0xD0, 0x00, 0x00, 0x18, 0x38,
                0x00, 0x00, 0x3C, 0x01, 0x00, 0x44, 0x11, 0x19,
                0x00, 0x00, 0x00, 0x7F, 0x13, 0x80, 0x02, 0x00
            };
            var target = new MemoryStream();
            SwfFile.Compress(new MemoryStream(source), target, SwfFormat.ZWS);

            var res = target.ToArray();
            Assert.AreEqual(0x4C, res[8]);
            Assert.AreEqual(0x5A, res[9]);
            Assert.AreEqual(0x49, res[10]);
            Assert.AreEqual(0x50, res[11]);
            Assert.AreEqual(0x5D, res[12]);
            Assert.AreEqual(0x00, res[13]);
            Assert.AreEqual(0x00, res[14]);
            Assert.AreEqual(0x20, res[15]);
            Assert.AreEqual(0x00, res[16]);
            Assert.AreEqual(0x00, res[17]);
        }
    }
}
