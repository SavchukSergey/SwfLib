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

        public override void AcceptAttribute(DefineTextTag tag, XAttribute attrib)
        {
            switch (attrib.Name.LocalName) {
                case OBJECT_ID_ATTRIB:
                    tag.ObjectID = SwfMillPrimitives.ParseObjectID(attrib);
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        public override void AcceptElement(DefineTextTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case BOUNDS_ELEM:
                    tag.Bounds = ParseRect(element.Element(XName.Get("Rectangle")));
                    break;
                case TRANSFORM_ELEM:
                    //TODO: read transform
                    break;
                case RECORDS_ELEM:
                    //TODO: read records
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(DefineTextTag tag) {
            var res = new XElement(XName.Get(SwfTagNameMapping.DEFINE_TEXT_TAG),
                                   new XAttribute(XName.Get("objectID"), tag.ObjectID));
            res.Add(new XElement(XName.Get("bounds"), GetRectangleXml(tag.Bounds)));
            if (tag.Matrix != null) {
                res.Add(new XElement(XName.Get("transform"), GetTransformXml(tag.Matrix)));
            }
            //TODO: remove unnessary nested nodes. Swfmill requires them
            res.Add(new XElement(XName.Get("records"),
                                 new XElement(XName.Get("TextRecord"),
                                              new XElement(XName.Get("records"),
                                                           tag.Records.Entries.Select(item => GetTextRecordEntryXml(item))
                                                  )
                                     )));
            //TODO: Other fields
            return res;
        }
    }
}
