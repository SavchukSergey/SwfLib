using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeTags {
    public class DefineShape3TagFormatter : TagFormatterBase<DefineShape3Tag> {

        private const string BOUNDS_ELEM = "bounds";
        private const string STYLES_ELEM = "styles";
        private const string SHAPES_ELEM = "shapes";

        protected override void AcceptTagAttribute(DefineShape3Tag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case OBJECT_ID_ATTRIB:
                    tag.ObjectID = SwfMillPrimitives.ParseObjectID(attrib);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(DefineShape3Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case BOUNDS_ELEM:
                    _formatters.Rectangle.Parse(element.Element(XName.Get("Rectangle")), out tag.Bounds);
                    break;
                case STYLES_ELEM:
                    ReadStyles(tag, element);
                    break;
                case SHAPES_ELEM:
                    ReadShapes(tag, element);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        private static void ReadStyles(DefineShape3Tag tag, XElement styleElements) {
            //TODO: Implement styles reading;
        }

        private static void ReadShapes(DefineShape3Tag tag, XElement shapes) {
            //TODO: Implement shapes reading;
        }

        protected override XElement FormatTagElement(DefineShape3Tag tag) {
            return new XElement(XName.Get(SwfTagNameMapping.DEFINE_SHAPE3_TAG));
        }
    }
}