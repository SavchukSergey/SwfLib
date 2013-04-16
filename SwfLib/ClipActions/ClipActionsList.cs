using System.Collections.Generic;
using SwfLib.ClipActions;

namespace Code.SwfLib.ClipActions {
    public class ClipActionsList {

        public ushort Reserved;

        //TODO: this is calculated field actually
        public ClipEventFlags Flags;

        public readonly IList<ClipActionRecord> Records = new List<ClipActionRecord>();
    }
}
