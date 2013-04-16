using System.IO;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.DisplayListTags;
using NUnit.Framework;
using SwfLib;

namespace Code.SwfLib.Tests.Tags.DisplayListTags {
    [TestFixture]
    public class RemoveObjectTagTest : TestFixtureBase {

        private static readonly byte[] _etalon = new byte[] { 0x10, 0x20, 0x30, 0x40 };

        [Test]
        public void ReadTest() {
            var mem = new MemoryStream(_etalon);
            var tagReader = new SwfTagDeserializer(new SwfFile());
            var tagData = new SwfTagData {
                Type = SwfTagType.RemoveObject,
                Data = mem.ToArray()
            };
            var res = tagReader.ReadTag<RemoveObjectTag>(tagData);
            Assert.IsNotNull(res);

            Assert.AreEqual(0x2010, res.CharacterID);
            Assert.AreEqual(0x4030, res.Depth);

            Assert.IsNull(res.RestData);
        }

        [Test]
        public void WriteTest() {
            var tag = new RemoveObjectTag {
                CharacterID = 0x2010,
                Depth = 0x4030
            };

            var tagWriter = new SwfTagSerializer(new SwfFile());
            var tagData = tagWriter.GetTagData(tag);

            Assert.AreEqual(_etalon, tagData.Data);
        }
    }
}
