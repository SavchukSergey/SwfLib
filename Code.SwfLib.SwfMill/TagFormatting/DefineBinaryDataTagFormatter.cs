using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class DefineBinaryDataTagFormatter : TagFormatterBase<DefineBinaryDataTag> {
        protected override XElement FormatTagElement(DefineBinaryDataTag tag, XElement xTag) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagAttribute(DefineBinaryDataTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagElement(DefineBinaryDataTag tag, XElement element) {
            throw new System.NotImplementedException();
        }
    }
}
