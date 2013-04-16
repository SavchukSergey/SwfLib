using System.Xml.Linq;
using Code.SwfLib.Tags.ControlTags;

namespace SwfLib.SwfMill.TagFormatting.ControlTags {
    public class EnableDebugger2TagFormatter : TagFormatterBase<EnableDebugger2Tag> {

        protected override void FormatTagElement(EnableDebugger2Tag tag, XElement xTag) {
        }

        protected override byte[] GetData(EnableDebugger2Tag tag) {
            return tag.Data;
        }

        protected override void SetData(EnableDebugger2Tag tag, byte[] data) {
            tag.Data = data;
        }

        public override string TagName {
            get { return "EnableDebugger2"; }
        }
    }
}
