namespace Code.SwfLib.Tags {
    public static class TagStreamExt {

        public static SwfTagData ReadTagData(this ISwfStreamReader reader) {
            var typeAndSize = reader.ReadUInt16();
            var type = (SwfTagType)(typeAndSize >> 6);
            var shortSize = typeAndSize & 0x3f;
            var size = shortSize < 0x3f ? shortSize : reader.ReadInt32();
            var tagData = reader.ReadBytes(size);
            return new SwfTagData { Type = type, Data = tagData };
        }

    }
}
