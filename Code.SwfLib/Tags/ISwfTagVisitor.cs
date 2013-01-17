using System;
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
using Code.SwfLib.Tags.VideoTags;

namespace Code.SwfLib.Tags {
    public interface ISwfTagVisitor {

        object Visit(CSMTextSettingsTag tag);

        object Visit(DefineBitsJPEG2Tag tag);

        object Visit(DefineBitsLosslessTag tag);

        object Visit(DefineButton2Tag tag);

        object Visit(DefineEditTextTag tag);

        object Visit(DefineFont3Tag tag);

        object Visit(DefineFontAlignZonesTag tag);

        object Visit(DefineFontInfoTag tag);

        object Visit(DefineFontNameTag tag);

        object Visit(DefineShapeTag tag);

        object Visit(DefineShape3Tag tag);

        object Visit(DefineSpriteTag tag);

        object Visit(DefineTextTag tag);

        object Visit(DoActionTag tag);

        object Visit(DoInitActionTag tag);

        object Visit(EndTag tag);

        object Visit(ExportAssetsTag tag);

        object Visit(FileAttributesTag tag);

        object Visit(FrameLabelTag tag);

        object Visit(MetadataTag tag);

        object Visit(PlaceObjectTag tag);

        object Visit(PlaceObject2Tag tag);

        object Visit(PlaceObject3Tag tag);

        object Visit(RemoveObjectTag tag);

        object Visit(RemoveObject2Tag tag);

        object Visit(SetBackgroundColorTag tag);

        object Visit(ScriptLimitsTag tag);

        object Visit(ShowFrameTag tag);

        object Visit(SwfTagBase tag);

        object Visit(UnknownTag tag);

    }

    public interface ISwfTagVisitor<TArg, TResult> {

        #region Display list tags

        TResult Visit(PlaceObjectTag tag, TArg arg);

        TResult Visit(PlaceObject2Tag tag, TArg arg);

        TResult Visit(PlaceObject3Tag tag, TArg arg);

        TResult Visit(RemoveObjectTag tag, TArg arg);

        TResult Visit(RemoveObject2Tag tag, TArg arg);

        TResult Visit(ShowFrameTag tag, TArg arg);

        #endregion

        #region Control tags

        TResult Visit(SetBackgroundColorTag tag, TArg arg);

        TResult Visit(FrameLabelTag tag, TArg arg);

        TResult Visit(ProtectTag tag, TArg arg);

        TResult Visit(EndTag tag, TArg arg);

        TResult Visit(ExportAssetsTag tag, TArg arg);

        TResult Visit(ImportAssetsTag tag, TArg arg);

        TResult Visit(EnableDebuggerTag tag, TArg arg);

        TResult Visit(EnableDebugger2Tag tag, TArg arg);

        TResult Visit(ScriptLimitsTag tag, TArg arg);

        TResult Visit(SetTabIndexTag tag, TArg arg);

        TResult Visit(FileAttributesTag tag, TArg arg);

        TResult Visit(ImportAssets2Tag tag, TArg arg);

        TResult Visit(SymbolClassTag tag, TArg arg);

        TResult Visit(MetadataTag tag, TArg arg);

        TResult Visit(DefineScalingGridTag tag, TArg arg);

        TResult Visit(DefineSceneAndFrameLabelDataTag tag, TArg arg);

        #endregion

        #region Action tags

        TResult Visit(DoActionTag tag, TArg arg);

        TResult Visit(DoInitActionTag tag, TArg arg);

        TResult Visit(DoABCTag tag, TArg arg);

        TResult Visit(DoABCDefineTag tag, TArg arg);

        #endregion

        #region Shape tags

        TResult Visit(DefineShapeTag tag, TArg arg);

        TResult Visit(DefineShape2Tag tag, TArg arg);

        TResult Visit(DefineShape3Tag tag, TArg arg);

        TResult Visit(DefineShape4Tag tag, TArg arg);

        #endregion

        #region Bitmap tags

        TResult Visit(DefineBitsTag tag, TArg arg);

        TResult Visit(JPEGTablesTag tag, TArg arg);

        TResult Visit(DefineBitsJPEG2Tag tag, TArg arg);

        TResult Visit(DefineBitsJPEG3Tag tag, TArg arg);

        TResult Visit(DefineBitsLosslessTag tag, TArg arg);

        TResult Visit(DefineBitsLossless2Tag tag, TArg arg);

        TResult Visit(DefineBitsJPEG4Tag tag, TArg arg);

        #endregion

        #region Shape morphing tags

        TResult Visit(DefineMorphShapeTag tag, TArg arg);

        TResult Visit(DefineMorphShape2Tag tag, TArg arg);

        #endregion

        #region Font tags

        TResult Visit(DefineFontTag tag, TArg arg);

        TResult Visit(DefineFontInfoTag tag, TArg arg);

        TResult Visit(DefineFontInfo2Tag tag, TArg arg);

        TResult Visit(DefineFont2Tag tag, TArg arg);

        TResult Visit(DefineFont3Tag tag, TArg arg);

        TResult Visit(DefineFontAlignZonesTag tag, TArg arg);

        TResult Visit(DefineFontNameTag tag, TArg arg);

        #endregion

        #region Text tags

        TResult Visit(DefineTextTag tag, TArg arg);

        TResult Visit(DefineText2Tag tag, TArg arg);

        TResult Visit(DefineEditTextTag tag, TArg arg);

        TResult Visit(CSMTextSettingsTag tag, TArg arg);

        TResult Visit(DefineFont4Tag tag, TArg arg);

        #endregion

        #region Sound tags

        TResult Visit(DefineSoundTag tag, TArg arg);

        TResult Visit(StartSoundTag tag, TArg arg);

        TResult Visit(StartSound2Tag tag, TArg arg);

        TResult Visit(SoundStreamHeadTag tag, TArg arg);

        TResult Visit(SoundStreamHead2Tag tag, TArg arg);

        TResult Visit(SoundStreamBlockTag tag, TArg arg);

        #endregion

        #region Button tags

        TResult Visit(DefineButtonTag tag, TArg arg);

        TResult Visit(DefineButton2Tag tag, TArg arg);

        TResult Visit(DefineButtonCxformTag tag, TArg arg);

        TResult Visit(DefineButtonSoundTag tag, TArg arg);
        
        #endregion

        #region Sprites and movie clips

        TResult Visit(DefineSpriteTag tag, TArg arg);
        
        #endregion

        #region Video tags

        TResult Visit(DefineVideoStreamTag tag, TArg arg);

        TResult Visit(VideoFrameTag tag, TArg arg);

        #endregion

        //TResult Visit(SwfTagBase tag, TArg arg);

        TResult Visit(DefineBinaryDataTag tag, TArg arg);

        TResult Visit(DebugIDTag tag, TArg arg);

        TResult Visit(ProductInfoTag tag, TArg arg);

        TResult Visit(UnknownTag tag, TArg arg);

    }
}
