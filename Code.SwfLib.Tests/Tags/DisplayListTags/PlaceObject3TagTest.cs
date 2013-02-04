using System.IO;
using Code.SwfLib.Data;
using Code.SwfLib.Filters;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.DisplayListTags;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Tags.DisplayListTags {
    [TestFixture]
    public class PlaceObject3TagTest : TestFixtureBase {

        private static readonly byte[] _etalon = new byte[] { 0x09, 0x01, 0x11, 0x00, 0x00, 0x01, 0x01, 0xd7, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08 };

        [Test]
        public void ReadTest() {
            var mem = new MemoryStream(_etalon);
            var tagReader = new SwfTagDeserializer(new SwfFile());
            var tagData = new SwfTagData {
                Type = SwfTagType.PlaceObject3,
                Data = mem.ToArray()
            };
            var res = tagReader.ReadTag<PlaceObject3Tag>(tagData);
            Assert.IsNotNull(res);

            Assert.AreEqual(0, res.CharacterID);
            Assert.AreEqual(17, res.Depth);
            Assert.IsFalse(res.Matrix.HasScale);
            Assert.IsFalse(res.Matrix.HasRotate);
            Assert.AreEqual(0, res.Matrix.TranslateX);
            Assert.AreEqual(0, res.Matrix.TranslateY);
            Assert.AreEqual(1, res.Filters.Count);
            var filter = (BlurFilter)res.Filters[0];
            Assert.AreEqual(1, filter.Passes);

            Assert.IsNull(res.RestData);
        }

        [Test]
        public void WriteTest() {
            var tag = new PlaceObject3Tag {
                Depth = 17,
                HasMatrix = false,
                Matrix = new SwfMatrix(),
                Move = true,
                ColorTransform = new ColorTransformRGBA(),
                Filters = {
                    new BlurFilter {BlurX = 5335 / 65536.0, BlurY = 0, Passes = 1}
                }
            };

            var tagWriter = new SwfTagSerializer(new SwfFile());
            var tagData = tagWriter.GetTagData(tag);

            Assert.AreEqual(_etalon, tagData.Data);
        }

    }
}
