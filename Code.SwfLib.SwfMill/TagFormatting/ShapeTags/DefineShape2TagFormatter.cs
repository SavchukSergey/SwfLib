using System.Xml.Linq;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeTags {
    public class DefineShape2TagFormatter : DefineShapeBaseFormatter<DefineShape2Tag> {

        protected override void FormatShapeElement(DefineShape2Tag tag, XElement elem) {
        }

        protected override void AcceptShapeTagElement(DefineShape2Tag tag, XElement element) {
        }

        protected override string TagName {
            get { return SwfTagNameMapping.DEFINE_SHAPE2_TAG; }
        }
    }
}
