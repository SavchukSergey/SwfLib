using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Actions;
using Code.SwfLib.Tags.ActionsTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ActionTags {
    public class DoActionTagFormatter : TagFormatterBase<DoActionTag> {
        private const string ACTIONS_ELEM = "actions";

        protected override void AcceptTagAttribute(DoActionTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(DoActionTag tag, XElement element) {
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

        protected override void FormatTagElement(DoActionTag tag, XElement xTag) {
            var actions = new XElement(ACTIONS_ELEM);
            foreach (var action in tag.ActionRecords) {
                actions.Add(XAction.ToXml(action));
            }
            xTag.Add(actions);
        }

        public override string TagName {
            get { return "DoAction"; }
        }
    }
}
