using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class DefineScalingGridTagFormatter : TagFormatterBase<DefineScalingGridTag> {
        
        protected override void FormatTagElement(DefineScalingGridTag tag, XElement xTag) {
        }

        protected override void AcceptTagElement(DefineScalingGridTag tag, XElement element) {
        }

        public override string TagName {
            get { return "DefineScalingGrid"; }
        }
    }
}
