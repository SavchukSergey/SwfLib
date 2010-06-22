using System.Collections.Generic;

namespace Code.SwfLib.Data.Text {
    public class TextRecord {

        public ushort? FontID;

        public SwfRGB? TextColor;

        public short? XOffset;

        public short? YOffset;

        public ushort? TextHeight;

        public TextRecordFlags Flags {
            get {
                TextRecordFlags flags = 0;
                if (FontID.HasValue) flags |= TextRecordFlags.HasFont;
                if (TextColor.HasValue) flags |= TextRecordFlags.HasColor;
                if (YOffset.HasValue) flags |= TextRecordFlags.HasYOffset;
                if (XOffset.HasValue) flags |= TextRecordFlags.HasXOffset;
                if (flags != 0 || Glyphs.Count > 0) flags |= TextRecordFlags.IsSetup;
                return flags;
            }
        }

        public bool HasFont {
            get {
                return FontID.HasValue;
            }
        }

        public bool HasColor {
            get {
                return TextColor.HasValue;
            }
        }

        public bool HasYOffset {
            get {
                return YOffset.HasValue;
            }
        }

        public bool HasXOffset {
            get {
                return XOffset.HasValue;
            }
        }
        
        public readonly IList<GlyphEntry> Glyphs = new List<GlyphEntry>();

    }
}