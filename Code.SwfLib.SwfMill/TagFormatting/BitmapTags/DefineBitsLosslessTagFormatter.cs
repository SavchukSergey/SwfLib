using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.BitmapTags;

namespace Code.SwfLib.SwfMill.TagFormatting.BitmapTags
{
    public class DefineBitsLosslessTagFormatter : TagFormatterBase<DefineBitsLosslessTag>
    {
        private const string FORMAT_ATTRIB = "format";
        private const string WIDTH_ATTRIB = "width";
        private const string HEIGHT_ATTRIB = "height";

        public override void AcceptAttribute(DefineBitsLosslessTag tag, XAttribute attrib)
        {
            switch (attrib.Name.LocalName)
            {
                case OBJECT_ID_ATTRIB:
                    tag.ObjectID = SwfMillPrimitives.ParseObjectID(attrib);
                    break;
                case FORMAT_ATTRIB:
                    //TODO: read format
                    break;
                case WIDTH_ATTRIB:
                    //TODO: read width
                    break;
                case HEIGHT_ATTRIB:
                    //TODO: read height
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(DefineBitsLosslessTag tag, XElement element)
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

        public override XElement FormatTag(DefineBitsLosslessTag tag)
        {
            return new XElement(XName.Get(SwfTagNameMapping.DEFINE_BITS_LOSSLESS_TAG));
        }
    }
}