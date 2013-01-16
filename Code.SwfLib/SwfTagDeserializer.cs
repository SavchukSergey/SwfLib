using System;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.Actions;
using Code.SwfLib.Tags.BitmapTags;
using Code.SwfLib.Tags.ControlTags;
using Code.SwfLib.Tags.DisplayListTags;
using Code.SwfLib.Tags.DynamicTextTags;
using Code.SwfLib.Tags.FontTags;
using Code.SwfLib.Tags.ShapeTags;

namespace Code.SwfLib {
    public class SwfTagDeserializer : ISwfTagVisitor {

        public SwfTagData TagData { get; set; }

        public SwfFile SwfFile { get; set; }

        public object Visit(CSMTextSettingsTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(DefineBitsJPEG2Tag tag) {
            throw new NotImplementedException();
        }

        public object Visit(DefineBitsLosslessTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(DefineButton2Tag tag) {
            throw new NotImplementedException();
        }

        public object Visit(DefineEditTextTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(DefineFont3Tag tag) {
            return SwfTagReader.ReadDefineFont3Tag(TagData);
        }

        public object Visit(DefineFontAlignZonesTag tag) {
            var reader = new SwfTagReader(SwfFile);
            return reader.ReadDefineFontAlignZonesTag(TagData);
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

        public object Visit(DefineSpriteTag tag) {
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

        public object Visit(EndTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(ExportTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(FileAttributesTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(FrameLabelTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(MetadataTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(PlaceObjectTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(PlaceObject2Tag tag) {
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

        public object Visit(SetBackgroundColorTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(ScriptLimitsTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(ShowFrameTag tag) {
            throw new NotImplementedException();
        }

        public object Visit(SwfTagBase tag) {
            throw new NotImplementedException();
        }

        public object Visit(UnknownTag tag) {
            throw new NotImplementedException();
        }
    }
}
