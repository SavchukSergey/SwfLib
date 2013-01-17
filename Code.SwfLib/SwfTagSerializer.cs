using System;
using System.IO;
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
    public class SwfTagSerializer : ISwfTagVisitor<object, SwfTagData> {

        private readonly SwfFile _file;

        public SwfTagSerializer(SwfFile file) {
            _file = file;
        }

        public SwfTagData GetTagData(SwfTagBase tag) {
            return tag.AcceptVistor(this, null);
        }

        //object ISwfTagVisitor.Visit(DefineFontAlignZonesTag tag) {
        //    var mem = new MemoryStream();
        //    var writer = new SwfStreamWriter(mem);
        //    writer.WriteUInt16(tag.FontID);
        //    writer.WriteByte(tag.CsmTableHint);

        //    foreach (var zoneArray in tag.Zones) {
        //        writer.WriteByte((byte)zoneArray.Data.Length);
        //        foreach (var zoneData in zoneArray.Data) {
        //            writer.WriteShortFloat(zoneData.Position);
        //            writer.WriteShortFloat(zoneData.Size);
        //        }
        //        writer.WriteByte((byte)zoneArray.Flags);
        //    }

        //    return new SwfTagData { Type = SwfTagType.DefineFontAlignZones, Data = mem.ToArray() };
        //}

        //public object Visit(DefineFontNameTag tag) {
        //    var mem = new MemoryStream();
        //    var writer = new SwfStreamWriter(mem);
        //    writer.WriteUInt16(tag.FontId);
        //    writer.WriteString(tag.FontName);
        //    writer.WriteString(tag.FontCopyright);
        //    writer.FlushBits();
        //    return new SwfTagData { Type = SwfTagType.DefineFontName, Data = mem.ToArray() };
        //}

        //object ISwfTagVisitor.Visit(DefineShapeTag tag) {
        //    var mem = new MemoryStream();
        //    var writer = new SwfStreamWriter(mem);
        //    writer.WriteUInt16(tag.ShapeID);
        //    writer.WriteRect(ref tag.ShapeBounds);
        //    writer.WriteShapeWithStyle(tag.Shapes);
        //    writer.FlushBits();
        //    return new SwfTagData { Type = SwfTagType.DefineShape, Data = mem.ToArray() };
        //}

        //public object Visit(DefineShape3Tag tag) {
        //    var mem = new MemoryStream();
        //    var writer = new SwfStreamWriter(mem);
        //    //TODO: Write other fields
        //    return new SwfTagData { Type = SwfTagType.DefineShape3, Data = mem.ToArray() };
        //}

        //public object Visit(DefineSpriteTag tag) {
        //    var mem = new MemoryStream();
        //    var writer = new SwfStreamWriter(mem);
        //    writer.WriteUInt16(tag.SpriteID);
        //    writer.WriteUInt16(tag.FramesCount);
        //    foreach (var subtag in tag.Tags) {
        //        SwfTagData subTagData = GetTagData(subtag);
        //        writer.WriteTagData(subTagData);
        //    }
        //    return new SwfTagData { Type = SwfTagType.DefineSprite, Data = mem.ToArray() };
        //}

        //public object Visit(DoActionTag tag) {
        //    var mem = new MemoryStream();
        //    var writer = new SwfStreamWriter(mem);
        //    //TODO: Write other fields
        //    return new SwfTagData { Type = SwfTagType.DoAction, Data = mem.ToArray() };
        //}

        //public object Visit(MetadataTag tag) {
        //    var mem = new MemoryStream();
        //    var writer = new SwfStreamWriter(mem);
        //    writer.WriteString(tag.Metadata);
        //    return new SwfTagData { Type = SwfTagType.Metadata, Data = mem.ToArray() };
        //}

        //public object Visit(ScriptLimitsTag tag) {
        //}

        //public object Visit(SwfTagBase tag) {
        //    throw new NotImplementedException();
        //}

        //public object Visit(UnknownTag tag) {
        //    return new SwfTagData { Type = tag.TagType, Data = tag.Data };
        //}

        #region Display list tags

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(PlaceObjectTag tag, object arg) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16(tag.CharacterID);
            writer.WriteUInt16(tag.Depth);
            writer.WriteMatrix(ref tag.Matrix);
            if (tag.ColorTransform.HasValue) {
                var transform = tag.ColorTransform.Value;
                writer.WriteColorTransformRGB(ref transform);
            }
            return new SwfTagData { Type = SwfTagType.PlaceObject, Data = mem.ToArray() };
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(PlaceObject2Tag tag, object arg) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
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
            return new SwfTagData { Type = SwfTagType.PlaceObject2, Data = mem.ToArray() };
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(PlaceObject3Tag tag, object arg) {
            var mem = new MemoryStream();
            //var writer = new SwfStreamWriter(mem);
            //TODO: put fields
            return new SwfTagData { Type = SwfTagType.PlaceObject3, Data = mem.ToArray() };

        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(RemoveObjectTag tag, object arg) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16(tag.CharacterID);
            writer.WriteUInt16(tag.Depth);
            return new SwfTagData { Type = SwfTagType.RemoveObject, Data = mem.ToArray() };
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(RemoveObject2Tag tag, object arg) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16(tag.Depth);
            return new SwfTagData { Type = SwfTagType.RemoveObject2, Data = mem.ToArray() };
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(ShowFrameTag tag, object arg) {
            return new SwfTagData { Type = SwfTagType.ShowFrame, Data = new byte[0] };
        }

        #endregion

        #region Control tags

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(SetBackgroundColorTag tag, object arg) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteRGB(ref tag.Color);
            return new SwfTagData { Type = SwfTagType.SetBackgroundColor, Data = mem.ToArray() };
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(FrameLabelTag tag, object arg) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteString(tag.Name);
            if (tag.IsAnchor) writer.WriteByte(1);
            return new SwfTagData { Type = SwfTagType.FrameLabel, Data = mem.ToArray() };
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(ProtectTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(EndTag tag, object arg) {
            return new SwfTagData { Type = SwfTagType.End, Data = new byte[0] };
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(ExportAssetsTag tag, object arg) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16((ushort)tag.Symbols.Count);
            foreach (var symbolref in tag.Symbols) {
                writer.WriteUInt16(symbolref.SymbolID);
                writer.WriteString(symbolref.SymbolName);
            }
            return new SwfTagData { Type = SwfTagType.ExportAssets, Data = mem.ToArray() };
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(ImportAssetsTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(EnableDebuggerTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(EnableDebugger2Tag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(ScriptLimitsTag tag, object arg) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16(tag.MaxRecursionDepth);
            writer.WriteUInt16(tag.ScriptTimeoutSeconds);
            return new SwfTagData { Type = SwfTagType.ScriptLimits, Data = mem.ToArray() };
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(SetTabIndexTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(FileAttributesTag tag, object arg) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt32((uint)tag.Attributes);
            return new SwfTagData { Type = SwfTagType.FileAttributes, Data = mem.ToArray() };
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(ImportAssets2Tag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(SymbolClassTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(MetadataTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineScalingGridTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineSceneAndFrameLabelDataTag tag, object arg) {
            throw new NotImplementedException();
        }

        #endregion

        #region Action tags

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DoActionTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DoInitActionTag tag, object arg) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16(tag.SpriteId);
            writer.WriteBytes(tag.RestData);
            return new SwfTagData { Type = SwfTagType.DoInitAction, Data = mem.ToArray() };
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DoABCTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DoABCDefineTag tag, object arg) {
            throw new NotImplementedException();
        }

        #endregion

        #region Shape tags

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineShapeTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineShape2Tag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineShape3Tag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineShape4Tag tag, object arg) {
            throw new NotImplementedException();
        }

        #endregion

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineBitsTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(JPEGTablesTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineBitsJPEG2Tag tag, object arg) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16(tag.CharacterID);
            if (tag.ImageData != null) writer.WriteBytes(tag.ImageData);
            return new SwfTagData { Type = SwfTagType.DefineBitsJPEG2, Data = mem.ToArray() };
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineBitsJPEG3Tag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineBitsLosslessTag tag, object arg) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
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
            return new SwfTagData { Type = SwfTagType.DefineBitsLossless, Data = mem.ToArray() };
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineBitsLossless2Tag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineBitsJPEG4Tag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(Tags.ShapeMorphingTags.DefineMorphShapeTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(Tags.ShapeMorphingTags.DefineMorphShape2Tag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineFontTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineFontInfoTag tag, object arg) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16(tag.FontId);
            writer.WriteBytes(tag.RestData);
            return new SwfTagData { Type = SwfTagType.DefineFontInfo, Data = mem.ToArray() };
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineFontInfo2Tag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineFont2Tag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineFont3Tag tag, object arg) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16(tag.FontId);
            writer.WriteByte((byte)tag.Attributes);
            writer.WriteByte(tag.Language);
            var name = Encoding.UTF8.GetBytes(tag.FontName);
            writer.WriteByte((byte)name.Length);
            writer.WriteBytes(name);
            writer.WriteUInt16((ushort)tag.Glyphs.Length);
            writer.WriteBytes(tag.RestData);
            return new SwfTagData { Type = SwfTagType.DefineFont3, Data = mem.ToArray() };
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineFontAlignZonesTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineFontNameTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineTextTag tag, object arg) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
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
            return new SwfTagData { Type = SwfTagType.DefineText, Data = mem.ToArray() };
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineText2Tag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineEditTextTag tag, object arg) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
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
            return new SwfTagData { Type = SwfTagType.DefineEditText, Data = mem.ToArray() };
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(CSMTextSettingsTag tag, object arg) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16(tag.TextID);
            writer.WriteUnsignedBits(tag.UseFlashType, 2);
            writer.WriteUnsignedBits(tag.GridFit, 3);
            writer.WriteUnsignedBits(tag.ReservedFlags, 3);
            writer.WriteSingle(tag.Thickness);
            writer.WriteSingle(tag.Sharpness);
            writer.WriteByte(tag.Reserved);
            return new SwfTagData { Type = SwfTagType.CSMTextSettings, Data = mem.ToArray() };
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineFont4Tag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(Tags.SoundTags.DefineSoundTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(Tags.SoundTags.StartSoundTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(Tags.SoundTags.StartSound2Tag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(Tags.SoundTags.SoundStreamHeadTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(Tags.SoundTags.SoundStreamHead2Tag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(Tags.SoundTags.SoundStreamBlockTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineButtonTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineButton2Tag tag, object arg) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            //TODO: put fields
            return new SwfTagData { Type = SwfTagType.DefineButton2, Data = mem.ToArray() };
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineButtonCxformTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineButtonSoundTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineSpriteTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(Tags.VideoTags.DefineVideoStreamTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(Tags.VideoTags.VideoFrameTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DefineBinaryDataTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(DebugIDTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(ProductInfoTag tag, object arg) {
            throw new NotImplementedException();
        }

        SwfTagData ISwfTagVisitor<object, SwfTagData>.Visit(UnknownTag tag, object arg) {
            throw new NotImplementedException();
        }
    }
}
