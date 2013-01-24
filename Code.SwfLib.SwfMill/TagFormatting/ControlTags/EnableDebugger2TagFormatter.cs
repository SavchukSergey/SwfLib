using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class EnableDebugger2TagFormatter : TagFormatterBase<EnableDebugger2Tag> {
        protected override XElement FormatTagElement(EnableDebugger2Tag tag, XElement xTag) {
            return xTag;
        }

        protected override void AcceptTagAttribute(EnableDebugger2Tag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagElement(EnableDebugger2Tag tag, XElement element) {
            throw new System.NotImplementedException();
        }

        protected override string TagName {
            get { return "EnableDebugger2"; }
        }
    }
}
