using System.IO;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.ControlTags;
using NUnit.Framework;
using SwfLib.Tests.Asserts.Tags;

namespace Code.SwfLib.Tests.Tags.ControlTags {
    [TestFixture]
    public class SetBackgroundColorTagTest : TestFixtureBase {
        private static readonly byte[] _etalon = new byte[] { 10, 20, 30 };

        [Test]
        public void ReadTest() {
            var mem = new MemoryStream(_etalon);
            var tagReader = new SwfTagDeserializer(new SwfFile());
            var tagData = new SwfTagData {
                Type = SwfTagType.SetBackgroundColor,
                Data = mem.ToArray()
            };
            var res = tagReader.ReadTag<SetBackgroundColorTag>(tagData);
            Assert.IsNotNull(res);
            AssertTag.AreEqual(GetSetBackgroundTag(), res);
        }

        [Test]
        public void WriteTest() {
            var tag = GetSetBackgroundTag();

            var tagWriter = new SwfTagSerializer(new SwfFile());
            var tagData = tagWriter.GetTagData(tag);

            Assert.AreEqual(_etalon, tagData.Data);
        }

        protected static SetBackgroundColorTag GetSetBackgroundTag() {
            return new SetBackgroundColorTag {
                Color = {
                    Red = 10,
                    Green = 20,
                    Blue = 30
                },
            };
        }
    }
}
