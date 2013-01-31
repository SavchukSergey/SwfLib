using System;
using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class ExportAssetsTagFormatter : TagFormatterBase<ExportAssetsTag> {

        private const string SYMBOLS_TAGS = "symbols";

        protected override void AcceptTagElement(ExportAssetsTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case SYMBOLS_TAGS:
                    ReadSymbols(tag, element);
                    break;
                default:
                    throw new FormatException("Invalid element " + element.Name.LocalName);
            }
        }

        protected override void FormatTagElement(ExportAssetsTag tag, XElement xTag) {
            xTag.Add(new XElement(XName.Get("symbols"), tag.Symbols.Select(FormatSymbol)));
        }

        private static void ReadSymbols(ExportAssetsTag tag, XElement symbolsElement) {
            foreach (var elem in symbolsElement.Elements()) {
                tag.Symbols.Add(ParseSymbol(elem));
            }
        }

        protected static SwfSymbolReference ParseSymbol(XElement element) {
            var symbol = new SwfSymbolReference {
                SymbolID = ushort.Parse(element.Attribute("objectID").Value),
                SymbolName = element.Attribute("name").Value

            };
            return symbol;
        }

        protected static XElement FormatSymbol(SwfSymbolReference symbol) {
            return new XElement(XName.Get("Symbol"),
                                new XAttribute("objectID", symbol.SymbolID),
                                new XAttribute(XName.Get("name"), symbol.SymbolName));
        }

        public override string TagName {
            get { return "Export"; }
        }


    }
}