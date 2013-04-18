using System.Xml.Linq;
using SwfLib.SwfMill.Data;
using SwfLib.Tags.TextTags;

namespace SwfLib.SwfMill.TagFormatting.TextTags {
    /// <summary>
    /// Represents DefineEditTextTag xml formatter.
    /// </summary>
    public class DefineEditTextTagFormatter : TagFormatterBase<DefineEditTextTag> {

        private const string WORD_WRAP_ATTRIB = "wordWrap";
        private const string MULTILINE_ATTRIB = "multiLine";
        private const string PASSWORD_ATTRIB = "password";
        private const string READONLY_ATTRIB = "readOnly";
        private const string MAX_LENGTH_ATTRIB = "maxLength";
        private const string AUTOSIZE_ATTRIB = "autoSize";
        private const string HAS_LAYOUT_ATTRIB = "hasLayout";
        private const string NOT_SELECTABLE_ATTRIB = "notSelectable";
        private const string HAS_BORDER_ATTRIB = "hasBorder";
        private const string IS_HTML_ATTRIB = "isHTML";
        private const string USE_OUTLINES_ATTRIB = "useOutlines";
        private const string FONT_REF_ATTRIB = "fontRef";
        private const string FONT_HEIGHT_ATTRIB = "fontHeight";
        private const string ALIGN_ATTRIB = "align";
        private const string BORDER_ATTRIB = "hasBorder";
        //private const string STATIC_ATTRIB = "wasStatic";
        private const string LEFT_MARGIN_ATTRIB = "leftMargin";
        private const string RIGHT_MARGIN_ATTRIB = "rightMargin";
        private const string INDENT_ATTRIB = "indent";
        private const string LEADING_ATTRIB = "leading";
        private const string VARIABLE_NAME_ATTRIB = "variableName";
        private const string INITIAL_TEXT_ATTRIB = "initialText";
        private const string SIZE_ELEM = "size";
        private const string COLOR_ELEM = "color";

        protected override bool AcceptTagAttribute(DefineEditTextTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case INITIAL_TEXT_ATTRIB:
                    tag.InitialText = attrib.Value;
                    break;
                case WORD_WRAP_ATTRIB:
                    tag.WordWrap = SwfMillPrimitives.ParseBoolean(attrib);
                    break;
                case MULTILINE_ATTRIB:
                    tag.Multiline = SwfMillPrimitives.ParseBoolean(attrib);
                    break;
                case PASSWORD_ATTRIB:
                    tag.Password = SwfMillPrimitives.ParseBoolean(attrib);
                    break;
                case READONLY_ATTRIB:
                    tag.ReadOnly = SwfMillPrimitives.ParseBoolean(attrib);
                    break;

                case AUTOSIZE_ATTRIB:
                    tag.AutoSize = SwfMillPrimitives.ParseBoolean(attrib);
                    break;
                case HAS_LAYOUT_ATTRIB:
                    tag.HasLayout = CommonFormatter.ParseBool(attrib.Value);
                    break;
                case NOT_SELECTABLE_ATTRIB:
                    tag.NoSelect = SwfMillPrimitives.ParseBoolean(attrib);
                    break;
                case HAS_BORDER_ATTRIB:
                    tag.Border = SwfMillPrimitives.ParseBoolean(attrib);
                    break;
                case "static":
                    tag.WasStatic = CommonFormatter.ParseBool(attrib.Value);
                    break;
                case IS_HTML_ATTRIB:
                    tag.HTML = SwfMillPrimitives.ParseBoolean(attrib);
                    break;
                case USE_OUTLINES_ATTRIB:
                    tag.UseOutlines = SwfMillPrimitives.ParseBoolean(attrib);
                    break;

                case FONT_REF_ATTRIB:
                    tag.FontID = ushort.Parse(attrib.Value);
                    tag.HasFont = true;
                    break;
                case "fontClass":
                    tag.FontClass = attrib.Value;
                    break;
                case FONT_HEIGHT_ATTRIB:
                    tag.FontHeight = ushort.Parse(attrib.Value);
                    tag.HasFont = true;
                    break;
                case MAX_LENGTH_ATTRIB:
                    tag.MaxLength = ushort.Parse(attrib.Value);
                    break;

                case ALIGN_ATTRIB:
                    tag.Align = byte.Parse(attrib.Value);
                    tag.HasLayout = true;
                    break;
                case LEFT_MARGIN_ATTRIB:
                    tag.LeftMargin = ushort.Parse(attrib.Value);
                    tag.HasLayout = true;
                    break;
                case RIGHT_MARGIN_ATTRIB:
                    tag.RightMargin = ushort.Parse(attrib.Value);
                    tag.HasLayout = true;
                    break;
                case INDENT_ATTRIB:
                    tag.Indent = ushort.Parse(attrib.Value);
                    tag.HasLayout = true;
                    break;
                case LEADING_ATTRIB:
                    tag.Leading = short.Parse(attrib.Value);
                    tag.HasLayout = true;
                    break;
                case VARIABLE_NAME_ATTRIB:
                    tag.VariableName = attrib.Value;
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override bool AcceptTagElement(DefineEditTextTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case SIZE_ELEM:
                    tag.Bounds = XRect.FromXml(element.Element("Rectangle"));
                    break;
                case COLOR_ELEM:
                    tag.TextColor = XColorRGBA.FromXml(element.Element("Color"));
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override void FormatTagElement(DefineEditTextTag tag, XElement xTag) {
            xTag.Add(new XElement(SIZE_ELEM, XRect.ToXml(tag.Bounds)));

            xTag.Add(new XAttribute(WORD_WRAP_ATTRIB, SwfMillPrimitives.GetStringValue(tag.WordWrap)));
            xTag.Add(new XAttribute(MULTILINE_ATTRIB, SwfMillPrimitives.GetStringValue(tag.Multiline)));
            xTag.Add(new XAttribute(PASSWORD_ATTRIB, SwfMillPrimitives.GetStringValue(tag.Password)));
            xTag.Add(new XAttribute(READONLY_ATTRIB, SwfMillPrimitives.GetStringValue(tag.ReadOnly)));

            xTag.Add(new XAttribute(AUTOSIZE_ATTRIB, SwfMillPrimitives.GetStringValue(tag.AutoSize)));
            xTag.Add(new XAttribute(HAS_LAYOUT_ATTRIB, CommonFormatter.Format(tag.HasLayout)));
            xTag.Add(new XAttribute(NOT_SELECTABLE_ATTRIB, CommonFormatter.Format(tag.NoSelect)));
            xTag.Add(new XAttribute(BORDER_ATTRIB, CommonFormatter.Format(tag.Border)));
            xTag.Add(new XAttribute("static", CommonFormatter.Format(tag.WasStatic)));
            xTag.Add(new XAttribute(IS_HTML_ATTRIB, CommonFormatter.Format(tag.HTML)));
            xTag.Add(new XAttribute(USE_OUTLINES_ATTRIB, CommonFormatter.Format(tag.UseOutlines)));

            if (tag.HasFont) {
                xTag.Add(new XAttribute(FONT_REF_ATTRIB, tag.FontID));
            }
            if (tag.FontClass != null) {
                xTag.Add(new XAttribute("fontClass", tag.FontClass));
            }
            if (tag.HasFont) {
                xTag.Add(new XAttribute(FONT_HEIGHT_ATTRIB, tag.FontHeight));
            }
            if (tag.TextColor.HasValue) {
                xTag.Add(new XElement("color", XColorRGBA.ToXml(tag.TextColor.Value)));
            }
            if (tag.MaxLength.HasValue) {
                xTag.Add(new XAttribute(MAX_LENGTH_ATTRIB, tag.MaxLength.Value));
            }
            if (tag.HasLayout) {
                xTag.Add(new XAttribute(ALIGN_ATTRIB, tag.Align));
                xTag.Add(new XAttribute(LEFT_MARGIN_ATTRIB, tag.LeftMargin));
                xTag.Add(new XAttribute(RIGHT_MARGIN_ATTRIB, tag.RightMargin));
                xTag.Add(new XAttribute(INDENT_ATTRIB, tag.Indent));
                xTag.Add(new XAttribute(LEADING_ATTRIB, tag.Leading));
            }
            xTag.Add(new XAttribute(VARIABLE_NAME_ATTRIB, tag.VariableName));
            if (tag.InitialText != null) {
                xTag.Add(new XAttribute(INITIAL_TEXT_ATTRIB, tag.InitialText));
            }
        }

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public override string TagName {
            get { return "DefineEditText"; }
        }

        protected override ushort? GetObjectID(DefineEditTextTag tag) {
            return tag.CharacterID;
        }

        protected override void SetObjectID(DefineEditTextTag tag, ushort value) {
            tag.CharacterID = value;
        }
    }
}