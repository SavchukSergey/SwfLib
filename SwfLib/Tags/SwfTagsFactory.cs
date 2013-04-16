using Code.SwfLib.Tags;
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

namespace SwfLib.Tags {
    public class SwfTagsFactory {

        public SwfTagBase Create(SwfTagType tagType) {
            switch (tagType) {
                case SwfTagType.End:
                    return new EndTag();
                case SwfTagType.ShowFrame:
                    return new ShowFrameTag();
                case SwfTagType.DefineShape:
                    return new DefineShapeTag();
                case SwfTagType.PlaceObject:
                    return new PlaceObjectTag();
                case SwfTagType.RemoveObject:
                    return new RemoveObjectTag();
                case SwfTagType.DefineBits:
                    return new DefineBitsTag();
                case SwfTagType.DefineButton:
                    return new DefineButtonTag();
                case SwfTagType.JPEGTables:
                    return new JPEGTablesTag();
                case SwfTagType.SetBackgroundColor:
                    return new SetBackgroundColorTag();
                case SwfTagType.DefineFont:
                    return new DefineFontTag();
                case SwfTagType.DefineText:
                    return new DefineTextTag();
                case SwfTagType.DoAction:
                    return new DoActionTag();
                case SwfTagType.DefineFontInfo:
                    return new DefineFontInfoTag();
                case SwfTagType.DefineSound:
                    return new DefineSoundTag();
                case SwfTagType.StartSound:
                    return new StartSoundTag();
                case SwfTagType.DefineButtonSound:
                    return new DefineButtonSoundTag();
                case SwfTagType.SoundStreamHead:
                    return new SoundStreamHeadTag();
                case SwfTagType.SoundStreamBlock:
                    return new SoundStreamBlockTag();
                case SwfTagType.DefineBitsLossless:
                    return new DefineBitsLosslessTag();
                case SwfTagType.DefineBitsJPEG2:
                    return new DefineBitsJPEG2Tag();
                case SwfTagType.DefineShape2:
                    return new DefineShape2Tag();
                case SwfTagType.DefineButtonCxform:
                    return new DefineButtonCxformTag();
                case SwfTagType.Protect:
                    return new ProtectTag();
                case SwfTagType.PlaceObject2:
                    return new PlaceObject2Tag();
                case SwfTagType.RemoveObject2:
                    return new RemoveObject2Tag();
                case SwfTagType.DefineShape3:
                    return new DefineShape3Tag();
                case SwfTagType.DefineText2:
                    return new DefineText2Tag();
                case SwfTagType.DefineButton2:
                    return new DefineButton2Tag();
                case SwfTagType.DefineBitsJPEG3:
                    return new DefineBitsJPEG3Tag();
                case SwfTagType.DefineBitsLossless2:
                    return new DefineBitsLossless2Tag();
                case SwfTagType.DefineEditText:
                    return new DefineEditTextTag();
                case SwfTagType.DefineSprite:
                    return new DefineSpriteTag();
                case SwfTagType.FrameLabel:
                    return new FrameLabelTag();
                case SwfTagType.SoundStreamHead2:
                    return new SoundStreamHead2Tag();
                case SwfTagType.DefineMorphShape:
                    return new DefineMorphShapeTag();
                case SwfTagType.DefineFont2:
                    return new DefineFont2Tag();
                case SwfTagType.ExportAssets:
                    return new ExportAssetsTag();
                case SwfTagType.ImportAssets:
                    return new ImportAssetsTag();
                case SwfTagType.EnableDebugger:
                    return new EnableDebuggerTag();
                case SwfTagType.DoInitAction:
                    return new DoInitActionTag();
                case SwfTagType.DefineVideoStream:
                    return new DefineVideoStreamTag();
                case SwfTagType.VideoFrame:
                    return new VideoFrameTag();
                case SwfTagType.DefineFontInfo2:
                    return new DefineFontInfo2Tag();
                case SwfTagType.EnableDebugger2:
                    return new EnableDebugger2Tag();
                case SwfTagType.ScriptLimits:
                    return new ScriptLimitsTag();
                case SwfTagType.SetTabIndex:
                    return new SetTabIndexTag();
                case SwfTagType.FileAttributes:
                    return new FileAttributesTag();
                case SwfTagType.PlaceObject3:
                    return new PlaceObject3Tag();
                case SwfTagType.ImportAssets2:
                    return new ImportAssets2Tag();
                case SwfTagType.DoABCDefine:
                    return new DoABCDefineTag();
                case SwfTagType.DefineFontAlignZones:
                    return new DefineFontAlignZonesTag();
                case SwfTagType.CSMTextSettings:
                    return new CSMTextSettingsTag();
                case SwfTagType.DefineFont3:
                    return new DefineFont3Tag();
                case SwfTagType.SymbolClass:
                    return new SymbolClassTag();
                case SwfTagType.Metadata:
                    return new MetadataTag();
                case SwfTagType.DefineScalingGrid:
                    return new DefineScalingGridTag();
                case SwfTagType.DoABC:
                    return new DoABCTag();
                case SwfTagType.DefineShape4:
                    return new DefineShape4Tag();
                case SwfTagType.DefineMorphShape2:
                    return new DefineMorphShape2Tag();
                case SwfTagType.DefineSceneAndFrameLabelData:
                    return new DefineSceneAndFrameLabelDataTag();
                case SwfTagType.DefineBinaryData:
                    return new DefineBinaryDataTag();
                case SwfTagType.DefineFontName:
                    return new DefineFontNameTag();
                case SwfTagType.StartSound2:
                    return new StartSound2Tag();
                case SwfTagType.DefineBitsJPEG4:
                    return new DefineBitsJPEG4Tag();
                case SwfTagType.DefineFont4:
                    return new DefineFont4Tag();
                default:
                    return new UnknownTag(tagType);
            }
        }
    }
}
