using System.Collections.Generic;

namespace SwfLib.Avm2 {
    public class AbcInstance {

        private readonly IList<AbcMultiname> _interfaces = new List<AbcMultiname>();
        private readonly IList<AbcTrait> _traits = new List<AbcTrait>();

        //todo: must be QName
        public AbcMultiname Name { get; set; }

        public AbcMultiname SuperName { get; set; }

        //todo:
        //public AsInstanceFlags Flags;

        //public uint ProtectedNs;

        public IList<AbcMultiname> Interfaces {
            get { return _interfaces; }
        }

        public AbcMethod InstanceInitializer;

        public IList<AbcTrait> Traits {
            get { return _traits; }
        }

        //public bool HasProtectedNs {
        //    get { return (Flags & (int)AsInstanceFlags.ProtectedNs) != 0; }
        //}
    }
}
