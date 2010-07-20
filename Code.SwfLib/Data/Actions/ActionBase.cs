using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.SwfLib.Data.Actions {
    public abstract class ActionBase {

        public abstract ActionCode ActionCode { get; }

        public abstract object AcceptVisitor(IActionVisitor visitor);

    }
}
