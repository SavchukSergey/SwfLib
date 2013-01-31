using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class DebugIDTagFormatter : TagFormatterBase<DebugIDTag> {
        protected override void FormatTagElement(DebugIDTag tag, XElement xTag) {
        }

        protected override bool AcceptTagElement(DebugIDTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "data":
                    tag.Data = XBinary.FromXml(element.Element("data"));
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override byte[] GetData(DebugIDTag tag) {
            return tag.Data;
        }

        public override string TagName {
            get { return "DebugID"; }
        }
    }
}
