using System;
using System.IO;
using System.Linq;
using System.Text;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.ActionsTags;
using Code.SwfLib.Tags.BitmapTags;
using Code.SwfLib.Tags.ButtonTags;
using Code.SwfLib.Tags.ControlTags;
using Code.SwfLib.Tags.DisplayListTags;
using Code.SwfLib.Tags.FontTags;
using Code.SwfLib.Tags.ShapeTags;
using Code.SwfLib.Tags.TextTags;

namespace Code.SwfLib {
    public class SwfTagDeserializer : ISwfTagVisitor<SwfTagData, SwfTagBase> {
        private readonly SwfFile _file;
        private readonly SwfTagsFactory _factory = new SwfTagsFactory();

        public SwfTagDeserializer(SwfFile file) {
            _file = file;
        }

        public SwfTagBase ReadTag(SwfTagData data) {
            var type = data.Type;
            var tag = _factory.Create(type);
            return tag.AcceptVistor(this, data);
        }

        public T ReadTag<T>(SwfTagData data) where T : SwfTagBase {
            return (T)ReadTag(data);
        }

        public SwfFile SwfFile { get { return _file; } }

        #region Old

        public object Visit(CSMTextSettingsTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(DefineButton2Tag tag) {
            throw new NotImplementedException();
        }

        public object Visit(DefineFontInfoTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(DefineFontNameTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(DefineShapeTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(DefineShape3Tag tag) {
            throw new NotImplementedException();
        }

        public object Visit(DefineTextTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(DoActionTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(DoInitActionTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(FrameLabelTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(PlaceObjectTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(PlaceObject3Tag tag) {
            throw new NotImplementedException();
        }

        public object Visit(RemoveObjectTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(RemoveObject2Tag tag) {
            throw new NotImplementedException();
        }

        public object Visit(SwfTagBase tag) {
            throw new NotImplementedException();
        }

        public object Visit(UnknownTag tag) {
            throw new NotImplementedException();
        }

        #endregion

        #region Display list tags

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(PlaceObjectTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(PlaceObject2Tag tag, SwfTagData tagData) {
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.HasClipActions = reader.ReadBit(); //TODO: Check swf version
            tag.HasClipDepth = reader.ReadBit();
            tag.HasName = reader.ReadBit();
            tag.HasRatio = reader.ReadBit();
            tag.HasColorTransform = reader.ReadBit();
            tag.HasMatrix = reader.ReadBit();
            tag.HasCharacter = reader.ReadBit();
            tag.Move = reader.ReadBit();
            tag.Depth = reader.ReadUInt16();
            if (tag.HasCharacter) {
                tag.CharacterID = reader.ReadUInt16();
            }
            if (tag.HasMatrix) {
                reader.ReadMatrix(out tag.Matrix);
            }
            if (tag.HasColorTransform) {
                reader.ReadColorTransformRGBA(out tag.ColorTransform);
            }
            if (tag.HasRatio) {
                tag.Ratio = reader.ReadUInt16();
            }
            if (tag.HasName) {
                tag.Name = reader.ReadString();
            }
            if (tag.HasClipDepth) {
                tag.ClipDepth = reader.ReadUInt16();
            }
            if (tag.HasClipActions) {
                reader.ReadClipActions(_file.FileInfo.Version, out tag.ClipActions);
            }
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(PlaceObject3Tag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(RemoveObjectTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(RemoveObject2Tag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(ShowFrameTag tag, SwfTagData tagData) {
            return tag;
        }

        #endregion

        #region Control tags

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(SetBackgroundColorTag tag, SwfTagData tagData) {
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            reader.ReadRGB(out tag.Color);
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(FrameLabelTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(ProtectTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(EndTag tag, SwfTagData tagData) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(ExportAssetsTag tag, SwfTagData tagData) {
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            var count = reader.ReadUInt16();
            for (var i = 0; i < count; i++) {
                var symbolRef = reader.ReadSymbolReference();
                tag.Symbols.Add(symbolRef);
            }
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(ImportAssetsTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(EnableDebuggerTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(EnableDebugger2Tag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(ScriptLimitsTag tag, SwfTagData tagData) {
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.MaxRecursionDepth = reader.ReadUInt16();
            tag.ScriptTimeoutSeconds = reader.ReadUInt16();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(SetTabIndexTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(FileAttributesTag tag, SwfTagData tagData) {
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.Attributes = (SwfFileAttributes)reader.ReadUInt32();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(ImportAssets2Tag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(SymbolClassTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(MetadataTag tag, SwfTagData tagData) {
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.Metadata = reader.ReadString();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineScalingGridTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineSceneAndFrameLabelDataTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        #endregion

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DoActionTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DoInitActionTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DoABCTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DoABCDefineTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineShapeTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineShape2Tag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineShape3Tag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineShape4Tag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineBitsTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(JPEGTablesTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineBitsJPEG2Tag tag, SwfTagData tagData) {
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.CharacterID = reader.ReadUInt16();
            var imageLength = stream.Length - stream.Position;
            tag.ImageData = reader.ReadBytes((int)imageLength);
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineBitsJPEG3Tag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineBitsLosslessTag tag, SwfTagData tagData) {
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.CharacterID = reader.ReadUInt16();
            tag.BitmapFormat = reader.ReadByte();
            tag.BitmapWidth = reader.ReadUInt16();
            tag.BitmapHeight = reader.ReadUInt16();
            if (tag.BitmapFormat == 3) {
                tag.BitmapColorTableSize = reader.ReadByte();
            }
            tag.ZlibBitmapData = reader.ReadBytes((int)reader.BytesLeft);
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineBitsLossless2Tag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineBitsJPEG4Tag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(Tags.ShapeMorphingTags.DefineMorphShapeTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(Tags.ShapeMorphingTags.DefineMorphShape2Tag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineFontTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineFontInfoTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineFontInfo2Tag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineFont2Tag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineFont3Tag tag, SwfTagData tagData) {
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.FontId = reader.ReadUInt16();
            tag.Attributes = (DefineFont3Attributes)reader.ReadByte();
            tag.Language = reader.ReadByte();
            int nameLength = reader.ReadByte();
            tag.FontName = Encoding.UTF8.GetString(reader.ReadBytes(nameLength));
            int glyphsCount = reader.ReadUInt16();
            tag.Glyphs = new DefineFont3Glyph[glyphsCount];
            //for (var i = 0; i < glyphsCount; i++) {
            //    tag.Glyphs[i] = new DefineFont3Glyph();
            //}
            tag.RestData = reader.ReadRest();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineFontAlignZonesTag tag, SwfTagData tagData) {
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.FontID = reader.ReadUInt16();
            tag.CsmTableHint = reader.ReadByte();
            var fontInfo = _file.IterateTagsRecursively()
                .OfType<DefineFont3Tag>()
                .FirstOrDefault(item => item.FontId == tag.FontID);
            if (fontInfo == null) {
                throw new InvalidDataException("Couldn't find corresponding DefineFont3Tag");
            }
            tag.Zones = new SwfZoneArray[fontInfo.Glyphs.Length];
            for (var i = 0; i < tag.Zones.Length; i++) {
                var zone = new SwfZoneArray();
                int count = reader.ReadByte();
                zone.Data = new SwfZoneData[count];
                for (var j = 0; j < count; j++) {
                    var zoneData = new SwfZoneData();
                    zoneData.Position = reader.ReadShortFloat();
                    zoneData.Size = reader.ReadShortFloat();
                    zone.Data[j] = zoneData;
                }
                zone.Flags = (SwfZoneArrayFlags)reader.ReadByte();
                //TODO: store to xml reserverd flags
                tag.Zones[i] = zone;

            }
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineFontNameTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineTextTag tag, SwfTagData tagData) {
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

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineText2Tag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineEditTextTag tag, SwfTagData tagData) {
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.CharacterID = reader.ReadUInt16();
            reader.ReadRect(out tag.Bounds);
            reader.AlignToByte();
            tag.HasText = reader.ReadBit();
            tag.WordWrap = reader.ReadBit();
            tag.Multiline = reader.ReadBit();
            tag.Password = reader.ReadBit();
            tag.ReadOnly = reader.ReadBit();
            tag.HasTextColor = reader.ReadBit();
            tag.HasMaxLength = reader.ReadBit();
            tag.HasFont = reader.ReadBit();
            tag.HasFontClass = reader.ReadBit();
            tag.AutoSize = reader.ReadBit();
            tag.HasLayout = reader.ReadBit();
            tag.NoSelect = reader.ReadBit();
            tag.Border = reader.ReadBit();
            tag.WasStatic = reader.ReadBit();
            tag.HTML = reader.ReadBit();
            tag.UseOutlines = reader.ReadBit();
            if (tag.HasFont) {
                tag.FontID = reader.ReadUInt16();
            }
            if (tag.HasFontClass) {
                tag.FontClass = reader.ReadString();
            }
            if (tag.HasFont) {
                tag.FontHeight = reader.ReadUInt16();
            }
            if (tag.HasTextColor) {
                reader.ReadRGBA(out tag.TextColor);
            }
            if (tag.HasMaxLength) {
                tag.MaxLength = reader.ReadUInt16();
            }
            if (tag.HasLayout) {
                tag.Align = reader.ReadByte();
                tag.LeftMargin = reader.ReadUInt16();
                tag.RightMargin = reader.ReadUInt16();
                tag.Indent = reader.ReadUInt16();
                tag.Leading = reader.ReadSInt16();
            }
            tag.VariableName = reader.ReadString();
            if (tag.HasText) {
                tag.InitialText = reader.ReadString();
            }
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(CSMTextSettingsTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineFont4Tag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(Tags.SoundTags.DefineSoundTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(Tags.SoundTags.StartSoundTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(Tags.SoundTags.StartSound2Tag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(Tags.SoundTags.SoundStreamHeadTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(Tags.SoundTags.SoundStreamHead2Tag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(Tags.SoundTags.SoundStreamBlockTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineButtonTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineButton2Tag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineButtonCxformTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineButtonSoundTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineSpriteTag tag, SwfTagData tagData) {
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.SpriteID = reader.ReadUInt16();
            tag.FramesCount = reader.ReadUInt16();
            SwfTagBase subTag;
            do {
                subTag = ReadDefineSpriteSubTag(reader);
                if (subTag != null) tag.Tags.Add(subTag);
            } while (subTag != null && subTag.TagType != SwfTagType.End);
            return tag;
        }

        private SwfTagBase ReadDefineSpriteSubTag(SwfStreamReader reader) {
            var tagData = reader.ReadTagData();
            var tag = ReadTag(tagData);
            //TODO: Check allowed for define sprite types
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(Tags.VideoTags.DefineVideoStreamTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(Tags.VideoTags.VideoFrameTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DefineBinaryDataTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(DebugIDTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(ProductInfoTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }

        SwfTagBase ISwfTagVisitor<SwfTagData, SwfTagBase>.Visit(UnknownTag tag, SwfTagData tagData) {
            throw new NotImplementedException();
        }
    }
}
