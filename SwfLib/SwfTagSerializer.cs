using System.Collections.Generic;
using System.IO;
using System.Text;
using Code.SwfLib.Actions;
using Code.SwfLib.Buttons;
using Code.SwfLib.ClipActions;
using Code.SwfLib.Data;
using Code.SwfLib.Filters;
using Code.SwfLib.Fonts;
using Code.SwfLib.Shapes;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.ActionsTags;
using Code.SwfLib.Tags.BitmapTags;
using Code.SwfLib.Tags.ButtonTags;
using Code.SwfLib.Tags.ControlTags;
using Code.SwfLib.Tags.DisplayListTags;
using Code.SwfLib.Tags.FontTags;
using Code.SwfLib.Tags.ShapeMorphingTags;
using Code.SwfLib.Tags.ShapeTags;
using Code.SwfLib.Tags.SoundTags;
using Code.SwfLib.Tags.TextTags;
using Code.SwfLib.Text;
using Code.SwfLib.Utils;
using SwfLib.Data;
using SwfLib.Tags.BitmapTags;
using SwfLib.Tags.ShapeTags;

namespace Code.SwfLib {
    public class SwfTagSerializer : ISwfTagVisitor<ISwfStreamWriter, SwfTagData> {

        private readonly SwfFile _file;

        public SwfTagSerializer(SwfFile file) {
            _file = file;
        }

        public SwfTagData GetTagData(SwfTagBase tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            tag.AcceptVistor(this, writer);
            writer.FlushBits();
            if (tag.RestData != null && tag.RestData.Length > 0) {
                writer.WriteBytes(tag.RestData);
            }
            return new SwfTagData { Type = tag.TagType, Data = mem.ToArray() };
        }

        #region Display list tags

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(PlaceObjectTag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.CharacterID);
            writer.WriteUInt16(tag.Depth);
            writer.WriteMatrix(ref tag.Matrix);
            if (tag.ColorTransform.HasValue) {
                var transform = tag.ColorTransform.Value;
                writer.WriteColorTransformRGB(ref transform);
            }
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(PlaceObject2Tag tag, ISwfStreamWriter writer) {
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
                writer.WriteClipActions(_file.FileInfo.Version, tag.ClipActions);
            }
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(PlaceObject3Tag tag, ISwfStreamWriter writer) {
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

            if (tag.ClassName != null) { //Adobe says class name is also present when (hasImage && hasCharacter)
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

            if (tag.Filters.Count > 0) {
                writer.WriteFilterList(tag.Filters);
            }

            if (tag.BlendMode.HasValue) {
                writer.WriteByte((byte)tag.BlendMode.Value);
            }

            if (tag.BitmapCache.HasValue) {
                writer.WriteByte(tag.BitmapCache.Value);
            }

            if (tag.HasClipActions) {
                writer.WriteClipActions(_file.FileInfo.Version, tag.ClipActions);
            }
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(RemoveObjectTag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.CharacterID);
            writer.WriteUInt16(tag.Depth);
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(RemoveObject2Tag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.Depth);
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(ShowFrameTag tag, ISwfStreamWriter writer) {
            return null;
        }

        #endregion

        #region Control tags

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(SetBackgroundColorTag tag, ISwfStreamWriter writer) {
            writer.WriteRGB(ref tag.Color);
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(FrameLabelTag tag, ISwfStreamWriter writer) {
            writer.WriteString(tag.Name);
            if (tag.AnchorFlag.HasValue) writer.WriteByte(tag.AnchorFlag.Value);
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(ProtectTag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(EndTag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(ExportAssetsTag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16((ushort)tag.Symbols.Count);
            foreach (var symbolref in tag.Symbols) {
                writer.WriteUInt16(symbolref.SymbolID);
                writer.WriteString(symbolref.SymbolName);
            }
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(ImportAssetsTag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(EnableDebuggerTag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(EnableDebugger2Tag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(ScriptLimitsTag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.MaxRecursionDepth);
            writer.WriteUInt16(tag.ScriptTimeoutSeconds);
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(SetTabIndexTag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(FileAttributesTag tag, ISwfStreamWriter writer) {
            writer.WriteBit(tag.Reserved0);
            writer.WriteBit(tag.UseDirectBlit);
            writer.WriteBit(tag.UseGPU);
            writer.WriteBit(tag.HasMetadata);
            writer.WriteBit(tag.AllowAbc);
            writer.WriteBit(tag.SuppressCrossDomainCaching);
            writer.WriteBit(tag.SwfRelativeUrls);
            writer.WriteBit(tag.UseNetwork);
            writer.WriteUnsignedBits(tag.Reserved, 24);
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(ImportAssets2Tag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(SymbolClassTag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16((ushort)tag.References.Count);
            foreach (var symbolRef in tag.References) {
                writer.WriteUInt16(symbolRef.SymbolID);
                writer.WriteString(symbolRef.SymbolName);
            }
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(MetadataTag tag, ISwfStreamWriter writer) {
            writer.WriteString(tag.Metadata);
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineScalingGridTag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineSceneAndFrameLabelDataTag tag, ISwfStreamWriter writer) {
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

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DoActionTag tag, ISwfStreamWriter writer) {
            var actionWriter = new ActionWriter(writer);
            foreach (var action in tag.ActionRecords) {
                actionWriter.WriteAction(action);
            }
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DoInitActionTag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.SpriteId);
            var actionWriter = new ActionWriter(writer);
            foreach (var action in tag.ActionRecords) {
                actionWriter.WriteAction(action);
            }
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DoABCTag tag, ISwfStreamWriter writer) {
            writer.WriteUInt32(tag.Flags);
            writer.WriteString(tag.Name);
            writer.WriteBytes(tag.ABCData);
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DoABCDefineTag tag, ISwfStreamWriter writer) {
            return null;
        }

        #endregion

        #region Shape tags

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineShapeTag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.ShapeID);
            writer.WriteRect(ref tag.ShapeBounds);

            writer.WriteFillStylesRGB(tag.FillStyles, false);
            writer.WriteLineStylesRGB(tag.LineStyles, false);
            writer.WriteShapeRecordsRGB(tag.ShapeRecords, new UnsignedBitsCount((uint)tag.FillStyles.Count).GetBits(), new UnsignedBitsCount((uint)tag.LineStyles.Count).GetBits());

            writer.FlushBits();
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineShape2Tag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.ShapeID);
            writer.WriteRect(ref tag.ShapeBounds);

            writer.WriteFillStylesRGB(tag.FillStyles, true);
            writer.WriteLineStylesRGB(tag.LineStyles, true);
            writer.WriteShapeRecordsRGB(tag.ShapeRecords, new UnsignedBitsCount((uint)tag.FillStyles.Count).GetBits(), new UnsignedBitsCount((uint)tag.LineStyles.Count).GetBits());

            writer.FlushBits();
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineShape3Tag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.ShapeID);
            writer.WriteRect(ref tag.ShapeBounds);

            writer.WriteFillStylesRGBA(tag.FillStyles);
            writer.WriteLineStylesRGBA(tag.LineStyles);
            writer.WriteShapeRecordsRGBA(tag.ShapeRecords, new UnsignedBitsCount((uint)tag.FillStyles.Count).GetBits(), new UnsignedBitsCount((uint)tag.LineStyles.Count).GetBits());

            writer.FlushBits();
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineShape4Tag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.ShapeID);
            writer.WriteRect(ref tag.ShapeBounds);
            writer.WriteRect(ref tag.EdgeBounds);
            writer.FlushBits();
            writer.WriteByte(tag.Flags);

            writer.WriteFillStylesRGBA(tag.FillStyles);
            writer.WriteLineStylesEx(tag.LineStyles);
            writer.WriteShapeRecordsEx(tag.ShapeRecords, new UnsignedBitsCount((uint)tag.FillStyles.Count).GetBits(), new UnsignedBitsCount((uint)tag.LineStyles.Count).GetBits());

            writer.FlushBits();
            return null;
        }

        #endregion

        #region Bitmap tags

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineBitsTag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.CharacterID);
            writer.WriteBytes(tag.JPEGData);
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(JPEGTablesTag tag, ISwfStreamWriter writer) {
            writer.WriteBytes(tag.JPEGData);
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineBitsJPEG2Tag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.CharacterID);
            if (tag.ImageData != null) writer.WriteBytes(tag.ImageData);
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineBitsJPEG3Tag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.CharacterID);
            writer.WriteUInt32((uint)tag.ImageData.Length);
            writer.WriteBytes(tag.ImageData);
            writer.WriteBytes(tag.BitmapAlphaData);
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineBitsJPEG4Tag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.CharacterID);
            writer.WriteUInt32((uint)tag.ImageData.Length);
            writer.WriteUInt16(tag.DeblockParam);
            writer.WriteBytes(tag.ImageData);
            writer.WriteBytes(tag.BitmapAlphaData);
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineBitsLosslessTag tag, ISwfStreamWriter writer) {
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

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineBitsLossless2Tag tag, ISwfStreamWriter writer) {
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

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineMorphShapeTag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineMorphShape2Tag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineFontTag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.FontID);
            foreach (var offset in tag.OffsetTable) {
                writer.WriteUInt16(offset);
            }
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineFontInfoTag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.FontID);
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineFontInfo2Tag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.FontID);
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineFont2Tag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.FontID);
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineFont3Tag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.FontID);

            writer.WriteBit(tag.HasLayout);
            writer.WriteBit(tag.ShiftJIS);
            writer.WriteBit(tag.SmallText);
            writer.WriteBit(tag.ANSI);

            writer.WriteBit(tag.WideOffsets);
            writer.WriteBit(tag.WideCodes);
            writer.WriteBit(tag.Italic);
            writer.WriteBit(tag.Bold);

            writer.WriteByte(tag.Language);
            var name = Encoding.UTF8.GetBytes(tag.FontName);
            writer.WriteByte((byte)name.Length);
            writer.WriteBytes(name);
            writer.WriteUInt16((ushort)tag.Glyphs.Count);

            var offsets = new List<uint>();
            var shapesData = SerializeGlyphsData(tag.Glyphs, offsets);

            var offsetBytes = (uint)(tag.WideOffsets ? 4 : 2);
            var offsetTableSize = offsetBytes * tag.Glyphs.Count;
            var firstShapeOffset = offsetTableSize + offsetBytes;

            WriteOffsets(writer, offsets, (uint) firstShapeOffset, tag.WideOffsets);

            var codeTableOffset = firstShapeOffset + (uint)shapesData.Length;
            if (tag.WideOffsets) {
                writer.WriteUInt32((uint) codeTableOffset);
            } else {
                writer.WriteUInt16((ushort)codeTableOffset);
            }

            writer.WriteBytes(shapesData);
            foreach (var glyph in tag.Glyphs) {
                if (tag.WideCodes) {
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
                    writer.WriteKerningRecord(kerningRecord, tag.WideCodes);
                }
            }
            return null;
        }

        private void WriteOffsets(ISwfStreamWriter writer, IEnumerable<uint> offsets, uint baseOffset, bool wideOffsets) {
            foreach (var offset in offsets) {
                var resOffset = offset + baseOffset;
                if (wideOffsets) {
                    writer.WriteUInt32(resOffset);
                } else {
                    writer.WriteUInt16((ushort)resOffset);
                }
            }
        }

        private byte[] SerializeGlyphsData(IEnumerable<Glyph> glyphs, IList<uint> offsets) {
            var shapesStream = new MemoryStream();
            var shapesSwfWriter = new SwfStreamWriter(shapesStream);
            foreach (var glyph in glyphs) {
                offsets.Add((uint)shapesStream.Position);
                shapesSwfWriter.WriteShapeRecordsRGB(glyph.Records, 1, 0);
                shapesSwfWriter.FlushBits();
            }
            return shapesStream.ToArray();
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineFont4Tag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.FontID);
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineFontAlignZonesTag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.FontID);
            writer.WriteUnsignedBits((byte)tag.CsmTableHint, 2);
            writer.WriteUnsignedBits(tag.Reserved, 6);

            foreach (var zoneArray in tag.ZoneTable) {
                writer.WriteByte((byte)zoneArray.Data.Count);
                foreach (var zoneData in zoneArray.Data) {
                    writer.WriteShortFloat(zoneData.Position);
                    writer.WriteShortFloat(zoneData.Size);
                }
                writer.WriteUnsignedBits(zoneArray.Reserved, 6);
                writer.WriteBit(zoneArray.ZoneX);
                writer.WriteBit(zoneArray.ZoneY);
            }

            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineFontNameTag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.FontID);
            writer.WriteString(tag.FontName);
            writer.WriteString(tag.FontCopyright);
            writer.FlushBits();
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineTextTag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.CharacterID);
            writer.WriteRect(ref tag.TextBounds);
            writer.WriteMatrix(ref tag.TextMatrix);
            var glyphBitsCounter = new UnsignedBitsCount(0);
            var advanceBitsCounter = new SignedBitsCount(0);
            foreach (var textRecord in tag.TextRecords) {
                foreach (var glyph in textRecord.Glyphs) {
                    glyphBitsCounter.AddValue(glyph.GlyphIndex);
                    advanceBitsCounter.AddValue(glyph.GlyphAdvance);
                }
            }
            var glyphBits = glyphBitsCounter.GetBits();
            var advanceBits = advanceBitsCounter.GetBits();

            writer.WriteByte((byte)glyphBits);
            writer.WriteByte((byte)advanceBits);
            foreach (var textRecord in tag.TextRecords) {
                writer.WriteTextRecordRGB(textRecord, glyphBits, advanceBits);
                writer.FlushBits();
            }
            writer.FlushBits();
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineText2Tag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.CharacterID);
            writer.WriteRect(ref tag.TextBounds);
            writer.WriteMatrix(ref tag.TextMatrix);
            var glyphBitsCounter = new UnsignedBitsCount(0);
            var advanceBitsCounter = new SignedBitsCount(0);
            foreach (var textRecord in tag.TextRecords) {
                foreach (var glyph in textRecord.Glyphs) {
                    glyphBitsCounter.AddValue(glyph.GlyphIndex);
                    advanceBitsCounter.AddValue(glyph.GlyphAdvance);
                }
            }
            var glyphBits = glyphBitsCounter.GetBits();
            var advanceBits = advanceBitsCounter.GetBits();

            writer.WriteByte((byte)glyphBits);
            writer.WriteByte((byte)advanceBits);
            foreach (var textRecord in tag.TextRecords) {
                writer.WriteTextRecordRGBA(textRecord, glyphBits, advanceBits);
                writer.FlushBits();
            }
            writer.FlushBits();
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineEditTextTag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.CharacterID);
            writer.WriteRect(tag.Bounds);

            writer.WriteBit(tag.InitialText != null);
            writer.WriteBit(tag.WordWrap);
            writer.WriteBit(tag.Multiline);
            writer.WriteBit(tag.Password);
            writer.WriteBit(tag.ReadOnly);
            writer.WriteBit(tag.TextColor.HasValue);
            writer.WriteBit(tag.MaxLength.HasValue);
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
            if (tag.TextColor.HasValue) {
                writer.WriteRGBA(tag.TextColor.Value);
            }
            if (tag.MaxLength.HasValue) {
                writer.WriteUInt16(tag.MaxLength.Value);
            }
            if (tag.HasLayout) {
                writer.WriteByte(tag.Align);
                writer.WriteUInt16(tag.LeftMargin);
                writer.WriteUInt16(tag.RightMargin);
                writer.WriteUInt16(tag.Indent);
                writer.WriteSInt16(tag.Leading);
            }
            writer.WriteString(tag.VariableName);
            if (tag.InitialText != null) {
                writer.WriteString(tag.InitialText);
            }
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(CSMTextSettingsTag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.TextID);
            writer.WriteUnsignedBits(tag.UseFlashType, 2);
            writer.WriteUnsignedBits(tag.GridFit, 3);
            writer.WriteUnsignedBits(tag.ReservedFlags, 3);
            writer.WriteSingle(tag.Thickness);
            writer.WriteSingle(tag.Sharpness);
            writer.WriteByte(tag.Reserved);
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineSoundTag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(StartSoundTag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(StartSound2Tag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(SoundStreamHeadTag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(SoundStreamHead2Tag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(SoundStreamBlockTag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineButtonTag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineButton2Tag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.ButtonID);
            writer.WriteUnsignedBits(tag.ReservedFlags, 7);
            writer.WriteBit(tag.TrackAsMenu);

            var mem = new MemoryStream();
            var buttonsWriter = new SwfStreamWriter(mem);
            foreach (var record in tag.Characters) {
                buttonsWriter.WriteButtonRecordEx(record);
            }
            var actionsOffset = tag.Conditions.Count > 0 ? (mem.Length + 2) : 0;
            writer.WriteUInt16((ushort)actionsOffset);

            writer.WriteBytes(mem.ToArray());

            if (tag.Conditions.Count > 0) {
                for (var i = 0; i < tag.Conditions.Count; i++) {
                    var cond = tag.Conditions[i];
                    var condMem = new MemoryStream();
                    var condWriter = new SwfStreamWriter(condMem);
                    condWriter.WriteButtonCondition(cond);

                    if (i != tag.Conditions.Count - 1) {
                        writer.WriteUInt16((ushort)(condMem.Length + 2));
                    } else {
                        writer.WriteUInt16(0);
                    }

                    writer.WriteBytes(condMem.ToArray());
                }
            }

            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineButtonCxformTag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineButtonSoundTag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineSpriteTag tag, ISwfStreamWriter writer) {
            writer.WriteUInt16(tag.SpriteID);
            writer.WriteUInt16(tag.FramesCount);
            foreach (var subtag in tag.Tags) {
                var subTagData = GetTagData(subtag);
                writer.WriteTagData(subTagData);
            }
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(Tags.VideoTags.DefineVideoStreamTag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(Tags.VideoTags.VideoFrameTag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DefineBinaryDataTag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(DebugIDTag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(ProductInfoTag tag, ISwfStreamWriter writer) {
            return null;
        }

        SwfTagData ISwfTagVisitor<ISwfStreamWriter, SwfTagData>.Visit(UnknownTag tag, ISwfStreamWriter writer) {
            writer.WriteBytes(tag.Data);
            return null;
        }
    }
}
