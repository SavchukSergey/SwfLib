using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Text;
using Code.SwfLib.Tags.TextTags;

namespace Code.SwfLib.SwfMill.TagFormatting.TextTags {
    public class DefineTextTagFormatter : BaseDefineTextTagFormatter<DefineTextTag> {

        protected override void ReadRecords(DefineTextTag tag, XElement xRecords) {
            var elem = xRecords.Element("TextRecord").Element("records");
            foreach (var recordElem in elem.Elements()) {
                tag.TextRecords.Add(XTextRecord.FromXmlRGB(recordElem));
            }
        }

        protected override void FormatRecords(DefineTextTag tag, XElement xRecords) {
            xRecords.Add(new XElement("TextRecord",
                            new XElement("records",
                                    tag.TextRecords.Select(XTextRecord.ToXmlRGB)
                            )
            ));
        }

        public override string TagName {
            get { return "DefineText"; }
        }


    }
}
