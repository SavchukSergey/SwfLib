using System.Xml.Linq;
using SwfLib.SwfMill.Data;
using SwfLib.Tags.DisplayListTags;

namespace SwfLib.SwfMill.TagFormatting.DisplayListTags {
    public class PlaceObjectTagFormatter : PlaceObjectBaseFormatter<PlaceObjectTag> {

        private const string COLOR_TRANSFORM_ELEM = "colorTransform";

        protected override void FormatPlaceElement(PlaceObjectTag tag, XElement elem) {
            if (tag.ColorTransform.HasValue) {
                elem.Add(new XElement(COLOR_TRANSFORM_ELEM, XColorTransformRGB.ToXml(tag.ColorTransform.Value)));
            }
        }

        protected override bool AcceptPlaceTagElement(PlaceObjectTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case COLOR_TRANSFORM_ELEM:
                    tag.ColorTransform = XColorTransformRGB.FromXml(element.Element(XColorTransformRGB.TAG_NAME));
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override bool HasCharacter(PlaceObjectTag tag) {
            return true;
        }

        protected override void HasCharacter(PlaceObjectTag tag, bool val) {
        }

        protected override bool HasMatrix(PlaceObjectTag tag) {
            return true;
        }

        protected override void HasMatrix(PlaceObjectTag tag, bool val) {
        }

        public override string TagName {
            get { return "PlaceObject"; }
        }

    }
}
