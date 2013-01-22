using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeTags {
    public abstract class DefineShapeBaseFormatter<T> : TagFormatterBase<T> where T : ShapeBaseTag {
        
        private const string BOUNDS_ELEM = "bounds";

        protected sealed override XElement FormatTagElement(T tag) {
            var res = new XElement(TagName);
            res.Add(new XAttribute(OBJECT_ID_ATTRIB, tag.ShapeID));
            res.Add(new XElement(BOUNDS_ELEM, _formatters.Rectangle.Format(ref tag.ShapeBounds)));
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

        protected abstract void FormatShapeElement(T tag, XElement elem);
        protected abstract void AcceptShapeTagElement(T tag, XElement element);
        protected abstract string TagName { get; }
    }
}
