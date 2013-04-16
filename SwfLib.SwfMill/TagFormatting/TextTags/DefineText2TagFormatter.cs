using System.Linq;
using System.Xml.Linq;
using SwfLib.SwfMill.Text;
using SwfLib.SwfMill.Utils;
using SwfLib.Tags.TextTags;

namespace SwfLib.SwfMill.TagFormatting.TextTags {
    public class DefineText2TagFormatter : BaseDefineTextTagFormatter<DefineText2Tag> {

        public override string TagName {
            get { return "DefineText2"; }
        }

        protected override void ReadRecords(DefineText2Tag tag, XElement xRecords) {
            var elem = xRecords.RequiredElement("TextRecord").RequiredElement("records");
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
