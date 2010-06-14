using System.Diagnostics;

namespace Code.SwfLib.Data
{
    [DebuggerDisplay("Index = {Index}, Advance = {Advance}")]
    public class SwfTextEntry
    {
        public ulong Index;

        public ulong Advance;

    }
}
