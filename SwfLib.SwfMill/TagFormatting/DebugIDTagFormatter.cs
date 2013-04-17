using System.Xml.Linq;
using SwfLib.Tags;

namespace SwfLib.SwfMill.TagFormatting {
    /// <summary>
    /// Represents DebugID xml formatter.
    /// </summary>
    public class DebugIDTagFormatter : TagFormatterBase<DebugIDTag> {
        protected override void FormatTagElement(DebugIDTag tag, XElement xTag) {
        }

        protected override byte[] GetData(DebugIDTag tag) {
            return tag.Data;
        }

        protected override void SetData(DebugIDTag tag, byte[] data) {
            tag.Data = data;
        }

        /// <summary>
        /// Gets the name of the tag.
        /// </summary>
        public override string TagName {
            get { return "DebugID"; }
        }
    }
}
