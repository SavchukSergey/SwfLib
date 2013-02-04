using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.TextTags;

namespace Code.SwfLib.SwfMill.TagFormatting.TextTags {
    public abstract class BaseDefineTextTagFormatter<T> : TagFormatterBase<T> where T: DefineTextBaseTag {

        private const string BOUNDS_ELEM = "bounds";
        private const string TRANSFORM_ELEM = "transform";
        private const string RECORDS_ELEM = "records";

        protected sealed override bool AcceptTagElement(T tag, XElement element) {
            switch (element.Name.LocalName) {
                case BOUNDS_ELEM:
                    tag.TextBounds = XRect.FromXml(element.Element("Rectangle"));
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
            return true;
        }

        protected sealed override void FormatTagElement(T tag, XElement xTag) {
            xTag.Add(new XElement("bounds", XRect.ToXml(tag.TextBounds)));
            xTag.Add(new XElement("transform", XMatrix.ToXml(tag.TextMatrix)));
            var xRecords = new XElement("records");
            xTag.Add(xRecords);
            FormatRecords(tag, xRecords);
            //TODO: remove unnessary nested nodes. Swfmill requires them
        }

        protected abstract void FormatRecords(T tag, XElement xRecords);
        protected abstract void ReadRecords(T tag, XElement xRecords);

        protected override ushort? GetObjectID(T tag) {
            return tag.CharacterID;
        }

        protected override void SetObjectID(T tag, ushort value) {
            tag.CharacterID = value;
        }
    }
}
