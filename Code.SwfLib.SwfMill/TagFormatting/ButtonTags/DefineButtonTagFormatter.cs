using System.Xml.Linq;
using Code.SwfLib.Tags.ButtonTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ButtonTags {
    public class DefineButtonTagFormatter : TagFormatterBase<DefineButtonTag> {
        protected override XElement FormatTagElement(DefineButtonTag tag, XElement xTag) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagAttribute(DefineButtonTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagElement(DefineButtonTag tag, XElement element) {
            throw new System.NotImplementedException();
        }
    }
}
