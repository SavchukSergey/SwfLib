using System.Xml.Linq;
using Code.SwfLib.Tags.SoundTags;

namespace Code.SwfLib.SwfMill.TagFormatting.SoundTags {
    public class SoundStreamHeadTagFormatter : TagFormatterBase<SoundStreamHeadTag> {
        public override XElement FormatTag(SoundStreamHeadTag tag) {
            throw new System.NotImplementedException();
        }

        public override void AcceptAttribute(SoundStreamHeadTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        public override void AcceptElement(SoundStreamHeadTag tag, XElement element) {
            throw new System.NotImplementedException();
        }
    }
}
