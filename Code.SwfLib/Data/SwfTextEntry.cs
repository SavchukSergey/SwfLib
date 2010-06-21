using System.Diagnostics;

namespace Code.SwfLib.Data
{
    [DebuggerDisplay("Index = {Index}, Advance = {Advance}")]
    public class SwfTextEntry
    {
        public uint Index;

        public uint Advance;

    }
}
