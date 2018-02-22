using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using SwfLib.Actions;
using SwfLib.Buttons;
using SwfLib.ClipActions;
using SwfLib.Data;
using SwfLib.Filters;
using SwfLib.Fonts;
using SwfLib.Shapes;
using SwfLib.Tags;
using SwfLib.Tags.ActionsTags;
using SwfLib.Tags.BitmapTags;
using SwfLib.Tags.ButtonTags;
using SwfLib.Tags.ControlTags;
using SwfLib.Tags.DisplayListTags;
using SwfLib.Tags.FontTags;
using SwfLib.Tags.ShapeMorphingTags;
using SwfLib.Tags.ShapeTags;
using SwfLib.Tags.SoundTags;
using SwfLib.Tags.TextTags;
using SwfLib.Tags.VideoTags;
using SwfLib.Text;

namespace SwfLib {
    public class SwfTagDeserializer : ISwfTagVisitor<ISwfStreamReader, SwfTagBase> {
        private readonly SwfFile _file;
        private readonly SwfTagsFactory _factory = new SwfTagsFactory();

        public SwfTagDeserializer(SwfFile file) {
            _file = file;
        }

        public SwfTagBase ReadTag(SwfTagData tagData) {
            var stream = new MemoryStream(tagData.Data);
            var reader = new SwfStreamReader(stream);
            var type = tagData.Type;
            return ReadTag(type, reader);
        }

        public SwfTagBase ReadTag(SwfTagType type, ISwfStreamReader reader) {
            var tag = _factory.Create(type);
            tag.AcceptVistor(this, reader);
            tag.RestData = reader.BytesLeft > 0 ? reader.ReadRest() : null;
            return tag;
        }

        public T ReadTag<T>(SwfTagData data) where T : SwfTagBase {
            return (T)ReadTag(data);
        }

        public SwfFile SwfFile { get { return _file; } }

        #region Display list tags

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(PlaceObjectTag tag, ISwfStreamReader reader) {
            tag.CharacterID = reader.ReadUInt16();
            tag.Depth = reader.ReadUInt16();
            tag.Matrix = reader.ReadMatrix();
            if (!reader.IsEOF) {
                tag.ColorTransform = reader.ReadColorTransformRGB();
            } else {
                tag.ColorTransform = null;
            }
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(PlaceObject2Tag tag, ISwfStreamReader reader) {
            tag.HasClipActions = reader.ReadBit();
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
                tag.Matrix = reader.ReadMatrix();
            }
            if (tag.HasColorTransform) {
                tag.ColorTransform = reader.ReadColorTransformRGBA();
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
                reader.ReadClipActions(_file.FileInfo.Version, tag.ClipActions);
            }
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(PlaceObject3Tag tag, ISwfStreamReader reader) {

            tag.HasClipActions = reader.ReadBit();
            tag.HasClipDepth = reader.ReadBit();
            tag.HasName = reader.ReadBit();
            tag.HasRatio = reader.ReadBit();
            tag.HasColorTransform = reader.ReadBit();
            tag.HasMatrix = reader.ReadBit();
            tag.HasCharacter = reader.ReadBit();
            tag.Move = reader.ReadBit();

            tag.Reserved = reader.ReadBit();
            tag.HasOpaqueBackground = reader.ReadBit();
            tag.HasVisible = reader.ReadBit();
            tag.HasImage = reader.ReadBit();
            tag.HasClassName = reader.ReadBit();
            tag.HasCacheAsBitmap = reader.ReadBit();
            tag.HasBlendMode = reader.ReadBit();
            tag.HasFilterList = reader.ReadBit();

            tag.Depth = reader.ReadUInt16();
            if (tag.HasClassName) { //Adobe says class name is also present when (hasImage && hasCharacter)
                tag.ClassName = reader.ReadString();
            }

            if (tag.HasCharacter) {
                tag.CharacterID = reader.ReadUInt16();
            }

            if (tag.HasMatrix) {
                tag.Matrix = reader.ReadMatrix();
            }

            if (tag.HasColorTransform) {
                tag.ColorTransform = reader.ReadColorTransformRGBA();
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

            if (tag.HasFilterList) {
                reader.ReadFilterList(tag.Filters);
            }

            if (tag.HasBlendMode) {
                tag.BlendMode = (BlendMode?)reader.ReadByte();
            }
            
            if (tag.HasVisible)
            {
                tag.Visible = reader.ReadByte();
                if (reader.BytesLeft > 0)
                {
                    tag.BackgroundColor = reader.ReadRGBA();
                }
                
            }

            if (tag.HasClipActions) {
                reader.ReadClipActions(_file.FileInfo.Version, tag.ClipActions);
            }
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(RemoveObjectTag tag, ISwfStreamReader reader) {
            tag.CharacterID = reader.ReadUInt16();
            tag.Depth = reader.ReadUInt16();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(RemoveObject2Tag tag, ISwfStreamReader reader) {
            tag.Depth = reader.ReadUInt16();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(ShowFrameTag tag, ISwfStreamReader reader) {
            return tag;
        }

        #endregion

        #region Control tags

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(SetBackgroundColorTag tag, ISwfStreamReader reader) {
            reader.ReadRGB(out tag.Color);
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(FrameLabelTag tag, ISwfStreamReader reader) {
            tag.Name = reader.ReadString();
            if (!reader.IsEOF) {
                tag.AnchorFlag = reader.ReadByte();
            }
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(ProtectTag tag, ISwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(EndTag tag, ISwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(ExportAssetsTag tag, ISwfStreamReader reader) {
            var count = reader.ReadUInt16();
            for (var i = 0; i < count; i++) {
                var symbolRef = reader.ReadSymbolReference();
                tag.Symbols.Add(symbolRef);
            }
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(ImportAssetsTag tag, ISwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(EnableDebuggerTag tag, ISwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(EnableDebugger2Tag tag, ISwfStreamReader reader) {
            return new EnableDebugger2Tag { Data = reader.ReadRest() };
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(ScriptLimitsTag tag, ISwfStreamReader reader) {
            tag.MaxRecursionDepth = reader.ReadUInt16();
            tag.ScriptTimeoutSeconds = reader.ReadUInt16();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(SetTabIndexTag tag, ISwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(FileAttributesTag tag, ISwfStreamReader reader) {
            tag.Reserved0 = reader.ReadBit();
            tag.UseDirectBlit = reader.ReadBit();
            tag.UseGPU = reader.ReadBit();
            tag.HasMetadata = reader.ReadBit();
            tag.AllowAbc = reader.ReadBit();
            tag.SuppressCrossDomainCaching = reader.ReadBit();
            tag.SwfRelativeUrls = reader.ReadBit();
            tag.UseNetwork = reader.ReadBit();
            tag.Reserved = reader.ReadUnsignedBits(24);
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(ImportAssets2Tag tag, ISwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(SymbolClassTag tag, ISwfStreamReader reader) {
            ushort count = reader.ReadUInt16();
            for (int i = 0; i < count; i++) {
                var reference = new SwfSymbolReference {
                    SymbolID = reader.ReadUInt16(),
                    SymbolName = reader.ReadString()
                };
                tag.References.Add(reference);
            }
            return tag;

        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(MetadataTag tag, ISwfStreamReader reader) {
            tag.Metadata = reader.ReadString();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineScalingGridTag tag, ISwfStreamReader reader) {
            tag.CharacterID = reader.ReadUInt16();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineSceneAndFrameLabelDataTag tag, ISwfStreamReader reader) {
            var scenesCount = reader.ReadEncodedU32();
            for (var i = 0; i < scenesCount; i++) {
                var item = new SceneOffsetData {
                    Offset = reader.ReadEncodedU32(),
                    Name = reader.ReadString()
                };
                tag.Scenes.Add(item);
            }
            var framesCount = reader.ReadEncodedU32();
            for (var i = 0; i < framesCount; i++) {
                var item = new FrameLabelData {
                    FrameNumber = reader.ReadEncodedU32(),
                    Label = reader.ReadString()
                };
                tag.Frames.Add(item);
            }
            return tag;
        }

        #endregion

        #region Actions tags

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DoActionTag tag, ISwfStreamReader reader) {
            var actionReader = new ActionReader(reader);
            ActionBase action;
            do {
                action = actionReader.ReadAction();
                tag.ActionRecords.Add(action);
            } while (!(action is ActionEnd));
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DoInitActionTag tag, ISwfStreamReader reader) {
            tag.SpriteId = reader.ReadUInt16();
            var actionReader = new ActionReader(reader);
            ActionBase action;
            do {
                action = actionReader.ReadAction();
                tag.ActionRecords.Add(action);
            } while (!(action is ActionEnd));
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DoABCTag tag, ISwfStreamReader reader) {
            tag.Flags = reader.ReadUInt32();
            tag.Name = reader.ReadString();
            tag.ABCData = reader.ReadRest();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DoABCDefineTag tag, ISwfStreamReader reader) {
            tag.ABCData = reader.ReadRest();
            return tag;
        }

        #endregion

        #region Shapes tags

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineShapeTag tag, ISwfStreamReader reader) {
            tag.ShapeID = reader.ReadUInt16();
            tag.ShapeBounds = reader.ReadRect();
            reader.ReadToFillStylesRGB(tag.FillStyles, false);
            reader.ReadToLineStylesRGB(tag.LineStyles, false);
            reader.ReadToShapeRecordsRGB(tag.ShapeRecords);
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineShape2Tag tag, ISwfStreamReader reader) {
            tag.ShapeID = reader.ReadUInt16();
            tag.ShapeBounds = reader.ReadRect();
            reader.ReadToFillStylesRGB(tag.FillStyles, true);
            reader.ReadToLineStylesRGB(tag.LineStyles, true);
            reader.ReadToShapeRecordsRGB(tag.ShapeRecords);
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineShape3Tag tag, ISwfStreamReader reader) {
            tag.ShapeID = reader.ReadUInt16();
            tag.ShapeBounds = reader.ReadRect();
            reader.ReadToFillStylesRGBA(tag.FillStyles);
            reader.ReadToLineStylesRGBA(tag.LineStyles);
            reader.ReadToShapeRecordsRGBA(tag.ShapeRecords);
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineShape4Tag tag, ISwfStreamReader reader) {
            tag.ShapeID = reader.ReadUInt16();
            tag.ShapeBounds = reader.ReadRect();
            reader.ReadRect(out tag.EdgeBounds);
            tag.Flags = reader.ReadByte();
            reader.ReadToFillStylesRGBA(tag.FillStyles);
            reader.ReadToLineStylesEx(tag.LineStyles);
            reader.ReadToShapeRecordsEx(tag.ShapeRecords);
            return tag;
        }

        #endregion

        #region Bitmap tags

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineBitsTag tag, ISwfStreamReader reader) {
            tag.CharacterID = reader.ReadUInt16();
            tag.JPEGData = reader.ReadRest();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(JPEGTablesTag tag, ISwfStreamReader reader) {
            tag.JPEGData = reader.ReadRest();
            return tag;
        }
#if NETFULL
        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineBitsJPEG2Tag tag, ISwfStreamReader reader) {
            tag.CharacterID = reader.ReadUInt16();
            tag.ImageData = reader.ReadRest();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineBitsJPEG3Tag tag, ISwfStreamReader reader) {
            tag.CharacterID = reader.ReadUInt16();
            var alphaDataOffset = reader.ReadUInt32();
            tag.ImageData = reader.ReadBytes((int)alphaDataOffset);
            tag.BitmapAlphaData = reader.ReadRest();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineBitsJPEG4Tag tag, ISwfStreamReader reader) {
            tag.CharacterID = reader.ReadUInt16();
            var alphaDataOffset = reader.ReadUInt32();
            tag.DeblockParam = reader.ReadUInt16();
            tag.ImageData = reader.ReadBytes((int)alphaDataOffset);
            tag.BitmapAlphaData = reader.ReadRest();
            return tag;
        }
#endif
        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineBitsLosslessTag tag, ISwfStreamReader reader) {
            tag.CharacterID = reader.ReadUInt16();
            tag.BitmapFormat = reader.ReadByte();
            tag.BitmapWidth = reader.ReadUInt16();
            tag.BitmapHeight = reader.ReadUInt16();
            if (tag.BitmapFormat == 3) {
                tag.BitmapColorTableSize = reader.ReadByte();
            }
            tag.ZlibBitmapData = reader.ReadRest();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineBitsLossless2Tag tag, ISwfStreamReader reader) {
            tag.CharacterID = reader.ReadUInt16();
            tag.BitmapFormat = reader.ReadByte();
            tag.BitmapWidth = reader.ReadUInt16();
            tag.BitmapHeight = reader.ReadUInt16();
            if (tag.BitmapFormat == 3) {
                tag.BitmapColorTableSize = reader.ReadByte();
            }
            tag.ZlibBitmapData = reader.ReadRest();
            return tag;
        }

#endregion

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineMorphShapeTag tag, ISwfStreamReader reader) {
            tag.CharacterID = reader.ReadUInt16();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineMorphShape2Tag tag, ISwfStreamReader reader) {
            tag.CharacterID = reader.ReadUInt16();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineFontTag tag, ISwfStreamReader reader) {
            tag.FontID = reader.ReadUInt16();
            var firstOffset = reader.ReadUInt16();
            var glyphsCount = firstOffset / 2;
            tag.OffsetTable.Add(firstOffset);
            for (var i = 1; i < glyphsCount; i++) {
                tag.OffsetTable.Add(reader.ReadUInt16());
            }

            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineFontInfoTag tag, ISwfStreamReader reader) {
            tag.FontID = reader.ReadUInt16();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineFontInfo2Tag tag, ISwfStreamReader reader) {
            tag.FontID = reader.ReadUInt16();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineFont2Tag tag, ISwfStreamReader reader) {
            tag.FontID = reader.ReadUInt16();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineFont3Tag tag, ISwfStreamReader reader) {

            tag.FontID = reader.ReadUInt16();

            tag.HasLayout = reader.ReadBit();
            tag.ShiftJIS = reader.ReadBit();
            tag.SmallText = reader.ReadBit();
            tag.ANSI = reader.ReadBit();

            tag.WideOffsets = reader.ReadBit();
            tag.WideCodes = reader.ReadBit();
            tag.Italic = reader.ReadBit();
            tag.Bold = reader.ReadBit();

            tag.Language = reader.ReadByte();
            int nameLength = reader.ReadByte();
            tag.FontName = Encoding.UTF8.GetString(reader.ReadBytes(nameLength));

            if (reader.BytesLeft == 0) {
                return tag;
            }

            int glyphsCount = reader.ReadUInt16();
            if (glyphsCount < 1)
            {
                return tag;
            }

            var offsetTable = new uint[glyphsCount];
            for (var i = 0; i < glyphsCount; i++) {
                offsetTable[i] = tag.WideOffsets ? reader.ReadUInt32() : reader.ReadUInt16();
            }
            uint codeTableOffset = tag.WideOffsets ? reader.ReadUInt32() : reader.ReadUInt16();

            for (var i = 0; i < glyphsCount; i++) {
                var glyph = new Glyph();
                reader.ReadToShapeRecordsRGB(glyph.Records);
                tag.Glyphs.Add(glyph);
                reader.AlignToByte();
            }

            for (var i = 0; i < glyphsCount; i++) {
                var glyph = tag.Glyphs[i];
                glyph.Code = tag.WideCodes ? reader.ReadUInt16() : reader.ReadByte();
            }

            if (tag.HasLayout) {
                tag.Ascent = reader.ReadSInt16();
                tag.Descent = reader.ReadSInt16();
                tag.Leading = reader.ReadSInt16();

                for (var i = 0; i < glyphsCount; i++) {
                    var glyph = tag.Glyphs[i];
                    glyph.Advance = reader.ReadSInt16();
                }

                for (var i = 0; i < glyphsCount; i++) {
                    var glyph = tag.Glyphs[i];
                    glyph.Bounds = reader.ReadRect();
                }

                var kerningCounts = reader.ReadUInt16();
                for (var i = 0; i < kerningCounts; i++) {
                    tag.KerningRecords.Add(reader.ReadKerningRecord(tag.WideCodes));
                }
            }
            return tag;
        }


        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineFont4Tag tag, ISwfStreamReader reader) {
            tag.FontID = reader.ReadUInt16();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineFontAlignZonesTag tag, ISwfStreamReader reader) {
            tag.FontID = reader.ReadUInt16();
            tag.CsmTableHint = (CSMTableHint)reader.ReadUnsignedBits(2);
            tag.Reserved = (byte)reader.ReadUnsignedBits(6);

            while (!reader.IsEOF) {
                var zone = new ZoneRecord();
                int count = reader.ReadByte();
                for (var j = 0; j < count; j++) {
                    var zoneData = new ZoneData {
                        Position = reader.ReadShortFloat(),
                        Size = reader.ReadShortFloat()
                    };
                    zone.Data.Add(zoneData);
                }
                zone.Reserved = (byte)reader.ReadUnsignedBits(6);
                zone.ZoneX = reader.ReadBit();
                zone.ZoneY = reader.ReadBit();
                tag.ZoneTable.Add(zone);
            }
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineFontNameTag tag, ISwfStreamReader reader) {
            tag.FontID = reader.ReadUInt16();
            tag.FontName = reader.ReadString();
            tag.FontCopyright = reader.ReadString();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineTextTag tag, ISwfStreamReader reader) {
            tag.CharacterID = reader.ReadUInt16();
            tag.TextBounds = reader.ReadRect();
            tag.TextMatrix = reader.ReadMatrix();
            uint glyphBits = reader.ReadByte();
            uint advanceBits = reader.ReadByte();
            foreach (var record in reader.ReadTextRecordsRGB(glyphBits, advanceBits)) {
                tag.TextRecords.Add(record);
            }
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineText2Tag tag, ISwfStreamReader reader) {
            tag.CharacterID = reader.ReadUInt16();
            tag.TextBounds = reader.ReadRect();
            tag.TextMatrix = reader.ReadMatrix();
            uint glyphBits = reader.ReadByte();
            uint advanceBits = reader.ReadByte();
            foreach (var record in reader.ReadTextRecordsRGBA(glyphBits, advanceBits)) {
                tag.TextRecords.Add(record);
            }
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineEditTextTag tag, ISwfStreamReader reader) {
            tag.CharacterID = reader.ReadUInt16();
            tag.Bounds = reader.ReadRect();

            var hasText = reader.ReadBit();
            tag.WordWrap = reader.ReadBit();
            tag.Multiline = reader.ReadBit();
            tag.Password = reader.ReadBit();
            tag.ReadOnly = reader.ReadBit();
            var hasTextColor = reader.ReadBit();
            var hasMaxLength = reader.ReadBit();
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
            if (hasTextColor) {
                tag.TextColor = reader.ReadRGBA();
            }
            if (hasMaxLength) {
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
            if (hasText) {
                tag.InitialText = reader.ReadString();
            }
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(CSMTextSettingsTag tag, ISwfStreamReader reader) {
            tag.TextID = reader.ReadUInt16();
            tag.UseFlashType = (byte)reader.ReadUnsignedBits(2);
            tag.GridFit = (byte)reader.ReadUnsignedBits(3);
            tag.ReservedFlags = (byte)reader.ReadUnsignedBits(3);
            tag.Thickness = reader.ReadSingle();
            tag.Sharpness = reader.ReadSingle();
            tag.Reserved = reader.ReadByte();
            return tag;
        }

#region Sound tags

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineSoundTag tag, ISwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(StartSoundTag tag, ISwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(StartSound2Tag tag, ISwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(SoundStreamHeadTag tag, ISwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(SoundStreamHead2Tag tag, ISwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(SoundStreamBlockTag tag, ISwfStreamReader reader) {
            return tag;
        }

#endregion

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineButtonTag tag, ISwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineButton2Tag tag, ISwfStreamReader reader) {
            tag.ButtonID = reader.ReadUInt16();
            tag.ReservedFlags = (byte)reader.ReadUnsignedBits(7);
            tag.TrackAsMenu = reader.ReadBit();
            var baseOffset = reader.Position;
            var actionsOffset = reader.ReadUInt16();

            while (actionsOffset != 0 ? (reader.Position - baseOffset) < actionsOffset : !reader.IsEOF) {
                tag.Characters.Add(reader.ReadButtonRecordEx());
            }

            if (actionsOffset != 0) {
                uint next;
                do {
                    next = reader.ReadUInt16();
                    var condition = reader.ReadButtonCondition();
                    tag.Conditions.Add(condition);
                } while (next != 0);
            }

            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineButtonCxformTag tag, ISwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineButtonSoundTag tag, ISwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineSpriteTag tag, ISwfStreamReader reader) {
            tag.SpriteID = reader.ReadUInt16();
            tag.FramesCount = reader.ReadUInt16();
            SwfTagBase subTag;
            do
            {
                subTag = ReadDefineSpriteSubTag(reader);
                if (subTag != null) tag.Tags.Add(subTag);
            } while (subTag != null && subTag.TagType != SwfTagType.End && reader.BytesLeft > 0);
            return tag;
        }

        private SwfTagBase ReadDefineSpriteSubTag(ISwfStreamReader reader) {
            var tagData = reader.ReadTagData();
            var tag = ReadTag(tagData);
            //TODO: Check allowed for define sprite types
            return tag;
        }

#region Video tags

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineVideoStreamTag tag, ISwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(VideoFrameTag tag, ISwfStreamReader reader) {
            return tag;
        }

#endregion

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DefineBinaryDataTag tag, ISwfStreamReader reader) {
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(DebugIDTag tag, ISwfStreamReader reader) {
            return new DebugIDTag { Data = reader.ReadRest() };
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(ProductInfoTag tag, ISwfStreamReader reader) {
            tag.ProductId = reader.ReadUInt32();
            tag.Edition = reader.ReadUInt32();
            tag.MajorVersion = reader.ReadByte();
            tag.MinorVersion = reader.ReadByte();
            tag.BuildNumber = reader.ReadUInt64();
            tag.CompilationDate = reader.ReadUInt64();
            return tag;
        }

        SwfTagBase ISwfTagVisitor<ISwfStreamReader, SwfTagBase>.Visit(UnknownTag tag, ISwfStreamReader reader) {
            tag.Data = reader.ReadRest();
            return tag;
        }
    }
}
