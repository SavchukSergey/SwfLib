using System.Linq;
using NUnit.Framework;
using SwfLib.Data;
using SwfLib.Shapes.FillStyles;
using SwfLib.Shapes.Records;
using SwfLib.Tags.ShapeTags;
using SwfLib.Tests.Asserts.Shapes;

namespace SwfLib.Tests.Samples.Shapes {
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
            AssertFillStyles.AreEqual(new SolidFillStyleRGB {
                Color = new SwfRGB { Red = 255, Green = 255, Blue = 255 }
            }, tag.FillStyles[0], "FillStyles[0]");

            Assert.AreEqual(0, tag.LineStyles.Count);

            Assert.AreEqual(33, tag.ShapeRecords.Count);
            var firstShape = tag.ShapeRecords.First() as StyleChangeShapeRecord;
            var lastShape = tag.ShapeRecords.Last() as EndShapeRecord;
            Assert.IsNotNull(firstShape);
            Assert.IsNotNull(lastShape);

            Assert.AreEqual(60, firstShape.MoveDeltaX);
            Assert.AreEqual(17, firstShape.MoveDeltaY);
            Assert.IsNull(firstShape.FillStyle0);
            Assert.IsNotNull(firstShape.FillStyle1);
            Assert.AreEqual(1, firstShape.FillStyle1.Value);

            var lineShape = tag.ShapeRecords[6] as StraightEdgeShapeRecord;
            var curveShape = tag.ShapeRecords[7] as CurvedEdgeShapeRecord;
            Assert.IsNotNull(lineShape);
            Assert.IsNotNull(curveShape);

            Assert.AreEqual(-2, lineShape.DeltaX);
            Assert.AreEqual(10, lineShape.DeltaY);

            Assert.AreEqual(0, curveShape.ControlDeltaX);
            Assert.AreEqual(12, curveShape.ControlDeltaY);
            Assert.AreEqual(9, curveShape.AnchorDeltaX);
            Assert.AreEqual(8, curveShape.AnchorDeltaY);

            Assert.AreEqual("0bc5103606398401fa8a9ed11bb0596c", GetTagHash(tag));
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
            AssertFillStyles.AreEqual(new SolidFillStyleRGB {
                Color = new SwfRGB { Red = 255, Green = 255, Blue = 255 }
            }, tag.FillStyles[0], "FillStyles[0]");

            Assert.AreEqual(0, tag.LineStyles.Count);

            Assert.AreEqual(15, tag.ShapeRecords.Count);
            var firstShape = tag.ShapeRecords.First() as StyleChangeShapeRecord;
            var lastShape = tag.ShapeRecords.Last() as EndShapeRecord;
            Assert.IsNotNull(firstShape);
            Assert.IsNotNull(lastShape);

            Assert.AreEqual(41, firstShape.MoveDeltaX);
            Assert.AreEqual(20, firstShape.MoveDeltaY);
            Assert.IsNull(firstShape.FillStyle0);
            Assert.IsNotNull(firstShape.FillStyle1);
            Assert.AreEqual(1, firstShape.FillStyle1.Value);

            var styleChange = tag.ShapeRecords[9] as StyleChangeShapeRecord;
            Assert.IsNotNull(styleChange);

            Assert.AreEqual(31, styleChange.MoveDeltaX);
            Assert.AreEqual(11, styleChange.MoveDeltaY);
            Assert.IsNull(styleChange.FillStyle0);
            Assert.IsNull(styleChange.FillStyle1);

            Assert.AreEqual("1a542a04b0196e306aab90b755982e0d", GetTagHash(tag));

        }
    }
}
