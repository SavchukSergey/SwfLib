using System.IO;
using System.Xml.Linq;
using SwfLib.Avm2;
using SwfLib.SwfMill.Data;
using SwfLib.SwfMill.Data.Avm2;
using SwfLib.Tags.ActionsTags;

namespace SwfLib.SwfMill.TagFormatting.ActionTags {
    public class DoABCDefineTagFormatter : TagFormatterBase<DoABCDefineTag> {

        protected override void FormatTagElement(DoABCDefineTag tag, XElement xTag) {
            xTag.Add(new XElement("abc", FormatBase64(tag.ABCData)));
            
            var reader = new AbcReader(new SwfStreamReader(new MemoryStream(tag.ABCData)));
            var info = reader.ReadAbcFile();
            xTag.Add(XAbcFile.ToXml(info));
        }

        protected override bool AcceptTagElement(DoABCDefineTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "abc":
                    tag.ABCData = ParseBase64(element.Value);
                    return true;
                case XAbcFile.TAG_NAME:
                    return true;
                default:
                    return base.AcceptTagElement(tag, element);
            }
        }

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public override string TagName {
            get { return "DoAbc"; }
        }

    }
}
