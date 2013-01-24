using System.Xml.Linq;
using Code.SwfLib.Tags.BitmapTags;

namespace Code.SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class DefineBitsJPEG3TagFormatter : TagFormatterBase<DefineBitsJPEG3Tag> {

        protected override XElement FormatTagElement(DefineBitsJPEG3Tag tag, XElement xTag) {
            return xTag;
        }

        protected override void AcceptTagAttribute(DefineBitsJPEG3Tag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagElement(DefineBitsJPEG3Tag tag, XElement element) {
            throw new System.NotImplementedException();
        }

        public override string TagName {
            get { return "DefineBitsJPEG3"; }
        }

        protected override ushort? GetObjectID(DefineBitsJPEG3Tag tag) {
            return tag.CharacterID;
        }

        protected override void SetObjectID(DefineBitsJPEG3Tag tag, ushort value) {
            tag.CharacterID = value;
        }
    }
}
