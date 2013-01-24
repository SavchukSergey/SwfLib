using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.VideoTags;

namespace Code.SwfLib.SwfMill.TagFormatting.VideoTags {
    public class VideoFrameTagFormatter : TagFormatterBase<VideoFrameTag> {
        protected override XElement FormatTagElement(VideoFrameTag tag, XElement xTag) {
            throw new NotImplementedException();
        }

        protected override void AcceptTagAttribute(VideoFrameTag tag, XAttribute attrib) {
            throw new NotImplementedException();
        }

        protected override void AcceptTagElement(VideoFrameTag tag, XElement element) {
            throw new NotImplementedException();
        }

        public override string TagName {
            get { return "VideoFrame"; }
        }
    }
}
