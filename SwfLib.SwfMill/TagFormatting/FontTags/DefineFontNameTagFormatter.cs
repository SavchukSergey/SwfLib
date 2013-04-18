using System.Xml.Linq;
using SwfLib.Tags.FontTags;

namespace SwfLib.SwfMill.TagFormatting.FontTags {
    /// <summary>
    /// Represents DefineFontNameTag xml formatter.
    /// </summary>
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

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public override string TagName {
            get { return "DefineFontName"; }
        }

    }
}
