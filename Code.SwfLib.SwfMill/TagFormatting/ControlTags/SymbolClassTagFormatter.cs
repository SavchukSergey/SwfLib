using System;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class SymbolClassTagFormatter : TagFormatterBase<SymbolClassTag> {
        protected override XElement FormatTagElement(SymbolClassTag tag, XElement xTag) {
            var xSymbols = new XElement("symbols");
            foreach (var symbolRef in tag.References) {
                var xSymbol = new XElement("Symbol");
                xSymbol.Add(new XAttribute("objectID", symbolRef.SymbolID));
                xSymbol.Add(new XAttribute(NAME_ATTRIB, symbolRef.SymbolName));
                xSymbols.Add(xSymbol);
            }
            xTag.Add(xSymbols);
            return xTag;
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
                SymbolID = ushort.Parse(xSymbol.Attribute("objectID").Value),
                SymbolName = xSymbol.Attribute(NAME_ATTRIB).Value
            };
        }

        protected override string TagName {
            get { return "SymbolClass"; }
        }

    }
}
