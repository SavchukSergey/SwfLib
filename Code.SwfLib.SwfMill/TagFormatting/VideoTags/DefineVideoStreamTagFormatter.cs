using System.Xml.Linq;
using Code.SwfLib.Tags.VideoTags;

namespace Code.SwfLib.SwfMill.TagFormatting.VideoTags {
    public class DefineVideoStreamTagFormatter : TagFormatterBase<DefineVideoStreamTag> {
        public override XElement FormatTag(DefineVideoStreamTag tag) {
            throw new System.NotImplementedException();
        }

        public override void AcceptAttribute(DefineVideoStreamTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        public override void AcceptElement(DefineVideoStreamTag tag, XElement element) {
            throw new System.NotImplementedException();
        }
    }
}
