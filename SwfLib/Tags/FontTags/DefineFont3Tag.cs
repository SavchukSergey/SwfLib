using System.Collections.Generic;
using SwfLib.Fonts;

namespace SwfLib.Tags.FontTags {
    /// <summary>
    /// Represents DefineFont3 tag.
    /// </summary>
    public class DefineFont3Tag : FontBaseTag {

        public byte Language { get; set; }

        /// <summary>
        /// Gets or sets the name of the font.
        /// </summary>
        /// <value>
        /// The name of the font.
        /// </value>
        public string FontName { get; set; }

        public bool HasLayout { get; set; }

        public bool ShiftJIS { get; set; }

        public bool SmallText { get; set; }

        public bool ANSI { get; set; }

        public bool WideOffsets { get; set; }

        public bool WideCodes { get; set; }

        public bool Italic { get; set; }

        public bool Bold { get; set; }


        public short Ascent { get; set; }

        public short Descent { get; set; }

        public short Leading { get; set; }

        public readonly IList<Glyph> Glyphs = new List<Glyph>();

        public readonly IList<KerningRecord> KerningRecords = new List<KerningRecord>();

        /// <summary>
        /// Gets swf tag type.
        /// </summary>
        public override SwfTagType TagType {
            get { return SwfTagType.DefineFont3; }
        }

        /// <summary>
        /// Accept visitor.
        /// </summary>
        /// <typeparam name="TArg">Type of argument to be passed to visitor.</typeparam>
        /// <typeparam name="TResult">Type of result.</typeparam>
        /// <param name="visitor">Visitor.</param>
        /// <param name="arg">Argument to be passed to visitor.</param>
        /// <returns></returns>
        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }
    }
}