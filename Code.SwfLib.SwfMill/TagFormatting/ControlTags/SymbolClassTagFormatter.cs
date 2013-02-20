using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.SwfMill.Utils;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class SymbolClassTagFormatter : TagFormatterBase<SymbolClassTag> {
        protected override void FormatTagElement(SymbolClassTag tag, XElement xTag) {
            var xSymbols = new XElement("symbols");
            foreach (var symbolRef in tag.References) {
                var xSymbol = new XElement("Symbol");
                xSymbol.Add(new XAttribute("objectID", symbolRef.SymbolID));
                xSymbol.Add(new XAttribute(NAME_ATTRIB, symbolRef.SymbolName));
                xSymbols.Add(xSymbol);
            }
            xTag.Add(xSymbols);
        }

        protected override bool AcceptTagElement(SymbolClassTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "symbols":
                    foreach (var xSymbol in element.Elements("Symbol")) {
                        tag.References.Add(ParseReference(xSymbol));
                    }
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected SwfSymbolReference ParseReference(XElement xSymbol) {
            return new SwfSymbolReference {
                SymbolID = xSymbol.RequiredUShortAttribute("objectID"),
                SymbolName = xSymbol.RequiredStringAttribute(NAME_ATTRIB)
            };
        }

        public override string TagName {
            get { return "SymbolClass"; }
        }

    }
}
