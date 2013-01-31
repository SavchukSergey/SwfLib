using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.DisplayListTags;

namespace Code.SwfLib.SwfMill.TagFormatting.DisplayListTags {
    //TODO: format & parse
    public class RemoveObjectTagFormatter : TagFormatterBase<RemoveObjectTag> {
        protected override void FormatTagElement(RemoveObjectTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "RemoveObject"; }
        }
    }
}
