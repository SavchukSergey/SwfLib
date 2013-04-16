using System.Xml.Linq;
using Code.SwfLib.Tags.VideoTags;

namespace SwfLib.SwfMill.TagFormatting.VideoTags {
    public class VideoFrameTagFormatter : TagFormatterBase<VideoFrameTag> {
        protected override void FormatTagElement(VideoFrameTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "VideoFrame"; }
        }
    }
}
