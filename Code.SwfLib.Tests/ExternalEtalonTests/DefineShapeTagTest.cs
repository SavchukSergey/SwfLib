using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code.SwfLib.Data;
using Code.SwfLib.Data.FillStyles;
using Code.SwfLib.Data.Shapes;
using Code.SwfLib.Tags;
using NUnit.Framework;

namespace Code.SwfLib.Tests.ExternalEtalonTests {
    [TestFixture]
    public class DefineShapeTagTest : ExternalEtalonTestFixtureBase {

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
        [Test]
        public void ReadTest() {
            var tagReader = new SwfTagReader(10);
            var tagData = new SwfTagData { Type = SwfTagType.DefineShape, Data = GetEmbeddedResourceData("DefineShape.bin") };
            var shape = tagReader.ReadDefineShapeTag(tagData);
            Assert.AreEqual(2, shape.ShapeID);
            Assert.AreEqual(6, shape.Shapes.ShapeRecords.Count);
            //TODO: Assert other fields
        }

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
        [Test]
        public void Read2Test() {
            var tagReader = new SwfTagReader(10);
            var tagData = new SwfTagData { Type = SwfTagType.DefineShape, Data = GetEmbeddedResourceData("DefineShape2.bin") };
            var shape = tagReader.ReadDefineShapeTag(tagData);
            Assert.AreEqual(7, shape.ShapeID);
            Assert.AreEqual(0, shape.ShapeBounds.XMin);
            Assert.AreEqual(14560, shape.ShapeBounds.XMax);
            Assert.AreEqual(0, shape.ShapeBounds.YMin);
            Assert.AreEqual(1800, shape.ShapeBounds.YMax);
            Assert.AreEqual(1, shape.Shapes.FillStyles.Count);
            Assert.IsAssignableFrom(typeof(SolidRGBFillStyle), shape.Shapes.FillStyles[0]);
            Assert.AreEqual(new SwfRGB(255, 255, 255), ((SolidRGBFillStyle)shape.Shapes.FillStyles[0]).Color);
            Assert.AreEqual(0, shape.Shapes.LineStyles.Count);
            Assert.AreEqual(6, shape.Shapes.ShapeRecords.Count);
            Assert.IsAssignableFrom(typeof(StyleChangeShapeRecord), shape.Shapes.ShapeRecords[0]);
            //TODO: Assert other fields
        }

        protected override string EmbeddedResourceFolder {
            get {
                return "DefineShape";
            }
        }
    }
}
