using System;
using System.Collections.Generic;
using Code.SwfLib.Tags;
using Code.SwfLib.Tags.ActionsTags;
using Code.SwfLib.Tags.BitmapTags;
using Code.SwfLib.Tags.ControlTags;
using Code.SwfLib.Tags.DisplayListTags;
using Code.SwfLib.Tags.FontTags;
using Code.SwfLib.Tags.ShapeTags;
using Code.SwfLib.Tags.TextTags;

namespace Code.SwfLib.SwfMill {
    public static class SwfTagNameMapping {

        private static readonly Dictionary<string, Func<SwfTagBase>> _tagMap = new Dictionary<string, Func<SwfTagBase>>();

        public const string CSM_TEXT_SETTINGS_TAG = "CSMTextSettings";
        public const string DEFINE_BITS_JPEG2_TAG = "DefineBitsJPEG2";
        public const string DEFINE_BITS_LOSSLESS_TAG = "DefineBitsLossless";
        public const string DEFINE_BUTTON2_TAG = "DefineButton2";
        public const string DEFINE_EDIT_TEXT_TAG = "DefineEditText";
        public const string DEFINE_FONT_3_TAG = "DefineFont3";
        public const string DEFINE_FONT_ALIGN_ZONES_TAG = "DefineFontAlignZones";
        public const string DEFINE_FONT_INFO_TAG = "DefineFontInfo";
        public const string DEFINE_FONT_NAME_TAG = "DefineFontInfo3";
        public const string DEFINE_SHAPE_TAG = "DefineShape";
        public const string DEFINE_SHAPE3_TAG = "DefineShape3";
        public const string DEFINE_SPRITE_TAG = "DefineSprite";
        public const string DEFINE_TEXT_TAG = "DefineText";
        public const string DO_ACTION_TAG = "DoAction";
        public const string DO_INIT_ACTION_TAG = "DoInitAction";
        public const string END_TAG = "End";
        public const string EXPORT_TAG = "Export";
        public const string FILE_ATTRIBUTES_TAG = "FileAttributes";
        public const string FRAME_LABEL_TAG = "FrameLabel";
        public const string METADATA_TAG = "Metadata";
        public const string PLACE_OBJECT2_TAG = "PlaceObject2";
        public const string PLACE_OBJECT3_TAG = "PlaceObject3";
        public const string REMOVE_OBJECT2_TAG = "RemoveObject2";
        public const string SET_BACKGROUND_COLOR_TAG = "SetBackgroundColor";
        public const string SCRIPT_LIMITES_TAG = "ScriptLimits";
        public const string SHOW_FRAME_TAG = "ShowFrame";
        public const string UNKNOWN_TAG = "UnknownTag";

        static SwfTagNameMapping() {
            _tagMap[CSM_TEXT_SETTINGS_TAG] = () => new CSMTextSettingsTag();
            _tagMap[DEFINE_BITS_JPEG2_TAG] = () => new DefineBitsJPEG2Tag();
            _tagMap[DEFINE_BITS_LOSSLESS_TAG] = () => new DefineBitsLosslessTag();
            _tagMap[DEFINE_BUTTON2_TAG] = () => new DefineButton2Tag();
            _tagMap[DEFINE_EDIT_TEXT_TAG] = () => new DefineEditTextTag();
            _tagMap[DEFINE_FONT_3_TAG] = () => new DefineFont3Tag();
            _tagMap[DEFINE_FONT_ALIGN_ZONES_TAG] = () => new DefineFontAlignZonesTag();
            _tagMap[DEFINE_FONT_INFO_TAG] = () => new DefineFontInfoTag();
            _tagMap[DEFINE_FONT_NAME_TAG] = () => new DefineFontNameTag();
            _tagMap[DEFINE_SHAPE_TAG] = () => new DefineShapeTag();
            _tagMap[DEFINE_SHAPE3_TAG] = () => new DefineShape3Tag();
            _tagMap[DEFINE_SPRITE_TAG] = () => new DefineSpriteTag();
            _tagMap[DEFINE_TEXT_TAG] = () => new DefineTextTag();
            _tagMap[DO_ACTION_TAG] = () => new DoActionTag();
            _tagMap[DO_INIT_ACTION_TAG] = () => new DoInitActionTag();
            _tagMap[END_TAG] = () => new EndTag();
            _tagMap[EXPORT_TAG] = () => new ExportAssetsTag();
            _tagMap[FILE_ATTRIBUTES_TAG] = () => new FileAttributesTag();
            _tagMap[FRAME_LABEL_TAG] = () => new FrameLabelTag();
            _tagMap[METADATA_TAG] = () => new MetadataTag();
            _tagMap[PLACE_OBJECT2_TAG] = () => new PlaceObject2Tag();
            _tagMap[PLACE_OBJECT3_TAG] = () => new PlaceObject3Tag();
            _tagMap[REMOVE_OBJECT2_TAG] = () => new RemoveObject2Tag();
            _tagMap[SET_BACKGROUND_COLOR_TAG] = () => new SetBackgroundColorTag();
            _tagMap[SCRIPT_LIMITES_TAG] = () => new ScriptLimitsTag();
            _tagMap[SHOW_FRAME_TAG] = () => new ShowFrameTag();
            _tagMap[UNKNOWN_TAG] = () => new UnknownTag();
        }

        public static SwfTagBase CreateTagByXmlName(string name) {
            Func<SwfTagBase> factory;
            if (!_tagMap.TryGetValue(name, out factory)) {
                throw new FormatException("Unknown tag name " + name);
            }
            return factory();
        }
    }
}
