using NUnit.Framework;
using SwfLib.SwfMill.TagFormatting.DisplayListTags;
using SwfLib.Tags.DisplayListTags;

namespace SwfLib.SwfMill.Tests.TagFormatting {
    [TestFixture]
    public class ShowFrameTagFormatterTest : BaseTagFormattingTest<ShowFrameTag, ShowFrameTagFormatter> {

        [Test]
        public void FormatTest() {
            var tag = new ShowFrameTag();
            ConvertToXmlAndCompare(tag, "ShowFrame.xml");
        }
    }
}
