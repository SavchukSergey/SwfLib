using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.TextTags;

namespace Code.SwfLib.SwfMill.TagFormatting.TextTags {
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

        //TODO: Font class name and wasStatic which is not supported by swfmill
        //TODO: check bit flags seting+check fields list
        protected override void AcceptTagAttribute(DefineEditTextTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
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
                    tag.HasLayout = SwfMillPrimitives.ParseBoolean(attrib);
                    //TODO: why does swfmill sets it?
                    break;
                case NOT_SELECTABLE_ATTRIB:
                    tag.NoSelect = SwfMillPrimitives.ParseBoolean(attrib);
                    break;
                case HAS_BORDER_ATTRIB:
                    tag.Border = SwfMillPrimitives.ParseBoolean(attrib);
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
                case FONT_HEIGHT_ATTRIB:
                    tag.FontHeight = ushort.Parse(attrib.Value);
                    tag.HasFont = true;
                    break;
                case MAX_LENGTH_ATTRIB:
                    tag.MaxLength = ushort.Parse(attrib.Value);
                    tag.HasMaxLength = true;
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
                case INITIAL_TEXT_ATTRIB:
                    tag.HasText = true;
                    tag.InitialText = attrib.Value;
                    break;
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(DefineEditTextTag tag, XElement element) {
            switch (element.Name.LocalName) {
                //case DATA_TAG:
                //    //TODO: set data
                //    FromBase64(element);
                //    break;
                case SIZE_ELEM:
                    tag.Bounds = XRect.FromXml(element.Element("Rectangle"));
                    break;
                case COLOR_ELEM:
                    tag.TextColor = XColorRGBA.FromXml(element.Element("Color"));
                    tag.HasTextColor = true;
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override XElement FormatTagElement(DefineEditTextTag tag, XElement xTag) {
            xTag.Add(new XElement(SIZE_ELEM, XRect.ToXml(tag.Bounds)));
            xTag.Add(new XAttribute(WORD_WRAP_ATTRIB, SwfMillPrimitives.GetStringValue(tag.WordWrap)));
            xTag.Add(new XAttribute(MULTILINE_ATTRIB, SwfMillPrimitives.GetStringValue(tag.Multiline)));
            xTag.Add(new XAttribute(PASSWORD_ATTRIB, SwfMillPrimitives.GetStringValue(tag.Password)));
            xTag.Add(new XAttribute(READONLY_ATTRIB, SwfMillPrimitives.GetStringValue(tag.ReadOnly)));
            xTag.Add(new XAttribute(AUTOSIZE_ATTRIB, SwfMillPrimitives.GetStringValue(tag.AutoSize)));
            xTag.Add(new XAttribute(HAS_LAYOUT_ATTRIB, FormatBoolToDigit(tag.HasLayout)));
            xTag.Add(new XAttribute(NOT_SELECTABLE_ATTRIB, FormatBoolToDigit(tag.NoSelect)));
            xTag.Add(new XAttribute(BORDER_ATTRIB, FormatBoolToDigit(tag.Border)));
            //res.Add(new XAttribute(STATIC_ATTRIB, FormatBoolToDigit(tag.WasStatic)));
            xTag.Add(new XAttribute(IS_HTML_ATTRIB, FormatBoolToDigit(tag.HTML)));
            xTag.Add(new XAttribute(USE_OUTLINES_ATTRIB, FormatBoolToDigit(tag.UseOutlines)));
            if (tag.HasFont) {
                xTag.Add(new XAttribute(FONT_REF_ATTRIB, tag.FontID));
                xTag.Add(new XAttribute(FONT_HEIGHT_ATTRIB, tag.FontHeight));
            }
            if (tag.HasTextColor) {
                xTag.Add(new XElement("color", XColorRGBA.ToXml(tag.TextColor)));
            }
            xTag.Add(new XAttribute(MAX_LENGTH_ATTRIB, tag.MaxLength));
            if (tag.HasLayout) {
                xTag.Add(new XAttribute(ALIGN_ATTRIB, tag.Align));
                xTag.Add(new XAttribute(LEFT_MARGIN_ATTRIB, tag.LeftMargin));
                xTag.Add(new XAttribute(RIGHT_MARGIN_ATTRIB, tag.RightMargin));
                xTag.Add(new XAttribute(INDENT_ATTRIB, tag.Indent));
                xTag.Add(new XAttribute(LEADING_ATTRIB, tag.Leading));
            }
            xTag.Add(new XAttribute(VARIABLE_NAME_ATTRIB, tag.VariableName));
            if (tag.HasText) {
                xTag.Add(new XAttribute(INITIAL_TEXT_ATTRIB, tag.InitialText));
            }
            return xTag;
        }

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