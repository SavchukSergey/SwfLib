using System.Xml.Linq;
using Code.SwfLib.Tags.ActionsTags;

namespace SwfLib.SwfMill.TagFormatting.ActionTags {
    public class DoABCDefineTagFormatter : TagFormatterBase<DoABCDefineTag> {

        protected override void FormatTagElement(DoABCDefineTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DoAbc"; }
        }

    }
}
