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

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
