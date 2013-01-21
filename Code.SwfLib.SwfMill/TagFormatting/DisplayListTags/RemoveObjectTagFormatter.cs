using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.DisplayListTags;

namespace Code.SwfLib.SwfMill.TagFormatting.DisplayListTags {
    public class RemoveObjectTagFormatter : TagFormatterBase<RemoveObjectTag> {
        public override XElement FormatTag(RemoveObjectTag tag) {
            throw new NotImplementedException();
        }

        public override void AcceptAttribute(RemoveObjectTag tag, XAttribute attrib) {
            throw new NotImplementedException();
        }

        public override void AcceptElement(RemoveObjectTag tag, XElement element) {
            throw new NotImplementedException();
        }
    }
}
