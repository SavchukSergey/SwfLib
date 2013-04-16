using System.IO;
using Code.SwfLib.Tags.ControlTags;
using NUnit.Framework;
using SwfLib.Tags;
using SwfLib.Tags.ControlTags;
using SwfLib.Tests.Asserts.Tags;

namespace SwfLib.Tests.Tags.ControlTags {
    [TestFixture]
    public class MetadataTagTest : TestFixtureBase {

        private static readonly byte[] _etalon = new byte[] { (byte)'a', (byte)'b', (byte)'c', 0x00 };

        [Test]
        public void ReadTest() {
            var mem = new MemoryStream(_etalon);
            var tagReader = new SwfTagDeserializer(new SwfFile());
            var tagData = new SwfTagData {
                Type = SwfTagType.Metadata,
                Data = mem.ToArray()
            };
            var res = tagReader.ReadTag<MetadataTag>(tagData);
            Assert.IsNotNull(res);
            AssertTag.AreEqual(GetMetadataTag(), res);
        }

        [Test]
        public void WriteTest() {
            var tag = GetMetadataTag();

            var tagWriter = new SwfTagSerializer(new SwfFile());
            var tagData = tagWriter.GetTagData(tag);

            Assert.AreEqual(_etalon, tagData.Data);
        }

        protected static MetadataTag GetMetadataTag() {
            return new MetadataTag {
                Metadata = "abc",
            };
        }
    }
}
