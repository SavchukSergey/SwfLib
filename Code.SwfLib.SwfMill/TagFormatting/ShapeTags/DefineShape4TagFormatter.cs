using System.Xml.Linq;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeTags {
    public class DefineShape4TagFormatter : TagFormatterBase<DefineShape4Tag> {
        protected override XElement FormatTagElement(DefineShape4Tag tag) {
            return new XElement(SwfTagNameMapping.DEFINE_SHAPE_4_TAG);
        }

        protected override void AcceptTagAttribute(DefineShape4Tag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagElement(DefineShape4Tag tag, XElement element) {
            throw new System.NotImplementedException();
        }
    }
}
