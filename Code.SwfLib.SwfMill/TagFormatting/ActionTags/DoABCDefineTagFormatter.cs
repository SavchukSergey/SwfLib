using System.Xml.Linq;
using Code.SwfLib.Tags.ActionsTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ActionTags {
    public class DoABCDefineTagFormatter : TagFormatterBase<DoABCDefineTag> {
        
        protected override XElement FormatTagElement(DoABCDefineTag tag, XElement xTag) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagAttribute(DoABCDefineTag tag, XAttribute attrib) {
            throw new System.NotImplementedException();
        }

        protected override void AcceptTagElement(DoABCDefineTag tag, XElement element) {
            throw new System.NotImplementedException();
        }

        public override string TagName {
            get { return "DoABCDefine"; }
        }

    }
}
