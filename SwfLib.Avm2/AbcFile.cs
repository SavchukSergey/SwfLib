using System.Collections.Generic;
using SwfLib.Avm2.Data;

namespace SwfLib.Avm2 {
    public class AbcFile {

        private readonly IList<AbcMethod> _methods = new List<AbcMethod>();
        private readonly IList<AbcClass> _classes = new List<AbcClass>();
        private readonly IList<AbcScript> _scripts = new List<AbcScript>();

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

        public static AbcFile From(AbcFileInfo fileInfo) {
            var res = new AbcFile {
                MajorVersion = fileInfo.MajorVersion,
                MinorVersion = fileInfo.MinorVersion
            };

            var loader = new AbcFileLoader(fileInfo);

            loader.SaveTo(res);

            return res;
        }


    }

}
