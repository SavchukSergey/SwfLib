using NUnit.Framework;
using SwfLib.SwfMill.TagFormatting.FontTags;
using SwfLib.Tags.FontTags;

namespace SwfLib.SwfMill.Tests.TagFormatting.FontTags {
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
