using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Code.SwfLib.Data;
using Code.SwfLib.Data.FillStyles;
using Code.SwfLib.Data.Shapes;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.ShapeTags;
using NUnit.Framework;

namespace Code.SwfLib.Tests.ExternalEtalonTests
{
    [TestFixture]
    public class DefineShapeTagTest : ExternalEtalonTestFixtureBase
    {

        #region DefineShape - 1

        /*
      <DefineShape objectID="2">
        <bounds>
          <Rectangle left="0" right="5354" top="0" bottom="1800"/>
        </bounds>
        <styles>
          <StyleList>
            <fillStyles>
              <TiledBitmap2 objectID="1">
                <matrix>
                  <Transform scaleX="20.00000000000000" scaleY="20.00000000000000" transX="-9206" transY="0"/>
                </matrix>
              </TiledBitmap2>
            </fillStyles>
            <lineStyles/>
          </StyleList>
        </styles>
        <shapes>
          <Shape>
            <edges>
              <ShapeSetup x="5354" y="1800" fillStyle1="1"/>
              <LineTo x="-5354" y="0"/>
              <LineTo x="267" y="-1800"/>
              <LineTo x="5087" y="0"/>
              <LineTo x="0" y="1800"/>
              <ShapeSetup/>
            </edges>
          </Shape>
        </shapes>
      </DefineShape>

         */
        private static DefineShapeTag GetDefineShapeTag1()
        {
            var tag = new DefineShapeTag();
            tag.ShapeID = 2;
            tag.ShapeBounds.XMin = 0;
            tag.ShapeBounds.XMax = 5354;
            tag.ShapeBounds.YMin = 0;
            tag.ShapeBounds.YMax = 1800;
            tag.Shapes.FillStyles.Add(new FillStyle
            {
                FillStyleType = FillStyleType.NonSmoothedRepeatingBitmap,
                BitmapID = 1,
                BitmapMatrix = new SwfMatrix
                {
                    ScaleX = 20.0,
                    ScaleY = 20.0,
                    TranslateX = -9206,
                    TranslateY = 0
                }
            });
            tag.Shapes.ShapeRecords.Add(new StyleChangeShapeRecord
            {
                MoveDeltaX = 5354,
                MoveDeltaY = 1800,
                FillStyle1 = 1
            });
            tag.Shapes.ShapeRecords.Add(new StraightEdgeShapeRecord
            {
                DeltaX = -5354,
                DeltaY = 0
            });
            tag.Shapes.ShapeRecords.Add(new StraightEdgeShapeRecord
            {
                DeltaX = 267,
                DeltaY = -1800
            });
            tag.Shapes.ShapeRecords.Add(new StraightEdgeShapeRecord
            {
                DeltaX = 5087,
                DeltaY = 0
            });
            tag.Shapes.ShapeRecords.Add(new StraightEdgeShapeRecord
            {
                DeltaX = 0,
                DeltaY = 1800
            });
            tag.Shapes.ShapeRecords.Add(new EndShapeRecord());
            return tag;
        }

        [Test]
        public void WriteTest()
        {
            var tag = GetDefineShapeTag1();
            var serializer = new TagSerializer(10);
            var tagData = serializer.GetTagData(tag);
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteTagData(tagData);
            mem.Seek(0, SeekOrigin.Begin);
            var etalon = GetEmbeddedResourceData("DefineShape.bin");
            var payload = GetTagPayload(mem.ToArray());


            var tagReader = new SwfTagReader(10);
            var tagData2 = new SwfTagData { Type = SwfTagType.DefineShape, Data = payload };
            var shape = tagReader.ReadDefineShapeTag(tagData2);
            AssertExt.AreEqual(tag, shape);

            AssertExt.AreEqual(etalon, payload, "Checking DefineShape");
        }

        [Test]
        public void ReadTest()
        {
            var tagReader = new SwfTagReader(10);
            var tagData = new SwfTagData { Type = SwfTagType.DefineShape, Data = GetEmbeddedResourceData("DefineShape.bin") };
            var shape = tagReader.ReadDefineShapeTag(tagData);
            AssertExt.AreEqual(GetDefineShapeTag1(), shape);
        }

        #endregion


        #region DefineShape - 2

        /*
       <DefineShape objectID="7">
        <bounds>
          <Rectangle left="0" right="14560" top="0" bottom="1800"/>
        </bounds>
        <styles>
          <StyleList>
            <fillStyles>
              <Solid>
                <color>
                  <Color red="255" green="255" blue="255"/>
                </color>
              </Solid>
            </fillStyles>
            <lineStyles/>
          </StyleList>
        </styles>
        <shapes>
          <Shape>
            <edges>
              <ShapeSetup x="14560" y="1800" fillStyle1="1"/>
              <LineTo x="-14560" y="0"/>
              <LineTo x="0" y="-1800"/>
              <LineTo x="14560" y="0"/>
              <LineTo x="0" y="1800"/>
              <ShapeSetup/>
            </edges>
          </Shape>
        </shapes>
      </DefineShape>
         */

        private static DefineShapeTag GetDefineShapeTag2()
        {
            var tag = new DefineShapeTag();
            tag.ShapeID = 7;
            tag.ShapeBounds.XMin = 0;
            tag.ShapeBounds.XMax = 14560;
            tag.ShapeBounds.YMin = 0;
            tag.ShapeBounds.YMax = 1800;
            tag.Shapes.FillStyles.Add(new FillStyle
            {
                FillStyleType = FillStyleType.SolidColor,
                ColorRGB = new SwfRGB(255, 255, 255)
            });
            tag.Shapes.ShapeRecords.Add(new StyleChangeShapeRecord
            {
                MoveDeltaX = 14560,
                MoveDeltaY = 1800,
                FillStyle1 = 1
            });
            tag.Shapes.ShapeRecords.Add(new StraightEdgeShapeRecord
            {
                DeltaX = -14560,
                DeltaY = 0
            });
            tag.Shapes.ShapeRecords.Add(new StraightEdgeShapeRecord
            {
                DeltaX = 0,
                DeltaY = -1800
            });
            tag.Shapes.ShapeRecords.Add(new StraightEdgeShapeRecord
            {
                DeltaX = 14560,
                DeltaY = 0
            });
            tag.Shapes.ShapeRecords.Add(new StraightEdgeShapeRecord
            {
                DeltaX = 0,
                DeltaY = 1800
            });
            tag.Shapes.ShapeRecords.Add(new EndShapeRecord());
            return tag;
        }

        [Test]
        public void Read2Test()
        {
            var tagReader = new SwfTagReader(10);
            var tagData = new SwfTagData { Type = SwfTagType.DefineShape, Data = GetEmbeddedResourceData("DefineShape2.bin") };
            var shape = tagReader.ReadDefineShapeTag(tagData);
            AssertExt.AreEqual(GetDefineShapeTag2(), shape);
        }

        [Test]
        public void Write2Test()
        {
            var tag = GetDefineShapeTag2();
            var serializer = new TagSerializer(10);
            var tagData = serializer.GetTagData(tag);
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteTagData(tagData);
            mem.Seek(0, SeekOrigin.Begin);
            var etalon = GetEmbeddedResourceData("DefineShape2.bin");
            var payload = GetTagPayload(mem.ToArray());


            var tagReader = new SwfTagReader(10);
            var tagData2 = new SwfTagData { Type = SwfTagType.DefineShape, Data = payload };
            var shape = tagReader.ReadDefineShapeTag(tagData2);
            AssertExt.AreEqual(tag, shape);

            AssertExt.AreEqual(etalon, payload, "Checking DefineShape");
        }

        #endregion

        protected override string EmbeddedResourceFolder
        {
            get
            {
                return "DefineShape";
            }
        }
    }
}
