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
                FileInfo = { Format = "FWS", Version = 8 },
                Header = { FrameSize = new SwfRect(0, 0, 100, 100), FrameRate = 20.0, FrameCount = 1 },
                Tags = {
                    new FileAttributesTag { UseNetwork = true },
                    new SetBackgroundColorTag { Color = new SwfRGB(10, 224, 224) },
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
        public void CompressTest() {
            var source = new byte[] {
                0x46, 0x57, 0x53, 0x09, 0x20, 0x00, 0x00, 0x00,
                0x78, 0x00, 0x07, 0x08, 0x00, 0x00, 0x11, 0xf8,
                0x00, 0x00, 0x14, 0x01, 0x00, 0x44, 0x11, 0x08,
                0x00, 0x00, 0x00, 0x43, 0x02, 0xff, 0x00, 0x00};
            var target = new MemoryStream();
            SwfFile.Compress(new MemoryStream(source), target);

            var res = target.ToArray();
            Assert.AreEqual(0x09, res[3]);
            Assert.AreEqual(0x20, res[4]);
            Assert.AreEqual(0x00, res[5]);
            Assert.AreEqual(0x00, res[6]);
            Assert.AreEqual(0x00, res[7]);
        }
    }
}
