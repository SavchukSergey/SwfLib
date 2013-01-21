using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.ActionsTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ActionTags {
    public class DoABCTagFormatter : TagFormatterBase<DoABCTag> {
        protected override XElement FormatTagElement(DoABCTag tag) {
            return new XElement(SwfTagNameMapping.DO_ABC_TAG);
        }

        protected override void AcceptTagAttribute(DoABCTag tag, XAttribute attrib) {
            throw new NotImplementedException();
        }

        protected override void AcceptTagElement(DoABCTag tag, XElement element) {
            throw new NotImplementedException();
        }
    }
}
