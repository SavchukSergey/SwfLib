using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.ActionsTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ActionTags {
    public class DoABCTagFormatter : TagFormatterBase<DoABCTag> {
        public override XElement FormatTag(DoABCTag tag) {
            throw new NotImplementedException();
        }

        public override void AcceptAttribute(DoABCTag tag, XAttribute attrib) {
            throw new NotImplementedException();
        }

        public override void AcceptElement(DoABCTag tag, XElement element) {
            throw new NotImplementedException();
        }
    }
}
