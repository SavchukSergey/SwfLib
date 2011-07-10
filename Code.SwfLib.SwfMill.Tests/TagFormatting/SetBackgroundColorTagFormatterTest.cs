using Code.SwfLib.Data;
using Code.SwfLib.SwfMill.TagFormatting.ControlTags;
using Code.SwfLib.Tags.ControlTags;
using NUnit.Framework;

namespace Code.SwfLib.SwfMill.Tests.TagFormatting {
    [TestFixture]
    public class SetBackgroundColorTagFormatterTest : BaseTagFormattingTest<SetBackgroundColorTag, SetBackgroundColorTagFormatter> {

        [Test]
        public void FormatTest() {
            var tag = new SetBackgroundColorTag { Color = new SwfRGB(10, 224, 224) };
            ConvertToXmlAndCompare(tag, "SetBackgroundColor.xml");
        }

        [Test]
        public void DoubleConversionTest() {
            DoubleConversionFromResourceTest("SetBackgroundColor.xml");
        }
    }
}
