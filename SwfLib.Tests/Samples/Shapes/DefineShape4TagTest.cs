using System.Linq;
using Code.SwfLib.Shapes.Records;
using Code.SwfLib.Tests.Samples;
using NUnit.Framework;
using SwfLib.Shapes.Records;
using SwfLib.Tags.ShapeTags;

namespace SwfLib.Tests.Samples.Shapes {
    [TestFixture]
    public class DefineShape4TagTest : BaseSampleTest {

        [Test]
        public void Test1()
        {
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


            var lineStyle = tag.LineStyles[0];

            Assert.AreEqual(0, lineStyle.Color.Red);
            Assert.AreEqual(0, lineStyle.Color.Green);
            Assert.AreEqual(0, lineStyle.Color.Blue);
            Assert.AreEqual(255, lineStyle.Color.Alpha);

            Assert.AreEqual(6, tag.ShapeRecords.Count);
            var firstShape = tag.ShapeRecords.First() as StyleChangeShapeRecord;
            var lastShape = tag.ShapeRecords.Last() as EndShapeRecord;
            Assert.IsNotNull(firstShape);
            Assert.IsNotNull(lastShape);

            Assert.AreEqual("6de111f18ae52ef83b08ff85603ce4e3", GetTagHash(tag));
        }

    }
}
