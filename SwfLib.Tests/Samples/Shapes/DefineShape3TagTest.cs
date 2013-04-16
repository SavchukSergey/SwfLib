using System.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Gradients;
using Code.SwfLib.Shapes.FillStyles;
using Code.SwfLib.Shapes.Records;
using Code.SwfLib.Tags.ShapeTags;
using Code.SwfLib.Tests.Asserts.Shapes;
using NUnit.Framework;
using SwfLib.Gradients;
using SwfLib.Shapes.Records;
using SwfLib.Tags.ShapeTags;
using SwfLib.Tests.Asserts.Shapes;

namespace Code.SwfLib.Tests.Samples.Shapes {
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

            AssertFillStyles.AreEqual(new LinearGradientFillStyleRGBA {
                GradientMatrix = {
                    ScaleX = 0,
                    ScaleY = 0,
                    HasScale = true,
                    RotateSkew0 = 0.05499267578125000,
                    RotateSkew1 = -0.05493164062500000,
                    HasRotate = true,
                    TranslateX = 7280,
                    TranslateY = 900
                },
                Gradient = new GradientRGBA {
                    InterpolationMode = InterpolationMode.Normal,
                    GradientRecords = {
                        new GradientRecordRGBA {Color = new SwfRGBA(0,0,0,0), Ratio = 0},
                        new GradientRecordRGBA {Color = new SwfRGBA(0,0,0,204), Ratio = 255},
                    }
                }
            }, fillStyle, "FillStyles[0]");


            Assert.AreEqual(6, tag.ShapeRecords.Count);
            var firstShape = tag.ShapeRecords.First() as StyleChangeShapeRecord;
            var lastShape = tag.ShapeRecords.Last() as EndShapeRecord;
            Assert.IsNotNull(firstShape);
            Assert.IsNotNull(lastShape);

            //Assert.AreEqual("a120edb8a47355bb3729d8330595ae84", GetTagHash(tag));
        }
    }
}
