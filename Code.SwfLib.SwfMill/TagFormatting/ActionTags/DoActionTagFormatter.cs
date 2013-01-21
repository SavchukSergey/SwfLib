using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.DataFormatting;
using Code.SwfLib.Tags.ActionsTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ActionTags {
    public class DoActionTagFormatter : TagFormatterBase<DoActionTag> {
        private const string ACTIONS_ELEM = "actions";

        private readonly ActionSerializer _serializer = new ActionSerializer();

        protected override void AcceptTagAttribute(DoActionTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(DoActionTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case ACTIONS_ELEM:
                    //TODO: Read actions
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override XElement FormatTagElement(DoActionTag tag) {
            var res = new XElement(SwfTagNameMapping.DO_ACTION_TAG);
            var actions = new XElement(ACTIONS_ELEM);
            //TODO: process functions bodies.
            foreach (var action in tag.ActionRecords) {
                actions.Add(_serializer.Serialize(action));
            }
            res.Add(actions);
            return res;
        }
    }
}
