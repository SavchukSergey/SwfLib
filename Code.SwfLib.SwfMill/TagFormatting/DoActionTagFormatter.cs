using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting
{
    public class DoActionTagFormatter : TagFormatterBase<DoActionTag>
    {
        private const string ACTIONS_ELEM = "actions";

        public override void AcceptAttribute(DoActionTag tag, XAttribute attrib)
        {
            switch (attrib.Name.LocalName)
            {
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(DoActionTag tag, XElement element)
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

        public override XElement FormatTag(DoActionTag tag)
        {
            return new XElement(XName.Get(SwfTagNameMapping.DO_ACTION_TAG));
        }
    }
}
