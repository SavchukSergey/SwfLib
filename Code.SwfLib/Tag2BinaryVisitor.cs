using System;
using System.IO;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.BitmapTags;
using Code.SwfLib.Tags.ControlTags;
using Code.SwfLib.Tags.DisplayListTags;
using Code.SwfLib.Tags.DynamicTextTags;
using Code.SwfLib.Tags.FontTags;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib
{
    public class Tag2BinaryVisitor : ISwfTagVisitor
    {

        public SwfTagData GetTagData(SwfTagBase tag)
        {
            return (SwfTagData) tag.AcceptVistor(this);
        }

        public object Visit(CSMTextSettingsTag tag)
        {
            throw new NotImplementedException();
        }

        object ISwfTagVisitor.Visit(DefineBitsJPEG2Tag tag)
        {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt16(tag.ObjectID);
            writer.WriteBytes(tag.ImageData);
            return new SwfTagData { Type = SwfTagType.DefineBitsJPEG2, Data = mem.ToArray() };
        }

        public object Visit(DefineBitsLosslessTag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(DefineButton2Tag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(DefineEditTextTag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(DefineFont3Tag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(DefineFontAlignZonesTag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(DefineFontNameTag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(DefineShapeTag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(DefineShape3Tag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(DefineSpriteTag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(DefineTextTag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(DoActionTag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(DoInitActionTag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(EndTag tag)
        {
            return new SwfTagData { Type = SwfTagType.End, Data = new byte[0] };
        }

        public object Visit(ExportTag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(FileAttributesTag tag)
        {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteUInt32((uint)tag.Attributes);
            return new SwfTagData { Type = SwfTagType.FileAttributes, Data = mem.ToArray() };
        }

        public object Visit(FrameLabelTag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(MetadataTag tag)
        {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteString(tag.Metadata);
            return new SwfTagData { Type = SwfTagType.MetaData, Data = mem.ToArray() };
        }

        public object Visit(PlaceObject2Tag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(PlaceObject3Tag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(RemoveObject2Tag tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(SetBackgroundColorTag tag)
        {
            var mem = new MemoryStream();
            var writer = new SwfStreamWriter(mem);
            writer.WriteRGB(tag.Color);
            return new SwfTagData { Type = SwfTagType.SetBackgroundColor, Data = mem.ToArray() };
        }

        public object Visit(ShowFrameTag tag)
        {
            return new SwfTagData { Type = SwfTagType.ShowFrame, Data = new byte[0] };
        }

        public object Visit(SwfTagBase tag)
        {
            throw new NotImplementedException();
        }

        public object Visit(UnknownTag tag)
        {
            throw new NotImplementedException();
        }
    }
}
