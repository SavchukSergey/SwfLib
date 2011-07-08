using System.Linq;
using Code.SwfLib.Tags;
using NUnit.Framework;

namespace Code.SwfLib.Tests.ExternalEtalonTests {
    [TestFixture]
    public class SwfStreamReaderExtTest : ExternalEtalonTestFixtureBase {

        [Test]
        public void ReadMatrixTest() {
            var file = new SwfFile();
            file.FileInfo.Version = 10;

            var reader = new SwfTagReader(file);
            var tags =
                GetTagBinariesFromSwfResource("Matrix-compiled.swf")
                .Where(item => item.Type == SwfTagType.PlaceObject2);
            var tagData = tags.First();
            var tag = reader.ReadPlaceObject2Tag(tagData);
            Assert.AreEqual(20.5, tag.Matrix.ScaleX);
            Assert.AreEqual(17.25, tag.Matrix.ScaleY);

            tagData = tags.Skip(1).First();
            tag = reader.ReadPlaceObject2Tag(tagData);
            Assert.AreEqual(0.5, tag.Matrix.ScaleX);
            Assert.AreEqual(1.25, tag.Matrix.ScaleY);

            tagData = tags.Skip(2).First();
            tag = reader.ReadPlaceObject2Tag(tagData);
            Assert.AreEqual(0.5, tag.Matrix.ScaleX);
            Assert.AreEqual(-1.25, tag.Matrix.ScaleY);
        }

    }
}
