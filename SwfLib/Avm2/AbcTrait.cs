using SwfLib.Avm2.Data;

namespace SwfLib.Avm2 {
    public abstract class AbcTrait {

        public AbcMultiname Name { get; set; }

        public abstract AsTraitKind Kind { get; }

        //todo: other fields

        //todo: metadata
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
