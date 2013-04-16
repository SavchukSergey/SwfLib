using Code.SwfLib.SwfMill.TagFormatting.ControlTags;
using Code.SwfLib.Tags.ControlTags;
using NUnit.Framework;

namespace Code.SwfLib.SwfMill.Tests.TagFormatting {
    [TestFixture]
    public class EndTagFormatterTest : BaseTagFormattingTest<EndTag, EndTagFormatter> {

        [Test]
        public void FormatTest() {
            var tag = new EndTag();
            ConvertToXmlAndCompare(tag, "End.xml");
        }
    }
}
