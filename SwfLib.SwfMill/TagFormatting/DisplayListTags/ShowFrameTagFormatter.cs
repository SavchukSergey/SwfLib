using System.Xml.Linq;
using SwfLib.Tags.DisplayListTags;

namespace SwfLib.SwfMill.TagFormatting.DisplayListTags {
    public class ShowFrameTagFormatter : TagFormatterBase<ShowFrameTag> {

        protected override void FormatTagElement(ShowFrameTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "ShowFrame"; }
        }
    }
}