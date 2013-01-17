using Code.SwfLib.Tags.ActionsTags;
using Code.SwfLib.Tags.BitmapTags;
using Code.SwfLib.Tags.ButtonTags;
using Code.SwfLib.Tags.ControlTags;
using Code.SwfLib.Tags.DisplayListTags;
using Code.SwfLib.Tags.FontTags;
using Code.SwfLib.Tags.ShapeTags;
using Code.SwfLib.Tags.TextTags;

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
}
