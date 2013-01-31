using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.VideoTags;

namespace Code.SwfLib.SwfMill.TagFormatting.VideoTags {
    public class VideoFrameTagFormatter : TagFormatterBase<VideoFrameTag> {
        protected override void FormatTagElement(VideoFrameTag tag, XElement xTag) {
        }

        protected override void AcceptTagAttribute(VideoFrameTag tag, XAttribute attrib) {
        }

        protected override void AcceptTagElement(VideoFrameTag tag, XElement element) {
        }

        public override string TagName {
            get { return "VideoFrame"; }
        }
    }
}
