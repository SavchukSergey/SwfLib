using SwfLib.Tags.FontTags;

namespace SwfLib.SwfMill.TagFormatting.FontTags {
    public abstract class DefineFontBaseFormatter<T> : TagFormatterBase<T> where T : FontBaseTag {

        protected override ushort? GetObjectID(T tag) {
            return tag.FontID;
        }

        protected override void SetObjectID(T tag, ushort value) {
            tag.FontID = value;
        }
    }
}
