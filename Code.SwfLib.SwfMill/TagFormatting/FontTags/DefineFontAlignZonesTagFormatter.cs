using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.TagFormatting.FontTags
{
    public class DefineFontAlignZonesTagFormatter : TagFormatterBase<DefineFontAlignZonesTag>
    {
        public override void AcceptAttribute(DefineFontAlignZonesTag tag, XAttribute attrib)
        {
            switch (attrib.Name.LocalName)
            {
                case OBJECT_ID_ATTRIB:
                    tag.FontID = ushort.Parse(attrib.Value);
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
                    //TODO: set data
                    FromBase64(element);
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