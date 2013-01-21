using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class EnableDebuggerTagFormatter : TagFormatterBase<EnableDebuggerTag> {
        public override XElement FormatTag(EnableDebuggerTag tag) {
            throw new System.NotImplementedException();
        }

        public override void AcceptAttribute(EnableDebuggerTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        public override void AcceptElement(EnableDebuggerTag tag, XElement element) {
            throw new System.NotImplementedException();
        }
    }
}
