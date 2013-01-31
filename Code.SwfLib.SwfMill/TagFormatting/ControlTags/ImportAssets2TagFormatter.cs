using System;
using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class ImportAssets2TagFormatter : TagFormatterBase<ImportAssets2Tag> {
        protected override void FormatTagElement(ImportAssets2Tag tag, XElement xTag) {
        }

        protected override void AcceptTagElement(ImportAssets2Tag tag, XElement element) {
        }

        public override string TagName {
            get { return "ImportAssets2"; }
        }
    }
}
