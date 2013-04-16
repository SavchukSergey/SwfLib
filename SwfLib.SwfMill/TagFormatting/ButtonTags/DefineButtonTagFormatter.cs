using System.Xml.Linq;
using SwfLib.Tags.ButtonTags;

namespace SwfLib.SwfMill.TagFormatting.ButtonTags {
    public class DefineButtonTagFormatter : DefineButtonBaseTagFormatter<DefineButtonTag> {
        
        protected override void FormatTagElement(DefineButtonTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DefineButton"; }
        }
    }
}
