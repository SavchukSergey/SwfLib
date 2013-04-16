using System.Xml.Linq;
using SwfLib.Tags.ControlTags;

namespace SwfLib.SwfMill.TagFormatting.ControlTags {
    public class DefineScalingGridTagFormatter : TagFormatterBase<DefineScalingGridTag> {
        
        protected override void FormatTagElement(DefineScalingGridTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DefineScalingGrid"; }
        }
    }
}
