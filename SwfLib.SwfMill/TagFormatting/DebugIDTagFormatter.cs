using System.Xml.Linq;
using Code.SwfLib.Tags;
using SwfLib.SwfMill.TagFormatting;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public class DebugIDTagFormatter : TagFormatterBase<DebugIDTag> {
        protected override void FormatTagElement(DebugIDTag tag, XElement xTag) {
        }

        protected override byte[] GetData(DebugIDTag tag) {
            return tag.Data;
        }

        protected override void SetData(DebugIDTag tag, byte[] data) {
            tag.Data = data;
        }

        public override string TagName {
            get { return "DebugID"; }
        }
    }
}
