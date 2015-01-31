using SwfLib.Avm2.Data;

namespace SwfLib.Avm2 {
    public class AbcNamespace {

        public AsType Kind;

        public string Name { get; set; }

        public override string ToString() {
            return string.Format("{0} {1}", Kind, !string.IsNullOrWhiteSpace(Name) ? Name : "*");
        }

        public static readonly AbcNamespace Any = new AbcNamespace { Kind = AsType.Void, Name = "" };

    }
}
