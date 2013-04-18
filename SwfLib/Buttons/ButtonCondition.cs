using System.Collections.Generic;
using SwfLib.Actions;

namespace SwfLib.Buttons {
    public class ButtonCondition {

        public bool IdleToOverDown { get; set; }

        public bool OutDownToIdle { get; set; }

        public bool OutDownToOverDown { get; set; }

        public bool OverDownToOutDown { get; set; }

        public bool OverDownToOverUp { get; set; }

        public bool OverUpToOverDown { get; set; }

        public bool OverUpToIdle { get; set; }

        public bool IdleToOverUp { get; set; }

        public byte KeyPress { get; set; }

        public bool OverDownToIdle { get; set; }

        /// <summary>
        /// Gets list of actions.
        /// </summary>
        public readonly IList<ActionBase> Actions = new List<ActionBase>();
    }
}
