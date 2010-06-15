using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code.SwfLib.Data;
using Code.SwfLib.SwfMill.TagFormatting;
using Code.SwfLib.Tags;
using NUnit.Framework;

namespace Code.SwfLib.SwfMill.Tests.TagFormatting {
    [TestFixture]
    public class ShowFrameTagFormatterTest : BaseTagFormattingTest<ShowFrameTag, ShowFrameTagFormatter> {

        [Test]
        public void FormatTest() {
            var tag = new ShowFrameTag();
            ConvertToXmlAndCompare(tag, "ShowFrame.xml");
        }
    }
}
