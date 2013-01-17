using Code.SwfLib.Tags.ActionsTags;
using Code.SwfLib.Tags.BitmapTags;
using Code.SwfLib.Tags.ButtonTags;
using Code.SwfLib.Tags.ControlTags;
using Code.SwfLib.Tags.DisplayListTags;
using Code.SwfLib.Tags.FontTags;
using Code.SwfLib.Tags.ShapeTags;
using Code.SwfLib.Tags.SoundTags;
using Code.SwfLib.Tags.TextTags;

namespace Code.SwfLib.Tags {
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
                default:
                    return new UnknownTag();
            }
        }
    }
}
