using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.VideoTags;

namespace Code.SwfLib.SwfMill.TagFormatting.VideoTags {
    public class VideoFrameTagFormatter : TagFormatterBase<VideoFrameTag> {
        public override XElement FormatTag(VideoFrameTag tag) {
            throw new NotImplementedException();
        }

        public override void AcceptAttribute(VideoFrameTag tag, XAttribute attrib) {
            throw new NotImplementedException();
        }

        public override void AcceptElement(VideoFrameTag tag, XElement element) {
            throw new NotImplementedException();
        }
    }
}
