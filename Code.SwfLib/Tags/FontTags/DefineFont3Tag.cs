namespace Code.SwfLib.Tags.FontTags {
    public class DefineFont3Tag : FontBaseTag {

        public ushort ObjectID;

        //public DefineFont3Attributes Attributes;

        //public byte Language;

        //public string FontName;
        /*
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

        public bool Unicode {
            get {
                return (Attributes & DefineFont3Attributes.Unicode) != 0;
            }
            set {
                if (value) Attributes |= DefineFont3Attributes.Unicode;
                else Attributes &= ~DefineFont3Attributes.Unicode;
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

        public bool Italics {
            get {
                return (Attributes & DefineFont3Attributes.Italics) != 0;
            }
            set {
                if (value) Attributes |= DefineFont3Attributes.Italics;
                else Attributes &= ~DefineFont3Attributes.Italics;
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
        */
        public DefineFont3Glyph[] Glyphs;

        //TODO: serialize other fields
        public byte[] RestData;

        public override SwfTagType TagType {
            get { return SwfTagType.DefineFont3; }
        }

        public override object AcceptVistor(ISwfTagVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}