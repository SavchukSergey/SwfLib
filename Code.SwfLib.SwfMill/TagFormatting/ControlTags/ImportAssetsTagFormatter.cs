using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class ImportAssetsTagFormatter : TagFormatterBase<ImportAssetsTag> {
        protected override void FormatTagElement(ImportAssetsTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "ImportAssets"; }
        }
    }
}
