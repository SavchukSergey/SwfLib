using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.SwfMill.TagFormatting;
using Code.SwfLib.Tags;
using NUnit.Framework;

namespace Code.SwfLib.SwfMill.Tests.TagFormatting {
    [TestFixture]
    public class SetBackgroundColorTagFormatterTest : BaseTagFormattingTest<SetBackgroundColorTag, SetBackgroundColorTagFormatter> {

        [Test]
        public void FormatTest() {
            var tag = new SetBackgroundColorTag {Color = new SwfRGB(10, 224, 224)};
            ConvertToXmlAndCompare(tag, "SetBackgroundColor.xml");
        }
    }
}
