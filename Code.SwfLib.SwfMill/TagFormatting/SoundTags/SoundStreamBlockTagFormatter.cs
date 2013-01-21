using System.Xml.Linq;
using Code.SwfLib.Tags.SoundTags;

namespace Code.SwfLib.SwfMill.TagFormatting.SoundTags {
    public class SoundStreamBlockTagFormatter : TagFormatterBase<SoundStreamBlockTag> {
        protected override XElement FormatTagElement(SoundStreamBlockTag tag) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagAttribute(SoundStreamBlockTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagElement(SoundStreamBlockTag tag, XElement element) {
            throw new System.NotImplementedException();
        }
    }
}
