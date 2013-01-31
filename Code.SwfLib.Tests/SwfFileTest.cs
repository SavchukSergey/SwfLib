using System.IO;
using Code.SwfLib.Data;
using Code.SwfLib.Tags.ControlTags;
using Code.SwfLib.Tags.DisplayListTags;
using NUnit.Framework;

namespace Code.SwfLib.Tests {
    [TestFixture]
    public class SwfFileTest {

        [Ignore]
        [Test]
        public void SimpleBackgroundTest() {

            var file = new SwfFile();
            file.FileInfo.Format = "FWS";
            file.FileInfo.Version = 8;
            file.Header.FrameSize = new SwfRect(0, 0, 100, 100);
            file.Header.FrameRate = 20.0;
            file.Header.FrameCount = 1;
            file.Tags.Add(new FileAttributesTag { UseNetwork = true});
            file.Tags.Add(new SetBackgroundColorTag {Color = new SwfRGB(10, 224, 224)});
            file.Tags.Add(new ShowFrameTag());
            file.Tags.Add(new EndTag());
            var swf = SwfFile.ReadFrom(null);
            using (var stream = File.Open(@"D:\temp\bgTest.swf", FileMode.Create, FileAccess.ReadWrite))
            {
                file.WriteTo(stream);
            }
            
        }
    }
}
