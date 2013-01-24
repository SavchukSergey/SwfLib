using System.Xml.Linq;
using Code.SwfLib.Tags.BitmapTags;

namespace Code.SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class DefineBitsJPEG4TagFormatter : TagFormatterBase<DefineBitsJPEG4Tag> {
        
        protected override XElement FormatTagElement(DefineBitsJPEG4Tag tag, XElement xTag) {
            return xTag;
        }

        protected override void AcceptTagAttribute(DefineBitsJPEG4Tag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagElement(DefineBitsJPEG4Tag tag, XElement element) {
            throw new System.NotImplementedException();
        }

        protected override string TagName {
            get { return "DefineBitsJPEG4"; }
        }

        protected override ushort? GetObjectID(DefineBitsJPEG4Tag tag) {
            return tag.CharacterID;
        }

        protected override void SetObjectID(DefineBitsJPEG4Tag tag, ushort value) {
            tag.CharacterID = value;
        }
    }
}
