using SwfLib.Tags.BitmapTags;

namespace SwfLib.SwfMill.TagFormatting.BitmapTags {
    public abstract class DefineBitmapBaseTagFormatter<T> : TagFormatterBase<T> where T : BitmapBaseTag {

        protected override ushort? GetObjectID(T tag) {
            return tag.CharacterID;
        }

        protected override void SetObjectID(T tag, ushort value) {
            tag.CharacterID = value;
        }
    }
}
