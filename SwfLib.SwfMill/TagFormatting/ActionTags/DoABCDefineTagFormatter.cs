using System.IO;
using System.Xml.Linq;
using SwfLib.Avm2;
using SwfLib.SwfMill.Data;
using SwfLib.Tags.ActionsTags;

namespace SwfLib.SwfMill.TagFormatting.ActionTags {
    public class DoABCDefineTagFormatter : TagFormatterBase<DoABCDefineTag> {

        protected override void FormatTagElement(DoABCDefineTag tag, XElement xTag) {
            var reader = new AbcReader(new SwfStreamReader(new MemoryStream(tag.ABCData)));
            var info = reader.ReadAbcFile();
            xTag.Add(XAbcFile.ToXml(info));
        }

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public override string TagName {
            get { return "DoAbc"; }
        }

    }
}
