using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting
{
    public class DefineFontAlignZonesTagFormatter : TagFormatterBase<DefineFontAlignZonesTag>
    {
        public const string OBJECT_ID_ATTRIB = "objectID";

        public override void AcceptAttribute(DefineFontAlignZonesTag tag, XAttribute attrib)
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

        public override void AcceptElement(DefineFontAlignZonesTag tag, XElement element)
        {
            switch (element.Name.LocalName)
            {
                case DATA_TAG:
                    ProcessRawData(tag, element);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(DefineFontAlignZonesTag tag)
        {
            return new XElement(XName.Get(SwfTagNameMapping.DEFINE_FONT_ALIGN_ZONES_TAG));
        }
    }
}
