using Code.SwfLib.SwfMill.TagFormatting.FontTags;
using Code.SwfLib.Tags.FontTags;
using NUnit.Framework;

namespace Code.SwfLib.SwfMill.Tests.TagFormatting.FontTags {
    [TestFixture]
    public class DefineFontAlignZonesTagFormatterTest : BaseTagFormattingTest<DefineFontAlignZonesTag, DefineFontAlignZonesTagFormatter> {

        [Test]
        public void ParseTest() {
            var tag = ParseTagFromResource("FontTags.DefineFontAlignZones.xml");
            Assert.IsNotNull(tag);
            //TODO: checked data
        }

        [Test]
        public void DoubleConversionTest() {
            DoubleConversionFromResourceTest("FontTags.DefineFontAlignZones.xml");
        }
    }
}
