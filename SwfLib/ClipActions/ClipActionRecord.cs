using System.Collections.Generic;
using Code.SwfLib.Actions;
using SwfLib.Actions;

namespace Code.SwfLib.ClipActions {
    public class ClipActionRecord {

        public ClipEventFlags Flags;

        public byte KeyCode;

        public readonly IList<ActionBase> Actions = new List<ActionBase>();

    }
}
