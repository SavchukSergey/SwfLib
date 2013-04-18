using System.Xml.Linq;
using SwfLib.Tags.SoundTags;

namespace SwfLib.SwfMill.TagFormatting.SoundTags {
    /// <summary>
    /// Represents StartSound2Tag xml formatter.
    /// </summary>
    public class StartSound2TagFormatter : TagFormatterBase<StartSound2Tag> {
        
        protected override void FormatTagElement(StartSound2Tag tag, XElement xTag) {
        }

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public override string TagName {
            get { return "StartSound2"; }
        }
    }
}
