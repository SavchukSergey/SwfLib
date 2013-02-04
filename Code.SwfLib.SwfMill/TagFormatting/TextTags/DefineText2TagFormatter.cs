using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Text;
using Code.SwfLib.Tags.TextTags;

namespace Code.SwfLib.SwfMill.TagFormatting.TextTags {
    public class DefineText2TagFormatter : BaseDefineTextTagFormatter<DefineText2Tag> {

        public override string TagName {
            get { return "DefineText2"; }
        }

        protected override void ReadRecords(DefineText2Tag tag, XElement xRecords) {
            var elem = xRecords.Element("TextRecord").Element("records");
            foreach (var recordElem in elem.Elements()) {
                tag.TextRecords.Add(XTextRecord.FromXmlRGBA(recordElem));
            }
        }

        protected override void FormatRecords(DefineText2Tag tag, XElement xRecords) {
            xRecords.Add(new XElement("TextRecord",
                             new XElement("records",
                                     tag.TextRecords.Select(XTextRecord.ToXmlRGBA)
                             )
             ));
        }

    }
}
