using System.Collections.Generic;
using SwfLib.Avm2.Data;

namespace SwfLib.Avm2 {
    public class AbcFile {

        private readonly IList<AbcMethod> _methods = new List<AbcMethod>();
        private readonly IList<AbcClass> _classes = new List<AbcClass>();
        private readonly IList<AbcScript> _scripts = new List<AbcScript>();
        private readonly IList<AbcMetadata> _metadata = new List<AbcMetadata>();

        public ushort MajorVersion;

        public ushort MinorVersion;

        public IList<AbcMethod> Methods {
            get { return _methods; }
        }

        public IList<AbcClass> Classes {
            get { return _classes; }
        }

        public IList<AbcScript> Scripts {
            get { return _scripts; }
        }

        public IList<AbcMetadata> Metadata {
            get { return _metadata; }
        }

        public static AbcFile From(AbcFileInfo fileInfo) {
            var res = new AbcFile {
                MajorVersion = fileInfo.MajorVersion,
                MinorVersion = fileInfo.MinorVersion
            };

            var loader = new AbcFileLoader(fileInfo);

            foreach (var metaInfo in fileInfo.Metadata) {
                res.Metadata.Add(GetMetadata(metaInfo, fileInfo));
            }

            loader.SaveTo(res);

            return res;
        }

        private static AbcMetadata GetMetadata(AsMetadataInfo metaInfo, AbcFileInfo info) {
            var res = new AbcMetadata {
                Name = info.ConstantPool.Strings[metaInfo.Name]
            };
            foreach (var item in metaInfo.Items) {
                res.Items.Add(new AbcMetadataItem {
                    Key = info.ConstantPool.Strings[item.Key],
                    Value = info.ConstantPool.Strings[item.Value]
                });
            }
            return res;
        }
     

    }

}
