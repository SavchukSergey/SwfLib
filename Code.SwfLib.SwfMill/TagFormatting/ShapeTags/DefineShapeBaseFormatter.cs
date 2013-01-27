using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeTags {
    public abstract class DefineShapeBaseFormatter<T> : TagFormatterBase<T> where T : ShapeBaseTag {

        private const string BOUNDS_ELEM = "bounds";
        private const string SHAPES_ELEM = "shapes";
        private const string STYLES_ELEM = "styles";

        protected sealed override XElement FormatTagElement(T tag, XElement xTag) {
            FormatAdditionalAttributes(tag, xTag);

            xTag.Add(new XElement(BOUNDS_ELEM, XRect.ToXml(tag.ShapeBounds)));

            FormatAdditionalBounds(tag, xTag);

            var xStyles = new XElement(STYLES_ELEM, FormatStyles(tag));
            xTag.Add(xStyles);

            var xShapes = new XElement(SHAPES_ELEM, FormatShape(tag));
            xTag.Add(xShapes);

            return xTag;
        }

        protected abstract XElement FormatStyles(T tag);
        protected abstract XElement FormatShape(T tag);

        protected abstract void ReadShapes(T tag, XElement xShape);
        protected abstract void ReadStyles(T tag, XElement xStyleList);

        protected sealed override void AcceptTagAttribute(T tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected sealed override void AcceptTagElement(T tag, XElement element) {
            switch (element.Name.LocalName) {
                case BOUNDS_ELEM:
                    tag.ShapeBounds = XRect.FromXml(element.Element("Rectangle"));
                    break;
                case STYLES_ELEM:
                    var xStyleList = element.Element("StyleList");
                    ReadStyles(tag, xStyleList);
                    break;
                case SHAPES_ELEM:
                    var xShape = element.Element("Shape");
                    ReadShapes(tag, xShape);
                    break;
                default:
                    AcceptShapeTagElement(tag, element);
                    break;
            }
        }

        protected virtual void FormatAdditionalAttributes(T tag, XElement xTag) { }

        protected virtual void FormatAdditionalBounds(T tag, XElement elem) { }

        protected virtual void AcceptShapeTagElement(T tag, XElement element) { }

        protected override ushort? GetObjectID(T tag) {
            return tag.ShapeID;
        }

        protected override void SetObjectID(T tag, ushort value) {
            tag.ShapeID = value;
        }
    }
}
