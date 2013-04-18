using System.Xml.Linq;
using SwfLib.Tags.SoundTags;

namespace SwfLib.SwfMill.TagFormatting.SoundTags {
    /// <summary>
    /// Represents SoundStreamHeadTag xml formatter.
    /// </summary>
    public class SoundStreamHeadTagFormatter : TagFormatterBase<SoundStreamHeadTag> {
        protected override void FormatTagElement(SoundStreamHeadTag tag, XElement xTag) {
        }

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public override string TagName {
            get { return "SoundStreamHeadTag"; }
        }
    }
}
