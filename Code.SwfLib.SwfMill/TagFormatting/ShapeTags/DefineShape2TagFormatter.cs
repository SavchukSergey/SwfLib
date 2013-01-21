using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeTags {
    public class DefineShape2TagFormatter : TagFormatterBase<DefineShape2Tag> {
        private const string BOUNDS_ELEM = "bounds";

        protected override XElement FormatTagElement(DefineShape2Tag tag) {
            var res = new XElement(SwfTagNameMapping.DEFINE_SHAPE2_TAG,
                 new XAttribute(OBJECT_ID_ATTRIB, tag.ShapeID),
                 new XElement(XName.Get(BOUNDS_ELEM), _formatters.Rectangle.Format(ref tag.ShapeBounds))
           );
            return res;
        }

        protected override void AcceptTagAttribute(DefineShape2Tag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case OBJECT_ID_ATTRIB:
                    tag.ShapeID = SwfMillPrimitives.ParseObjectID(attrib);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(DefineShape2Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case BOUNDS_ELEM:
                    _formatters.Rectangle.Parse(element.Element(XName.Get("Rectangle")), out tag.ShapeBounds);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }
    }
}
