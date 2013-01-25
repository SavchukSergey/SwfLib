using System;
using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Data.Text;
using Code.SwfLib.SwfMill.Data;

namespace Code.SwfLib.SwfMill
{
    public static class SwfMillPrimitives
    {

        public static ushort ParseObjectID(XAttribute attrib)
        {
            return ushort.Parse(attrib.Value);
        }

        private static void OnUnknownElementFound(XElement elem)
        {
            throw new FormatException("Unknown element " + elem.Name.LocalName);
        }

        private static void OnUnknownAttributeFound(XAttribute elem)
        {
            throw new FormatException("Unknown attribute " + elem.Name.LocalName);
        }

        public static XElement FormatTextRecord(TextRecord entry)
        {
            var res = new XElement(XName.Get("TextRecord6"));
            if (entry.HasFont)
            {
                res.Add(new XAttribute(XName.Get("objectID"), entry.FontID.Value));
            }
            if (entry.HasXOffset)
            {
                res.Add(new XAttribute(XName.Get("x"), entry.XOffset.Value));
            }
            if (entry.HasYOffset)
            {
                res.Add(new XAttribute(XName.Get("y"), entry.YOffset.Value));
            }
            if (entry.HasFont)
            {
                if (!entry.TextHeight.HasValue) throw new InvalidOperationException("Text Height must be specified");
                res.Add(new XAttribute(XName.Get("fontHeight"), entry.TextHeight.Value));
            }
            if (entry.HasColor)
            {
                var color = entry.TextColor.Value;
                res.Add(new XElement(XName.Get("color"), XColorRGB.ToXml(color)));
            }
            res.Add(new XElement(XName.Get("glyphs"), entry.Glyphs.Select(FormatGlyphEntry)));
            return res;
        }

        public static TextRecord ParseTextRecord(XElement element)
        {
            var result = new TextRecord();
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "objectID":
                        result.FontID = ushort.Parse(attribute.Value);
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
                        OnUnknownAttributeFound(attribute);
                        break;

                }
            }
            foreach (var elem in element.Elements())
            {
                switch (elem.Name.LocalName)
                {
                    case "color":
                        SwfRGB color = XColorRGB.FromXml(elem.Element("Color"));
                        result.TextColor = color;
                        break;
                    case "glyphs":
                        foreach (var glyphElem in elem.Elements())
                        {
                            result.Glyphs.Add(ParseGlyphEntry(glyphElem));
                        }
                        break;
                    default:
                        OnUnknownElementFound(elem);
                        break;
                }
            }
            return result;
        }

        public static XElement FormatGlyphEntry(GlyphEntry entry)
        {
            return new XElement(XName.Get("TextEntry"),
                                new XAttribute(XName.Get("glyph"), entry.GlyphIndex),
                                new XAttribute(XName.Get("advance"), entry.GlyphAdvance));
        }

        public static GlyphEntry ParseGlyphEntry(XElement element)
        {
            var result = new GlyphEntry();
            foreach (var attribute in element.Attributes())
            {
                switch (attribute.Name.LocalName)
                {
                    case "glyph":
                        result.GlyphIndex = uint.Parse(attribute.Value);
                        break;
                    case "advance":
                        result.GlyphAdvance = int.Parse(attribute.Value);
                        break;
                    default:
                        OnUnknownAttributeFound(attribute);
                        break;

                }
            }
            foreach (var elem in element.Elements())
            {
                switch (elem.Name.LocalName)
                {
                    default:
                        OnUnknownElementFound(elem);
                        break;
                }
            }
            return result;
        }

        public static bool ParseBoolean(XAttribute attribute)
        {
            switch (attribute.Value)
            {
                case "0":
                    return false;
                case "1":
                    return true;
                default:
                    throw new FormatException("Unknown value");
            }
        }

        public static string GetStringValue(bool val)
        {
            return val ? "1" : "0";
        }

    }
}
