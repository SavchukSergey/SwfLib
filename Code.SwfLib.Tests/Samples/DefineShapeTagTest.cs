using System.Linq;
using Code.SwfLib.Data.FillStyles;
using Code.SwfLib.Data.Shapes;
using Code.SwfLib.Tags.ShapeTags;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Samples {
    [TestFixture]
    public class DefineShapeTagTest : BaseSampleTest {

        [Test]
        public void Test1()
        {
            var tag = ReadTag<DefineShapeTag>("Sample - 1.swf", "0bc5103606398401fa8a9ed11bb0596c");
            Assert.IsNotNull(tag);
            Assert.AreEqual(517, tag.ShapeID);
            Assert.AreEqual(3, tag.ShapeBounds.XMin);
            Assert.AreEqual(75, tag.ShapeBounds.XMax);
            Assert.AreEqual(3, tag.ShapeBounds.YMin);
            Assert.AreEqual(71, tag.ShapeBounds.YMax);

            Assert.AreEqual(1, tag.FillStyles.Count);
            Assert.AreEqual(FillStyleType.SolidColor, tag.FillStyles[0].FillStyleType);
            Assert.AreEqual(255, tag.FillStyles[0].ColorRGB.Red);
            Assert.AreEqual(255, tag.FillStyles[0].ColorRGB.Green);
            Assert.AreEqual(255, tag.FillStyles[0].ColorRGB.Blue);

            Assert.AreEqual(0, tag.Shapes.LineStyles.Count);

            Assert.AreEqual(33, tag.Shapes.ShapeRecords.Count);
            var firstShape = tag.Shapes.ShapeRecords.First() as StyleChangeShapeRecord;
            var lastShape = tag.Shapes.ShapeRecords.Last() as EndShapeRecord;
            Assert.IsNotNull(firstShape);
            Assert.IsNotNull(lastShape);

            Assert.AreEqual(60, firstShape.MoveDeltaX);
            Assert.AreEqual(17, firstShape.MoveDeltaY);
            Assert.IsNull(firstShape.FillStyle0);
            Assert.IsNotNull(firstShape.FillStyle1);
            Assert.AreEqual(1, firstShape.FillStyle1.Value);
        }
    }
}
