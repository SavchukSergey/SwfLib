using System;
using System.Globalization;
using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class UnknownTagFormatter : TagFormatterBase<UnknownTag> {

        private const string ID_ATTRIB = "id";

        protected override void AcceptTagAttribute(UnknownTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case ID_ATTRIB:
                    tag.SetTagType((SwfTagType) ParseHex(attrib.Value));
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(UnknownTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case DATA_TAG:
                    tag.Data = FromBase64(element);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override XElement FormatTagElement(UnknownTag tag, XElement xTag) {
            return new XElement(XName.Get(SwfTagNameMapping.UNKNOWN_TAG),
                                 new XAttribute(XName.Get("id"), string.Format("0x{0:x}", (int)tag.TagType)),
                                 new XElement(XName.Get("data"), Convert.ToBase64String(tag.Data)));
        }

        private static uint ParseHex(string value) {
            value = value.Replace("0x", "");
            return uint.Parse(value, NumberStyles.HexNumber | NumberStyles.AllowHexSpecifier);
        }
    }
}
