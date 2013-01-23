using System.Linq;
using Code.SwfLib.Data.FillStyles;
using Code.SwfLib.Data.Shapes;
using Code.SwfLib.Tags.ShapeTags;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Samples {
    [TestFixture]
    public class DefineShapeTagTest : BaseSampleTest {

        [Test]
        public void Test1() {
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

            var lineShape = tag.Shapes.ShapeRecords[6] as StraightEdgeShapeRecord;
            var curveShape = tag.Shapes.ShapeRecords[7] as CurvedEdgeShapeRecord;
            Assert.IsNotNull(lineShape);
            Assert.IsNotNull(curveShape);

            Assert.AreEqual(-2, lineShape.DeltaX);
            Assert.AreEqual(10, lineShape.DeltaY);

            Assert.AreEqual(0, curveShape.ControlDeltaX);
            Assert.AreEqual(12, curveShape.ControlDeltaY);
            Assert.AreEqual(9, curveShape.AnchorDeltaX);
            Assert.AreEqual(8, curveShape.AnchorDeltaY);
        }

        [Test]
        public void Test2() {
            var tag = ReadTag<DefineShapeTag>("Sample - 1.swf", "1a542a04b0196e306aab90b755982e0d");
            Assert.IsNotNull(tag);
            Assert.AreEqual(511, tag.ShapeID);
            Assert.AreEqual(2, tag.ShapeBounds.XMin);
            Assert.AreEqual(41, tag.ShapeBounds.XMax);
            Assert.AreEqual(2, tag.ShapeBounds.YMin);
            Assert.AreEqual(38, tag.ShapeBounds.YMax);

            Assert.AreEqual(1, tag.FillStyles.Count);
            Assert.AreEqual(FillStyleType.SolidColor, tag.FillStyles[0].FillStyleType);
            Assert.AreEqual(255, tag.FillStyles[0].ColorRGB.Red);
            Assert.AreEqual(255, tag.FillStyles[0].ColorRGB.Green);
            Assert.AreEqual(255, tag.FillStyles[0].ColorRGB.Blue);

            Assert.AreEqual(0, tag.Shapes.LineStyles.Count);

            Assert.AreEqual(15, tag.Shapes.ShapeRecords.Count);
            var firstShape = tag.Shapes.ShapeRecords.First() as StyleChangeShapeRecord;
            var lastShape = tag.Shapes.ShapeRecords.Last() as EndShapeRecord;
            Assert.IsNotNull(firstShape);
            Assert.IsNotNull(lastShape);

            Assert.AreEqual(41, firstShape.MoveDeltaX);
            Assert.AreEqual(20, firstShape.MoveDeltaY);
            Assert.IsNull(firstShape.FillStyle0);
            Assert.IsNotNull(firstShape.FillStyle1);
            Assert.AreEqual(1, firstShape.FillStyle1.Value);

            var styleChange = tag.Shapes.ShapeRecords[9] as StyleChangeShapeRecord;
            Assert.IsNotNull(styleChange);

            Assert.AreEqual(31, styleChange.MoveDeltaX);
            Assert.AreEqual(11, styleChange.MoveDeltaY);
            Assert.IsNull(styleChange.FillStyle0);
            Assert.IsNull(styleChange.FillStyle1);
        }
    }
}
