using System.Xml.Linq;
using Code.SwfLib.SwfMill.Actions;
using Code.SwfLib.Tags.ActionsTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ActionTags {
    public class DoInitActionTagFormatter : TagFormatterBase<DoInitActionTag> {

        private const string ACTIONS_ELEM = "actions";

        protected override bool AcceptTagAttribute(DoInitActionTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case "sprite":
                    tag.SpriteId = ushort.Parse(attrib.Value);
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override bool AcceptTagElement(DoInitActionTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case ACTIONS_ELEM:
                    foreach (var xAction in element.Elements()) {
                        var action = XAction.FromXml(xAction);
                        tag.ActionRecords.Add(action);
                    }
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override void FormatTagElement(DoInitActionTag tag, XElement xTag) {
            xTag.Add(new XAttribute("sprite", tag.SpriteId));
            var actions = new XElement(ACTIONS_ELEM);
            foreach (var action in tag.ActionRecords) {
                actions.Add(XAction.ToXml(action));
            }
            xTag.Add(actions);
        }

        public override string TagName {
            get { return "DoInitAction"; }
        }
    }
}
