using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class DebugIDTagFormatter : TagFormatterBase<DebugIDTag> {
        protected override void FormatTagElement(DebugIDTag tag, XElement xTag) {
            xTag.Add(new XElement("data", XBinary.ToXml(tag.Data)));
        }

        protected override void AcceptTagAttribute(DebugIDTag tag, XAttribute attrib) {
        }

        protected override void AcceptTagElement(DebugIDTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "data":
                    tag.Data = XBinary.FromXml(element.Element("data"));
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override string TagName {
            get { return "DebugID"; }
        }
    }
}
