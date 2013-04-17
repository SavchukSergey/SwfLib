namespace SwfLib.Actions {
    public struct ActionPushItem {

        public ActionPushItemType Type { get; set; }

        public string String { get; set; }

        public byte Register { get; set; }

        public float Float { get; set; }

        public byte Boolean { get; set; }

        public double Double { get; set; }

        public int Integer { get; set; }

        public byte Constant8 { get; set; }

        public ushort Constant16 { get; set; }

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
