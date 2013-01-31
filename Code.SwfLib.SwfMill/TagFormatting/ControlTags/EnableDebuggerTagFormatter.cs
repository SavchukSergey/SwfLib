using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class EnableDebuggerTagFormatter : TagFormatterBase<EnableDebuggerTag> {
        
        protected override void FormatTagElement(EnableDebuggerTag tag, XElement xTag) {
        }

        protected override void AcceptTagAttribute(EnableDebuggerTag tag, XAttribute attrib) {
        }

        protected override void AcceptTagElement(EnableDebuggerTag tag, XElement element) {
        }

        public override string TagName {
            get { return "EnableDebugger"; }
        }
    }
}
