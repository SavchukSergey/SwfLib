using System.IO;
using Code.SwfLib.Data;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.DisplayListTags;
using NUnit.Framework;
using SwfLib;
using SwfLib.Data;
using SwfLib.Tags.DisplayListTags;
using SwfLib.Tests.Asserts.Tags;

namespace Code.SwfLib.Tests.Tags.DisplayListTags {
    [TestFixture]
    public class PlaceObject2TagTest : TestFixtureBase {

        private static readonly byte[] _etalon = new byte[] { 0x09, 0x05, 0x00, 0x04 };

        [Test]
        public void ReadTest() {
            var mem = new MemoryStream(_etalon);
            var tagReader = new SwfTagDeserializer(new SwfFile());
            var tagData = new SwfTagData {
                Type = SwfTagType.PlaceObject2,
                Data = mem.ToArray()
            };
            var res = tagReader.ReadTag<PlaceObject2Tag>(tagData);
            Assert.IsNotNull(res);
            AssertTag.AreEqual(GetPlaceObjectTag(), res);
        }

        [Test]
        public void WriteTest() {
            var tag = GetPlaceObjectTag();

            var tagWriter = new SwfTagSerializer(new SwfFile());
            var tagData = tagWriter.GetTagData(tag);

            Assert.AreEqual(_etalon, tagData.Data);
        }

        private static PlaceObject2Tag GetPlaceObjectTag() {
            return new PlaceObject2Tag {
                Depth = 0x05,
                HasMatrix = false,
                Matrix = new SwfMatrix(),
                HasColorTransform = true,
                Move = true,
                ColorTransform = new ColorTransformRGBA()
            };
        }

    }
}
