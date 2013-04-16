using SwfLib.Tags.ButtonTags;

namespace SwfLib.SwfMill.TagFormatting.ButtonTags {
    public abstract class DefineButtonBaseTagFormatter<T> : TagFormatterBase<T> where T : DefineButtonBaseTag {

        protected override ushort? GetObjectID(T tag) {
            return tag.ButtonID;
        }

        protected override void SetObjectID(T tag, ushort value) {
            tag.ButtonID = value;
        }

    }
}
