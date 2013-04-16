namespace Code.SwfLib.Actions {
    public struct ActionPushItem {

        public ActionPushItemType Type;

        public string String;

        public byte Register;

        public float Float;

        public byte Boolean;

        public double Double;

        public int Integer;

        public byte Constant8;

        public ushort Constant16;

        public override string ToString() {
            switch (Type) {
                case ActionPushItemType.String:
                    return "String: " + String;
                default:
                    return base.ToString();
            }
        }
    }
}
