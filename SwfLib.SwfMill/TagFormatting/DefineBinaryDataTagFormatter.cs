using System.Xml.Linq;
using Code.SwfLib.Tags;
using SwfLib.Tags;

namespace SwfLib.SwfMill.TagFormatting {
    public class DefineBinaryDataTagFormatter : TagFormatterBase<DefineBinaryDataTag> {
        protected override void FormatTagElement(DefineBinaryDataTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DefineBinaryData"; }
        }
    }
}
