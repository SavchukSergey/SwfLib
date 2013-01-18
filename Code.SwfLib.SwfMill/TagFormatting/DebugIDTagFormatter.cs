using System;
using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class DebugIDTagFormatter : TagFormatterBase<DebugIDTag> {
        public override XElement FormatTag(DebugIDTag tag) {
            throw new NotImplementedException();
        }

        public override void AcceptAttribute(DebugIDTag tag, XAttribute attrib) {
            throw new NotImplementedException();
        }

        public override void AcceptElement(DebugIDTag tag, XElement element) {
            throw new NotImplementedException();
        }
    }
}
