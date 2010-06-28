using System;
using System.IO;
using Code.SwfLib.Data;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.BitmapTags;
using Code.SwfLib.Tags.ControlTags;
using Code.SwfLib.Tags.DisplayListTags;
using Code.SwfLib.Tags.DynamicTextTags;
using Code.SwfLib.Tags.FontTags;
using Code.SwfLib.Tags.ShapeTags;

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
            tag.CharacterID = reader.ReadUInt16();
            reader.ReadRect(out tag.TextBounds);
            reader.ReadMatrix(out tag.TextMatrix);
            uint glyphBits = reader.ReadByte();
            uint advanceBits = reader.ReadByte();
            tag.TextRecords.Clear();
            foreach (var record in reader.ReadTextRecord(glyphBits, advanceBits)) {
                tag.TextRecords.Add(record);
            }
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

        public static FrameLabelTag ReadFrameLabelTag(SwfTagData tagData) {
            FrameLabelTag tag = new FrameLabelTag { RawData = tagData };
            MemoryStream stream = new MemoryStream(tagData.Data);
            SwfStreamReader reader = new SwfStreamReader(stream);
            tag.Name = reader.ReadString();
            if (!reader.IsEOF) {
                var anchorFlag = reader.ReadByte();
                tag.IsAnchor = anchorFlag != 0;
            }
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
            tag.TextID = reader.ReadUInt16();
            tag.UseFlashType = (byte)reader.ReadUnsignedBits(2);
            tag.GridFit = (byte)reader.ReadUnsignedBits(3);
            tag.ReservedFlags = (byte)reader.ReadUnsignedBits(3);
            tag.Thickness = reader.ReadSingle();
            tag.Sharpness = reader.ReadSingle();
            tag.Reserved = reader.ReadByte();
            return tag;
        }

        public static DefineBitsJPEG2Tag ReadDefineBitsJPEG2Tag(SwfTagData tagData) {
            var tag = new DefineBitsJPEG2Tag { RawData = tagData };
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.CharacterID = reader.ReadUInt16();
            var imageLength = stream.Length - stream.Position;
            tag.ImageData = reader.ReadBytes((int)imageLength);
            return tag;
        }

        public DefineEditTextTag ReadDefineEditTextTag(SwfTagData tagData) {
            var tag = new DefineEditTextTag { RawData = tagData };
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.CharacterID = reader.ReadUInt16();
            reader.ReadRect(out tag.Bounds);
            bool hasText = reader.ReadBit();
            tag.WordWrap = reader.ReadBit();
            tag.Multiline = reader.ReadBit();
            tag.Password = reader.ReadBit();
            tag.ReadOnly = reader.ReadBit();
            bool hasTextColor = reader.ReadBit();
            bool hasMaxLength = reader.ReadBit();
            bool hasFont = reader.ReadBit();
            bool hasFontClass = reader.ReadBit();
            tag.AutoSize = reader.ReadBit();

            //TODO: other fields
            return tag;
        }

        public static DefineFontNameTag ReadDefineFontNameTag(SwfTagData tagData) {
            var tag = new DefineFontNameTag { RawData = tagData };
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.FontId = reader.ReadUInt16();
            tag.FontName = reader.ReadString();
            tag.FontCopyright = reader.ReadString();
            return tag;
        }

        public static DefineFont3Tag ReadDefineFont3Tag(SwfTagData tagData) {
            var tag = new DefineFont3Tag { RawData = tagData };
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.ObjectID = reader.ReadUInt16();
            //TODO: read other fields
            return tag;
        }

        public DefineShapeTag ReadDefineShapeTag(SwfTagData tagData) {
            var tag = new DefineShapeTag { RawData = tagData };
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.ShapeID = reader.ReadUInt16();
            reader.ReadRect(out tag.ShapeBounds);
            reader.ReadToShapeWithStyle(tag.Shapes);
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
        public PlaceObjectTag ReadPlaceObjectTag(SwfTagData tagData) {
            var tag = new PlaceObjectTag { RawData = tagData };
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.CharacterID = reader.ReadUInt16();
            tag.Depth = reader.ReadUInt16();
            reader.ReadMatrix(out tag.Matrix);
            if (!reader.IsEOF) {
                tag.ColorTransform = reader.ReadColorTransformRGB();
            } else {
                tag.ColorTransform = null;
            }
            return tag;
        }

        public PlaceObject2Tag ReadPlaceObject2Tag(SwfTagData tagData) {
            var tag = new PlaceObject2Tag { RawData = tagData };
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            var flags = (PlaceObject2Flags)reader.ReadByte();
            tag.Depth = reader.ReadUInt16();
            //TODO: make non nullable + bit accessor roperties
            if ((flags & PlaceObject2Flags.HasIdRef) > 0) {
                tag.CharacterID = reader.ReadUInt16();
            } else {
                tag.CharacterID = null;
            }
            if ((flags & PlaceObject2Flags.HasMatrix) > 0) {
                SwfMatrix matrix;
                reader.ReadMatrix(out matrix);
                tag.Matrix = matrix;
            } else {
                tag.Matrix = null;
            }
            tag.ColorTransform = (flags & PlaceObject2Flags.HasColorTransform) > 0 ? reader.ReadColorTransformRGB() : (ColorTransformRGB?)null;
            if ((flags & PlaceObject2Flags.HasRatio) > 0) {
                tag.Ratio = reader.ReadUInt16();
            } else {
                tag.Ratio = null;
            }
            tag.Name = (flags & PlaceObject2Flags.HasName) > 0 ? reader.ReadString() : null;
            if ((flags & PlaceObject2Flags.HasClippingDepth) > 0) {
                tag.ClipDepth = reader.ReadUInt16();
            } else {
                tag.ClipDepth = null;
            }
            if ((flags & PlaceObject2Flags.HasActions) > 0) {
                tag.ActionsReserved = reader.ReadUInt16();
                tag.ActionsFlags = _version >= 6 ? reader.ReadUInt32() : reader.ReadUInt16();
                //TODO: read other fields
            }
            //TODO: Read the others fields
            return tag;
        }

        public static RemoveObjectTag ReadRemoveObjectTag(SwfTagData tagData) {
            RemoveObjectTag tag = new RemoveObjectTag { RawData = tagData };
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.CharacterID = reader.ReadUInt16();
            tag.Depth = reader.ReadUInt16();
            return tag;
        }

        public SetBackgroundColorTag ReadSetBackgroundColorTag(SwfTagData tagData) {
            var tag = new SetBackgroundColorTag { RawData = tagData };
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            reader.ReadRGB(out tag.Color);
            return tag;
        }

        public ShowFrameTag ReadShowFrameTag(SwfTagData data) {
            return new ShowFrameTag { RawData = data };
        }

        public SwfTagBase ReadTag(SwfStreamReader reader) {
            var tagData = reader.ReadTagData();
            switch (tagData.Type) {
                //case SwfTagType.CSMTextSettings:
                //    return ReadCSMTextSettingsTag(tagData);
                case SwfTagType.DefineBitsJPEG2:
                    return ReadDefineBitsJPEG2Tag(tagData);
                case SwfTagType.DefineEditText:
                    return ReadDefineEditTextTag(tagData);
                case SwfTagType.DefineFontName:
                    return ReadDefineFontNameTag(tagData);
                //case SwfTagType.DefineFont3:
                //    return ReadDefineFont3Tag(tagData);
                case SwfTagType.DefineShape:
                    return ReadDefineShapeTag(tagData);
                //case SwfTagType.DefineSprite:
                //    return ReadDefineSpriteTag(tagData);
                case SwfTagType.DefineText:
                    return ReadDefineTextTag(tagData);
                case SwfTagType.End:
                    return ReadEndTag(tagData);
                case SwfTagType.Export:
                    return ReadExportTag(tagData);
                case SwfTagType.FrameLabel:
                    return ReadFrameLabelTag(tagData);
                case SwfTagType.PlaceObject:
                    return ReadPlaceObjectTag(tagData);
                //case SwfTagType.PlaceObject2:
                //    return ReadPlaceObject2Tag(tagData);
                case SwfTagType.ShowFrame:
                    return ReadShowFrameTag(tagData);
                case SwfTagType.FileAttributes:
                    return ReadFileAttributesTag(tagData);
                case SwfTagType.MetaData:
                    return ReadMetadataTag(tagData);
                case SwfTagType.RemoveObject:
                    return ReadRemoveObjectTag(tagData);
                case SwfTagType.SetBackgroundColor:
                    return ReadSetBackgroundColorTag(tagData);
                default:
                    return ReadUnknownTag(tagData);
            }

        }

    }
}