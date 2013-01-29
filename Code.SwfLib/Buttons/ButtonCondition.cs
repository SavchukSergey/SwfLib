using System.Collections.Generic;
using Code.SwfLib.Actions;

namespace Code.SwfLib.Buttons {
    public class ButtonCondition {

        public bool IdleToOverDown;

        public bool OutDownToIdle;

        public bool OutDownToOverDown;

        public bool OverDownToOutDown;

        public bool OverDownToOverUp;

        public bool OverUpToOverDown;

        public bool OverUpToIdle;

        public bool IdleToOverUp;

        public byte KeyPress;

        public bool OverDownToIdle;

        public readonly IList<ActionBase> Actions = new List<ActionBase>();
    }
}
