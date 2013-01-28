using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Code.SwfLib.Actions;
using Code.SwfLib.Fonts;
using Code.SwfLib.Shapes;
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
    public class SwfTagSerializer : ISwfTagVisitor<SwfStreamWriter, SwfTagData> {

        private readonly SwfFile _file;

        public SwfTagSerializer(SwfFile file) {
            _file = file;
        }

        public SwfTagData GetTagData(SwfTagBase tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            tag.AcceptVistor(this, writer);
            if (tag.RestData != null && tag.RestData.Length > 0) {
                writer.WriteBytes(tag.RestData);
            }
            return new SwfTagData { Type = tag.TagType, Data = mem.ToArray() };
        }

        #region Display list tags

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(PlaceObjectTag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.CharacterID);
            writer.WriteUInt16(tag.Depth);
            writer.WriteMatrix(ref tag.Matrix);
            if (tag.ColorTransform.HasValue) {
                var transform = tag.ColorTransform.Value;
                writer.WriteColorTransformRGB(ref transform);
            }
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(PlaceObject2Tag tag, SwfStreamWriter writer) {
            writer.WriteBit(tag.HasClipActions);
            writer.WriteBit(tag.HasClipDepth);
            writer.WriteBit(tag.HasName);
            writer.WriteBit(tag.HasRatio);
            writer.WriteBit(tag.HasColorTransform);
            writer.WriteBit(tag.HasMatrix);
            writer.WriteBit(tag.HasCharacter);
            writer.WriteBit(tag.Move);
            writer.WriteUInt16(tag.Depth);
            if (tag.HasCharacter) writer.WriteUInt16(tag.CharacterID);
            if (tag.HasMatrix) writer.WriteMatrix(ref tag.Matrix);
            if (tag.HasColorTransform) writer.WriteColorTransformRGBA(ref tag.ColorTransform);
            if (tag.HasRatio) writer.WriteUInt16(tag.Ratio);
            if (tag.HasName) writer.WriteString(tag.Name);
            if (tag.HasClipDepth) writer.WriteUInt16(tag.ClipDepth);
            if (tag.HasClipActions) {
                writer.WriteClipActions(_file.FileInfo.Version, ref tag.ClipActions);
            }
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(PlaceObject3Tag tag, SwfStreamWriter writer) {
            writer.WriteBit(tag.HasClipActions);
            writer.WriteBit(tag.ClipDepth.HasValue);
            writer.WriteBit(tag.Name != null);
            writer.WriteBit(tag.Ratio.HasValue);
            writer.WriteBit(tag.ColorTransform.HasValue);
            writer.WriteBit(tag.HasMatrix);
            writer.WriteBit(tag.HasCharacter);
            writer.WriteBit(tag.Move);

            writer.WriteUnsignedBits(tag.Reserved, 3);
            writer.WriteBit(tag.HasImage);
            writer.WriteBit(tag.ClassName != null);
            writer.WriteBit(tag.BitmapCache.HasValue);
            writer.WriteBit(tag.BlendMode.HasValue);
            writer.WriteBit(tag.Filters.Count > 0);

            writer.WriteUInt16(tag.Depth);
            if (tag.ClassName != null) {
                writer.WriteString(tag.ClassName);
            }

            if (tag.HasCharacter) {
                writer.WriteUInt16(tag.CharacterID);
            }

            if (tag.HasMatrix) {
                writer.WriteMatrix(ref tag.Matrix);
            }

            if (tag.ColorTransform.HasValue) {
                writer.WriteColorTransformRGBA(tag.ColorTransform.Value);
            }
            if (tag.Ratio.HasValue) {
                writer.WriteUInt16(tag.Ratio.Value);
            }
            if (tag.Name != null) {
                writer.WriteString(tag.Name);
            }
            if (tag.ClipDepth.HasValue) {
                writer.WriteUInt16(tag.ClipDepth.Value);
            }

            //TODO: writer filters
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(RemoveObjectTag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.CharacterID);
            writer.WriteUInt16(tag.Depth);
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(RemoveObject2Tag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.Depth);
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(ShowFrameTag tag, SwfStreamWriter writer) {
            return null;
        }

        #endregion

        #region Control tags

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(SetBackgroundColorTag tag, SwfStreamWriter writer) {
            writer.WriteRGB(ref tag.Color);
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(FrameLabelTag tag, SwfStreamWriter writer) {
            writer.WriteString(tag.Name);
            if (tag.AnchorFlag != 0) writer.WriteByte(tag.AnchorFlag);
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(ProtectTag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(EndTag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(ExportAssetsTag tag, SwfStreamWriter writer) {
            writer.WriteUInt16((ushort)tag.Symbols.Count);
            foreach (var symbolref in tag.Symbols) {
                writer.WriteUInt16(symbolref.SymbolID);
                writer.WriteString(symbolref.SymbolName);
            }
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(ImportAssetsTag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(EnableDebuggerTag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(EnableDebugger2Tag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(ScriptLimitsTag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.MaxRecursionDepth);
            writer.WriteUInt16(tag.ScriptTimeoutSeconds);
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(SetTabIndexTag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(FileAttributesTag tag, SwfStreamWriter writer) {
            writer.WriteUInt32((uint)tag.Attributes);
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(ImportAssets2Tag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(SymbolClassTag tag, SwfStreamWriter writer) {
            writer.WriteUInt16((ushort)tag.References.Count);
            foreach (var symbolRef in tag.References) {
                writer.WriteUInt16(symbolRef.SymbolID);
                writer.WriteString(symbolRef.SymbolName);
            }
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(MetadataTag tag, SwfStreamWriter writer) {
            writer.WriteString(tag.Metadata);
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineScalingGridTag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineSceneAndFrameLabelDataTag tag, SwfStreamWriter writer) {
            writer.WriteEncodedU32((uint)tag.Scenes.Count);
            foreach (var scene in tag.Scenes) {
                writer.WriteEncodedU32(scene.Offset);
                writer.WriteString(scene.Name);
            }
            writer.WriteEncodedU32((uint)tag.Frames.Count);
            foreach (var frame in tag.Frames) {
                writer.WriteEncodedU32(frame.FrameNumber);
                writer.WriteString(frame.Label);
            }
            return null;
        }

        #endregion

        #region Action tags

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DoActionTag tag, SwfStreamWriter writer) {
            var actionWriter = new ActionWriter(writer);
            foreach (var action in tag.ActionRecords) {
                actionWriter.WriteAction(action);
            }
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DoInitActionTag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.SpriteId);
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DoABCTag tag, SwfStreamWriter writer) {
            writer.WriteUInt32(tag.Flags);
            writer.WriteString(tag.Name);
            writer.WriteBytes(tag.ABCData);
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DoABCDefineTag tag, SwfStreamWriter writer) {
            return null;
        }

        #endregion

        #region Shape tags

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineShapeTag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.ShapeID);
            writer.WriteRect(ref tag.ShapeBounds);

            writer.WriteFillStylesRGB(tag.FillStyles, false);
            writer.WriteLineStylesRGB(tag.LineStyles, false);
            writer.WriteShapeRecordsRGB(tag.ShapeRecords, new BitsCount(tag.FillStyles.Count).GetUnsignedBits(), new BitsCount(tag.LineStyles.Count).GetUnsignedBits());

            writer.FlushBits();
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineShape2Tag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.ShapeID);
            writer.WriteRect(ref tag.ShapeBounds);

            writer.WriteFillStylesRGB(tag.FillStyles, true);
            writer.WriteLineStylesRGB(tag.LineStyles, true);
            writer.WriteShapeRecordsRGB(tag.ShapeRecords, new BitsCount(tag.FillStyles.Count).GetUnsignedBits(), new BitsCount(tag.LineStyles.Count).GetUnsignedBits());

            writer.FlushBits();
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineShape3Tag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.ShapeID);
            writer.WriteRect(ref tag.ShapeBounds);

            writer.WriteFillStylesRGBA(tag.FillStyles);
            writer.WriteLineStylesRGBA(tag.LineStyles);
            writer.WriteShapeRecordsRGBA(tag.ShapeRecords, new BitsCount(tag.FillStyles.Count).GetUnsignedBits(), new BitsCount(tag.LineStyles.Count).GetUnsignedBits());

            writer.FlushBits();
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineShape4Tag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.ShapeID);
            writer.WriteRect(ref tag.ShapeBounds);
            writer.WriteRect(ref tag.EdgeBounds);
            writer.FlushBits();
            writer.WriteByte(tag.Flags);

            writer.WriteFillStylesRGBA(tag.FillStyles);
            writer.WriteLineStylesEx(tag.LineStyles);
            writer.WriteShapeRecordsEx(tag.ShapeRecords, new BitsCount(tag.FillStyles.Count).GetUnsignedBits(), new BitsCount(tag.LineStyles.Count).GetUnsignedBits());

            writer.FlushBits();
            return null;
        }

        #endregion

        #region Bitmap tags

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineBitsTag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.CharacterID);
            writer.WriteBytes(tag.JPEGData);
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(JPEGTablesTag tag, SwfStreamWriter writer) {
            writer.WriteBytes(tag.JPEGData);
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineBitsJPEG2Tag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.CharacterID);
            if (tag.ImageData != null) writer.WriteBytes(tag.ImageData);
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineBitsJPEG3Tag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.CharacterID);
            writer.WriteUInt32((uint)tag.ImageData.Length);
            writer.WriteBytes(tag.ImageData);
            writer.WriteBytes(tag.BitmapAlphaData);
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineBitsJPEG4Tag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.CharacterID);
            writer.WriteUInt32((uint)tag.ImageData.Length);
            writer.WriteUInt16(tag.DeblockParam);
            writer.WriteBytes(tag.ImageData);
            writer.WriteBytes(tag.BitmapAlphaData);
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineBitsLosslessTag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.CharacterID);
            writer.WriteByte(tag.BitmapFormat);
            writer.WriteUInt16(tag.BitmapWidth);
            writer.WriteUInt16(tag.BitmapHeight);
            if (tag.BitmapFormat == 3) {
                writer.WriteByte(tag.BitmapColorTableSize);
            }
            if (tag.ZlibBitmapData != null) {
                writer.WriteBytes(tag.ZlibBitmapData);
            }
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineBitsLossless2Tag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.CharacterID);
            writer.WriteByte(tag.BitmapFormat);
            writer.WriteUInt16(tag.BitmapWidth);
            writer.WriteUInt16(tag.BitmapHeight);
            if (tag.BitmapFormat == 3) {
                writer.WriteByte(tag.BitmapColorTableSize);
            }
            if (tag.ZlibBitmapData != null) {
                writer.WriteBytes(tag.ZlibBitmapData);
            }
            return null;
        }

        #endregion

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(Tags.ShapeMorphingTags.DefineMorphShapeTag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(Tags.ShapeMorphingTags.DefineMorphShape2Tag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineFontTag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.FontID);
            foreach (var offset in tag.OffsetTable) {
                writer.WriteUInt16(offset);
            }
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineFontInfoTag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.FontID);
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineFontInfo2Tag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.FontID);
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineFont2Tag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.FontID);
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineFont3Tag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.FontID);

            var wideCodes = tag.Glyphs.Any(item => item.Code > 255);
            writer.WriteBit(tag.HasLayout);
            writer.WriteBit(tag.ShiftJIS);
            writer.WriteBit(tag.SmallText);
            writer.WriteBit(tag.ANSI);

            writer.WriteBit(tag.WideOffsets);
            writer.WriteBit(wideCodes);
            writer.WriteBit(tag.Italic);
            writer.WriteBit(tag.Bold);

            writer.WriteByte(tag.Language);
            var name = Encoding.UTF8.GetBytes(tag.FontName);
            writer.WriteByte((byte)name.Length);
            writer.WriteBytes(name);
            writer.WriteUInt16((ushort)tag.Glyphs.Count);

            var offsetTable = new uint[tag.Glyphs.Count];

            var shapesStream = new MemoryStream();
            var shapesSwfWriter = new SwfStreamWriter(shapesStream);
            for (int i = 0; i < tag.Glyphs.Count; i++) {
                offsetTable[i] = (uint)shapesStream.Position;
                var glyph = tag.Glyphs[i];
                shapesSwfWriter.WriteShapeRecordsRGB(glyph.Records, 1, 0);
                shapesSwfWriter.FlushBits();
            }

            var offsetTableSize = (uint)(tag.WideOffsets ? 4 * tag.Glyphs.Count : 2 * tag.Glyphs.Count);

            foreach (var offset in offsetTable) {
                var resOffset = offset + offsetTableSize;
                if (tag.WideOffsets) {
                    writer.WriteUInt32(resOffset);
                } else {
                    writer.WriteUInt16((ushort)resOffset);
                }
            }

            var codeTableOffset = offsetTableSize + (uint)shapesStream.Length;
            if (tag.WideOffsets) {
                writer.WriteUInt32(codeTableOffset);
            } else {
                writer.WriteUInt16((ushort)codeTableOffset);
            }

            writer.WriteBytes(shapesStream.ToArray());
            foreach (var glyph in tag.Glyphs) {
                if (wideCodes) {
                    writer.WriteUInt16(glyph.Code);
                } else {
                    writer.WriteByte((byte)glyph.Code);
                }
            }

            if (tag.HasLayout) {
                writer.WriteSInt16(tag.Ascent);
                writer.WriteSInt16(tag.Descent);
                writer.WriteSInt16(tag.Leading);

                foreach (var glyph in tag.Glyphs) {
                    writer.WriteSInt16(glyph.Advance);
                }

                foreach (var glyph in tag.Glyphs) {
                    writer.WriteRect(ref glyph.Bounds);
                }

                writer.WriteUInt16((ushort)tag.KerningRecords.Count);
                foreach (var kerningRecord in tag.KerningRecords) {
                    writer.WriteKerningRecord(kerningRecord, wideCodes);
                }
            }
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineFont4Tag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.FontID);
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineFontAlignZonesTag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.FontID);
            writer.WriteUnsignedBits((byte)tag.CsmTableHint, 2);
            writer.WriteUnsignedBits(tag.Reserved, 6);

            foreach (var zoneArray in tag.ZoneTable) {
                writer.WriteByte((byte)zoneArray.Data.Length);
                foreach (var zoneData in zoneArray.Data) {
                    writer.WriteShortFloat(zoneData.Position);
                    writer.WriteShortFloat(zoneData.Size);
                }
                writer.WriteByte((byte)zoneArray.Flags);
            }

            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineFontNameTag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.FontID);
            writer.WriteString(tag.FontName);
            writer.WriteString(tag.FontCopyright);
            writer.FlushBits();
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineTextTag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.CharacterID);
            writer.WriteRect(ref tag.TextBounds);
            writer.WriteMatrix(ref tag.TextMatrix);
            var glyphBitsCounter = new BitsCount(0);
            var advanceBitsCounter = new BitsCount(0);
            foreach (var textRecord in tag.TextRecords) {
                foreach (var glyph in textRecord.Glyphs) {
                    glyphBitsCounter.AddValue(glyph.GlyphIndex);
                    advanceBitsCounter.AddValue(glyph.GlyphAdvance);
                }
            }
            var glyphBits = glyphBitsCounter.GetUnsignedBits();
            var advanceBits = advanceBitsCounter.GetSignedBits();

            writer.WriteByte((byte)glyphBits);
            writer.WriteByte((byte)advanceBits);
            foreach (var textRecord in tag.TextRecords) {
                writer.WriteTextRecord(textRecord, glyphBits, advanceBits);
                writer.FlushBits();
            }
            writer.FlushBits();
            //TODO: What if end record is missed?
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineText2Tag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineEditTextTag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.CharacterID);
            writer.WriteRect(ref tag.Bounds);
            writer.FlushBits();
            writer.WriteBit(tag.HasText);
            writer.WriteBit(tag.WordWrap);
            writer.WriteBit(tag.Multiline);
            writer.WriteBit(tag.Password);
            writer.WriteBit(tag.ReadOnly);
            writer.WriteBit(tag.HasTextColor);
            writer.WriteBit(tag.HasMaxLength);
            writer.WriteBit(tag.HasFont);
            writer.WriteBit(tag.HasFontClass);
            writer.WriteBit(tag.AutoSize);
            writer.WriteBit(tag.HasLayout);
            writer.WriteBit(tag.NoSelect);
            writer.WriteBit(tag.Border);
            writer.WriteBit(tag.WasStatic);
            writer.WriteBit(tag.HTML);
            writer.WriteBit(tag.UseOutlines);
            if (tag.HasFont) {
                writer.WriteUInt16(tag.FontID);
            }
            if (tag.HasFontClass) {
                writer.WriteString(tag.FontClass);
            }
            if (tag.HasFont) {
                writer.WriteUInt16(tag.FontHeight);
            }
            if (tag.HasTextColor) {
                writer.WriteRGBA(ref tag.TextColor);
            }
            if (tag.HasMaxLength) {
                writer.WriteUInt16(tag.MaxLength);
            }
            if (tag.HasLayout) {
                writer.WriteByte(tag.Align);
                writer.WriteUInt16(tag.LeftMargin);
                writer.WriteUInt16(tag.RightMargin);
                writer.WriteUInt16(tag.Indent);
                writer.WriteSInt16(tag.Leading);
            }
            writer.WriteString(tag.VariableName);
            if (tag.HasText) {
                writer.WriteString(tag.InitialText);
            }
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(CSMTextSettingsTag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.TextID);
            writer.WriteUnsignedBits(tag.UseFlashType, 2);
            writer.WriteUnsignedBits(tag.GridFit, 3);
            writer.WriteUnsignedBits(tag.ReservedFlags, 3);
            writer.WriteSingle(tag.Thickness);
            writer.WriteSingle(tag.Sharpness);
            writer.WriteByte(tag.Reserved);
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(Tags.SoundTags.DefineSoundTag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(Tags.SoundTags.StartSoundTag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(Tags.SoundTags.StartSound2Tag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(Tags.SoundTags.SoundStreamHeadTag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(Tags.SoundTags.SoundStreamHead2Tag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(Tags.SoundTags.SoundStreamBlockTag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineButtonTag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineButton2Tag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.ButtonID);
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineButtonCxformTag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineButtonSoundTag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineSpriteTag tag, SwfStreamWriter writer) {
            writer.WriteUInt16(tag.SpriteID);
            writer.WriteUInt16(tag.FramesCount);
            foreach (var subtag in tag.Tags) {
                SwfTagData subTagData = GetTagData(subtag);
                writer.WriteTagData(subTagData);
            }
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(Tags.VideoTags.DefineVideoStreamTag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(Tags.VideoTags.VideoFrameTag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DefineBinaryDataTag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(DebugIDTag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(ProductInfoTag tag, SwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<SwfStreamWriter, SwfTagData>.Visit(UnknownTag tag, SwfStreamWriter writer) {
            return null;
        }
    }
}
