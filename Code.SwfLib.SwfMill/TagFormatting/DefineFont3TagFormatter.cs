using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting
{
    public class DefineFont3TagFormatter : TagFormatterBase<DefineFont3Tag>
    {

        public const string OBJECT_ID_ATTRIB = "objectID";

        public override void AcceptAttribute(DefineFont3Tag tag, XAttribute attrib)
        {
            switch (attrib.Name.LocalName)
            {
                case OBJECT_ID_ATTRIB:
                    tag.ObjectID = ushort.Parse(attrib.Value);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(DefineFont3Tag tag, XElement element)
        {
            switch (element.Name.LocalName)
            {
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(DefineFont3Tag tag)
        {
            return new XElement(XName.Get(SwfTagNameMapping.DEFINE_FONT_3_TAG),
                new XAttribute(XName.Get(OBJECT_ID_ATTRIB), tag.ObjectID));
        }
    }
}
