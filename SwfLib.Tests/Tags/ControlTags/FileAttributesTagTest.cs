using System.IO;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.ControlTags;
using NUnit.Framework;
using SwfLib;
using SwfLib.Tests.Asserts.Tags;

namespace Code.SwfLib.Tests.Tags.ControlTags {
    [TestFixture]
    public class FileAttributesTagTest : TestFixtureBase {

        private static readonly byte[] _etalon = new byte[] { 0x11, 0x00, 0x00, 0x00 };

        [Test]
        public void ReadTest() {
            var mem = new MemoryStream(_etalon);
            var tagReader = new SwfTagDeserializer(new SwfFile());
            var tagData = new SwfTagData {
                Type = SwfTagType.FileAttributes,
                Data = mem.ToArray()
            };
            var res = tagReader.ReadTag<FileAttributesTag>(tagData);
            Assert.IsNotNull(res);
            AssertTag.AreEqual(GetFileAttributesTag(), res);
        }

        [Test]
        public void WriteTest() {
            var tag = GetFileAttributesTag();

            var tagWriter = new SwfTagSerializer(new SwfFile());
            var tagData = tagWriter.GetTagData(tag);

            Assert.AreEqual(_etalon, tagData.Data);
        }

        private static FileAttributesTag GetFileAttributesTag() {
            return new FileAttributesTag { HasMetadata = true, UseNetwork = true };
        }
    }
}
