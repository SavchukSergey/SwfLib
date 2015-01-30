using System.Collections.Generic;

namespace SwfLib.Avm2 {
    public class AbcScript {

        private readonly IList<AbcTrait> _traits = new List<AbcTrait>();

        //todo:
        //public uint ScriptInitializer;


        public IList<AbcTrait> Traits {
            get { return _traits; }
        }
    }
}
