using System;
using System.IO;
using Code.SwfLib.Data;
using Code.SwfLib.Tags;

namespace Code.SwfLib {
    public class SwfTagReader {
        private readonly ushort _version;

        public SwfTagReader(ushort version) {
            _version = version;
        }

        public DefineSpriteTag ReadDefineSpriteTag(SwfTagData tagData) {
            var tag = new DefineSpriteTag { RawData = tagData };
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.SpriteID = reader.ReadUInt16();
            tag.FramesCount = reader.ReadUInt16();
            SwfTagBase subTag;
            do {
                subTag = ReadDefineSpriteSubTag(reader);
                if (subTag != null) tag.Tags.Add(subTag);
            } while (subTag != null && subTag.RawData.Type != SwfTagType.End);
            return tag;
        }

        public SwfTagBase ReadDefineSpriteSubTag(SwfStreamReader reader) {
            var tag = ReadTag(reader);
            //TODO: Check allowed for define sprite types
            return tag;
        }

        public DefineTextTag ReadDefineTextTag(SwfTagData tagData) {
            var tag = new DefineTextTag { RawData = tagData };
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.TextID = reader.ReadUInt16();
            tag.Rectangle = reader.ReadRect();
            tag.Matrix = reader.ReadMatrix();
            tag.GlyphBits = reader.ReadByte();
            tag.AdvanceBits = reader.ReadByte();
            tag.Records = reader.ReadTextRecord(tag.GlyphBits, tag.AdvanceBits);
            return tag;
        }

        public static SymbolClassTag ReadSymbolClassTag(byte[] tagData) {
            SymbolClassTag tag = new SymbolClassTag();
            MemoryStream stream = new MemoryStream(tagData);
            SwfStreamReader reader = new SwfStreamReader(stream);
            ushort count = reader.ReadUInt16();
            tag.References = new SwfSymbolReference[count];
            for (int i = 0; i < count; i++) {
                SwfSymbolReference reference = new SwfSymbolReference();
                reference.SymbolID = reader.ReadUInt16();
                reference.SymbolName = reader.ReadString();
                tag.References[i] = reference;
            }
            return tag;
        }

        public static DoABCTag ReadDoAbcTag(byte[] tagData) {
            DoABCTag tag = new DoABCTag();
            MemoryStream stream = new MemoryStream(tagData);
            SwfStreamReader reader = new SwfStreamReader(stream);
            tag.ABCData = reader.ReadBytes((int)(stream.Length - stream.Position));
            return tag;
        }

        public static DoABCDefineTag ReadDoAbcDefineTag(byte[] tagData) {
            DoABCDefineTag tag = new DoABCDefineTag();
            MemoryStream stream = new MemoryStream(tagData);
            SwfStreamReader reader = new SwfStreamReader(stream);
            tag.Flags = reader.ReadUInt32();
            tag.Name = reader.ReadString();
            tag.ABCData = reader.ReadBytes((int)(stream.Length - stream.Position));
            return tag;
        }

        public static ProtectDebug2Tag ReadProtectedDebug2Tag(byte[] tagData) {
            return new ProtectDebug2Tag { Data = tagData };
        }

        public static DebugIDTag ReadDebugIDTag(byte[] tagData) {
            return new DebugIDTag { Data = tagData };
        }

        public static ScriptLimitsTag ReadScriptLimitsTag(byte[] tagData) {
            ScriptLimitsTag tag = new ScriptLimitsTag();
            MemoryStream stream = new MemoryStream(tagData);
            SwfStreamReader reader = new SwfStreamReader(stream);
            tag.MaxRecursionDepth = reader.ReadUInt16();
            tag.ScriptTimeoutSeconds = reader.ReadUInt16();
            return tag;
        }

        public static ProductInfoTag ReadProductInfoTag(byte[] tagData) {
            ProductInfoTag tag = new ProductInfoTag();
            MemoryStream stream = new MemoryStream(tagData);
            SwfStreamReader reader = new SwfStreamReader(stream);
            tag.ProductId = reader.ReadUInt32();
            tag.Edition = reader.ReadUInt32();
            tag.MajorVersion = reader.ReadByte();
            tag.MinorVersion = reader.ReadByte();
            tag.BuildNumber = reader.ReadUInt64();
            tag.CompilationDate = reader.ReadUInt64();
            return tag;
        }

        public static FrameLabelTag ReadFrameLabelTag(byte[] tagData) {
            FrameLabelTag tag = new FrameLabelTag();
            MemoryStream stream = new MemoryStream(tagData);
            SwfStreamReader reader = new SwfStreamReader(stream);
            tag.Name = reader.ReadString();
            return tag;
        }

        public static UnknownTag ReadUnknownTag(SwfTagData data) {
            return new UnknownTag { RawData = data };
        }

        public EndTag ReadEndTag(SwfTagData data) {
            return new EndTag { RawData = data };
        }

        public FileAttributesTag ReadFileAttributesTag(SwfTagData tagData) {
            var tag = new FileAttributesTag { RawData = tagData };
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.Attributes = (SwfFileAttributes)reader.ReadUInt32();
            return tag;
        }

        public MetadataTag ReadMetadataTag(SwfTagData tagData) {
            var tag = new MetadataTag { RawData = tagData };
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.Metadata = reader.ReadString();
            return tag;
        }

        public static CSMTextSettingsTag ReadCSMTextSettingsTag(SwfTagData tagData) {
            var tag = new CSMTextSettingsTag { RawData = tagData };
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.TextId = reader.ReadUInt16();
            var flags = reader.ReadByte();
            tag.UseType = (byte)((flags >> 6) & 0x03);
            tag.GridFit = (byte)((flags >> 3) & 0x07);
            tag.ReservedFlags = (byte)((flags >> 0) & 0x07);
            tag.Thickness = reader.ReadSingle();
            tag.Sharpness = reader.ReadSingle();
            tag.Reserved = reader.ReadByte();
            return tag;
        }

        public static DefineBitsJPEG2Tag ReadDefineBitsJPEG2Tag(SwfTagData tagData)
        {
            var tag = new DefineBitsJPEG2Tag { RawData = tagData };
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.ObjectID = reader.ReadUInt16();
            //TODO: Read other fields
            tag.ImageData = new byte[] {0};
            return tag;
        }

        public static DefineFontNameTag ReadDefineFontNameTag(SwfTagData tagData)
        {
            var tag = new DefineFontNameTag { RawData = tagData };
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.FontNameId = reader.ReadUInt16();
            tag.DisplayName = reader.ReadString();
            tag.Copyright = reader.ReadString();
            return tag;
        }

        public static DefineFont3Tag ReadDefineFont3Tag(SwfTagData tagData)
        {
            var tag = new DefineFont3Tag { RawData = tagData };
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.ObjectID = reader.ReadUInt16();
            //TODO: read other fields
            return tag;
        }

        public ExportTag ReadExportTag(SwfTagData tagData) {
            var tag = new ExportTag { RawData = tagData };
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            var count = reader.ReadUInt16();
            for (var i = 0; i < count; i++) {
                var symbolRef = reader.ReadSymbolReference();
                tag.Symbols.Add(symbolRef);
            }
            return tag;
        }

        public PlaceObject2Tag ReadPlaceObject2Tag(SwfTagData tagData) {
            var tag = new PlaceObject2Tag { RawData = tagData };
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            var flags = (PlaceObject2Flags)reader.ReadByte();
            tag.Depth = reader.ReadUInt16();
            if ((flags & PlaceObject2Flags.HasIdRef) > 0) {
                tag.ObjectID = reader.ReadUInt16();
            } else {
                tag.ObjectID = null;
            }
            tag.Matrix = (flags & PlaceObject2Flags.HasMatrix) > 0 ? reader.ReadMatrix() : null;
            tag.ColorTransform = (flags & PlaceObject2Flags.HasColorTransform) > 0 ? reader.ReadColorTransform() : null;
            if ((flags & PlaceObject2Flags.HasMorphPosition) > 0) {
                tag.MorphPosition = reader.ReadUInt16();
            } else {
                tag.MorphPosition = null;
            }
            tag.Name = (flags & PlaceObject2Flags.HasName) > 0 ? reader.ReadString() : null;
            if ((flags & PlaceObject2Flags.HasClippingDepth) > 0) {
                tag.ClippingDepth = reader.ReadUInt16();
            } else {
                tag.ClippingDepth = null;
            }
            if ((flags & PlaceObject2Flags.HasActions) > 0) {
                tag.ActionsReserved = reader.ReadUInt16();
                tag.ActionsFlags = _version >= 6 ? reader.ReadUInt32() : reader.ReadUInt16();
            }
            //TODO: Read the others fields
            return tag;
        }

        public SetBackgroundColorTag ReadSetBackgroundColorTag(SwfTagData tagData) {
            var tag = new SetBackgroundColorTag { RawData = tagData };
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.Color = reader.ReadRGB();
            return tag;
        }

        public ShowFrameTag ReadShowFrameTag(SwfTagData data)
        {
            return new ShowFrameTag { RawData = data };
        }

        public SwfTagBase ReadTag(SwfStreamReader reader) {
            var tagData = reader.ReadTagData();
            switch (tagData.Type) {
                case SwfTagType.CSMTextSettings:
                    return ReadCSMTextSettingsTag(tagData);
                case SwfTagType.DefineBitsJPEG2:
                    return ReadDefineBitsJPEG2Tag(tagData);
                case SwfTagType.DefineFontName:
                    return ReadDefineFontNameTag(tagData);
                case SwfTagType.DefineFont3:
                    return ReadDefineFont3Tag(tagData);
                case SwfTagType.DefineSprite:
                    return ReadDefineSpriteTag(tagData);
                case SwfTagType.DefineText:
                    return ReadDefineTextTag(tagData);
                case SwfTagType.End:
                    return ReadEndTag(tagData);
                case SwfTagType.Export:
                    return ReadExportTag(tagData);
                case SwfTagType.PlaceObject2:
                    return ReadPlaceObject2Tag(tagData);
                case SwfTagType.ShowFrame:
                    return ReadShowFrameTag(tagData);
                case SwfTagType.FileAttributes:
                    return ReadFileAttributesTag(tagData);
                case SwfTagType.MetaData:
                    return ReadMetadataTag(tagData);
                case SwfTagType.SetBackgroundColor:
                    return ReadSetBackgroundColorTag(tagData);
                default:
                    return ReadUnknownTag(tagData);
            }

        }
    }
}