using System.Collections.Generic;

namespace SwfLib.Avm2 {
    public class AbcMetadata {

        private readonly IList<AbcMetadataItem> _items = new List<AbcMetadataItem>();

        public string Name { get; set; }

        public IList<AbcMetadataItem> Items {
            get { return _items; }
        }
    }

    public class AbcMetadataItem {

        public string Key { get; set; }

        public string Value { get; set; }

    }
}
