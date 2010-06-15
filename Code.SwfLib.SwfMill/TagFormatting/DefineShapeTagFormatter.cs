using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting
{
    public class DefineShapeTagFormatter : TagFormatterBase<DefineShapeTag>
    {

        private const string OBJECT_ID_ATTRIB = "objectID";
        private const string BOUNDS_ELEM = "bounds";

        public override void AcceptAttribute(DefineShapeTag tag, XAttribute attrib)
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

        public override void AcceptElement(DefineShapeTag tag, XElement element)
        {
            switch (element.Name.LocalName)
            {
                case BOUNDS_ELEM:
                    tag.Bounds = ParseRect(element.Element(XName.Get("Rectangle")));
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(DefineShapeTag tag)
        {
            return new XElement(XName.Get(SwfTagNameMapping.DEFINE_SHAPE_TAG));
        }
    }
}
