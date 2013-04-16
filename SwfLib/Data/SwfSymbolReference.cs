using System.Diagnostics;

namespace SwfLib.Data {
    [DebuggerDisplay("ID: {SymbolID}, Name: {SymbolName}")]
    public class SwfSymbolReference {
        public ushort SymbolID;

        public string SymbolName;
    }
}