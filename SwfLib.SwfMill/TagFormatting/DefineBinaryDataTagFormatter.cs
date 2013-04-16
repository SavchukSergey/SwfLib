using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class DefineBinaryDataTagFormatter : TagFormatterBase<DefineBinaryDataTag> {
        protected override void FormatTagElement(DefineBinaryDataTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DefineBinaryData"; }
        }
    }
}
