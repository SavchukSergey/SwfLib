using System.IO;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.DisplayListTags;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Tags.DisplayListTags {
    [TestFixture]
    public class ShowFrameTagTest : TestFixtureBase {

        private static readonly byte[] _etalon = new byte[] { };

        [Test]
        public void ReadTest() {
            var mem = new MemoryStream(_etalon);
            var tagReader = new SwfTagDeserializer(new SwfFile());
            var tagData = new SwfTagData {
                Type = SwfTagType.ShowFrame,
                Data = mem.ToArray()
            };
            var res = tagReader.ReadTag<ShowFrameTag>(tagData);
            Assert.IsNotNull(res);
        }

        [Test]
        public void WriteTest() {
            var tag = new ShowFrameTag();

            var tagWriter = new SwfTagSerializer(new SwfFile());
            var tagData = tagWriter.GetTagData(tag);

            Assert.AreEqual(_etalon, tagData.Data);
        }

    }
}
