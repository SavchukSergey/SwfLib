using System;
using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public abstract class TagFormatterBase<T> : ITagFormatter<T> where T : SwfTagBase {

        #region ITagFormatter
        
        XElement ITagFormatter.FormatTag(SwfTagBase tag) {
            return FormatTag((T)tag);
        }

        void ITagFormatter.AcceptAttribute(SwfTagBase tag, XAttribute attrib) {
            AcceptAttribute((T)tag, attrib);
        }

        void ITagFormatter.AcceptElement(SwfTagBase tag, XElement element) {
            AcceptElement((T)tag, element);
        }

        public abstract XElement FormatTag(T tag);
        public abstract void AcceptAttribute(T tag, XAttribute attrib);
        public abstract void AcceptElement(T tag, XElement element);

        #endregion

        protected uint SetFlagsValue(uint flags, uint shiftedBitFlags, bool flag) {
            if (flag) {
                return flags | shiftedBitFlags;
            }
            return flags & (~shiftedBitFlags);
        }

        protected bool ParseBoolFromDigit(XAttribute attrib) {
            switch (attrib.Value) {
                case "1":
                    return true;
                case "0":
                    return false;
                default:
                    throw new FormatException("Invalid attribute value");
            }
        }

        protected SwfRGB ParseRGBFromFirstChild(XElement elem) {
            var colorElem = elem.Element(XName.Get("Color"));
            SwfRGB rgb;
            rgb.Red = byte.Parse(colorElem.Attribute(XName.Get("red")).Value);
            rgb.Green = byte.Parse(colorElem.Attribute(XName.Get("green")).Value);
            rgb.Blue = byte.Parse(colorElem.Attribute(XName.Get("blue")).Value);
            return rgb;
        }

        protected static XElement GetColor(SwfRGB rgb) {
            return new XElement(XName.Get("Color"),
                                new XAttribute(XName.Get("red"), rgb.Red),
                                new XAttribute(XName.Get("green"), rgb.Green),
                                new XAttribute(XName.Get("blue"), rgb.Blue));
        }

        protected static XElement GetTransformXml(SwfMatrix matrix) {
            //TODO: put other fields
            return new XElement(XName.Get("Transform"),
                                new XAttribute(XName.Get("transX"), matrix.TranslateX),
                                new XAttribute(XName.Get("transY"), matrix.TranslateY));
        }

        protected static XElement GetRectangleXml(SwfRect rect) {
            return new XElement(XName.Get("Rectangle"),
                                new XAttribute(XName.Get("left"), rect.XMin),
                                new XAttribute(XName.Get("right"), rect.XMax),
                                new XAttribute(XName.Get("top"), rect.YMin),
                                new XAttribute(XName.Get("bottom"), rect.YMax));
        }

        protected static XElement GetSymbol(SwfSymbolReference symbol) {
            return new XElement(XName.Get("Symbol"),
                                new XAttribute(XName.Get("objectID"), symbol.SymbolID),
                                new XAttribute(XName.Get("name"), symbol.SymbolName));
        }

        protected static XElement GetTextRecordEntryXml(SwfTextRecordEntry entry) {
            if (entry is SwfTextRecordSetupEntry) {
                return GetTextRecordEntryXml((SwfTextRecordSetupEntry)entry);
            }
            if (entry is SwfTextRecordGlyphEntry) {
                return GetTextRecordEntryXml((SwfTextRecordGlyphEntry)entry);
            }
            if (entry is SwfTextRecordEndEntry) {
                return GetTextRecordEntryXml((SwfTextRecordEndEntry)entry);
            }
            throw new InvalidOperationException();
        }

        private static XElement GetTextRecordEntryXml(SwfTextRecordSetupEntry entry) {
            var res = new XElement(XName.Get("TextRecord6"), new XAttribute(XName.Get("isSetup"), "1"));
            if (entry.FontID.HasValue) {
                res.Add(new XAttribute(XName.Get("objectID"), entry.FontID.Value));
            }
            if (entry.MoveX.HasValue) {
                res.Add(new XAttribute(XName.Get("x"), entry.MoveX.Value));
            }
            if (entry.MoveY.HasValue) {
                res.Add(new XAttribute(XName.Get("y"), entry.MoveY.Value));
            }
            if (entry.FontHeight.HasValue) {
                res.Add(new XAttribute(XName.Get("fontHeight"), entry.FontHeight.Value));
            }
            if (entry.RGB.HasValue) {
                res.Add(new XElement(XName.Get("color"), GetColor(entry.RGB.Value)));
            }
            //TODO: other fields
            return res;
        }

        private static XElement GetTextRecordEntryXml(SwfTextRecordGlyphEntry entry) {
            var res = new XElement(XName.Get("TextRecord6"), new XAttribute(XName.Get("isSetup"), "0"));
            res.Add(new XElement(XName.Get("glyphs"), entry.Glyphs.Select(item => GetGlyphXml(item))));
            //TODO: other fields
            return res;
        }

        private static XElement GetTextRecordEntryXml(SwfTextRecordEndEntry entry) {
            var res = new XElement(XName.Get("TextRecord6"), new XAttribute(XName.Get("isSetup"), "0"));
            res.Add(new XElement(XName.Get("glyphs")));
            return res;
        }

        private static XElement GetGlyphXml(SwfTextEntry entry) {
            return new XElement(XName.Get("TextEntry"),
                                new XAttribute(XName.Get("glyph"), entry.Index),
                                new XAttribute(XName.Get("advance"), entry.Advance));
        }


    }


}
