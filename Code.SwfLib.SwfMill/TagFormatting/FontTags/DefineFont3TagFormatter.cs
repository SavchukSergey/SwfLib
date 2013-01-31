using System;
using System.Diagnostics;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.Fonts;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib.SwfMill.TagFormatting.FontTags {
    public class DefineFont3TagFormatter : DefineFontBaseFormatter<DefineFont3Tag> {

        private const string SHIFT_JIS_ATTRIB = "isShiftJIS";
        private const string UNICODE_ATTRIB = "isUnicode";
        private const string ANSI_ATTRIB = "isANSII";
        private const string WIDE_GLYPH_OFFSETS_ATTRIB = "wideGlyphOffsets";
        private const string ITALIC_ATTRIB = "italic";
        private const string BOLD_ATTRIB = "bold";

        private const string LANGUAGE_ATTRIB = "language";

        protected override bool AcceptTagAttribute(DefineFont3Tag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case NAME_ATTRIB:
                    tag.FontName = attrib.Value;
                    break;
                case LANGUAGE_ATTRIB:
                    tag.Language = byte.Parse(attrib.Value);
                    break;
                case SHIFT_JIS_ATTRIB:
                    tag.ShiftJIS = ParseBoolFromDigit(attrib);
                    break;
                case UNICODE_ATTRIB:
                    tag.SmallText = ParseBoolFromDigit(attrib);
                    break;
                case ANSI_ATTRIB:
                    tag.ANSI = ParseBoolFromDigit(attrib);
                    break;
                case WIDE_GLYPH_OFFSETS_ATTRIB:
                    tag.WideOffsets = ParseBoolFromDigit(attrib);
                    break;
                case ITALIC_ATTRIB:
                    tag.Italic = ParseBoolFromDigit(attrib);
                    break;
                case BOLD_ATTRIB:
                    tag.Bold = ParseBoolFromDigit(attrib);
                    break;
                case "ascent":
                    tag.HasLayout = true;
                    tag.Ascent = short.Parse(attrib.Value);
                    break;
                case "descent":
                    tag.HasLayout = true;
                    tag.Descent = short.Parse(attrib.Value);
                    break;
                case "leading":
                    tag.HasLayout = true;
                    tag.Leading = short.Parse(attrib.Value);
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override void AcceptTagElement(DefineFont3Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "wideKerning":
                    tag.HasLayout = true;
                    foreach (var xRecord in element.Elements()) {
                        tag.KerningRecords.Add(XKerningRecord.FromXml(xRecord));
                    }
                    break;
                case "advance":
                    tag.HasLayout = true;
                    var advanceIndex = 0;
                    foreach (var xAdvance in element.Elements()) {
                        var xValue = xAdvance.Attribute("value");
                        tag.Glyphs[advanceIndex].Advance = short.Parse(xValue.Value);
                        advanceIndex++;
                    }
                    break;
                case "bounds":
                    tag.HasLayout = true;
                    var boundIndex = 0;
                    foreach (var xBound in element.Elements()) {
                        tag.Glyphs[boundIndex].Bounds = XRect.FromXml(xBound);
                        boundIndex++;
                    }
                    break;
                case "glyphs":
                    foreach (var xGlyph in element.Elements()) {
                        tag.Glyphs.Add(XGlyph.FromXml(xGlyph));
                    }
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override void FormatTagElement(DefineFont3Tag tag, XElement xTag) {
            xTag.Add(new XAttribute(LANGUAGE_ATTRIB, tag.Language));
            xTag.Add(new XAttribute(SHIFT_JIS_ATTRIB, FormatBoolToDigit(tag.ShiftJIS)));
            xTag.Add(new XAttribute(UNICODE_ATTRIB, FormatBoolToDigit(tag.SmallText)));
            xTag.Add(new XAttribute(ANSI_ATTRIB, FormatBoolToDigit(tag.ANSI)));
            xTag.Add(new XAttribute(WIDE_GLYPH_OFFSETS_ATTRIB, FormatBoolToDigit(tag.WideOffsets)));
            xTag.Add(new XAttribute(ITALIC_ATTRIB, FormatBoolToDigit(tag.Italic)));
            xTag.Add(new XAttribute(BOLD_ATTRIB, FormatBoolToDigit(tag.Bold)));
            xTag.Add(new XAttribute(NAME_ATTRIB, tag.FontName));

            var xGlyphs = new XElement("glyphs");
            foreach (var glyph in tag.Glyphs) {
                var xGlyph = XGlyph.ToXml(glyph);
                xGlyphs.Add(xGlyph);
            }
            xTag.Add(xGlyphs);

            if (tag.HasLayout) {
                xTag.Add(new XAttribute("ascent", tag.Ascent));
                xTag.Add(new XAttribute("descent", tag.Descent));
                xTag.Add(new XAttribute("leading", tag.Leading));

                var xAdvance = new XElement("advance");
                foreach (var glyph in tag.Glyphs) {
                    var xGlyph = new XElement("Short");
                    xGlyph.Add(new XAttribute("value", glyph.Advance));
                    xAdvance.Add(xGlyph);
                }
                xTag.Add(xAdvance);

                var xBounds = new XElement("bounds");
                foreach (var glyph in tag.Glyphs) {
                    xBounds.Add(XRect.ToXml(glyph.Bounds));
                }
                xTag.Add(xBounds);

                var xKerningRecords = new XElement("wideKerning");
                foreach (var kerningRecord in tag.KerningRecords) {
                    xKerningRecords.Add(XKerningRecord.ToXml(kerningRecord));
                }
                xTag.Add(xKerningRecords);
            }

        }

        public override string TagName {
            get { return "DefineFont3"; }
        }

    }
}