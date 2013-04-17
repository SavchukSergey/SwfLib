using System.Xml.Linq;
using SwfLib.Tags.ButtonTags;

namespace SwfLib.SwfMill.TagFormatting.ButtonTags {
    public class DefineButtonTagFormatter : DefineButtonBaseTagFormatter<DefineButtonTag> {

        protected override void FormatTagElement(DefineButtonTag tag, XElement xTag) {
        }

        /// <summary>
        /// Gets the name of the tag.
        /// </summary>
        public override string TagName {
            get { return "DefineButton"; }
        }
    }
}
