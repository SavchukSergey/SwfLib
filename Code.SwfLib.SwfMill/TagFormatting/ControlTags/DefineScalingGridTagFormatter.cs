using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class DefineScalingGridTagFormatter : TagFormatterBase<DefineScalingGridTag> {
        protected override XElement FormatTagElement(DefineScalingGridTag tag) {
            throw new NotImplementedException();
        }

        protected override void AcceptTagAttribute(DefineScalingGridTag tag, XAttribute attrib) {
            throw new NotImplementedException();
        }

        protected override void AcceptTagElement(DefineScalingGridTag tag, XElement element) {
            throw new NotImplementedException();
        }
    }
}
