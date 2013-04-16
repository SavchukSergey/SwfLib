using NUnit.Framework;
using SwfLib.SwfMill.TagFormatting.ControlTags;
using SwfLib.Tags.ControlTags;

namespace SwfLib.SwfMill.Tests.TagFormatting {
    [TestFixture]
    public class EndTagFormatterTest : BaseTagFormattingTest<EndTag, EndTagFormatter> {

        [Test]
        public void FormatTest() {
            var tag = new EndTag();
            ConvertToXmlAndCompare(tag, "End.xml");
        }
    }
}
