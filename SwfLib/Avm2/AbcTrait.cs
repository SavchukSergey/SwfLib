using System.Collections.Generic;
using SwfLib.Avm2.Data;

namespace SwfLib.Avm2 {
    public abstract class AbcTrait {

        private readonly IList<AbcMetadata> _metadata = new List<AbcMetadata>();

        public AbcMultiname Name { get; set; }

        public abstract AsTraitKind Kind { get; }

        public IList<AbcMetadata> Metadata {
            get {
                return _metadata;
            }
        }

        public bool Final { get; set; }
        
        public bool Override { get; set; }

    }

    public class AbcConstTrait : AbcTrait {

        public uint SlotId { get; set; }

        public AbcMultiname TypeName { get; set; }

        public AbcConstant Value { get; set; }

        public override AsTraitKind Kind {
            get { return AsTraitKind.Const; }
        }

    }

    public class AbcSlotTrait : AbcTrait {

        public uint SlotId { get; set; }

        public AbcMultiname TypeName { get; set; }

        public AbcConstant Value { get; set; }

        public override AsTraitKind Kind {
            get { return AsTraitKind.Slot; }
        }
    }

    public class AbcClassTrait : AbcTrait {

        public uint SlotId { get; set; }

        public AbcClass Class { get; set; }

        public override AsTraitKind Kind {
            get { return AsTraitKind.Class; }
        }

    }

    public class AbcFunctionTrait : AbcTrait {

        public uint SlotId { get; set; }

        public AbcMethod Method { get; set; }

        public override AsTraitKind Kind {
            get { return AsTraitKind.Function; }
        }

    }

    public class AbcMethodTrait : AbcTrait {

        public uint DispId { get; set; }

        public AbcMethod Method { get; set; }

        public override AsTraitKind Kind {
            get { return AsTraitKind.Method; }
        }

    }

    public class AbcGetterTrait : AbcTrait {

        public uint DispId { get; set; }

        public AbcMethod Method { get; set; }

        public override AsTraitKind Kind {
            get { return AsTraitKind.Getter; }
        }

    }

    public class AbcSetterTrait : AbcTrait {

        public uint DispId { get; set; }

        public AbcMethod Method { get; set; }

        public override AsTraitKind Kind {
            get { return AsTraitKind.Setter; }
        }

    }
}
