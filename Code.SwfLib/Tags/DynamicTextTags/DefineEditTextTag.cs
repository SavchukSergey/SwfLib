using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.DynamicTextTags
{
    public class DefineEditTextTag : SwfTagBase
    {

        public ushort ObjectID;

        public SwfRect Bounds;

        public bool HasText
        {
            get { return !string.IsNullOrEmpty(InitialText); }
        }

        public bool WordWrap;

        public bool Multiline;

        public bool Password;

        public bool ReadOnly;

        public bool HasTextColor
        {
            get { return TextColor.HasValue; }
        }

        public bool HasMaxLength
        {
            get { return MaxLength.HasValue; }
        }

        public bool HasFont
        {
            get { return FontID.HasValue; }
        }

        public bool HasFontClass
        {
            get { return !string.IsNullOrEmpty(FontClass); }
        }

        public ushort? FontID;

        public string FontClass;

        public SwfRGBA? TextColor;

        public ushort? MaxLength;

        public string InitialText;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}