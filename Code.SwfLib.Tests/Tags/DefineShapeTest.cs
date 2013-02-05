using System.IO;
using Code.SwfLib.Data;
using Code.SwfLib.Shapes.FillStyles;
using Code.SwfLib.Shapes.Records;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.ShapeTags;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Tags {
    [TestFixture]
    public class DefineShapeTest : TestFixtureBase {

        private static readonly byte[] _etalon0 = new byte[] {
            0x01, 0x00,
            0x70, 0xfb, 0x49, 0x97, 0x0d, 0x0c, 0x7d, 0x50,
            0x00, 0x01, 0x14, 0x00, 0x00, 0x00, 0x00,
            0x01,
            0x25, 0xc9, 0x92, 0x0d, 0x21,
            0xed, 0x48, 0x87, 0x65, 0x30, 0x3b, 0x6d, 0xe1, 0xd8, 0xb4, 0x00, 0x00
        };


        private static readonly byte[] _etalon1 = new byte[] {
            0x02, 0x00, 0x70, 0x00, 0x0a, 0x75, 0x00, 0x00,
            0x38, 0x40, 0x01, 0x42, 0x01, 0x00, 0xd9, 0x40,
            0x00, 0x05, 0x00, 0x00, 0x0f, 0xb8, 0x14, 0x00,
            0x00, 0x00, 0x10, 0x15, 0xca, 0x75, 0x0e, 0x11,
            0xf0, 0xac, 0x5b, 0xa8, 0x85, 0xc7, 0xc7, 0x82,
            0x7b, 0xfd, 0x2e, 0x10, 0x00
        };

        [Test]
        public void ReadTest() {
            var mem = new MemoryStream(_etalon0);
            var tagReader = new SwfTagDeserializer(new SwfFile());
            var tagData = new SwfTagData {
                Type = SwfTagType.DefineShape,
                Data = mem.ToArray()
            };
            var res = tagReader.ReadTag<DefineShapeTag>(tagData);
            AssertExt.AreEqual(GetDefineShapeTag0(), res);

            //Assert.IsFalse(firstShape.FillStyle0.HasValue);
            //Assert.IsFalse(firstShape.FillStyle1.HasValue);
            //Assert.IsTrue(firstShape.LineStyle.HasValue);
            //Assert.IsTrue(firstShape.StateMoveTo);

            //Assert.AreEqual(1, firstShape.LineStyle.Value);
            //Assert.AreEqual(4900, firstShape.MoveDeltaX);
            //Assert.AreEqual(1680, firstShape.MoveDeltaY);

            //Assert.AreEqual(0, secondShape.DeltaX);
            //Assert.AreEqual(2320, secondShape.DeltaY);

            //Assert.AreEqual(-2880, thirdShape.DeltaX);
            //Assert.AreEqual(0, thirdShape.DeltaY);

            //Assert.AreEqual(0, fourthShape.DeltaX);
            //Assert.AreEqual(-2320, fourthShape.DeltaY);

            //Assert.AreEqual(2880, fifthShape.DeltaX);
            //Assert.AreEqual(0, fifthShape.DeltaY);

            //Assert.IsNotNull(sixthShape);
        }

        [Test]
        public void WriteTest() {
            var tag = GetDefineShapeTag0();
            var tagWriter = new SwfTagSerializer(new SwfFile());
            var tagData = tagWriter.GetTagData(tag);

            Assert.AreEqual(_etalon0, tagData.Data);
        }

        [Test]
        public void Read1Test() {
            var mem = new MemoryStream(_etalon1);
            var tagReader = new SwfTagDeserializer(new SwfFile());
            var tagData = new SwfTagData {
                Type = SwfTagType.DefineShape,
                Data = mem.ToArray()
            };
            var res = tagReader.ReadTag<DefineShapeTag>(tagData);
            AssertExt.AreEqual(GetDefineShapeTag1(), res);

            //Assert.IsFalse(firstShape.FillStyle0.HasValue);
            //Assert.IsFalse(firstShape.FillStyle1.HasValue);
            //Assert.IsTrue(firstShape.LineStyle.HasValue);
            //Assert.IsTrue(firstShape.StateMoveTo);

            //Assert.AreEqual(1, firstShape.LineStyle.Value);
            //Assert.AreEqual(4900, firstShape.MoveDeltaX);
            //Assert.AreEqual(1680, firstShape.MoveDeltaY);

            //Assert.AreEqual(0, secondShape.DeltaX);
            //Assert.AreEqual(2320, secondShape.DeltaY);

            //Assert.AreEqual(-2880, thirdShape.DeltaX);
            //Assert.AreEqual(0, thirdShape.DeltaY);

            //Assert.AreEqual(0, fourthShape.DeltaX);
            //Assert.AreEqual(-2320, fourthShape.DeltaY);

            //Assert.AreEqual(2880, fifthShape.DeltaX);
            //Assert.AreEqual(0, fifthShape.DeltaY);

            //Assert.IsNotNull(sixthShape);
        }

        [Test]
        public void Write1Test() {
            var tag = GetDefineShapeTag1();
            var tagWriter = new SwfTagSerializer(new SwfFile());
            var tagData = tagWriter.GetTagData(tag);

            Assert.AreEqual(_etalon1, tagData.Data);
        }


        private static DefineShapeTag GetDefineShapeTag0() {
            return new DefineShapeTag {
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
        }
        private static DefineShapeTag GetDefineShapeTag1() {
            return new DefineShapeTag {
                ShapeID = 2,
                ShapeBounds = { XMin = 0, XMax = 5354, YMin = 0, YMax = 1800 },
                FillStyles = {
                    new FillStyleRGB {
                        FillStyleType = FillStyleType.NonSmoothedRepeatingBitmap,
                        BitmapID = 1,
                        BitmapMatrix = new SwfMatrix {
                            ScaleX = 20.0,
                            ScaleY = 20.0,
                            TranslateX = -9206,
                            TranslateY = 0,
                            HasScale = true
                        }
                    }
                },
                ShapeRecords = {
                    new StyleChangeShapeRecordRGB { StateMoveTo = true, MoveDeltaX = 5354, MoveDeltaY = 1800, FillStyle1 = 1 },
                    new StraightEdgeShapeRecord { DeltaX = -5354, DeltaY = 0 },
                    new StraightEdgeShapeRecord { DeltaX = 267, DeltaY = -1800},
                    new StraightEdgeShapeRecord {DeltaX = 5087,DeltaY = 0},
                    new StraightEdgeShapeRecord {DeltaX = 0,DeltaY = 1800},
                    new EndShapeRecord()
                }
            };
        }

        private static DefineShapeTag GetDefineShapeTag2() {
            var tag = new DefineShapeTag();
            tag.ShapeID = 7;
            tag.ShapeBounds.XMin = 0;
            tag.ShapeBounds.XMax = 14560;
            tag.ShapeBounds.YMin = 0;
            tag.ShapeBounds.YMax = 1800;
            tag.FillStyles.Add(new FillStyleRGB {
                FillStyleType = FillStyleType.SolidColor,
                Color = new SwfRGB(255, 255, 255)
            });
            tag.ShapeRecords.Add(new StyleChangeShapeRecordRGB {
                MoveDeltaX = 14560,
                MoveDeltaY = 1800,
                FillStyle1 = 1
            });
            tag.ShapeRecords.Add(new StraightEdgeShapeRecord {
                DeltaX = -14560,
                DeltaY = 0
            });
            tag.ShapeRecords.Add(new StraightEdgeShapeRecord {
                DeltaX = 0,
                DeltaY = -1800
            });
            tag.ShapeRecords.Add(new StraightEdgeShapeRecord {
                DeltaX = 14560,
                DeltaY = 0
            });
            tag.ShapeRecords.Add(new StraightEdgeShapeRecord {
                DeltaX = 0,
                DeltaY = 1800
            });
            tag.ShapeRecords.Add(new EndShapeRecord());
            return tag;
        }
    }
}
