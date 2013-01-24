using System;
using System.Collections.Generic;
using System.Xml.Linq;
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

        public static string DEFINE_SHAPE2_TAG = "DefineShape2";
        public const string DEFINE_SHAPE3_TAG = "DefineShape3";
        public static string DEFINE_SHAPE_4_TAG = "DefineShape5";
        
        public static XName DEFINE_SCALING_GRID_TAG = "DefineScalingGrid";

        public const string PLACE_OBJECT_TAG = "PlaceObject";
        public const string PLACE_OBJECT2_TAG = "PlaceObject2";
        public const string PLACE_OBJECT3_TAG = "PlaceObject3";

        public const string DEFINE_BITS_LOSSLESS_TAG = "DefineBitsLossless";
        public const string DEFINE_FONT_TAG = "DefineFont";
        public const string DEFINE_FONT_ALIGN_ZONES_TAG = "DefineFontAlignZones";
        public const string DEFINE_FONT_INFO_TAG = "DefineFontInfo";
        public const string DO_ACTION_TAG = "DoAction";
        public const string DO_INIT_ACTION_TAG = "DoInitAction";
        public const string END_TAG = "End";
        public const string METADATA_TAG = "Metadata";
        public const string REMOVE_OBJECT2_TAG = "RemoveObject2";
        public const string SET_BACKGROUND_COLOR_TAG = "SetBackgroundColor";
        public const string SCRIPT_LIMITES_TAG = "ScriptLimits";
        public const string DO_ABC_TAG = "DoAbc";

        public const string DEFINE_SCENE_AND_FRAME_LABEL_DATA_TAG = "DefineSceneAndFrameLabelData";

        static SwfTagNameMapping() {
            _tagMap[DEFINE_BITS_LOSSLESS_TAG] = () => new DefineBitsLosslessTag();
            _tagMap[DEFINE_FONT_ALIGN_ZONES_TAG] = () => new DefineFontAlignZonesTag();
            _tagMap[DEFINE_FONT_INFO_TAG] = () => new DefineFontInfoTag();
            _tagMap[DEFINE_SHAPE_TAG] = () => new DefineShapeTag();
            _tagMap[DEFINE_SHAPE3_TAG] = () => new DefineShape3Tag();
            _tagMap[DO_ACTION_TAG] = () => new DoActionTag();
            _tagMap[DO_INIT_ACTION_TAG] = () => new DoInitActionTag();
            _tagMap[END_TAG] = () => new EndTag();
            _tagMap[METADATA_TAG] = () => new MetadataTag();
            _tagMap[PLACE_OBJECT2_TAG] = () => new PlaceObject2Tag();
            _tagMap[PLACE_OBJECT3_TAG] = () => new PlaceObject3Tag();
            _tagMap[REMOVE_OBJECT2_TAG] = () => new RemoveObject2Tag();
            _tagMap[SET_BACKGROUND_COLOR_TAG] = () => new SetBackgroundColorTag();
            _tagMap[SCRIPT_LIMITES_TAG] = () => new ScriptLimitsTag();
            _tagMap[DO_ABC_TAG] = () => new DoABCTag();
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
