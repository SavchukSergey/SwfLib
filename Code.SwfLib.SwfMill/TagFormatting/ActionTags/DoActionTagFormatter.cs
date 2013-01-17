using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.DataFormatting;
using Code.SwfLib.Tags.ActionsTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ActionTags {
    public class DoActionTagFormatter : TagFormatterBase<DoActionTag> {
        private const string ACTIONS_ELEM = "actions";

        private ActionSerializer serializer = new ActionSerializer();

        public override void AcceptAttribute(DoActionTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(DoActionTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case ACTIONS_ELEM:
                    //TODO: Read actions
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(DoActionTag tag) {
            var res = new XElement(SwfTagNameMapping.DO_ACTION_TAG);
            var actions = new XElement(ACTIONS_ELEM);
            //TODO: process functions bodies.
            foreach (var action in tag.ActionRecords) {
                actions.Add(serializer.Serialize(action));
            }
            res.Add(actions);
            return res;
        }
    }
}
