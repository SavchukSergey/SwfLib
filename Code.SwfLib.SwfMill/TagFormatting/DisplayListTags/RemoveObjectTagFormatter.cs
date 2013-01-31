using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.DisplayListTags;

namespace Code.SwfLib.SwfMill.TagFormatting.DisplayListTags {
    public class RemoveObjectTagFormatter : TagFormatterBase<RemoveObjectTag> {
        protected override void FormatTagElement(RemoveObjectTag tag, XElement xTag) {
            //TODO: format & parse
        }

        protected override void AcceptTagAttribute(RemoveObjectTag tag, XAttribute attrib) {
        }

        protected override void AcceptTagElement(RemoveObjectTag tag, XElement element) {
        }

        public override string TagName {
            get { return "RemoveObject"; }
        }
    }
}
