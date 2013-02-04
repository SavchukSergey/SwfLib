using System.IO;
using Code.SwfLib.Data;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.DisplayListTags;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Tags.DisplayListTags {
    [TestFixture]
    public class PlaceObject2TagTest : TestFixtureBase {

        private static readonly byte[] _etalon = new byte[] { 0x09, 0x05, 0x00, 0x00 };

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

            Assert.AreEqual(0, res.CharacterID);
            Assert.AreEqual(5, res.Depth);
            Assert.IsFalse(res.Matrix.HasScale);
            Assert.IsFalse(res.Matrix.HasRotate);
            Assert.AreEqual(0, res.Matrix.TranslateX);
            Assert.AreEqual(0, res.Matrix.TranslateY);

            Assert.IsNull(res.RestData);
        }

        [Test]
        public void WriteTest() {
            var tag = new PlaceObject2Tag {
                Depth = 0x05,
                HasMatrix = false,
                Matrix = new SwfMatrix(),
                HasColorTransform = true,
                Move = true,
                ColorTransform = new ColorTransformRGBA()
            };

            var tagWriter = new SwfTagSerializer(new SwfFile());
            var tagData = tagWriter.GetTagData(tag);

            Assert.AreEqual(_etalon, tagData.Data);
        }

    }
}
