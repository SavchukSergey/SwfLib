namespace Code.SwfLib.Tags.FontTags {
    public class DefineFont3Tag : FontBaseTag {

        public DefineFont3Attributes Attributes;

        public byte Language;

        public string FontName;
        
        #region Attributes flags

        public bool HasLayout {
            get {
                return (Attributes & DefineFont3Attributes.HasLayout) != 0;
            }
            set {
                if (value) Attributes |= DefineFont3Attributes.HasLayout;
                else Attributes &= ~DefineFont3Attributes.HasLayout;
            }
        }

        public bool ShiftJIS {
            get {
                return (Attributes & DefineFont3Attributes.ShiftJIS) != 0;
            }
            set {
                if (value) Attributes |= DefineFont3Attributes.ShiftJIS;
                else Attributes &= ~DefineFont3Attributes.ShiftJIS;
            }
        }

        public bool SmallText {
            get {
                return (Attributes & DefineFont3Attributes.SmallText) != 0;
            }
            set {
                if (value) Attributes |= DefineFont3Attributes.SmallText;
                else Attributes &= ~DefineFont3Attributes.SmallText;
            }
        }

        public bool ANSI {
            get {
                return (Attributes & DefineFont3Attributes.ANSI) != 0;
            }
            set {
                if (value) Attributes |= DefineFont3Attributes.ANSI;
                else Attributes &= ~DefineFont3Attributes.ANSI;
            }
        }

        public bool WideOffsets {
            get {
                return (Attributes & DefineFont3Attributes.WideOffsets) != 0;
            }
            set {
                if (value) Attributes |= DefineFont3Attributes.WideOffsets;
                else Attributes &= ~DefineFont3Attributes.WideOffsets;
            }
        }

        public bool WideCodes {
            get {
                return (Attributes & DefineFont3Attributes.WideCodes) != 0;
            }
            set {
                if (value) Attributes |= DefineFont3Attributes.WideCodes;
                else Attributes &= ~DefineFont3Attributes.WideCodes;
            }
        }

        public bool Italic {
            get {
                return (Attributes & DefineFont3Attributes.Italic) != 0;
            }
            set {
                if (value) Attributes |= DefineFont3Attributes.Italic;
                else Attributes &= ~DefineFont3Attributes.Italic;
            }
        }

        public bool Bold {
            get {
                return (Attributes & DefineFont3Attributes.Bold) != 0;
            }
            set {
                if (value) Attributes |= DefineFont3Attributes.Bold;
                else Attributes &= ~DefineFont3Attributes.Bold;
            }
        }

        #endregion

        public DefineFont3Glyph[] Glyphs;

        public override SwfTagType TagType {
            get { return SwfTagType.DefineFont3; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}