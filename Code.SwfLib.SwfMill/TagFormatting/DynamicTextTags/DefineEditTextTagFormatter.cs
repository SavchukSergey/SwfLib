using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Tags.DynamicTextTags;

namespace Code.SwfLib.SwfMill.TagFormatting.DynamicTextTags {
    public class DefineEditTextTagFormatter : TagFormatterBase<DefineEditTextTag> {

        private const string WORD_WRAP_ATTRIB = "wordWrap";
        private const string MULTILINE_ATTRIB = "multiLine";
        private const string PASSWORD_ATTRIB = "password";
        private const string READONLY_ATTRIB = "readOnly";
        private const string AUTOSIZE_ATTRIB = "autoSize";
        private const string HAS_LAYOUT_ATTRIB = "hasLayout";
        private const string NOT_SELECTABLE_ATTRIB = "notSelectable";
        private const string HAS_BORDER_ATTRIB = "hasBorder";
        private const string IS_HTML_ATTRIB = "isHTML";
        private const string USE_OUTLINES_ATTRIB = "useOutlines";
        private const string FONT_REF_ATTRIB = "fontRef";
        private const string FONT_HEIGHT_ATTRIB = "fontHeight";
        private const string ALIGN_ATTRIB = "align";
        private const string LEFT_MARGIN_ATTRIB = "leftMargin";
        private const string RIGHT_MARGIN_ATTRIB = "rightMargin";
        private const string INDENT_ATTRIB = "indent";
        private const string LEADING_ATTRIB = "leading";
        private const string VARIABLE_NAME_ATTRIB = "variableName";
        private const string INITIAL_TEXT_ATTRIB = "initialText";
        private const string SIZE_ELEM = "size";
        private const string COLOR_ELEM = "color";

        //TODO: check bit flags seting+check fields list
        public override void AcceptAttribute(DefineEditTextTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case OBJECT_ID_ATTRIB:
                    tag.CharacterID = ushort.Parse(attrib.Value);
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
                    tag.HasLayout = SwfMillPrimitives.ParseBoolean(attrib);
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
                case ALIGN_ATTRIB:
                    //TODO: password
                    break;
                case LEFT_MARGIN_ATTRIB:
                    tag.LeftMargin = ushort.Parse(attrib.Value);
                    break;
                case RIGHT_MARGIN_ATTRIB:
                    tag.RightMargin = ushort.Parse(attrib.Value);
                    break;
                case INDENT_ATTRIB:
                    tag.Indent = ushort.Parse(attrib.Value);
                    break;
                case LEADING_ATTRIB:
                    tag.Leading = short.Parse(attrib.Value);
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

        public override void AcceptElement(DefineEditTextTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case DATA_TAG:
                    //TODO: set data
                    FromBase64(element);
                    break;
                case SIZE_ELEM:
                    _formatters.Rectangle.Parse(element.Element("Rectangle"), out tag.Bounds);
                    break;
                case COLOR_ELEM:
                    //TODO: password
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        public override XElement FormatTag(DefineEditTextTag tag) {
            //TODO: check fields
            var res = new XElement(SwfTagNameMapping.DEFINE_EDIT_TEXT_TAG,
                                new XAttribute(OBJECT_ID_ATTRIB, tag.CharacterID),
                                new XAttribute(WORD_WRAP_ATTRIB, SwfMillPrimitives.GetStringValue(tag.WordWrap)),
                                new XAttribute(MULTILINE_ATTRIB, SwfMillPrimitives.GetStringValue(tag.Multiline)),
                                new XAttribute(READONLY_ATTRIB, SwfMillPrimitives.GetStringValue(tag.ReadOnly)),
                                new XAttribute(PASSWORD_ATTRIB, SwfMillPrimitives.GetStringValue(tag.Password)),
                                new XAttribute(AUTOSIZE_ATTRIB, SwfMillPrimitives.GetStringValue(tag.AutoSize))

            );
            if (tag.HasLayout) {
                res.Add(new XAttribute(LEFT_MARGIN_ATTRIB, tag.LeftMargin));
                res.Add(new XAttribute(RIGHT_MARGIN_ATTRIB, tag.RightMargin));
                res.Add(new XAttribute(INDENT_ATTRIB, tag.Indent));
                res.Add(new XAttribute(LEADING_ATTRIB, tag.Leading));
            }
            res.Add(new XAttribute(VARIABLE_NAME_ATTRIB, tag.VariableName));
            if (tag.HasText) {
                res.Add(new XAttribute(INITIAL_TEXT_ATTRIB, tag.InitialText));
            }
            return res;
        }
    }
}