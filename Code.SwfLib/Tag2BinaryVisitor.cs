using System;
using System.IO;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.BitmapTags;
using Code.SwfLib.Tags.ControlTags;
using Code.SwfLib.Tags.DisplayListTags;
using Code.SwfLib.Tags.DynamicTextTags;
using Code.SwfLib.Tags.FontTags;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib {
    public class Tag2BinaryVisitor : ISwfTagVisitor {

        public SwfTagData GetTagData(SwfTagBase tag) {
            return (SwfTagData)tag.AcceptVistor(this);
        }

        public object Visit(CSMTextSettingsTag tag) {
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

        object ISwfTagVisitor.Visit(DefineBitsJPEG2Tag tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16(tag.CharacterID);
            if (tag.ImageData != null) writer.WriteBytes(tag.ImageData);
            return new SwfTagData { Type = SwfTagType.DefineBitsJPEG2, Data = mem.ToArray() };
        }

        object ISwfTagVisitor.Visit(DefineBitsLosslessTag tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16(tag.ObjectID);
            //TODO: Put other fields
            return new SwfTagData { Type = SwfTagType.DefineBitsLossless2, Data = mem.ToArray() };
        }

        public object Visit(DefineButton2Tag tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            //TODO: put fields
            return new SwfTagData { Type = SwfTagType.DefineButton2, Data = mem.ToArray() };
        }

        public object Visit(DefineEditTextTag tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16(tag.CharacterID);
            writer.WriteRect(tag.Bounds);
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
            //TODO: Write other fields
            return new SwfTagData { Type = SwfTagType.DefineEditText, Data = mem.ToArray() };
        }

        public object Visit(DefineFont3Tag tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16(tag.ObjectID);
            writer.WriteByte((byte)tag.Attributes);
            //TODO: Write other fields
            writer.FlushBits();
            return new SwfTagData { Type = SwfTagType.DefineFont3, Data = mem.ToArray() };
        }

        public object Visit(DefineFontAlignZonesTag tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16(tag.ObjectID);
            //TODO: Write other fields
            return new SwfTagData { Type = SwfTagType.DefineFontAlignZones, Data = mem.ToArray() };
        }

        public object Visit(DefineFontNameTag tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16(tag.FontId);
            writer.WriteString(tag.FontName);
            writer.WriteString(tag.FontCopyright);
            writer.FlushBits();
            return new SwfTagData { Type = SwfTagType.DefineFontName, Data = mem.ToArray() };
        }

        public object Visit(DefineShapeTag tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16(tag.ShapeID);
            writer.WriteRect(tag.ShapeBounds);
            writer.WriteShapeWithStyle(tag.Shapes);
            writer.FlushBits();
            return new SwfTagData { Type = SwfTagType.DefineShape, Data = mem.ToArray() };
        }

        public object Visit(DefineShape3Tag tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            //TODO: Write other fields
            return new SwfTagData { Type = SwfTagType.DefineShape3, Data = mem.ToArray() };
        }

        public object Visit(DefineSpriteTag tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16(tag.SpriteID);
            writer.WriteUInt16(tag.FramesCount);
            foreach (var subtag in tag.Tags) {
                var subTagData = GetTagData(subtag);
                writer.WriteTagData(subTagData);
            }
            return new SwfTagData { Type = SwfTagType.DefineSprite, Data = mem.ToArray() };
        }

        object ISwfTagVisitor.Visit(DefineTextTag tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16(tag.CharacterID);
            writer.WriteRect(tag.TextBounds);
            writer.WriteMatrix(tag.TextMatrix);
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

        public object Visit(DoActionTag tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            //TODO: Write other fields
            return new SwfTagData { Type = SwfTagType.DoAction, Data = mem.ToArray() };
        }

        public object Visit(DoInitActionTag tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            //TODO: Write other fields
            return new SwfTagData { Type = SwfTagType.DoInitAction, Data = mem.ToArray() };
        }

        public object Visit(EndTag tag) {
            return new SwfTagData { Type = SwfTagType.End, Data = new byte[0] };
        }

        public object Visit(ExportTag tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16((ushort)tag.Symbols.Count);
            foreach (var symbolref in tag.Symbols) {
                writer.WriteUInt16(symbolref.SymbolID);
                writer.WriteString(symbolref.SymbolName);
            }
            return new SwfTagData { Type = SwfTagType.Export, Data = mem.ToArray() };
        }

        public object Visit(FileAttributesTag tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt32((uint)tag.Attributes);
            return new SwfTagData { Type = SwfTagType.FileAttributes, Data = mem.ToArray() };
        }

        public object Visit(FrameLabelTag tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteString(tag.Name);
            if (tag.IsAnchor) writer.WriteByte(1);
            return new SwfTagData { Type = SwfTagType.FrameLabel, Data = mem.ToArray() };
        }

        public object Visit(MetadataTag tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteString(tag.Metadata);
            return new SwfTagData { Type = SwfTagType.MetaData, Data = mem.ToArray() };
        }

        object ISwfTagVisitor.Visit(PlaceObject2Tag tag) {
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
            if (tag.HasCharacter) writer.WriteUInt16(tag.CharacterID.Value);
            if (tag.HasMatrix) writer.WriteMatrix(tag.Matrix.Value);
            if (tag.HasColorTransform) writer.WriteColorTransformRGB(tag.ColorTransform.Value);
            if (tag.HasRatio) writer.WriteUInt16(tag.Ratio.Value);
            if (tag.HasName) writer.WriteString(tag.Name);
            if (tag.HasClipDepth) writer.WriteUInt16(tag.ClipDepth.Value);
            if (tag.HasClipActions) {
                throw new NotImplementedException();
            }
            return new SwfTagData { Type = SwfTagType.PlaceObject2, Data = mem.ToArray() };
        }

        public object Visit(PlaceObject3Tag tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            //TODO: put fields
            return new SwfTagData { Type = SwfTagType.PlaceObject3, Data = mem.ToArray() };
        }

        public object Visit(RemoveObject2Tag tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16(tag.Depth);
            return new SwfTagData { Type = SwfTagType.RemoveObject2, Data = mem.ToArray() };
        }

        public object Visit(SetBackgroundColorTag tag) {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteRGB(tag.Color);
            return new SwfTagData { Type = SwfTagType.SetBackgroundColor, Data = mem.ToArray() };
        }

        public object Visit(ShowFrameTag tag) {
            return new SwfTagData { Type = SwfTagType.ShowFrame, Data = new byte[0] };
        }

        public object Visit(SwfTagBase tag) {
            throw new NotImplementedException();
        }

        public object Visit(UnknownTag tag) {
            return new SwfTagData { Type = tag.RawData.Type, Data = tag.RawData.Data };
        }
    }
}
