using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.ActionsTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ActionTags {
    //TODO: Read actions
    public class DoInitActionTagFormatter : TagFormatterBase<DoInitActionTag> {

        private const string SPRITE_ATTRIB = "sprite";
        private const string ACTIONS_ELEM = "actions";

        protected override void AcceptTagAttribute(DoInitActionTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case SPRITE_ATTRIB:
                    tag.SpriteId = ushort.Parse(attrib.Value);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(DoInitActionTag tag, XElement element) {
            switch (element.Name.LocalName) {
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override XElement FormatTagElement(DoInitActionTag tag) {
            return new XElement(XName.Get(SwfTagNameMapping.DO_INIT_ACTION_TAG),
                new XAttribute(SPRITE_ATTRIB, tag.SpriteId));
        }
    }
}
