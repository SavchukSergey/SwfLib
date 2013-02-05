using System.Linq;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.FontTags;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Tags.FontTags {
    [TestFixture]
    public class DefineFont3TagTest : TestFixtureBase {

        [Test]
        public void ReadTest() {
            var tagData = ReadEmbeddedTagData("DefineFont3Tag.bin", SwfTagType.DefineFont3);
            var tagReader = new SwfTagDeserializer(new SwfFile());
            var tag = tagReader.ReadTag<DefineFont3Tag>(tagData);
            Assert.IsNotNull(tag);

            Assert.AreEqual(17, tag.FontID);

            Assert.AreEqual("BlacklightD\0", tag.FontName);
            Assert.AreEqual(24, tag.Glyphs.Count);

            var secondGlyph = tag.Glyphs[1];
            Assert.AreEqual(46, secondGlyph.Code);
            Assert.AreEqual(12, secondGlyph.Records.Count);

            var lastShape = tag.Glyphs.Last();
            Assert.AreEqual(120, lastShape.Code);
            Assert.AreEqual(43, lastShape.Records.Count);

            var tagWriter = new SwfTagSerializer(new SwfFile());
            var writtenTagData = tagWriter.GetTagData(tag);

            Assert.AreEqual(tagData.Data, writtenTagData.Data);

            Assert.IsNull(tag.RestData);
        }
    }
}
