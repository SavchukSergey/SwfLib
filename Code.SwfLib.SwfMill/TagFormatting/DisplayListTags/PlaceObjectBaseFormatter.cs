using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Tags.DisplayListTags;

namespace Code.SwfLib.SwfMill.TagFormatting.DisplayListTags {
    public abstract class PlaceObjectBaseFormatter<T> : TagFormatterBase<T> where T : PlaceObjectBaseTag {

        private const string DEPTH_ATTRIB = "depth";
        private const string TRANSFORM_ELEM = "transform";

        protected sealed override XElement FormatTagElement(T tag) {
            var res = new XElement(TagName);

            if (HasCharacter(tag)) {
                res.Add(new XAttribute(OBJECT_ID_ATTRIB, tag.CharacterID));
            }

            res.Add(new XAttribute(DEPTH_ATTRIB, tag.Depth));

            if (HasMatrix(tag)) {
                res.Add(new XElement(TRANSFORM_ELEM, _formatters.Matrix.Format(ref tag.Matrix)));
            }

            FormatPlaceElement(tag, res);
            return res;
        }

        protected sealed override void AcceptTagAttribute(T tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case OBJECT_ID_ATTRIB:
                    tag.CharacterID = SwfMillPrimitives.ParseObjectID(attrib);
                    HasCharacter(tag, true);
                    break;
                case DEPTH_ATTRIB:
                    tag.Depth = ushort.Parse(attrib.Value);
                    break;
                default:
                    AcceptPlaceAttribute(tag, attrib);
                    break;
            }
        }

        protected sealed override void AcceptTagElement(T tag, XElement element) {
            switch (element.Name.LocalName) {
                case TRANSFORM_ELEM:
                    SwfMatrix matrix;
                    _formatters.Matrix.Parse(element.Element(TRANSFORM_TYPE_ELEM), out matrix);
                    tag.Matrix = matrix;
                    HasMatrix(tag, true);
                    break;
                default:
                    AcceptPlaceTagElement(tag, element);
                    break;
            }
        }

        protected abstract string TagName { get; }
        protected abstract void FormatPlaceElement(T tag, XElement elem);

        protected abstract bool HasCharacter(T tag);
        protected abstract void HasCharacter(T tag, bool val);

        protected abstract bool HasMatrix(T tag);
        protected abstract void HasMatrix(T tag, bool val);

        protected abstract void AcceptPlaceAttribute(T tag, XAttribute attrib);
        protected abstract void AcceptPlaceTagElement(T tag, XElement element);
    }
}
