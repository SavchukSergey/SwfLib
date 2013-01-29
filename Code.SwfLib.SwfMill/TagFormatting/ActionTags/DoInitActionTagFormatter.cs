using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Actions;
using Code.SwfLib.Tags.ActionsTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ActionTags {
    public class DoInitActionTagFormatter : TagFormatterBase<DoInitActionTag> {

        private const string ACTIONS_ELEM = "actions";

        protected override void AcceptTagAttribute(DoInitActionTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case "sprite":
                    tag.SpriteId = ushort.Parse(attrib.Value);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(DoInitActionTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case ACTIONS_ELEM:
                    foreach (var xAction in element.Elements()) {
                        var action = XAction.FromXml(xAction);
                        tag.ActionRecords.Add(action);
                    }
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override XElement FormatTagElement(DoInitActionTag tag, XElement xTag) {
            var res = new XElement(TagName);
            res.Add(new XAttribute("sprite", tag.SpriteId));
            var actions = new XElement(ACTIONS_ELEM);
            foreach (var action in tag.ActionRecords) {
                actions.Add(XAction.ToXml(action));
            }
            res.Add(actions);
            return res;
        }

        public override string TagName {
            get { return "DoInitAction"; }
        }
    }
}
