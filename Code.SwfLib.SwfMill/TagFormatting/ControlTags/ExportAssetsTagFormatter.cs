﻿using System;
using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class ExportAssetsTagFormatter : TagFormatterBase<ExportAssetsTag> {

        private const string SYMBOLS_TAGS = "symbols";

        protected override void AcceptTagAttribute(ExportAssetsTag tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                default:
                    throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
            }
        }

        protected override void AcceptTagElement(ExportAssetsTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case SYMBOLS_TAGS:
                    ReadSymbols(tag, element);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override XElement FormatTagElement(ExportAssetsTag tag) {
            return new XElement(XName.Get(SwfTagNameMapping.EXPORT_TAG),
                                new XElement(XName.Get("symbols"), tag.Symbols.Select(item => FormatSymbol(item))));
        }

        private static void ReadSymbols(ExportAssetsTag tag, XElement symbolsElement) {
            foreach (var elem in symbolsElement.Elements()) {
                tag.Symbols.Add(ParseSymbol(elem));
            }
        }

        protected static SwfSymbolReference ParseSymbol(XElement element) {
            var symbol = new SwfSymbolReference {
                SymbolID = ushort.Parse(element.Attribute(OBJECT_ID_ATTRIB).Value),
                SymbolName = element.Attribute("name").Value

            };
            return symbol;
        }

        protected static XElement FormatSymbol(SwfSymbolReference symbol) {
            return new XElement(XName.Get("Symbol"),
                                new XAttribute(XName.Get("objectID"), symbol.SymbolID),
                                new XAttribute(XName.Get("name"), symbol.SymbolName));
        }



    }
}