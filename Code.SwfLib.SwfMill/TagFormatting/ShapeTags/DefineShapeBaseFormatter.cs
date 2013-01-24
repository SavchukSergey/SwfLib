using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Shapes;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeTags {
    public abstract class DefineShapeBaseFormatter<T> : TagFormatterBase<T> where T : ShapeBaseTag {

        private const string BOUNDS_ELEM = "bounds";
        private const string SHAPES_ELEM = "shapes";

        protected sealed override XElement FormatTagElement(T tag, XElement xTag) {
            xTag.Add(new XElement(BOUNDS_ELEM, XRect.ToXml(tag.ShapeBounds)));

            FormatAdditionalBounds(tag, xTag);

            var xStyles = new XElement("styles");
            xTag.Add(xStyles);

            var xStyleList = new XElement("StyleList");

            var xFillStyles = new XElement("fillStyles");
            FormatFillStyles(tag, xFillStyles);
            xStyleList.Add(xFillStyles);

            var xLineStyles = new XElement("lineStyles");
            FormatLineStyles(tag, xLineStyles);
            xStyleList.Add(xLineStyles);

            xStyles.Add(xStyleList);

            FormatShapeElement(tag, xTag);
            return xTag;
        }

        protected abstract void FormatFillStyles(T tag, XElement xFillStyles);

        protected abstract void FormatLineStyles(T tag, XElement xLineStyles);

        protected void FormatShapeElement(T tag, XElement xml) {
            var xShapes = new XElement(SHAPES_ELEM);
            var xShape = new XElement("Shape");

            var xEdges = new XElement("edges");

            foreach (var shapeRecord in tag.ShapeRecords) {
                xEdges.Add(XShapeRecord.ToXml(shapeRecord));
            }

            xShape.Add(xEdges);
            xShapes.Add(xShape);
            xml.Add(xShapes);
        }

        private static void ReadShapes(T tag, XElement shapes) {
            var array = shapes.Element(XName.Get("Shape"));
            var edges = array.Element("edges");
            if (edges != null) {
                foreach (var xShapeRecord in edges.Elements()) {
                    tag.ShapeRecords.Add(XShapeRecord.FromXml(xShapeRecord));
                }
            }
        }

        protected sealed override void AcceptTagAttribute(T tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case OBJECT_ID_ATTRIB:
                    tag.ShapeID = SwfMillPrimitives.ParseObjectID(attrib);
                    break;
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
                    ReadShapes(tag, element);
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
    }
}
