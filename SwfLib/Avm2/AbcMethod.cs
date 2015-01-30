using System.Collections.Generic;
using System.Linq;

namespace SwfLib.Avm2 {
    public class AbcMethod {

        private readonly IList<AbcMethodParam> _params = new List<AbcMethodParam>();

        public string Name { get; set; }

        public AbcMethodBody Body { get; set; }

        public IList<AbcMethodParam> Params {
            get { return _params; }
        }

        public AbcMultiname ReturnType { get; set; }

        //public byte Flags; // todo: MethodFlags bitmask

        public bool HasOptional {
            get { return Params.Any(item => item.Default != null); }
        }

        public bool HasParamNames {
            get { return Params.Any(item => !string.IsNullOrWhiteSpace(item.Name)); }
        }

        public bool NeedArguments { get; set; }
        
        public bool NeedActivation { get; set; }
        
        public bool NeedRest { get; set; }
        
        public bool SetDxns { get; set; }
        
        public bool IgnoreRest { get; set; }
        
        public bool Native { get; set; }
    }
}
