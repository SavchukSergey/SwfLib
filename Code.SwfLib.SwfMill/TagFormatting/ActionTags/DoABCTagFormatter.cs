using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.ActionsTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ActionTags {
    public class DoABCTagFormatter : TagFormatterBase<DoABCTag> {

        protected override void FormatTagElement(DoABCTag tag, XElement xTag) {
            xTag.Add(new XAttribute("flags", tag.Flags));
            xTag.Add(new XAttribute("name", tag.Name));
            xTag.Add(new XElement("abc", Convert.ToBase64String(tag.ABCData)));
        }

        protected override void AcceptTagAttribute(DoABCTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case "flags":
                    tag.Flags = uint.Parse(attrib.Value);
                    break;
                case "name":
                    tag.Name = attrib.Value;
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(DoABCTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "abc":
                    tag.ABCData = Convert.FromBase64String(element.Value);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override string TagName {
            get { return "DoAbc"; }
        }

    }
}
