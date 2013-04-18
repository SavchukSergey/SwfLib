using SwfLib.Tags.FontTags;

namespace SwfLib.SwfMill.TagFormatting.FontTags {
    /// <summary>
    /// Represents base xml formatter for DefineFont tags.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DefineFontBaseFormatter<T> : TagFormatterBase<T> where T : FontBaseTag {

        protected override ushort? GetObjectID(T tag) {
            return tag.FontID;
        }

        protected override void SetObjectID(T tag, ushort value) {
            tag.FontID = value;
        }
    }
}
