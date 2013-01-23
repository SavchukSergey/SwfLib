using System.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Data.Shapes;
using Code.SwfLib.Gradients;
using Code.SwfLib.Tags.ShapeTags;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Samples {
    [TestFixture]
    public class DefineShape3TagTest : BaseSampleTest {

        [Test]
        public void Test1() {
            var tag = ReadTag<DefineShape3Tag>("Sample - 1.swf", "a120edb8a47355bb3729d8330595ae84");
            Assert.IsNotNull(tag);
            Assert.AreEqual(5, tag.ShapeID);
            Assert.AreEqual(0, tag.ShapeBounds.XMin);
            Assert.AreEqual(14560, tag.ShapeBounds.XMax);
            Assert.AreEqual(0, tag.ShapeBounds.YMin);
            Assert.AreEqual(1800, tag.ShapeBounds.YMax);

            Assert.AreEqual(1, tag.FillStyles.Count);
            var fillStyle = tag.FillStyles[0];

            Assert.AreEqual(FillStyleType.LinearGradient, fillStyle.FillStyleType);
            Assert.AreEqual(0, fillStyle.GradientMatrix.ScaleX);
            Assert.AreEqual(0, fillStyle.GradientMatrix.ScaleY);
            Assert.AreEqual(0.05499267578125000, fillStyle.GradientMatrix.RotateSkew0);
            Assert.AreEqual(-0.05493164062500000, fillStyle.GradientMatrix.RotateSkew1);
            Assert.AreEqual(7280, fillStyle.GradientMatrix.TranslateX);
            Assert.AreEqual(900, fillStyle.GradientMatrix.TranslateY);

            Assert.AreEqual(InterpolationMode.Normal, fillStyle.Gradient.InterpolationMode);
            Assert.AreEqual(2, fillStyle.Gradient.GradientRecords.Count);

            var rec0 = fillStyle.Gradient.GradientRecords[0];
            var rec1 = fillStyle.Gradient.GradientRecords[1];

            Assert.AreEqual(0, rec0.Ratio);
            Assert.AreEqual(new SwfRGBA(0, 0, 0, 0), rec0.Color);

            Assert.AreEqual(255, rec1.Ratio);
            Assert.AreEqual(new SwfRGBA(0, 0, 0, 204), rec1.Color);

            Assert.AreEqual(6, tag.ShapeRecords.Count);
            var firstShape = tag.ShapeRecords.First() as StyleChangeShapeRecord;
            var lastShape = tag.ShapeRecords.Last() as EndShapeRecord;
            Assert.IsNotNull(firstShape);
            Assert.IsNotNull(lastShape);
        }
    }
}
