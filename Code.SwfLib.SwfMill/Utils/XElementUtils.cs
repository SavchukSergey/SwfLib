using System;
using System.Xml.Linq;

namespace Code.SwfLib.SwfMill.Utils {
    public static class XElementUtils {

        public static string RequiredAttribute(this XElement node, string attributeName, string message) {
            var xAttr = node.Attribute(attributeName);
            if (xAttr != null) return xAttr.Value;
            throw new InvalidOperationException(message + " is missing required " + attributeName + " attribute.");
        }

        public static double RequiredDoubleAttribute(this XElement node, string attributeName, string message) {
            var str = node.RequiredAttribute(attributeName, message);
            double val;
            if (double.TryParse(str, out val)) return val;
            throw new InvalidOperationException(message + "'s attribute " + attributeName + " is not a double");
        }

        public static int RequiredIntAttribute(this XElement node, string attributeName, string message) {
            var str = node.RequiredAttribute(attributeName, message);
            int val;
            if (int.TryParse(str, out val)) return val;
            throw new InvalidOperationException(message + "'s attribute " + attributeName + " is not an integer");
        }
    }
}
