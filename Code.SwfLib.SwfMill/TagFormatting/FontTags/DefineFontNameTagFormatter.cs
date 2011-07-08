using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.TagFormatting.FontTags
{
    public class DefineFontNameTagFormatter : TagFormatterBase<DefineFontNameTag>
    {

        protected const string NAME_ATTRIB = "name";
        protected const string COPYRIGHT_ATTRIB = "copyright";

        public override void AcceptAttribute(DefineFontNameTag tag, XAttribute attrib)
        {
            switch (attrib.Name.LocalName)
            {
                case OBJECT_ID_ATTRIB:
                    tag.FontId = SwfMillPrimitives.ParseObjectID(attrib);
                    break;
                case NAME_ATTRIB:
                    tag.FontName = attrib.Value;
                    break;
                case COPYRIGHT_ATTRIB:
                    tag.FontCopyright = attrib.Value;
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(DefineFontNameTag tag, XElement element)
        {
            switch (element.Name.LocalName)
            {
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(DefineFontNameTag tag)
        {
            return new XElement(XName.Get(SwfTagNameMapping.DEFINE_FONT_NAME_TAG),
                               new XAttribute(XName.Get(OBJECT_ID_ATTRIB), tag.FontId),
                               new XAttribute(XName.Get(NAME_ATTRIB), tag.FontName),
                               new XAttribute(XName.Get(COPYRIGHT_ATTRIB), tag.FontCopyright));
        }
    }
}
