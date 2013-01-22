using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Code.SwfLib.Data.FillStyles;
using Code.SwfLib.Data.Shapes;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeTags {
    public abstract class DefineShapeBaseFormatter<T> : TagFormatterBase<T> where T : ShapeBaseTag {

        private const string BOUNDS_ELEM = "bounds";

        protected sealed override XElement FormatTagElement(T tag) {
            var res = new XElement(TagName);
            res.Add(new XAttribute(OBJECT_ID_ATTRIB, tag.ShapeID));
            res.Add(new XElement(BOUNDS_ELEM, _formatters.Rectangle.Format(ref tag.ShapeBounds)));

            FormatAdditionalBounds(tag, res);

            var xStyles = new XElement("styles");
            res.Add(xStyles);

            var xStyleList = new XElement("StyleList");
            xStyleList.Add(FormatFillStyles(tag.FillStyles));
            xStyles.Add(xStyleList);

            FormatShapeElement(tag, res);
            return res;
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
                    _formatters.Rectangle.Parse(element.Element("Rectangle"), out tag.ShapeBounds);
                    break;
                default:
                    AcceptShapeTagElement(tag, element);
                    break;
            }
        }

        protected static XElement FormatEdges(IEnumerable<ShapeRecord> edges) {
            var edgesElem = new XElement("edges");

            foreach (var shape in edges) {
                var styleChange = shape as StyleChangeShapeRecord;
                if (styleChange != null) edgesElem.Add(FormatShapeSetup(styleChange));
                var endRecord = shape as EndShapeRecord;
                if (endRecord != null) edgesElem.Add(FormatEndRecord(endRecord));
                var lineRecord = shape as StraightEdgeShapeRecord;
                if (lineRecord != null) edgesElem.Add(FormatStraightEdgeShapeRecord(lineRecord));
                var curvedRecord = shape as CurvedEdgeShapeRecord;
                if (curvedRecord != null) edgesElem.Add(FormatCurvedEdgeShapeRecord(curvedRecord));
                //TODO: default behavior? throw new exception
            }
            return edgesElem;
        }

        private static XElement FormatShapeSetup(StyleChangeShapeRecord styleChange) {
            var setup = new XElement("ShapeSetup");
            if (styleChange.FillStyle0.HasValue) {
                setup.Add(new XAttribute(XName.Get("fillStyle0"), styleChange.FillStyle0.Value));
            }
            if (styleChange.FillStyle1.HasValue) {
                setup.Add(new XAttribute(XName.Get("fillStyle1"), styleChange.FillStyle1.Value));
            }
            //TODO: line style
            setup.Add(new XAttribute(XName.Get("x"), styleChange.MoveDeltaX));
            setup.Add(new XAttribute(XName.Get("y"), styleChange.MoveDeltaY));

            //TODO: Glyphs  
            return setup;
        }

        private static XElement FormatEndRecord(EndShapeRecord endRecord) {
            var setup = new XElement("ShapeSetup");
            return setup;
        }

        private static XElement FormatStraightEdgeShapeRecord(StraightEdgeShapeRecord record) {
            return new XElement("LineTo",
                new XAttribute("x", record.DeltaX),
                new XAttribute("y", record.DeltaY)
            );
        }

        private static XElement FormatCurvedEdgeShapeRecord(CurvedEdgeShapeRecord record) {
            return new XElement("CurveTo",
                new XAttribute("x1", record.ControlDeltaX),
                new XAttribute("y1", record.ControlDeltaY),
                new XAttribute("x2", record.AnchorDeltaX),
                new XAttribute("y2", record.AnchorDeltaY)
            );
        }

        protected static XElement FormatFillStyles(IEnumerable<FillStyle> styles) {
            var fillStylesElem = new XElement("fillStyles");
            foreach (var style in styles) {
                var fillStyle = style;
                fillStylesElem.Add(_formatters.FillStyle1.Format(ref fillStyle));
            }
            return fillStylesElem;
        }

        protected virtual void FormatAdditionalBounds(T tag, XElement elem) { }
        protected abstract void FormatShapeElement(T tag, XElement elem);
        protected abstract void AcceptShapeTagElement(T tag, XElement element);
        protected abstract string TagName { get; }
    }
}
