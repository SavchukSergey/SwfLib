using System.IO;
using Code.SwfLib.Data;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.DisplayListTags;
using NUnit.Framework;
using SwfLib;
using SwfLib.Data;
using SwfLib.Tags;

namespace Code.SwfLib.Tests.Tags.DisplayListTags {
    [TestFixture]
    public class PlaceObjectTagTest : TestFixtureBase {

        private static readonly byte[] _etalon = new byte[] { 0x10, 0x20, 0x30, 0x40, 0x02, 0x00, 0x04 };

        [Test]
        public void ReadTest() {
            var mem = new MemoryStream(_etalon);
            var tagReader = new SwfTagDeserializer(new SwfFile());
            var tagData = new SwfTagData {
                Type = SwfTagType.PlaceObject,
                Data = mem.ToArray()
            };
            var res = tagReader.ReadTag<PlaceObjectTag>(tagData);
            Assert.IsNotNull(res);

            Assert.AreEqual(0x2010, res.CharacterID);
            Assert.AreEqual(0x4030, res.Depth);
            Assert.IsFalse(res.Matrix.HasScale);
            Assert.IsFalse(res.Matrix.HasRotate);
            Assert.AreEqual(0, res.Matrix.TranslateX);
            Assert.AreEqual(0, res.Matrix.TranslateY);

            Assert.IsTrue(res.ColorTransform.HasValue);
            Assert.IsFalse(res.ColorTransform.Value.HasAddTerms);
            Assert.IsFalse(res.ColorTransform.Value.HasMultTerms);

            Assert.IsNull(res.RestData);
        }

        [Test]
        public void WriteTest() {
            var tag = new PlaceObjectTag {
                CharacterID = 0x2010,
                Depth = 0x4030,
                Matrix = new SwfMatrix(),
                ColorTransform = new ColorTransformRGB()
            };

            var tagWriter = new SwfTagSerializer(new SwfFile());
            var tagData = tagWriter.GetTagData(tag);

            Assert.AreEqual(_etalon, tagData.Data);
        }

    }
}
