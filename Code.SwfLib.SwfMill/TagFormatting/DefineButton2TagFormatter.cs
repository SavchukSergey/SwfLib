using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.ButtonTags;

namespace Code.SwfLib.SwfMill.TagFormatting
{
    public class DefineButton2TagFormatter : TagFormatterBase<DefineButton2Tag>
    {

        private const string MENU_ATTRIB = "menu";
        private const string BUTTONS_SIZE_ATTRIB = "buttonsSize";
        private const string BUTTONS_ELEM = "buttons";
        private const string CONDITIONS_ELEM = "conditions";

        public override void AcceptAttribute(DefineButton2Tag tag, XAttribute attrib)
        {
            switch (attrib.Name.LocalName)
            {
                case OBJECT_ID_ATTRIB:
                    tag.ButtonID = SwfMillPrimitives.ParseObjectID(attrib);
                    break;
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

        public override void AcceptElement(DefineButton2Tag tag, XElement element)
        {
            switch (element.Name.LocalName)
            {
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

        public override XElement FormatTag(DefineButton2Tag tag)
        {
            return new XElement(XName.Get(SwfTagNameMapping.DEFINE_BUTTON2_TAG));
        }

    }
}
