using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting
{
    public class DoInitActionTagFormatter : TagFormatterBase<DoInitActionTag>
    {

        private const string SPRITE_ATTRIB = "sprite";
        private const string ACTIONS_ELEM = "actions";

        public override void AcceptAttribute(DoInitActionTag tag, XAttribute attrib)
        {
            switch (attrib.Name.LocalName)
            {
                case SPRITE_ATTRIB:
                    //TODO: read sprite attrib
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(DoInitActionTag tag, XElement element)
        {
            switch (element.Name.LocalName)
            {
                case ACTIONS_ELEM:
                    //TODO: Read actions
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(DoInitActionTag tag)
        {
            return new XElement(XName.Get(SwfTagNameMapping.DO_INIT_ACTION_TAG));
        }
    }
}
