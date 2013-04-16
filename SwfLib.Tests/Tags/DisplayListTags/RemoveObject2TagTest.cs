using System.IO;
using NUnit.Framework;
using SwfLib.Tags;
using SwfLib.Tags.DisplayListTags;

namespace SwfLib.Tests.Tags.DisplayListTags {
    [TestFixture]
    public class RemoveObject2TagTest : TestFixtureBase {

        private static readonly byte[] _etalon = new byte[] {0x30, 0x40 };

        [Test]
        public void ReadTest() {
            var mem = new MemoryStream(_etalon);
            var tagReader = new SwfTagDeserializer(new SwfFile());
            var tagData = new SwfTagData {
                Type = SwfTagType.RemoveObject2,
                Data = mem.ToArray()
            };
            var res = tagReader.ReadTag<RemoveObject2Tag>(tagData);
            Assert.IsNotNull(res);

            Assert.AreEqual(0x4030, res.Depth);

            Assert.IsNull(res.RestData);
        }

        [Test]
        public void WriteTest() {
            var tag = new RemoveObject2Tag {
                Depth = 0x4030
            };

            var tagWriter = new SwfTagSerializer(new SwfFile());
            var tagData = tagWriter.GetTagData(tag);

            Assert.AreEqual(_etalon, tagData.Data);
        }
    }
}
