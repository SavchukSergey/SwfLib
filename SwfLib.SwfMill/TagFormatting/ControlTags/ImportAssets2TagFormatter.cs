using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;
using SwfLib.SwfMill.TagFormatting;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class ImportAssets2TagFormatter : TagFormatterBase<ImportAssets2Tag> {
        protected override void FormatTagElement(ImportAssets2Tag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "ImportAssets2"; }
        }
    }
}
