using System.Xml.Linq;
using Code.SwfLib.Tags.BitmapTags;

namespace SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class DefineBitsJPEG2TagFormatter : DefineBitmapBaseTagFormatter<DefineBitsJPEG2Tag> {

        protected override void FormatTagElement(DefineBitsJPEG2Tag tag, XElement xTag) {
        }

        protected override byte[] GetData(DefineBitsJPEG2Tag tag) {
            return tag.ImageData;
        }

        protected override void SetData(DefineBitsJPEG2Tag tag, byte[] data) {
            tag.ImageData = data;
        }

        public override string TagName {
            get { return "DefineBitsJPEG2"; }
        }

    }
}