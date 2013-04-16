using System.Globalization;
using System.Xml.Linq;
using SwfLib.Tags;

namespace SwfLib.SwfMill.TagFormatting {
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

        protected override void FormatTagElement(UnknownTag tag, XElement xTag) {
            xTag.Add(new XAttribute(XName.Get("id"), string.Format("0x{0:x}", (int)tag.TagType)));
        }

        private static uint ParseHex(string value) {
            value = value.Replace("0x", "");
            return uint.Parse(value, NumberStyles.HexNumber | NumberStyles.AllowHexSpecifier);
        }

        protected override byte[] GetData(UnknownTag tag) {
            return tag.Data;
        }

        protected override void SetData(UnknownTag tag, byte[] data) {
            tag.Data = data;
        }

        public override string TagName {
            get { return "UnknownTag"; }
        }
    }
}
