using System.Xml.Linq;
using SwfLib.Tags.ButtonTags;

namespace SwfLib.SwfMill.TagFormatting.ButtonTags {
    /// <summary>
    /// Represents DefineButtonSound tag formatter.
    /// </summary>
    public class DefineButtonSoundTagFormatter : DefineButtonBaseTagFormatter<DefineButtonSoundTag> {
        
        protected override void FormatTagElement(DefineButtonSoundTag tag, XElement xTag) {
        }

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public override string TagName {
            get { return "DefineButtonSound"; }
        }
    }
}
