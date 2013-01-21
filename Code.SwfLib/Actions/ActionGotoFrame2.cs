using Code.SwfLib.Data.Actions;

namespace Code.SwfLib.Actions {
    public class ActionGotoFrame2 : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.GotoFrame2; }
        }

        public byte Flags { get; set; }

        public bool SceneBiasFlag {
            get { return (Flags & 0x40) > 0; }
            set {
                if (value) {
                    Flags = (byte)(Flags | 0x40);
                } else {
                    Flags = (byte)(Flags & 0xbf);
                }
            }
        }

        public ushort SceneBias { get; set; }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
