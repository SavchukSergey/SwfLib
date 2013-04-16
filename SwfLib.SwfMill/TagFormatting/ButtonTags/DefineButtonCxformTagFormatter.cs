using System.Xml.Linq;
using Code.SwfLib.Tags.ButtonTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ButtonTags {
    public class DefineButtonCxformTagFormatter : DefineButtonBaseTagFormatter<DefineButtonCxformTag> {
        protected override void FormatTagElement(DefineButtonCxformTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DefineButtonCxform"; }
        }
    }
}
