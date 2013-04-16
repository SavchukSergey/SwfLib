using System.Collections.Generic;
using Code.SwfLib.SwfMill.TagFormatting;
using Code.SwfLib.SwfMill.TagFormatting.ActionTags;
using Code.SwfLib.SwfMill.TagFormatting.BitmapTags;
using Code.SwfLib.SwfMill.TagFormatting.ButtonTags;
using Code.SwfLib.SwfMill.TagFormatting.ControlTags;
using Code.SwfLib.SwfMill.TagFormatting.DisplayListTags;
using Code.SwfLib.SwfMill.TagFormatting.ShapeTags;
using Code.SwfLib.SwfMill.TagFormatting.SoundTags;
using Code.SwfLib.SwfMill.TagFormatting.TextTags;
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
using SwfLib.SwfMill.TagFormatting;
using SwfLib.SwfMill.TagFormatting.ActionTags;
using SwfLib.SwfMill.TagFormatting.BitmapTags;
using SwfLib.SwfMill.TagFormatting.ControlTags;
using SwfLib.SwfMill.TagFormatting.DisplayListTags;
using SwfLib.SwfMill.TagFormatting.FontTags;
using SwfLib.SwfMill.TagFormatting.ShapeMorphingTags;
using SwfLib.SwfMill.TagFormatting.ShapeTags;
using SwfLib.SwfMill.TagFormatting.SoundTags;
using SwfLib.SwfMill.TagFormatting.TextTags;
using SwfLib.SwfMill.TagFormatting.VideoTags;
using SwfLib.Tags;
using SwfLib.Tags.ActionsTags;
using SwfLib.Tags.BitmapTags;
using SwfLib.Tags.ButtonTags;
using SwfLib.Tags.ControlTags;
using SwfLib.Tags.DisplayListTags;
using SwfLib.Tags.FontTags;
using SwfLib.Tags.ShapeMorphingTags;
using SwfLib.Tags.ShapeTags;
using SwfLib.Tags.VideoTags;

namespace Code.SwfLib.SwfMill {
    public class TagFormatterFactory : ISwfTagVisitor<object, ITagFormatter> {
        
        private readonly ushort _version;

        private readonly Dictionary<SwfTagType, ITagFormatter> _cache = new Dictionary<SwfTagType, ITagFormatter>();

        public TagFormatterFactory(ushort version) {
            _version = version;
        }

        public ITagFormatter GetFormatter(SwfTagBase tag) {
            var type = tag.TagType;
            ITagFormatter formatter;
            if (!_cache.TryGetValue(type, out formatter)) {
                formatter = tag.AcceptVistor(this, null);
                _cache[type] = formatter;
            }
            return formatter;
        }

        #region Display list tags

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(PlaceObjectTag tag, object arg) {
            return new PlaceObjectTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(PlaceObject2Tag tag, object arg) {
            return new PlaceObject2TagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(PlaceObject3Tag tag, object arg) {
            return new PlaceObject3TagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(RemoveObjectTag tag, object arg) {
            return new RemoveObjectTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(RemoveObject2Tag tag, object arg) {
            return new RemoveObject2TagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(ShowFrameTag tag, object arg) {
            return new ShowFrameTagFormatter();
        }

        #endregion

        #region Control tags

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(SetBackgroundColorTag tag, object arg) {
            return new SetBackgroundColorTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(FrameLabelTag tag, object arg) {
            return new FrameLabelTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(ProtectTag tag, object arg) {
            return new ProtectTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(EndTag tag, object arg) {
            return new EndTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(ExportAssetsTag tag, object arg) {
            return new ExportAssetsTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(ImportAssetsTag tag, object arg) {
            return new ImportAssetsTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(EnableDebuggerTag tag, object arg) {
            return new EnableDebuggerTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(EnableDebugger2Tag tag, object arg) {
            return new EnableDebugger2TagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(ScriptLimitsTag tag, object arg) {
            return new ScriptLimitsTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(SetTabIndexTag tag, object arg) {
            return new SetTabIndexTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(FileAttributesTag tag, object arg) {
            return new FileAttributesTagFormatter(_version);
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(ImportAssets2Tag tag, object arg) {
            return new ImportAssets2TagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(SymbolClassTag tag, object arg) {
            return new SymbolClassTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(MetadataTag tag, object arg) {
            return new MetadataTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineScalingGridTag tag, object arg) {
            return new DefineScalingGridTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineSceneAndFrameLabelDataTag tag, object arg) {
            return new DefineSceneAndFrameLabelDataTagFormatter();
        }

        #endregion

        #region Action tags

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DoActionTag tag, object arg) {
            return new DoActionTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DoInitActionTag tag, object arg) {
            return new DoInitActionTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DoABCTag tag, object arg) {
            return new DoABCTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DoABCDefineTag tag, object arg) {
            return new DoABCDefineTagFormatter();
        }

        #endregion

        #region Shape tags

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineShapeTag tag, object arg) {
            return new DefineShapeTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineShape2Tag tag, object arg) {
            return new DefineShape2TagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineShape3Tag tag, object arg) {
            return new DefineShape3TagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineShape4Tag tag, object arg) {
            return new DefineShape4TagFormatter();
        }

        #endregion

        #region Bitmap tags

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineBitsTag tag, object arg) {
            return new DefineBitsTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(JPEGTablesTag tag, object arg) {
            return new JPEGTablesTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineBitsJPEG2Tag tag, object arg) {
            return new DefineBitsJPEG2TagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineBitsJPEG3Tag tag, object arg) {
            return new DefineBitsJPEG3TagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineBitsLosslessTag tag, object arg) {
            return new DefineBitsLosslessTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineBitsLossless2Tag tag, object arg) {
            return new DefineBitsLossless2TagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineBitsJPEG4Tag tag, object arg) {
            return new DefineBitsJPEG4TagFormatter();
        }

        #endregion

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineMorphShapeTag tag, object arg) {
            return new DefineMorphShapeTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineMorphShape2Tag tag, object arg) {
            return new DefineMorphShape2TagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineFontTag tag, object arg) {
            return new DefineFontTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineFontInfoTag tag, object arg) {
            return new DefineFontInfoTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineFontInfo2Tag tag, object arg) {
            return new DefineFontInfo2TagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineFont2Tag tag, object arg) {
            return new DefineFont2TagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineFont3Tag tag, object arg) {
            return new DefineFont3TagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineFontAlignZonesTag tag, object arg) {
            return new DefineFontAlignZonesTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineFontNameTag tag, object arg) {
            return new DefineFontNameTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineTextTag tag, object arg) {
            return new DefineTextTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineText2Tag tag, object arg) {
            return new DefineText2TagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineEditTextTag tag, object arg) {
            return new DefineEditTextTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(CSMTextSettingsTag tag, object arg) {
            return new CSMTextSettingsTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineFont4Tag tag, object arg) {
            return new DefineFont4TagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineSoundTag tag, object arg) {
            return new DefineSoundTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(StartSoundTag tag, object arg) {
            return new StartSoundTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(StartSound2Tag tag, object arg) {
            return new StartSound2TagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(SoundStreamHeadTag tag, object arg) {
            return new SoundStreamHeadTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(SoundStreamHead2Tag tag, object arg) {
            return new SoundStreamHead2TagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(SoundStreamBlockTag tag, object arg) {
            return new SoundStreamBlockTagFormatter();
        }

        #region Button tags

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineButtonTag tag, object arg) {
            return new DefineButtonTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineButton2Tag tag, object arg) {
            return new DefineButton2TagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineButtonCxformTag tag, object arg) {
            return new DefineButtonCxformTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineButtonSoundTag tag, object arg) {
            return new DefineButtonSoundTagFormatter();
        }

        #endregion

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineSpriteTag tag, object arg) {
            return new DefineSpriteTagFormatter(_version);
        }

        #region Video tags

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineVideoStreamTag tag, object arg) {
            return new DefineVideoStreamTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(VideoFrameTag tag, object arg) {
            return new VideoFrameTagFormatter();
        }

        #endregion

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DefineBinaryDataTag tag, object arg) {
            return new DefineBinaryDataTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(DebugIDTag tag, object arg) {
            return new DebugIDTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(ProductInfoTag tag, object arg) {
            return new ProductInfoTagFormatter();
        }

        ITagFormatter ISwfTagVisitor<object, ITagFormatter>.Visit(UnknownTag tag, object arg) {
            return new UnknownTagFormatter();
        }
    }
}
