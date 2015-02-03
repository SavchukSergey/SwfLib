using System.Collections.Generic;
using System.Text;

namespace SwfLib.Avm2 {
    public abstract class AbcMultiname {

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

    public class AbcMultinameQNameA : AbcMultiname {

        public string Name { get; set; }

        public AbcNamespace Namespace { get; set; }

        public override string ToString() {
            return string.Format("{0}:{1}", Namespace, Name);
        }
    }

    public class AbcMultinameMultiname : AbcMultiname {

        public string Name { get; set; }

        public AbcNamespaceSet NamespaceSet { get; set; }

        public override string ToString() {
            return string.Format("{0}:{1}", NamespaceSet, Name);
        }
    }

    public class AbcMultinameVoid : AbcMultiname {

    }

    public class AbcMultinameAny : AbcMultiname {

        public override string ToString() {
            return "*";
        }

    }

    public class AbcMultinameGeneric : AbcMultiname {

        private readonly IList<AbcMultiname> _params = new List<AbcMultiname>();

        public AbcMultiname Name { get; set; }

        public IList<AbcMultiname> Params {
            get { return _params; }
        }

        public override string ToString() {
            var sb = new StringBuilder();
            sb.Append(Name);
            sb.Append('<');
            for (var i = 0; i < _params.Count; i++) {
                if (i != 0) sb.Append(", ");
                sb.Append(_params[i]);
            }
            sb.Append('>');

            return sb.ToString();
        }
    }
}
