using System;
using System.Linq;
using System.Xml.Linq;
using SwfLib.SwfMill.Data;
using SwfLib.Text;

namespace SwfLib.SwfMill.Text {
    /// <summary>
    /// Represents TextRecord xml formatter.
    /// </summary>
    public static class XTextRecord {

        public static XElement ToXmlRGB(TextRecordRGB entry) {
            var res = new XElement(XName.Get("TextRecord6"));
            res.Add(new XAttribute("isSetup", CommonFormatter.Format(entry.Type)));
            if (entry.FontID.HasValue) {
                res.Add(new XAttribute("objectID", entry.FontID.Value));
            }
            if (entry.Reserved != 0) {
                res.Add(new XAttribute("reserved", entry.Reserved));
            }
            if (entry.XOffset.HasValue) {
                res.Add(new XAttribute("x", entry.XOffset.Value));
            }
            if (entry.YOffset.HasValue) {
                res.Add(new XAttribute("y", entry.YOffset.Value));
            }
            if (entry.FontID.HasValue) {
                if (!entry.TextHeight.HasValue) throw new InvalidOperationException("Text Height must be specified");
                res.Add(new XAttribute("fontHeight", entry.TextHeight.Value));
            }
            if (entry.TextColor.HasValue) {
                var color = entry.TextColor.Value;
                res.Add(new XElement("color", XColorRGB.ToXml(color)));
            }
            res.Add(new XElement(XName.Get("glyphs"), entry.Glyphs.Select(FormatGlyphEntry)));
            return res;
        }

        public static TextRecordRGB FromXmlRGB(XElement element) {
            var result = new TextRecordRGB();
            foreach (var attribute in element.Attributes()) {
                switch (attribute.Name.LocalName) {
                    case "objectID":
                        result.FontID = ushort.Parse(attribute.Value);
                        break;
                    case "isSetup":
                        result.Type = CommonFormatter.ParseBool(attribute.Value);
                        break;
                    case "reserved":
                        result.Reserved = byte.Parse(attribute.Value);
                        break;
                    case "x":
                        result.XOffset = short.Parse(attribute.Value);
                        break;
                    case "y":
                        result.YOffset = short.Parse(attribute.Value);
                        break;
                    case "fontHeight":
                        result.TextHeight = ushort.Parse(attribute.Value);
                        break;
                    default:
                        throw new NotSupportedException();

                }
            }
            foreach (var elem in element.Elements()) {
                switch (elem.Name.LocalName) {
                    case "color":
                        var color = XColorRGB.FromXml(elem.Element("Color"));
                        result.TextColor = color;
                        break;
                    case "glyphs":
                        foreach (var glyphElem in elem.Elements()) {
                            result.Glyphs.Add(ParseGlyphEntry(glyphElem));
                        }
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }
            return result;
        }


        public static XElement ToXmlRGBA(TextRecordRGBA entry) {
            var res = new XElement(XName.Get("TextRecord6"));
            res.Add(new XAttribute("isSetup", CommonFormatter.Format(entry.Type)));
            if (entry.FontID.HasValue) {
                res.Add(new XAttribute("objectID", entry.FontID.Value));
            }
            if (entry.Reserved != 0) {
                res.Add(new XAttribute("reserved", entry.Reserved));
            }
            if (entry.XOffset.HasValue) {
                res.Add(new XAttribute("x", entry.XOffset.Value));
            }
            if (entry.YOffset.HasValue) {
                res.Add(new XAttribute("y", entry.YOffset.Value));
            }
            if (entry.FontID.HasValue) {
                if (!entry.TextHeight.HasValue) throw new InvalidOperationException("Text Height must be specified");
                res.Add(new XAttribute("fontHeight", entry.TextHeight.Value));
            }
            if (entry.TextColor.HasValue) {
                var color = entry.TextColor.Value;
                res.Add(new XElement("color", XColorRGBA.ToXml(color)));
            }
            res.Add(new XElement(XName.Get("glyphs"), entry.Glyphs.Select(FormatGlyphEntry)));
            return res;
        }

        public static TextRecordRGBA FromXmlRGBA(XElement element) {
            var result = new TextRecordRGBA();
            foreach (var attribute in element.Attributes()) {
                switch (attribute.Name.LocalName) {
                    case "objectID":
                        result.FontID = ushort.Parse(attribute.Value);
                        break;
                    case "isSetup":
                        result.Type = CommonFormatter.ParseBool(attribute.Value);
                        break;
                    case "reserved":
                        result.Reserved = byte.Parse(attribute.Value);
                        break;
                    case "x":
                        result.XOffset = short.Parse(attribute.Value);
                        break;
                    case "y":
                        result.YOffset = short.Parse(attribute.Value);
                        break;
                    case "fontHeight":
                        result.TextHeight = ushort.Parse(attribute.Value);
                        break;
                    default:
                        throw new NotSupportedException();

                }
            }
            foreach (var elem in element.Elements()) {
                switch (elem.Name.LocalName) {
                    case "color":
                        var color = XColorRGBA.FromXml(elem.Element("Color"));
                        result.TextColor = color;
                        break;
                    case "glyphs":
                        foreach (var glyphElem in elem.Elements()) {
                            result.Glyphs.Add(ParseGlyphEntry(glyphElem));
                        }
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }
            return result;
        }

        public static GlyphEntry ParseGlyphEntry(XElement element) {
            var result = new GlyphEntry();
            foreach (var attribute in element.Attributes()) {
                switch (attribute.Name.LocalName) {
                    case "glyph":
                        result.GlyphIndex = uint.Parse(attribute.Value);
                        break;
                    case "advance":
                        result.GlyphAdvance = int.Parse(attribute.Value);
                        break;
                    default:
                        throw new NotSupportedException();

                }
            }
            foreach (var elem in element.Elements()) {
                switch (elem.Name.LocalName) {
                    default:
                        throw new NotSupportedException();
                }
            }
            return result;
        }

        public static XElement FormatGlyphEntry(GlyphEntry entry) {
            return new XElement(XName.Get("TextEntry"),
                                new XAttribute(XName.Get("glyph"), entry.GlyphIndex),
                                new XAttribute(XName.Get("advance"), entry.GlyphAdvance));
        }
    }
}
