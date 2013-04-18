using System.Xml.Linq;
using SwfLib.Tags.VideoTags;

namespace SwfLib.SwfMill.TagFormatting.VideoTags {
    /// <summary>
    /// Represents VideoFrameTag xml formatter.
    /// </summary>
    public class VideoFrameTagFormatter : TagFormatterBase<VideoFrameTag> {
        protected override void FormatTagElement(VideoFrameTag tag, XElement xTag) {
        }

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public override string TagName {
            get { return "VideoFrame"; }
        }
    }
}
