using System.Linq;
using Code.SwfLib;
using Code.SwfLib.Tags;
using Code.SwfLib.Tests.ExternalEtalonTests;
using NUnit.Framework;
using SwfLib.Tags.DisplayListTags;

namespace SwfLib.Tests.ExternalEtalonTests {
    [TestFixture]
    public class SwfStreamReaderExtTest : ExternalEtalonTestFixtureBase {

        [Test]
        public void ReadMatrixTest() {
            var file = new SwfFile();
            file.FileInfo.Version = 10;

            var tags =
                GetTagBinariesFromSwfResource("Matrix-compiled.swf")
                .Where(item => item.Type == SwfTagType.PlaceObject2);
            var tagData = tags.First();
            var ser = new SwfTagDeserializer(file);
            var tag = ser.ReadTag<PlaceObject2Tag>(tagData);
            Assert.AreEqual(20.5, tag.Matrix.ScaleX);
            Assert.AreEqual(17.25, tag.Matrix.ScaleY);

            tagData = tags.Skip(1).First();
            tag = ser.ReadTag<PlaceObject2Tag>(tagData);
            Assert.AreEqual(0.5, tag.Matrix.ScaleX);
            Assert.AreEqual(1.25, tag.Matrix.ScaleY);

            tagData = tags.Skip(2).First();
            tag = ser.ReadTag<PlaceObject2Tag>(tagData);
            Assert.AreEqual(0.5, tag.Matrix.ScaleX);
            Assert.AreEqual(-1.25, tag.Matrix.ScaleY);
        }

    }
}
