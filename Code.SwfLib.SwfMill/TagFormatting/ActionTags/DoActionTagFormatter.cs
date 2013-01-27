using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Actions;
using Code.SwfLib.Tags.ActionsTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ActionTags {
    public class DoActionTagFormatter : TagFormatterBase<DoActionTag> {
        private const string ACTIONS_ELEM = "actions";

        private readonly XActionWriter _writer = new XActionWriter();
        private readonly XActionReader _reader = new XActionReader();

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
                        var action = _reader.Deserialize(xAction);
                        tag.ActionRecords.Add(action);
                    }
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override XElement FormatTagElement(DoActionTag tag, XElement xTag) {
            var res = new XElement(SwfTagNameMapping.DO_ACTION_TAG);
            var actions = new XElement(ACTIONS_ELEM);
            //TODO: process functions bodies.
            foreach (var action in tag.ActionRecords) {
                actions.Add(_writer.Serialize(action));
            }
            res.Add(actions);
            return res;
        }

        public override string TagName {
            get { return "DoAction"; }
        }
    }
}
