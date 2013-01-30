using System.Collections.Generic;

namespace Code.SwfLib.ClipActions {
    public class ClipActionsList {

        public ushort Reserved;

        public ClipEventFlags Flags;

        public readonly IList<ClipActionRecord> Records = new List<ClipActionRecord>();
    }
}
