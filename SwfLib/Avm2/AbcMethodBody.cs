using System.Collections.Generic;

namespace SwfLib.Avm2 {
    public class AbcMethodBody {

        private readonly IList<AbcTrait> _traits = new List<AbcTrait>();
        private readonly IList<AbcExceptionBlock> _exceptions = new List<AbcExceptionBlock>();

        public uint MaxStack { get; set; }

        public uint LocalCount { get; set; }

        public uint InitScopeDepth { get; set; }

        public uint MaxScopeDepth { get; set; }

        public IList<AbcExceptionBlock> Exceptions {
            get { return _exceptions; }
        }

        public IList<AbcTrait> Traits {
            get { return _traits; }
        }

        //todo:
        //public byte[] Code;

    }
}
