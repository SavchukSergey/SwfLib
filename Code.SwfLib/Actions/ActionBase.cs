using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code.SwfLib.Actions;

namespace Code.SwfLib.Data.Actions {
    public abstract class ActionBase {

        public abstract ActionCode ActionCode { get; }

        public abstract object AcceptVisitor(IActionVisitor visitor);

    }
}
