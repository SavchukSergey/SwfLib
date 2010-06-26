using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class DefineTextTagFormatter : TagFormatterBase<DefineTextTag> {

        private const string BOUNDS_ELEM = "bounds";
        private const string TRANSFORM_ELEM = "transform";
        private const string RECORDS_ELEM = "records";

        public override void AcceptAttribute(DefineTextTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case OBJECT_ID_ATTRIB:
                    tag.CharacterID = SwfMillPrimitives.ParseObjectID(attrib);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(DefineTextTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case BOUNDS_ELEM:
                    _formatters.Rectangle.Parse(element.Element(XName.Get("Rectangle")), out tag.TextBounds);
                    break;
                case TRANSFORM_ELEM:
                    tag.TextMatrix = SwfMillPrimitives.ParseMatrix(element.Element(XName.Get("Transform")));
                    break;
                case RECORDS_ELEM:
                    ReadRecords(tag, element);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        private static void ReadRecords(DefineTextTag tag, XElement recordsElem) {
            var elem = recordsElem.Element(XName.Get("TextRecord")).Element(XName.Get("records"));
            foreach (var recordElem in elem.Elements()) {
                tag.TextRecords.Add(SwfMillPrimitives.ParseTextRecord(recordElem));
            }
        }

        //TODO: simulate swfmill incorrect structure of TextRecord (parsing, formating)

        public override XElement FormatTag(DefineTextTag tag) {
            var res = new XElement(XName.Get(SwfTagNameMapping.DEFINE_TEXT_TAG),
                                   new XAttribute(XName.Get("objectID"), tag.CharacterID));
            res.Add(new XElement(XName.Get("bounds"), _formatters.Rectangle.Format(ref tag.TextBounds)));
            res.Add(new XElement(XName.Get("transform"), GetTransformXml(tag.TextMatrix)));
            //TODO: remove unnessary nested nodes. Swfmill requires them
            res.Add(new XElement(XName.Get("records"),
                                 new XElement(XName.Get("TextRecord"),
                                              new XElement(XName.Get("records"),
                                                           tag.TextRecords.Select(item => SwfMillPrimitives.FormatTextRecord(item))
                                                  )
                                     )));
            //TODO: Other fields
            return res;
        }
    }
}
