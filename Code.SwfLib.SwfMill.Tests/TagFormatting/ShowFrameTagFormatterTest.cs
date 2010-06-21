using Code.SwfLib.SwfMill.TagFormatting.DisplayListTags;
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
