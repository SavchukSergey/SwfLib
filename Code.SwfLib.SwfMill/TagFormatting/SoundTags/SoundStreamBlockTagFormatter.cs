using System.Xml.Linq;
using Code.SwfLib.Tags.SoundTags;

namespace Code.SwfLib.SwfMill.TagFormatting.SoundTags {
    public class SoundStreamBlockTagFormatter : TagFormatterBase<SoundStreamBlockTag> {
        public override XElement FormatTag(SoundStreamBlockTag tag) {
            throw new System.NotImplementedException();
        }

        public override void AcceptAttribute(SoundStreamBlockTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        public override void AcceptElement(SoundStreamBlockTag tag, XElement element) {
            throw new System.NotImplementedException();
        }
    }
}
