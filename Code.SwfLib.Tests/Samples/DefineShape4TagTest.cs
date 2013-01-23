using System.Linq;
using Code.SwfLib.Data.Shapes;
using Code.SwfLib.Tags.ShapeTags;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Samples {
    [TestFixture]
    public class DefineShape4TagTest : BaseSampleTest {

        [Test]
        public void Test1() {
            var tag = ReadTag<DefineShape4Tag>("Sample - 1.swf", "6de111f18ae52ef83b08ff85603ce4e3");
            Assert.IsNotNull(tag);
            Assert.AreEqual(14, tag.ShapeID);
            
            Assert.AreEqual(-10, tag.ShapeBounds.XMin);
            Assert.AreEqual(14550, tag.ShapeBounds.XMax);
            Assert.AreEqual(0, tag.ShapeBounds.YMin);
            Assert.AreEqual(1800, tag.ShapeBounds.YMax);

            Assert.AreEqual(0, tag.EdgeBounds.XMin);
            Assert.AreEqual(14540, tag.EdgeBounds.XMax);
            Assert.AreEqual(10, tag.EdgeBounds.YMin);
            Assert.AreEqual(1790, tag.EdgeBounds.YMax);

            Assert.IsFalse(tag.UsesNonScalingStrokes);
            Assert.IsTrue(tag.UsesScalingStrokes);
            Assert.IsFalse(tag.UsesFillWindingRule);

            Assert.AreEqual(0, tag.FillStyles.Count);

            Assert.AreEqual(1, tag.LineStyles.Count);
            //Assert.AreEqual(1, tag.FillStyles.Count);
            //Assert.AreEqual(FillStyleType.SolidColor, tag.FillStyles[0].FillStyleType);
            //Assert.AreEqual(255, tag.FillStyles[0].ColorRGB.Red);
            //Assert.AreEqual(255, tag.FillStyles[0].ColorRGB.Green);
            //Assert.AreEqual(255, tag.FillStyles[0].ColorRGB.Blue);

            //Assert.AreEqual(0, tag.Shapes.LineStyles.Count);

            //Assert.AreEqual(33, tag.Shapes.ShapeRecords.Count);
            //var firstShape = tag.Shapes.ShapeRecords.First() as StyleChangeShapeRecord;
            //var lastShape = tag.Shapes.ShapeRecords.Last() as EndShapeRecord;
            //Assert.IsNotNull(firstShape);
            //Assert.IsNotNull(lastShape);

            //Assert.AreEqual(60, firstShape.MoveDeltaX);
            //Assert.AreEqual(17, firstShape.MoveDeltaY);
            //Assert.IsNull(firstShape.FillStyle0);
            //Assert.IsNotNull(firstShape.FillStyle1);
            //Assert.AreEqual(1, firstShape.FillStyle1.Value);

            //var lineShape = tag.Shapes.ShapeRecords[6] as StraightEdgeShapeRecord;
            //var curveShape = tag.Shapes.ShapeRecords[7] as CurvedEdgeShapeRecord;
            //Assert.IsNotNull(lineShape);
            //Assert.IsNotNull(curveShape);

            //Assert.AreEqual(-2, lineShape.DeltaX);
            //Assert.AreEqual(10, lineShape.DeltaY);

            //Assert.AreEqual(0, curveShape.ControlDeltaX);
            //Assert.AreEqual(12, curveShape.ControlDeltaY);
            //Assert.AreEqual(9, curveShape.AnchorDeltaX);
            //Assert.AreEqual(8, curveShape.AnchorDeltaY);
        }

      
    }
}
