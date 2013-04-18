using System.Xml.Linq;
using SwfLib.SwfMill.Shapes;
using SwfLib.Tags.ShapeTags;

namespace SwfLib.SwfMill.TagFormatting.ShapeTags {
    /// <summary>
    /// Represents DefineShape2Tag xml formatter.
    /// </summary>
    public class DefineShape2TagFormatter : DefineShapeBaseFormatter<DefineShape2Tag> {

        protected override XElement FormatStyles(DefineShape2Tag tag) {
            return XStyleList.ToXml(tag.FillStyles, tag.LineStyles);
        }

        protected override XElement FormatShape(DefineShape2Tag tag) {
            return XShape.ToXml(tag.ShapeRecords);
        }

        protected override void ReadShapes(DefineShape2Tag tag, XElement xShape) {
            XShape.FromXml(xShape, tag.ShapeRecords);
        }

        protected override void ReadStyles(DefineShape2Tag tag, XElement xStyleList) {
            XStyleList.FromXml(xStyleList, tag.FillStyles, tag.LineStyles);
        }

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public override string TagName {
            get { return "DefineShape2"; }
        }
    }
}
