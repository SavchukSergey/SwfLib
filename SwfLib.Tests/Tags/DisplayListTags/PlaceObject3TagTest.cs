using System.IO;
using NUnit.Framework;
using SwfLib.Data;
using SwfLib.Filters;
using SwfLib.Tags;
using SwfLib.Tags.DisplayListTags;
using SwfLib.Tests.Asserts.Tags;

namespace SwfLib.Tests.Tags.DisplayListTags {
    [TestFixture]
    public class PlaceObject3TagTest : TestFixtureBase {

        private static readonly byte[] _etalon = new byte[] { 0x09, 0x01, 0x11, 0x00, 0x04, 0x01, 0x01, 0xd7, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08 };

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
            AssertTag.AreEqual(GetPlaceObject3Tag(), res);
        }

        [Test]
        public void WriteTest()
        {
            var tag = GetPlaceObject3Tag();

            var tagWriter = new SwfTagSerializer(new SwfFile());
            var tagData = tagWriter.GetTagData(tag);

            Assert.AreEqual(_etalon, tagData.Data);
        }

        private static PlaceObject3Tag GetPlaceObject3Tag() {
            return new PlaceObject3Tag {
                Depth = 17,
                HasMatrix = false,
                Matrix = SwfMatrix.Identity,
                Move = true,
                ColorTransform = new ColorTransformRGBA(),
                Filters = {
                    new BlurFilter {BlurX = 5335 / 65536.0, BlurY = 0, Passes = 1}
                }
            };
        }

    }
}
