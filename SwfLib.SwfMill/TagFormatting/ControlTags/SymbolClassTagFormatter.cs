using System.Xml.Linq;
using SwfLib.Data;
using SwfLib.SwfMill.Utils;
using SwfLib.Tags.ControlTags;

namespace SwfLib.SwfMill.TagFormatting.ControlTags {
    /// <summary>
    /// Represents SymbolClassTag xml formatter.
    /// </summary>
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

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public override string TagName {
            get { return "SymbolClass"; }
        }

    }
}
