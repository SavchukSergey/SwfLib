using System.Linq;
using Code.SwfLib.Tags.FontTags;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Samples.Fonts {
    [TestFixture]
    public class DefineFont3Test : BaseSampleTest {

        [Test]
        public void Test1() {
            var tag = ReadTag<DefineFont3Tag>("Sample - 1.swf", "cbf1ec2485e16c9b624af319cb8d32af");
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
            Assert.AreEqual("cbf1ec2485e16c9b624af319cb8d32af", GetTagHash(tag));
        }

    }
}
