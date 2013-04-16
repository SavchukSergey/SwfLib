using System.Xml.Linq;
using SwfLib.Tags.ButtonTags;

namespace SwfLib.SwfMill.TagFormatting.ButtonTags {
    public class DefineButtonCxformTagFormatter : DefineButtonBaseTagFormatter<DefineButtonCxformTag> {
        protected override void FormatTagElement(DefineButtonCxformTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DefineButtonCxform"; }
        }
    }
}
