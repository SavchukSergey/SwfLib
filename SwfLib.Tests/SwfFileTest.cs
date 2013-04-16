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
    }
}
