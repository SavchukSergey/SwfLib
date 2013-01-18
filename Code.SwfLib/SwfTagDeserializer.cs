using System.IO;
using System.Linq;
using System.Text;
using Code.SwfLib.Data;
using Code.SwfLib.Data.Actions;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.ActionsTags;
using Code.SwfLib.Tags.BitmapTags;
using Code.SwfLib.Tags.ButtonTags;
using Code.SwfLib.Tags.ControlTags;
using Code.SwfLib.Tags.DisplayListTags;
using Code.SwfLib.Tags.FontTags;
using Code.SwfLib.Tags.ShapeTags;
using Code.SwfLib.Tags.SoundTags;
using Code.SwfLib.Tags.TextTags;

namespace Code.SwfLib {
    public class SwfTagDeserializer : ISwfTagVisitor<SwfStreamReader, SwfTagBase> {
        private readonly SwfFile _file;
        private readonly SwfTagsFactory _factory = new SwfTagsFactory();

        public SwfTagDeserializer(SwfFile file) {
            _file = file;
        }

        public SwfTagBase ReadTag(SwfTagData tagData) {
            var type = tagData.Type;
            var tag = _factory.Create(type);
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            tag.AcceptVistor(this, reader);
            tag.RestData = reader.BytesLeft > 0 ? reader.ReadRest() : null;
            return tag;
        }

        public T ReadTag<T>(SwfTagData data) where T : SwfTagBase {
            return (T)ReadTag(data);
        }

        public SwfFile SwfFile { get { return _file; } }

        #region Display list tags

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(PlaceObjectTag tag, SwfStreamReader reader) {
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

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(PlaceObject2Tag tag, SwfStreamReader reader) {
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

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(PlaceObject3Tag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(RemoveObjectTag tag, SwfStreamReader reader) {
            tag.CharacterID = reader.ReadUInt16();
            tag.Depth = reader.ReadUInt16();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(RemoveObject2Tag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(ShowFrameTag tag, SwfStreamReader reader) {
            return tag;
        }

        #endregion

        #region Control tags

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(SetBackgroundColorTag tag, SwfStreamReader reader) {
            reader.ReadRGB(out tag.Color);
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(FrameLabelTag tag, SwfStreamReader reader) {
            tag.Name = reader.ReadString();
            if (!reader.IsEOF) {
                var anchorFlag = reader.ReadByte();
                tag.IsAnchor = anchorFlag != 0;
            }
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(ProtectTag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(EndTag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(ExportAssetsTag tag, SwfStreamReader reader) {
            var count = reader.ReadUInt16();
            for (var i = 0; i < count; i++) {
                var symbolRef = reader.ReadSymbolReference();
                tag.Symbols.Add(symbolRef);
            }
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(ImportAssetsTag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(EnableDebuggerTag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(EnableDebugger2Tag tag, SwfStreamReader reader) {
            return new EnableDebugger2Tag { Data = reader.ReadRest() };
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(ScriptLimitsTag tag, SwfStreamReader reader) {
            tag.MaxRecursionDepth = reader.ReadUInt16();
            tag.ScriptTimeoutSeconds = reader.ReadUInt16();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(SetTabIndexTag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(FileAttributesTag tag, SwfStreamReader reader) {
            tag.Attributes = (SwfFileAttributes)reader.ReadUInt32();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(ImportAssets2Tag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(SymbolClassTag tag, SwfStreamReader reader) {
            ushort count = reader.ReadUInt16();
            tag.References = new SwfSymbolReference[count];
            for (int i = 0; i < count; i++) {
                var reference = new SwfSymbolReference {
                    SymbolID = reader.ReadUInt16(),
                    SymbolName = reader.ReadString()
                };
                tag.References[i] = reference;
            }
            return tag;

        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(MetadataTag tag, SwfStreamReader reader) {
            tag.Metadata = reader.ReadString();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineScalingGridTag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineSceneAndFrameLabelDataTag tag, SwfStreamReader reader) {
            return tag;
        }

        #endregion

        #region Actions tags

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DoActionTag tag, SwfStreamReader reader) {
            ActionBase action;
            do {
                action = reader.ReadAction();
                if (action != null) {
                    tag.ActionRecords.Add(action);
                }
            } while (action != null);
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DoInitActionTag tag, SwfStreamReader reader) {
            tag.SpriteId = reader.ReadUInt16();
            tag.RestData = reader.ReadRest();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DoABCTag tag, SwfStreamReader reader) {
            tag.Flags = reader.ReadUInt32();
            tag.Name = reader.ReadString();
            tag.ABCData = reader.ReadRest();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DoABCDefineTag tag, SwfStreamReader reader) {
            tag.ABCData = reader.ReadRest();
            return tag;
        }

        #endregion

        #region Shapes tags

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineShapeTag tag, SwfStreamReader reader) {
            tag.ShapeID = reader.ReadUInt16();
            reader.ReadRect(out tag.ShapeBounds);
            reader.ReadToShapeWithStyle(tag.Shapes);
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineShape2Tag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineShape3Tag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineShape4Tag tag, SwfStreamReader reader) {
            return tag;
        }

        #endregion

        #region Bitmap tags

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineBitsTag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(JPEGTablesTag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineBitsJPEG2Tag tag, SwfStreamReader reader) {
            tag.CharacterID = reader.ReadUInt16();
            tag.ImageData = reader.ReadRest();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineBitsJPEG3Tag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineBitsLosslessTag tag, SwfStreamReader reader) {
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

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineBitsLossless2Tag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineBitsJPEG4Tag tag, SwfStreamReader reader) {
            return tag;
        }

        #endregion

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(Tags.ShapeMorphingTags.DefineMorphShapeTag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(Tags.ShapeMorphingTags.DefineMorphShape2Tag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineFontTag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineFontInfoTag tag, SwfStreamReader reader) {
            tag.FontId = reader.ReadUInt16();
            tag.RestData = reader.ReadRest();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineFontInfo2Tag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineFont2Tag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineFont3Tag tag, SwfStreamReader reader) {
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

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineFontAlignZonesTag tag, SwfStreamReader reader) {
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
                    var zoneData = new SwfZoneData {
                        Position = reader.ReadShortFloat(),
                        Size = reader.ReadShortFloat()
                    };
                    zone.Data[j] = zoneData;
                }
                zone.Flags = (SwfZoneArrayFlags)reader.ReadByte();
                //TODO: store to xml reserverd flags
                tag.Zones[i] = zone;

            }
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineFontNameTag tag, SwfStreamReader reader) {
            tag.FontId = reader.ReadUInt16();
            tag.FontName = reader.ReadString();
            tag.FontCopyright = reader.ReadString();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineTextTag tag, SwfStreamReader reader) {
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

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineText2Tag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineEditTextTag tag, SwfStreamReader reader) {
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

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(CSMTextSettingsTag tag, SwfStreamReader reader) {
            tag.TextID = reader.ReadUInt16();
            tag.UseFlashType = (byte)reader.ReadUnsignedBits(2);
            tag.GridFit = (byte)reader.ReadUnsignedBits(3);
            tag.ReservedFlags = (byte)reader.ReadUnsignedBits(3);
            tag.Thickness = reader.ReadSingle();
            tag.Sharpness = reader.ReadSingle();
            tag.Reserved = reader.ReadByte();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineFont4Tag tag, SwfStreamReader reader) {
            return tag;
        }

        #region Sound tags

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineSoundTag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(StartSoundTag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(StartSound2Tag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(SoundStreamHeadTag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(SoundStreamHead2Tag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(SoundStreamBlockTag tag, SwfStreamReader reader) {
            return tag;
        }

        #endregion

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineButtonTag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineButton2Tag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineButtonCxformTag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineButtonSoundTag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineSpriteTag tag, SwfStreamReader reader) {
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

        #region Video tags

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(Tags.VideoTags.DefineVideoStreamTag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(Tags.VideoTags.VideoFrameTag tag, SwfStreamReader reader) {
            return tag;
        }

        #endregion

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DefineBinaryDataTag tag, SwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(DebugIDTag tag, SwfStreamReader reader) {
            return new DebugIDTag { Data = reader.ReadRest() };
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(ProductInfoTag tag, SwfStreamReader reader) {
            tag.ProductId = reader.ReadUInt32();
            tag.Edition = reader.ReadUInt32();
            tag.MajorVersion = reader.ReadByte();
            tag.MinorVersion = reader.ReadByte();
            tag.BuildNumber = reader.ReadUInt64();
            tag.CompilationDate = reader.ReadUInt64();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<SwfStreamReader, SwfTagBase>.Visit(UnknownTag tag, SwfStreamReader reader) {
            tag.Data = reader.ReadRest();
            return tag;
        }
    }
}
