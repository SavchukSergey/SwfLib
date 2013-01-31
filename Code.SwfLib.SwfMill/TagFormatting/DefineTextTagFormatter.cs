using System;
using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Text;
using Code.SwfLib.Tags.TextTags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class DefineTextTagFormatter : TagFormatterBase<DefineTextTag> {

        private const string BOUNDS_ELEM = "bounds";
        private const string TRANSFORM_ELEM = "transform";
        private const string RECORDS_ELEM = "records";

        protected override void AcceptTagElement(DefineTextTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case BOUNDS_ELEM:
                    tag.TextBounds = XRect.FromXml(element.Element(XName.Get("Rectangle")));
                    break;
                case TRANSFORM_ELEM:
                    tag.TextMatrix = XMatrix.FromXml(element.Element("Transform"));
                    break;
                case RECORDS_ELEM:
                    ReadRecords(tag, element);
                    break;
                default:
                    return false;
            }
        }

        private static void ReadRecords(DefineTextTag tag, XElement recordsElem) {
            var elem = recordsElem.Element(XName.Get("TextRecord")).Element(XName.Get("records"));
            foreach (var recordElem in elem.Elements()) {
                tag.TextRecords.Add(XTextRecord.FromXml(recordElem));
            }
        }

        //TODO: simulate swfmill incorrect structure of TextRecord (parsing, formating)

        protected override void FormatTagElement(DefineTextTag tag, XElement xTag) {
            xTag.Add(new XElement("bounds", XRect.ToXml(tag.TextBounds)));
            xTag.Add(new XElement("transform", XMatrix.ToXml(tag.TextMatrix)));
            //TODO: remove unnessary nested nodes. Swfmill requires them
            xTag.Add(new XElement("records",
                                 new XElement("TextRecord",
                                              new XElement("records",
                                                           tag.TextRecords.Select(XTextRecord.ToXml)
                                                  )
                                     )));
            //TODO: Other fields
        }

        public override string TagName {
            get { return "DefineText"; }
        }

        protected override ushort? GetObjectID(DefineTextTag tag) {
            return tag.CharacterID;
        }

        protected override void SetObjectID(DefineTextTag tag, ushort value) {
            tag.CharacterID = value;
        }
    }
}
