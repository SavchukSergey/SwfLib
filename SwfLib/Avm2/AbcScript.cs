using System.Collections.Generic;

namespace SwfLib.Avm2 {
    public class AbcScript {

        private readonly IList<AbcTrait> _traits = new List<AbcTrait>();

        public AbcMethod ScriptInitializer { get; set; }

        public IList<AbcTrait> Traits {
            get { return _traits; }
        }
    }
}
