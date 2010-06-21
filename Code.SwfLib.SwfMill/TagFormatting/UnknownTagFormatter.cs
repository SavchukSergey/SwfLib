using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class UnknownTagFormatter : TagFormatterBase<UnknownTag> {

        private const string ID_ATTRIB = "id";

        public override void AcceptAttribute(UnknownTag tag, XAttribute attrib) {
            if (tag.RawData == null) tag.RawData = new SwfTagData();
            switch (attrib.Name.LocalName) {
                case ID_ATTRIB:
                    tag.RawData.Type = (SwfTagType) ParseHex(attrib.Value);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(UnknownTag tag, XElement element) {
            if (tag.RawData == null) tag.RawData = new SwfTagData();
            switch (element.Name.LocalName) {
                case DATA_TAG:
                    tag.RawData.Data = FromBase64(element);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(UnknownTag tag) {
            return new XElement(XName.Get(SwfTagNameMapping.UNKNOWN_TAG),
                                 new XAttribute(XName.Get("id"), string.Format("0x{0:x}", (int)tag.RawData.Type)),
                                 new XElement(XName.Get("data"), Convert.ToBase64String(tag.RawData.Data)));
        }

        private static uint ParseHex(string value) {
            value = value.Replace("0x", "");
            return uint.Parse(value, NumberStyles.HexNumber | NumberStyles.AllowHexSpecifier);
        }
    }
}
