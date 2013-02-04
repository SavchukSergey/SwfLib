using System.IO;
using Code.SwfLib.Data;
using Code.SwfLib.Shapes.Records;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.ShapeTags;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Tags {
    [TestFixture]
    public class DefineShapeTest : TestFixtureBase {

        private static readonly byte[] _etalon = new byte[] {
            0x01, 0x00,
            0x70, 0xfb, 0x49, 0x97, 0x0d, 0x0c, 0x7d, 0x50,
            0x00, 0x01, 0x14, 0x00, 0x00, 0x00, 0x00,
            0x01,
            0x25, 0xc9, 0x92, 0x0d, 0x21,
            0xed, 0x48, 0x87, 0x65, 0x30, 0x3b, 0x6d, 0xe1, 0xd8, 0xb4, 0x00, 0x00
        };

        [Test]
        public void ReadTest() {
            var mem = new MemoryStream(_etalon);
            var tagReader = new SwfTagDeserializer(new SwfFile());
            var tagData = new SwfTagData {
                Type = SwfTagType.DefineShape,
                Data = mem.ToArray()
            };
            var res = tagReader.ReadTag<DefineShapeTag>(tagData);
            Assert.AreEqual(1, res.ShapeID);
            Assert.AreEqual(2010, res.ShapeBounds.XMin);
            Assert.AreEqual(4910, res.ShapeBounds.XMax);
            Assert.AreEqual(1670, res.ShapeBounds.YMin);
            Assert.AreEqual(4010, res.ShapeBounds.YMax);

            Assert.AreEqual(0, res.FillStyles.Count);
            Assert.AreEqual(1, res.LineStyles.Count);

            Assert.AreEqual(20, res.LineStyles[0].Width);
            Assert.AreEqual(new SwfRGB { Red = 0, Green = 0, Blue = 0 }, res.LineStyles[0].Color);

            Assert.AreEqual(6, res.ShapeRecords.Count);

            var firstShape = (StyleChangeShapeRecordRGB)res.ShapeRecords[0];
            var secondShape = (StraightEdgeShapeRecord)res.ShapeRecords[1];
            var thirdShape = (StraightEdgeShapeRecord)res.ShapeRecords[2];
            var fourthShape = (StraightEdgeShapeRecord)res.ShapeRecords[3];
            var fifthShape = (StraightEdgeShapeRecord)res.ShapeRecords[4];
            var sixthShape = (EndShapeRecord)res.ShapeRecords[5];

            Assert.IsFalse(firstShape.StateNewStyles);
            Assert.IsFalse(firstShape.FillStyle0.HasValue);
            Assert.IsFalse(firstShape.FillStyle1.HasValue);
            Assert.IsTrue(firstShape.LineStyle.HasValue);
            Assert.IsTrue(firstShape.StateMoveTo);

            Assert.AreEqual(1, firstShape.LineStyle.Value);
            Assert.AreEqual(4900, firstShape.MoveDeltaX);
            Assert.AreEqual(1680, firstShape.MoveDeltaY);

            Assert.AreEqual(0, secondShape.DeltaX);
            Assert.AreEqual(2320, secondShape.DeltaY);

            Assert.AreEqual(-2880, thirdShape.DeltaX);
            Assert.AreEqual(0, thirdShape.DeltaY);

            Assert.AreEqual(0, fourthShape.DeltaX);
            Assert.AreEqual(-2320, fourthShape.DeltaY);

            Assert.AreEqual(2880, fifthShape.DeltaX);
            Assert.AreEqual(0, fifthShape.DeltaY);

            Assert.IsNotNull(sixthShape);
        }

        [Test]
        public void WriteTest() {
            var tag = new DefineShapeTag {
                ShapeID = 1,
                ShapeBounds = new SwfRect {
                    XMin = 2010,
                    XMax = 4910,
                    YMin = 1670,
                    YMax = 4010
                },
                LineStyles = { new LineStyleRGB { Width = 20, Color = new SwfRGB(0, 0, 0) } },
                ShapeRecords = {
                    new StyleChangeShapeRecordRGB { LineStyle = 1, MoveDeltaX = 4900, MoveDeltaY = 1680, StateMoveTo = true},
                    new StraightEdgeShapeRecord {DeltaX = 0, DeltaY = 2320},
                    new StraightEdgeShapeRecord {DeltaX = -2880, DeltaY = 0},
                    new StraightEdgeShapeRecord {DeltaX = 0, DeltaY = -2320},
                    new StraightEdgeShapeRecord {DeltaX = 2880, DeltaY = 0},
                    new EndShapeRecord()
                }
            };

            var tagWriter = new SwfTagSerializer(new SwfFile());
            var tagData = tagWriter.GetTagData(tag);

            Assert.AreEqual(_etalon, tagData.Data);
        }
    }
}
