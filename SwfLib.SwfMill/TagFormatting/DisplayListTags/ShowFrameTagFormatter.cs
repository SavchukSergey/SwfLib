using System.Xml.Linq;
using SwfLib.Tags.DisplayListTags;

namespace SwfLib.SwfMill.TagFormatting.DisplayListTags {
    /// <summary>
    /// Represents ShowFrameTag xml formatter.
    /// </summary>
    public class ShowFrameTagFormatter : TagFormatterBase<ShowFrameTag> {

        protected override void FormatTagElement(ShowFrameTag tag, XElement xTag) {
        }

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public override string TagName {
            get { return "ShowFrame"; }
        }
    }
}