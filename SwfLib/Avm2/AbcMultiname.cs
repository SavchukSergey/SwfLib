namespace SwfLib.Avm2 {
    public abstract class AbcMultiname {

        //todo: exists?
        public static readonly AbcMultinameAny Any = new AbcMultinameAny();
        
        public static readonly AbcMultinameVoid Void = new AbcMultinameVoid();

    }

    public class AbcMultinameQName : AbcMultiname {

        public string Name { get; set; }

        public AbcNamespace Namespace { get; set; }

        public override string ToString() {
            return string.Format("{0}:{1}", Namespace, Name);
        }
    }

    public class AbcMultinameVoid : AbcMultiname {

    }

    public class AbcMultinameAny : AbcMultiname {
        public override string ToString() {
            return "*";
        }

    }
}
