using System.Xml.Linq;
using Code.SwfLib.Tags.VideoTags;

namespace Code.SwfLib.SwfMill.TagFormatting.VideoTags {
    public class DefineVideoStreamTagFormatter : TagFormatterBase<DefineVideoStreamTag> {
        protected override void FormatTagElement(DefineVideoStreamTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DefineVideoStream"; }
        }
    }
}
