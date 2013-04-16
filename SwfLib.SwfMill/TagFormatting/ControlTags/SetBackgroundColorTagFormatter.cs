using System.Xml.Linq;
using SwfLib.SwfMill.Data;
using SwfLib.Tags.ControlTags;

namespace SwfLib.SwfMill.TagFormatting.ControlTags {
    public class SetBackgroundColorTagFormatter : TagFormatterBase<SetBackgroundColorTag> {

        private const string COLOR_ELEM = "color";

        protected override bool AcceptTagElement(SetBackgroundColorTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case COLOR_ELEM:
                    tag.Color = XColorRGB.FromXml(element.Element("Color"));
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override void FormatTagElement(SetBackgroundColorTag tag, XElement xTag) {
            xTag.Add(new XElement("color", XColorRGB.ToXml(tag.Color)));
        }

        public override string TagName {
            get { return "SetBackgroundColor"; }
        }
    }
}