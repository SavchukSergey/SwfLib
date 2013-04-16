using System.IO;
using NUnit.Framework;
using SwfLib.Tags;
using SwfLib.Tags.ControlTags;

namespace SwfLib.Tests.Tags.ControlTags {
    [TestFixture]
    public class EndTagTest : TestFixtureBase {

        private static readonly byte[] _etalon = new byte[] { };

        [Test]
        public void ReadTest() {
            var mem = new MemoryStream(_etalon);
            var tagReader = new SwfTagDeserializer(new SwfFile());
            var tagData = new SwfTagData {
                Type = SwfTagType.End,
                Data = mem.ToArray()
            };
            var res = tagReader.ReadTag<EndTag>(tagData);
            Assert.IsNotNull(res);

            Assert.IsNull(res.RestData);
        }

        [Test]
        public void WriteTest() {
            var tag = new EndTag();

            var tagWriter = new SwfTagSerializer(new SwfFile());
            var tagData = tagWriter.GetTagData(tag);

            Assert.AreEqual(_etalon, tagData.Data);
        }
    }
}
