using System;
using System.Globalization;
using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class UnknownTagFormatter : TagFormatterBase<UnknownTag> {

        private const string ID_ATTRIB = "id";

        protected override bool AcceptTagAttribute(UnknownTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case ID_ATTRIB:
                    tag.SetTagType((SwfTagType)ParseHex(attrib.Value));
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override bool AcceptTagElement(UnknownTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case DATA_TAG:
                    tag.Data = FromBase64(element);
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override void FormatTagElement(UnknownTag tag, XElement xTag) {
            xTag.Add(new XAttribute(XName.Get("id"), string.Format("0x{0:x}", (int)tag.TagType)));
            xTag.Add(new XElement(XName.Get("data"), Convert.ToBase64String(tag.Data)));
        }

        private static uint ParseHex(string value) {
            value = value.Replace("0x", "");
            return uint.Parse(value, NumberStyles.HexNumber | NumberStyles.AllowHexSpecifier);
        }

        public override string TagName {
            get { return "UnknownTag"; }
        }
    }
}
