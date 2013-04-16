using System;
using System.Collections.Generic;
using SwfLib.Tags;

namespace SwfLib.SwfMill {
    public static class SwfTagNameMapping {

        private static readonly SwfTagsFactory _factory = new SwfTagsFactory();
        private static readonly Dictionary<string, SwfTagType> _tagMap = new Dictionary<string, SwfTagType>();

        public const string DEFINE_BITS_LOSSLESS_TAG = "DefineBitsLossless";
        public const string DEFINE_FONT_TAG = "DefineFont";
        public const string DEFINE_FONT_ALIGN_ZONES_TAG = "DefineFontAlignZones";
        public const string DEFINE_FONT_INFO_TAG = "DefineFontInfo";
        public const string SET_BACKGROUND_COLOR_TAG = "SetBackgroundColor";
        public const string SCRIPT_LIMITES_TAG = "ScriptLimits";
        public const string DO_ABC_TAG = "DoAbc";

        public const string DEFINE_SCENE_AND_FRAME_LABEL_DATA_TAG = "DefineSceneAndFrameLabelData";

        static SwfTagNameMapping() {
            var formatterFactory = new TagFormatterFactory(10);
            foreach (SwfTagType tagType in Enum.GetValues(typeof(SwfTagType))) {
                var tag = _factory.Create(tagType);
                var formatter = formatterFactory.GetFormatter(tag);
                var tagName = formatter.TagName;
                _tagMap[tagName] = tagType;
            }
        }

        public static SwfTagBase CreateTagByXmlName(string name) {
            SwfTagType type;
            if (!_tagMap.TryGetValue(name, out type)) {
                throw new FormatException("Unknown tag name " + name);
            }
            return _factory.Create(type);
        }
    }
}
