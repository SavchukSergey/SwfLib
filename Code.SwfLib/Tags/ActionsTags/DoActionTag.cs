using System.Collections.Generic;
using Code.SwfLib.Data.Actions;

namespace Code.SwfLib.Tags.Actions {
    public class DoActionTag : SwfTagBase {

        public readonly IList<ActionBase> ActionRecords = new List<ActionBase>();

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }

        public override SwfTagType TagType {
            get {
                return SwfTagType.DoAction;
            }
        }
    }
}