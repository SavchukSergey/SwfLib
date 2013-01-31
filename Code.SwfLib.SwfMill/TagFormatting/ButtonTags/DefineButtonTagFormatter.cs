using System.Xml.Linq;
using Code.SwfLib.Tags.ButtonTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ButtonTags {
    public class DefineButtonTagFormatter : DefineButtonBaseTagFormatter<DefineButtonTag> {
        
        protected override void FormatTagElement(DefineButtonTag tag, XElement xTag) {
        }

        protected override void AcceptTagElement(DefineButtonTag tag, XElement element) {
        }

        public override string TagName {
            get { return "DefineButton"; }
        }
    }
}
