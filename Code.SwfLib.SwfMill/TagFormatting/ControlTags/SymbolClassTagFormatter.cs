using System;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class SymbolClassTagFormatter : TagFormatterBase<SymbolClassTag> {
        protected override XElement FormatTagElement(SymbolClassTag tag) {
            var res = new XElement(SwfTagNameMapping.SYMBOL_CLASS_TAG);
            var xSymbols = new XElement("symbols");
            foreach (var symbolRef in tag.References) {
                var xSymbol = new XElement("Symbol");
                xSymbol.Add(new XAttribute(OBJECT_ID_ATTRIB, symbolRef.SymbolID));
                xSymbol.Add(new XAttribute(NAME_ATTRIB, symbolRef.SymbolName));
                xSymbols.Add(xSymbol);
            }
            res.Add(xSymbols);
            return res;
        }

        protected override void AcceptTagAttribute(SymbolClassTag tag, XAttribute attrib) {
            throw new FormatException("Invalid attribute " + attrib.Name.LocalName);
        }

        protected override void AcceptTagElement(SymbolClassTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "symbols":
                    foreach (var xSymbol in element.Elements("Symbol")) {
                        tag.References.Add(ParseReference(xSymbol));
                    }
                    break;
            }
        }

        protected SwfSymbolReference ParseReference(XElement xSymbol) {
            return new SwfSymbolReference {
                SymbolID = ushort.Parse(xSymbol.Attribute(OBJECT_ID_ATTRIB).Value),
                SymbolName = xSymbol.Attribute(NAME_ATTRIB).Value
            };
        }
    }
}
