using System.Xml.Linq;
using SwfLib.Tags.BitmapTags;

namespace SwfLib.SwfMill.TagFormatting.BitmapTags {
    /// <summary>
    /// Represents DefineBits tag formatter.
    /// </summary>
    public class DefineBitsTagFormatter : TagFormatterBase<DefineBitsTag> {

        protected override void FormatTagElement(DefineBitsTag tag, XElement xTag) {
        }

        protected override byte[] GetData(DefineBitsTag tag) {
            return tag.JPEGData;
        }

        protected override void SetData(DefineBitsTag tag, byte[] data) {
            tag.JPEGData = data;
        }

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public override string TagName {
            get { return "DefineBits"; }
        }
    }
}
