using System.Collections.Generic;

namespace SwfLib.Avm2 {
    public class AbcNamespaceSet {

        private readonly IList<AbcNamespace> _namespaces = new List<AbcNamespace>();

        public IList<AbcNamespace> Namespaces {
            get { return _namespaces; }
        }
    }
}
