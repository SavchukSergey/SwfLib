using System.Collections.Generic;
using Code.SwfLib.Fonts;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.FontTags;

namespace SwfLib.Tags.FontTags {
    public class DefineFont3Tag : FontBaseTag {

        public byte Language;

        public string FontName;

        public bool HasLayout;

        public bool ShiftJIS;

        public bool SmallText;

        public bool ANSI;

        public bool WideOffsets;

        public bool WideCodes;

        public bool Italic;

        public bool Bold;


        public short Ascent { get; set; }

        public short Descent { get; set; }

        public short Leading { get; set; }

        public readonly IList<Glyph> Glyphs = new List<Glyph>();

        public readonly IList<KerningRecord> KerningRecords = new List<KerningRecord>();

        public override SwfTagType TagType {
            get { return SwfTagType.DefineFont3; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}