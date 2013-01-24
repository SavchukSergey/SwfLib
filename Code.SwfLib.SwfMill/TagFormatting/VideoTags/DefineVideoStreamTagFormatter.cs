using System.Xml.Linq;
using Code.SwfLib.Tags.VideoTags;

namespace Code.SwfLib.SwfMill.TagFormatting.VideoTags {
    public class DefineVideoStreamTagFormatter : TagFormatterBase<DefineVideoStreamTag> {
        protected override XElement FormatTagElement(DefineVideoStreamTag tag, XElement xTag) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagAttribute(DefineVideoStreamTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagElement(DefineVideoStreamTag tag, XElement element) {
            throw new System.NotImplementedException();
        }
    }
}
