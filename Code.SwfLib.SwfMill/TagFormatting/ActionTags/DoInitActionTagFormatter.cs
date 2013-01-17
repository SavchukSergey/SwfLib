using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.ActionsTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ActionTags {
    //TODO: Read actions
    public class DoInitActionTagFormatter : TagFormatterBase<DoInitActionTag> {

        private const string SPRITE_ATTRIB = "sprite";
        private const string ACTIONS_ELEM = "actions";
        private const string REST_ELEM = "rest";

        public override void AcceptAttribute(DoInitActionTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case SPRITE_ATTRIB:
                    tag.SpriteId = ushort.Parse(attrib.Value);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(DoInitActionTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case REST_ELEM:
                    tag.RestData = Convert.FromBase64String(element.Value);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(DoInitActionTag tag) {
            return new XElement(XName.Get(SwfTagNameMapping.DO_INIT_ACTION_TAG),
                new XAttribute(SPRITE_ATTRIB, tag.SpriteId),
                new XElement(REST_ELEM, Convert.ToBase64String(tag.RestData)));
        }
    }
}
