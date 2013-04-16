using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class EndTagFormatter : TagFormatterBase<EndTag> {

        protected override void FormatTagElement(EndTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "End"; }
        }
    }
}