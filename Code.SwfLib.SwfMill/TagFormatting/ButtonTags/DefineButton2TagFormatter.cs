using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.ButtonTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ButtonTags {
    public class DefineButton2TagFormatter : DefineButtonBaseTagFormatter<DefineButton2Tag> {

        private const string MENU_ATTRIB = "menu";
        private const string BUTTONS_SIZE_ATTRIB = "buttonsSize";
        private const string BUTTONS_ELEM = "buttons";
        private const string CONDITIONS_ELEM = "conditions";

        protected override void AcceptTagAttribute(DefineButton2Tag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case MENU_ATTRIB:
                    //TODO: read menu
                    break;
                case BUTTONS_SIZE_ATTRIB:
                    //TODO: read buttons size
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(DefineButton2Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case BUTTONS_ELEM:
                    //TODO: read buttons
                    break;
                case CONDITIONS_ELEM:
                    //TODO: read conditions;
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override XElement FormatTagElement(DefineButton2Tag tag, XElement xTag) {
            return xTag;
        }

        public override string TagName {
            get { return "DefineButton2"; }
        }

        protected override ushort? GetObjectID(DefineButton2Tag tag) {
            return tag.ButtonID;
        }

        protected override void SetObjectID(DefineButton2Tag tag, ushort value) {
            tag.ButtonID = value;
        }

    }
}
