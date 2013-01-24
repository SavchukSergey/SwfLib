using System;
using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class DebugIDTagFormatter : TagFormatterBase<DebugIDTag> {
        protected override XElement FormatTagElement(DebugIDTag tag, XElement xTag) {
            return xTag;
        }

        protected override void AcceptTagAttribute(DebugIDTag tag, XAttribute attrib) {
            throw new NotImplementedException();
        }

        protected override void AcceptTagElement(DebugIDTag tag, XElement element) {
            throw new NotImplementedException();
        }

        protected override string TagName {
            get { return "DebugID"; }
        }
    }
}
