using System;
using System.Collections.Generic;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill {
    public static class SwfTagNameMapping {

        private static readonly Dictionary<string, Func<SwfTagBase>> _tagMap = new Dictionary<string, Func<SwfTagBase>>();

        public const string EXPORT_TAG = "Export";
        public const string FILE_ATTRIBUTES_TAG = "FileAttributes";
        public const string METADATA_TAG = "Metadata";
        public const string PLACE_OBJECT2_TAG = "PlaceObject2";
        public const string SET_BACKGROUND_COLOR_TAG = "SetBackgroundColor";
        public const string UNKNOWN_TAG = "UnknownTag";

        static SwfTagNameMapping() {
            _tagMap[EXPORT_TAG] = () => new ExportTag();
            _tagMap[FILE_ATTRIBUTES_TAG] = () => new FileAttributesTag();
            _tagMap[METADATA_TAG] = () => new MetadataTag();
            _tagMap[PLACE_OBJECT2_TAG] = () => new PlaceObject2Tag();
            _tagMap[SET_BACKGROUND_COLOR_TAG] = () => new SetBackgroundColorTag();
            _tagMap[UNKNOWN_TAG] = () => new UnknownTag();
        }

        public static SwfTagBase CreateTagByXmlName(string name) {
            Func<SwfTagBase> factory;
            if (!_tagMap.TryGetValue(name, out factory)) {
                throw new FormatException("Unknown tag name");
            }
            return factory();
        }
    }
}
