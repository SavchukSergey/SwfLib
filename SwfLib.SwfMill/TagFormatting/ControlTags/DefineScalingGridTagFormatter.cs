using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;
using SwfLib.SwfMill.TagFormatting;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class DefineScalingGridTagFormatter : TagFormatterBase<DefineScalingGridTag> {
        
        protected override void FormatTagElement(DefineScalingGridTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DefineScalingGrid"; }
        }
    }
}
