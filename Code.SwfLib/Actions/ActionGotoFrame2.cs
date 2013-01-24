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

        public bool Play {
            get { return (Flags & 0x80) > 0; }
            set {
                if (value) {
                    Flags = (byte)(Flags | 0x80);
                } else {
                    Flags = (byte)(Flags & 0x7f);
                }
            }
        }

        public byte Reserved {
            get { return (byte)(Flags & 0x3f); }
            set {
                Flags = (byte)((Flags & 0xc0) | (value & 0x3f));
            }
        }

        public ushort SceneBias { get; set; }

        public override TResult AcceptVisitor<TArg, TResult>(IActionVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
