using System;
using System.Xml.Linq;
using SwfLib.Tags.ActionsTags;

namespace SwfLib.SwfMill.TagFormatting.ActionTags {
    public class DoABCTagFormatter : TagFormatterBase<DoABCTag> {

        protected override void FormatTagElement(DoABCTag tag, XElement xTag) {
            xTag.Add(new XAttribute("flags", tag.Flags));
            xTag.Add(new XAttribute("name", tag.Name));
            xTag.Add(new XElement("abc", Convert.ToBase64String(tag.ABCData)));
        }

        protected override bool AcceptTagAttribute(DoABCTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case "flags":
                    tag.Flags = uint.Parse(attrib.Value);
                    break;
                case "name":
                    tag.Name = attrib.Value;
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override bool AcceptTagElement(DoABCTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "abc":
                    tag.ABCData = Convert.FromBase64String(element.Value);
                    break;
                default:
                    return false;
            }
            return true;
        }

        public override string TagName {
            get { return "DoABCDefine"; }
        }

    }
}
