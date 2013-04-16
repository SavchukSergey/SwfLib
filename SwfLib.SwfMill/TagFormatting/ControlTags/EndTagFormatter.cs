using System.Xml.Linq;
using SwfLib.Tags.ControlTags;

namespace SwfLib.SwfMill.TagFormatting.ControlTags {
    public class EndTagFormatter : TagFormatterBase<EndTag> {

        protected override void FormatTagElement(EndTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "End"; }
        }
    }
}