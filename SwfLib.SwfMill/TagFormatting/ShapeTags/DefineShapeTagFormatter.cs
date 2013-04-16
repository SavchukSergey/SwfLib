using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Shapes;
using SwfLib.SwfMill.Shapes;
using SwfLib.Tags.ShapeTags;

namespace SwfLib.SwfMill.TagFormatting.ShapeTags {
    public class DefineShapeTagFormatter : DefineShapeBaseFormatter<DefineShapeTag> {

        protected override XElement FormatStyles(DefineShapeTag tag) {
            return XStyleList.ToXml(tag.FillStyles, tag.LineStyles);
        }

        protected override XElement FormatShape(DefineShapeTag tag) {
            return XShape.ToXml(tag.ShapeRecords);
        }

        protected override void ReadShapes(DefineShapeTag tag, XElement xShape) {
            XShape.FromXml(xShape, tag.ShapeRecords);
        }

        protected override void ReadStyles(DefineShapeTag tag, XElement xStyleList) {
            XStyleList.FromXml(xStyleList, tag.FillStyles, tag.LineStyles);
        }

        protected override bool AcceptShapeTagElement(DefineShapeTag tag, XElement element) {
            switch (element.Name.LocalName) {
                
                default:
                    throw new FormatException("Invalid xRecords " + element.Name.LocalName);
            }
        }

        public override string TagName {
            get { return "DefineShape"; }
        }


    }
}