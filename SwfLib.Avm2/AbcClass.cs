using System.Collections.Generic;

namespace SwfLib.Avm2 {
    public class AbcClass {

        private readonly IList<AbcTrait> _traits = new List<AbcTrait>();

        public AbcInstance Instance { get; set; }

        public AbcMethod ClassInitializer { get; set; }

        public IList<AbcTrait> Traits {
            get { return _traits; }
        }

    }

}
