using System.Xml.Linq;
using SwfLib.SwfMill.Data;
using SwfLib.Tags.ShapeTags;

namespace SwfLib.SwfMill.TagFormatting.ShapeTags {
    public abstract class DefineShapeBaseFormatter<T> : TagFormatterBase<T> where T : ShapeBaseTag {

        private const string BOUNDS_ELEM = "bounds";
        private const string SHAPES_ELEM = "shapes";
        private const string STYLES_ELEM = "styles";

        protected sealed override void FormatTagElement(T tag, XElement xTag) {
            FormatAdditionalAttributes(tag, xTag);

            xTag.Add(new XElement(BOUNDS_ELEM, XRect.ToXml(tag.ShapeBounds)));

            FormatAdditionalBounds(tag, xTag);

            var xStyles = new XElement(STYLES_ELEM, FormatStyles(tag));
            xTag.Add(xStyles);

            var xShapes = new XElement(SHAPES_ELEM, FormatShape(tag));
            xTag.Add(xShapes);
        }

        protected abstract XElement FormatStyles(T tag);
        protected abstract XElement FormatShape(T tag);

        protected abstract void ReadShapes(T tag, XElement xShape);
        protected abstract void ReadStyles(T tag, XElement xStyleList);

        protected sealed override bool AcceptTagAttribute(T tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                default:
                    var handled = AcceptShapeAttribute(tag, attrib);
                    return handled;
            }
        }

        protected sealed override bool AcceptTagElement(T tag, XElement element) {
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
                    return AcceptShapeTagElement(tag, element);
            }
            return true;
        }

        protected virtual void FormatAdditionalAttributes(T tag, XElement xTag) { }

        protected virtual void FormatAdditionalBounds(T tag, XElement elem) { }

        protected virtual bool AcceptShapeTagElement(T tag, XElement element) {
            return false;
        }

        protected virtual bool AcceptShapeAttribute(T tag, XAttribute attribute) {
            return false;
        }

        protected override ushort? GetObjectID(T tag) {
            return tag.ShapeID;
        }

        protected override void SetObjectID(T tag, ushort value) {
            tag.ShapeID = value;
        }
    }
}
