using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class SetTabIndexTagFormatter : TagFormatterBase<SetTabIndexTag> {
        protected override void FormatTagElement(SetTabIndexTag tag, XElement xTag) {
        }

        protected override void AcceptTagElement(SetTabIndexTag tag, XElement element) {
        }

        public override string TagName {
            get { return "SetTabIndex"; }
        }
    }
}
