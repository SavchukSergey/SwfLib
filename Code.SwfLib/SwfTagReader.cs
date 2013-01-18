using System.IO;
using Code.SwfLib.Data;
using Code.SwfLib.Data.Actions;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.ActionsTags;
using Code.SwfLib.Tags.ControlTags;
using Code.SwfLib.Tags.DisplayListTags;
using Code.SwfLib.Tags.FontTags;

namespace Code.SwfLib {
    public class SwfTagReader {

        private readonly SwfFile _file;

        public SwfTagReader(SwfFile file) {
            _file = file;
        }

        public DoActionTag ReadDoActionTag(SwfTagData tagData) {
            var tag = new DoActionTag();
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            ActionBase action = null;
            do {
                action = reader.ReadAction();
                if (action != null) {
                    tag.ActionRecords.Add(action);
                }
            } while (action != null);
            return tag;
        }

        public DoInitActionTag ReadDoInitActionTag(SwfTagData tagData) {
            var tag = new DoInitActionTag();
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.SpriteId = reader.ReadUInt16();
            tag.RestData = reader.ReadRest();
            return tag;
        }

        public DefineFontInfoTag ReadDefineFontInfoTag(SwfTagData tagData) {
            var tag = new DefineFontInfoTag();
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.FontId = reader.ReadUInt16();
            tag.RestData = reader.ReadRest();
            return tag;
        }

        public static SymbolClassTag ReadSymbolClassTag(byte[] tagData) {
            var tag = new SymbolClassTag();
            var stream = new MemoryStream(tagData);
            var reader = new SwfStreamReader(stream);
            ushort count = reader.ReadUInt16();
            tag.References = new SwfSymbolReference[count];
            for (int i = 0; i < count; i++) {
                var reference = new SwfSymbolReference();
                reference.SymbolID = reader.ReadUInt16();
                reference.SymbolName = reader.ReadString();
                tag.References[i] = reference;
            }
            return tag;
        }


        #region Control Tags

        public static EnableDebugger2Tag ReadEnableDebugger2Tag(byte[] tagData) {
            return new EnableDebugger2Tag { Data = tagData };
        }

        #endregion

        #region Actions Tags

        public static DoABCTag ReadDoAbcTag(byte[] tagData) {
            var tag = new DoABCTag();
            var stream = new MemoryStream(tagData);
            var reader = new SwfStreamReader(stream);
            tag.Flags = reader.ReadUInt32();
            tag.Name = reader.ReadString();
            tag.ABCData = reader.ReadBytes((int)(stream.Length - stream.Position));
            return tag;
        }

        public static DoABCDefineTag ReadDoAbcDefineTag(byte[] tagData) {
            var tag = new DoABCDefineTag();
            var stream = new MemoryStream(tagData);
            var reader = new SwfStreamReader(stream);
            tag.ABCData = reader.ReadBytes((int)(stream.Length - stream.Position));
            return tag;
        }

        #endregion

        public static DebugIDTag ReadDebugIDTag(byte[] tagData) {
            return new DebugIDTag { Data = tagData };
        }

        public static ProductInfoTag ReadProductInfoTag(byte[] tagData) {
            var tag = new ProductInfoTag();
            var stream = new MemoryStream(tagData);
            var reader = new SwfStreamReader(stream);
            tag.ProductId = reader.ReadUInt32();
            tag.Edition = reader.ReadUInt32();
            tag.MajorVersion = reader.ReadByte();
            tag.MinorVersion = reader.ReadByte();
            tag.BuildNumber = reader.ReadUInt64();
            tag.CompilationDate = reader.ReadUInt64();
            return tag;
        }

        public static UnknownTag ReadUnknownTag(SwfTagData tagData) {
            var tag = new UnknownTag { Data = tagData.Data };
            tag.SetTagType(tagData.Type);
            return tag;
        }

        public static DefineFontNameTag ReadDefineFontNameTag(SwfTagData tagData) {
            var tag = new DefineFontNameTag();
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.FontId = reader.ReadUInt16();
            tag.FontName = reader.ReadString();
            tag.FontCopyright = reader.ReadString();
            return tag;
        }

        public static RemoveObjectTag ReadRemoveObjectTag(SwfTagData tagData) {
            var tag = new RemoveObjectTag();
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.CharacterID = reader.ReadUInt16();
            tag.Depth = reader.ReadUInt16();
            return tag;
        }

        public SwfTagBase ReadTag(SwfStreamReader reader) {
            var tagData = reader.ReadTagData();
            var ser = new SwfTagDeserializer(_file);
            return ser.ReadTag(tagData);
            switch (tagData.Type) {
                case SwfTagType.DefineFontName:
                    return ReadDefineFontNameTag(tagData);
                case SwfTagType.DefineFontInfo:
                    return ReadDefineFontInfoTag(tagData);
                case SwfTagType.DoInitAction:
                    return ReadDoInitActionTag(tagData);
                case SwfTagType.DoAction:
                    return ReadDoActionTag(tagData);
                case SwfTagType.RemoveObject:
                    return ReadRemoveObjectTag(tagData);
                default:
                    return ReadUnknownTag(tagData);
            }

        }

    }
}