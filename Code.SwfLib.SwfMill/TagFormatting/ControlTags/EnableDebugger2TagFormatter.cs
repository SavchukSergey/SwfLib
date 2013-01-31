using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class EnableDebugger2TagFormatter : TagFormatterBase<EnableDebugger2Tag> {
        
        protected override void FormatTagElement(EnableDebugger2Tag tag, XElement xTag) {
            xTag.Add(new XElement("data", XBinary.ToXml(tag.Data)));
        }

        protected override void AcceptTagAttribute(EnableDebugger2Tag tag, XAttribute attrib) {
        }

        protected override void AcceptTagElement(EnableDebugger2Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "data":
                    tag.Data = XBinary.FromXml(element.Element("data"));
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override string TagName {
            get { return "EnableDebugger2"; }
        }
    }
}
