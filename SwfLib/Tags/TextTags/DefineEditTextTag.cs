using SwfLib.Data;

namespace SwfLib.Tags.TextTags {
    public class DefineEditTextTag : TextBaseTag {

        public ushort CharacterID { get; set; }

        public SwfRect Bounds { get; set; }

        public bool WordWrap { get; set; }

        public bool Multiline { get; set; }

        public bool Password { get; set; }

        public bool ReadOnly { get; set; }

        public bool HasFont { get; set; }

        public bool HasFontClass { get; set; }

        public bool AutoSize { get; set; }

        public bool HasLayout { get; set; }

        public bool NoSelect { get; set; }

        public bool Border { get; set; }

        public bool WasStatic { get; set; }

        public bool HTML { get; set; }

        public bool UseOutlines { get; set; }

        public ushort FontID { get; set; }

        public string FontClass { get; set; }

        public ushort FontHeight { get; set; }

        public SwfRGBA? TextColor { get; set; }

        public ushort? MaxLength { get; set; }

        //TODO: Use enum
        public byte Align { get; set; }

        public ushort LeftMargin { get; set; }

        public ushort RightMargin { get; set; }

        public ushort Indent { get; set; }

        public short Leading { get; set; }

        public string VariableName { get; set; }

        public string InitialText { get; set; }

        public override SwfTagType TagType {
            get { return SwfTagType.DefineEditText; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}