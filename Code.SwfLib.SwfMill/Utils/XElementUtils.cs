using System;
using System.Xml.Linq;

namespace Code.SwfLib.SwfMill.Utils {
    public static class XElementUtils {

        public static string RequiredAttribute(this XElement node, string attributeName, string message) {
            var xAttr = node.Attribute(attributeName);
            if (xAttr != null) return xAttr.Value;
            throw new InvalidOperationException(message + " is missing required " + attributeName + " attribute.");
        }
    }
}
