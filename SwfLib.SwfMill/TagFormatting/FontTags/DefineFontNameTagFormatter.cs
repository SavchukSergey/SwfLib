using System.Xml.Linq;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.TagFormatting.FontTags {
    public class DefineFontNameTagFormatter : DefineFontBaseFormatter<DefineFontNameTag> {

        protected const string COPYRIGHT_ATTRIB = "copyright";

        protected override bool AcceptTagAttribute(DefineFontNameTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case NAME_ATTRIB:
                    tag.FontName = attrib.Value;
                    break;
                case COPYRIGHT_ATTRIB:
                    tag.FontCopyright = attrib.Value;
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override void FormatTagElement(DefineFontNameTag tag, XElement xTag) {
            xTag.Add(new XAttribute(XName.Get(NAME_ATTRIB), tag.FontName));
            xTag.Add(new XAttribute(XName.Get(COPYRIGHT_ATTRIB), tag.FontCopyright));
        }

        public override string TagName {
            get { return "DefineFontName"; }
        }

    }
}
