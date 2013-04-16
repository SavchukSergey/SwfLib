using System.Xml.Linq;
using Code.SwfLib.Tags.DisplayListTags;

namespace Code.SwfLib.SwfMill.TagFormatting.DisplayListTags {
    public class ShowFrameTagFormatter : TagFormatterBase<ShowFrameTag> {

        protected override void FormatTagElement(ShowFrameTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "ShowFrame"; }
        }
    }
}