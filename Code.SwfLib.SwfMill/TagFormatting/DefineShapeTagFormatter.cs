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
        private const string STYLES_ELEM = "styles";
        private const string SHAPES_ELEM = "shapes";

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
                case STYLES_ELEM:
                    ReadStyles(tag, element);
                    break;
                case SHAPES_ELEM:
                    ReadShapes(tag, element);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        private static void ReadStyles(DefineShapeTag tag, XElement styleElements)
        {
            foreach (var styleElem in styleElements.Elements())
            {
                var style = SwfMillPrimitives.ParseSwfShapeWithStyle(styleElem);
                //TODO: put into collection
            }
        }

        private static void ReadShapes(DefineShapeTag tag, XElement shapes)
        {
            //TODO: Implement shapes reading;
        }

        public override XElement FormatTag(DefineShapeTag tag)
        {
            return new XElement(XName.Get(SwfTagNameMapping.DEFINE_SHAPE_TAG));
        }
    }
}
