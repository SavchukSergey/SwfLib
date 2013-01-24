using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.DisplayListTags;

namespace Code.SwfLib.SwfMill.TagFormatting.DisplayListTags {
    public class RemoveObjectTagFormatter : TagFormatterBase<RemoveObjectTag> {
        protected override XElement FormatTagElement(RemoveObjectTag tag, XElement xTag) {
            throw new NotImplementedException();
        }

        protected override void AcceptTagAttribute(RemoveObjectTag tag, XAttribute attrib) {
            throw new NotImplementedException();
        }

        protected override void AcceptTagElement(RemoveObjectTag tag, XElement element) {
            throw new NotImplementedException();
        }
    }
}
