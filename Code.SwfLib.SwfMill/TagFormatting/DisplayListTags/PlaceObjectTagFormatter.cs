using System.Xml.Linq;
using Code.SwfLib.Tags.DisplayListTags;

namespace Code.SwfLib.SwfMill.TagFormatting.DisplayListTags {
    public class PlaceObjectTagFormatter : PlaceObjectBaseFormatter<PlaceObjectTag> {

        protected override void FormatPlaceElement(PlaceObjectTag tag, XElement elem) {
        }

        protected override void AcceptPlaceAttribute(PlaceObjectTag tag, XAttribute attrib) {
        }

        protected override void AcceptPlaceTagElement(PlaceObjectTag tag, XElement element) {
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

        protected override string TagName {
            get { return SwfTagNameMapping.PLACE_OBJECT_TAG; }
        }

    }
}
