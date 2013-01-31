using System.Xml.Linq;
using Code.SwfLib.Tags.ActionsTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ActionTags {
    public class DoABCDefineTagFormatter : TagFormatterBase<DoABCDefineTag> {

        protected override void FormatTagElement(DoABCDefineTag tag, XElement xTag) {
        }

        protected override void AcceptTagElement(DoABCDefineTag tag, XElement element) {
        }

        public override string TagName {
            get { return "DoABCDefine"; }
        }

    }
}
