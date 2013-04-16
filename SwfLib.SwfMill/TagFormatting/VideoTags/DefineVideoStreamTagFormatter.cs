using System.Xml.Linq;
using SwfLib.Tags.VideoTags;

namespace SwfLib.SwfMill.TagFormatting.VideoTags {
    public class DefineVideoStreamTagFormatter : TagFormatterBase<DefineVideoStreamTag> {
        protected override void FormatTagElement(DefineVideoStreamTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DefineVideoStream"; }
        }
    }
}
