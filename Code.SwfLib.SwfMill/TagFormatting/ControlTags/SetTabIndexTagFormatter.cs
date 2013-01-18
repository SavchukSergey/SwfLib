using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class SetTabIndexTagFormatter : TagFormatterBase<SetTabIndexTag> {
        public override XElement FormatTag(SetTabIndexTag tag) {
            throw new NotImplementedException();
        }

        public override void AcceptAttribute(SetTabIndexTag tag, XAttribute attrib) {
            throw new NotImplementedException();
        }

        public override void AcceptElement(SetTabIndexTag tag, XElement element) {
            throw new NotImplementedException();
        }
    }
}
