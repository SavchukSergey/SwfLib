using System.Xml.Linq;
using SwfLib.Tags.ControlTags;

namespace SwfLib.SwfMill.TagFormatting.ControlTags {
    /// <summary>
    /// Represents ScriptLimitsTag xml formatter.
    /// </summary>
    public class ScriptLimitsTagFormatter : TagFormatterBase<ScriptLimitsTag> {

        private const string MAX_RECURSION_ATTRIB = "maxRecursionDepth";
        private const string TIMEOUT_ATTRIB = "timeout";

        protected override void FormatTagElement(ScriptLimitsTag tag, XElement xTag) {
            xTag.Add(new XAttribute(XName.Get(MAX_RECURSION_ATTRIB), tag.MaxRecursionDepth));
            xTag.Add(new XAttribute(XName.Get(TIMEOUT_ATTRIB), tag.ScriptTimeoutSeconds));
        }

        protected override bool AcceptTagAttribute(ScriptLimitsTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case MAX_RECURSION_ATTRIB:
                    tag.MaxRecursionDepth = ushort.Parse(attrib.Value);
                    break;
                case TIMEOUT_ATTRIB:
                    tag.ScriptTimeoutSeconds = ushort.Parse(attrib.Value);
                    break;
                default:
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public override string TagName {
            get { return "ScriptLimits"; }
        }

    }
}
