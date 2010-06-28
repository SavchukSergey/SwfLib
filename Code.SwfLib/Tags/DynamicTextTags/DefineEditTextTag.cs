using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.DynamicTextTags {
    public class DefineEditTextTag : SwfTagBase {

        public ushort CharacterID;

        public SwfRect Bounds;

        public bool HasText;

        public bool WordWrap;

        public bool Multiline;

        public bool Password;

        public bool ReadOnly;

        public bool HasTextColor;

        public bool HasMaxLength;

        public bool HasFont;

        public bool HasFontClass;

        public bool AutoSize;

        public bool HasLayout;

        public bool NoSelect;

        public bool Border;

        public bool WasStatic;

        public bool HTML;

        public bool UseOutlines;

        public ushort FontID;

        public string FontClass;

        public ushort FontHeight;

        public SwfRGBA TextColor;

        public ushort MaxLength;

        //TODO: Use enum
        public byte Align;

        public ushort LeftMargin;

        public ushort RightMargin;

        public ushort Indent;

        public short Leading;

        public string VariableName;

        public string InitialText;

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}