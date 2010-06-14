using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Code.SwfLib.Data;
using Code.SwfLib.Tags;
using NUnit.Framework;

namespace Code.SwfLib.Tests {
    [TestFixture]
    public class SwfModelTest {

        [Test]
        public void SimpleBackgroundTest() {

            var file = new SwfFile();
            file.FileInfo.Format = "FWS";
            file.FileInfo.Version = 10;
            file.Header.FrameSize = new SwfRect(0, 0, 100, 100);
            file.Header.FrameRate = 20.0;
            file.Header.FrameCount = 1;
            file.Tags.Add(new FileAttributesTag { Attributes = SwfFileAttributes.UseNetwork});
            file.Tags.Add(new SetBackgroundColorTag {Color = new SwfRGB(10, 224, 224)});
            file.Tags.Add(new ShowFrameTag());
            file.Tags.Add(new EndTag());
            using (var stream = File.Open(@"D:\temp\bgTest.swf", FileMode.Create, FileAccess.ReadWrite))
            {
                SwfModel.WriteSwf(file, stream);
            }
            
        }
    }
}
