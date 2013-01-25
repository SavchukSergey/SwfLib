using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeTags {
    public abstract class DefineShapeBaseFormatter<T> : TagFormatterBase<T> where T : ShapeBaseTag {

        private const string BOUNDS_ELEM = "bounds";
        private const string SHAPES_ELEM = "shapes";
        protected const string STYLES_ELEM = "styles";


        protected sealed override XElement FormatTagElement(T tag, XElement xTag) {
            xTag.Add(new XElement(BOUNDS_ELEM, XRect.ToXml(tag.ShapeBounds)));

            FormatAdditionalBounds(tag, xTag);

            var xStyles = new XElement("styles");
            WriteStyles(tag, xStyles);
            xTag.Add(xStyles);

            FormatShapeElement(tag, xTag);
            return xTag;
        }

        protected void FormatShapeElement(T tag, XElement xml) {
            var xShapes = new XElement(SHAPES_ELEM);
            var xShape = new XElement("Shape");

            var xEdges = new XElement("edges");

            WriteShapes(tag, xEdges);

            xShape.Add(xEdges);
            xShapes.Add(xShape);
            xml.Add(xShapes);
        }

        protected abstract void WriteStyles(T tag, XElement xStyles);

        protected abstract void ReadShapes(T tag, XElement xEdges);

        protected abstract void WriteShapes(T tag, XElement xEdges);

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
                case SHAPES_ELEM:
                    var array = element.Element(XName.Get("Shape"));
                    var xEdges = array.Element("edges");
                    if (xEdges != null) {
                        ReadShapes(tag, xEdges);
                    }
                    break;
                default:
                    AcceptShapeTagElement(tag, element);
                    break;
            }
        }

        protected static XElement FormatFillStyle(FillStyleRGB style) {
            var fillStyle = style;
            return _formatters.FillStyleRGB.Format(ref fillStyle);
        }

        protected static XElement FormatFillStyle(FillStyleRGBA style) {
            var fillStyle = style;
            return _formatters.FillStyleRGBA.Format(ref fillStyle);
        }

        protected virtual void FormatAdditionalBounds(T tag, XElement elem) { }
        protected abstract void AcceptShapeTagElement(T tag, XElement element);

        protected override ushort? GetObjectID(T tag) {
            return tag.ShapeID;
        }

        protected override void SetObjectID(T tag, ushort value) {
            tag.ShapeID = value;
        }
    }
}
