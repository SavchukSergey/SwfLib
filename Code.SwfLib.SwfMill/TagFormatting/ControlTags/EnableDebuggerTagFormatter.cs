using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class EnableDebuggerTagFormatter : TagFormatterBase<EnableDebuggerTag> {
        protected override XElement FormatTagElement(EnableDebuggerTag tag) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagAttribute(EnableDebuggerTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagElement(EnableDebuggerTag tag, XElement element) {
            throw new System.NotImplementedException();
        }
    }
}
