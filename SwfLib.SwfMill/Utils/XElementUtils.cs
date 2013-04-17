using System.Xml.Linq;

namespace SwfLib.SwfMill.Utils {
    public static class XElementUtils {

        public static string RequiredAttribute(this XElement node, string attributeName) {
            var xAttr = node.Attribute(attributeName);
            if (xAttr != null) return xAttr.Value;
            throw new SwfMillXmlException(string.Format("{0} is missing required '{1}' attribute. Path: {2}", node.Name, attributeName, BuildNodePath(node)));
        }

        public static XElement RequiredElement(this XElement node, string elementName) {
            var xChild = node.Element(elementName);
            if (xChild != null) return xChild;
            throw new SwfMillXmlException(string.Format("{0} is missing required '{1}' element. Path: {2}", node.Name, elementName, BuildNodePath(node)));
        }

        /// <summary>
        /// Reads required String attribute.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attributeName">Attribute name.</param>
        /// <returns></returns>
        public static string RequiredStringAttribute(this XElement node, string attributeName) {
            return node.RequiredAttribute(attributeName);
        }

        /// <summary>
        /// Reads required Double attribute.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attributeName">Attribute name.</param>
        /// <returns></returns>
        public static double RequiredDoubleAttribute(this XElement node, string attributeName) {
            var str = node.RequiredAttribute(attributeName);
            double val;
            if (double.TryParse(str, out val)) return val;
            throw new SwfMillXmlException(string.Format("{0}'s attribute '{1}' is not a double. Path: {2}", node.Name, attributeName, BuildNodePath(node)));
        }

        /// <summary>
        /// Reads required Float attribute.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attributeName">Attribute name.</param>
        /// <returns></returns>
        public static float RequiredFloatAttribute(this XElement node, string attributeName) {
            var str = node.RequiredAttribute(attributeName);
            float val;
            if (float.TryParse(str, out val)) return val;
            throw new SwfMillXmlException(string.Format("{0}'s attribute '{1}' is not a float. Path: {2}", node.Name, attributeName, BuildNodePath(node)));
        }

        /// <summary>
        /// Reads required UInt attribute.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attributeName">Attribute name.</param>
        /// <returns></returns>
        public static uint RequiredUIntAttribute(this XElement node, string attributeName) {
            var str = node.RequiredAttribute(attributeName);
            uint val;
            if (uint.TryParse(str, out val)) return val;
            throw new SwfMillXmlException(string.Format("{0}'s attribute '{1}' is not an unsigned integer. Path: {2}", node.Name, attributeName, BuildNodePath(node)));
        }

        /// <summary>
        /// Reads required Int attribute.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attributeName">Attribute name.</param>
        /// <returns></returns>
        public static int RequiredIntAttribute(this XElement node, string attributeName) {
            var str = node.RequiredAttribute(attributeName);
            int val;
            if (int.TryParse(str, out val)) return val;
            throw new SwfMillXmlException(string.Format("{0}'s attribute '{1}' is not an integer. Path: {2}", node.Name, attributeName, BuildNodePath(node)));
        }

        /// <summary>
        /// Reads required UShort attribute.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attributeName">Attribute name.</param>
        /// <returns></returns>
        public static ushort RequiredUShortAttribute(this XElement node, string attributeName) {
            var str = node.RequiredAttribute(attributeName);
            ushort val;
            if (ushort.TryParse(str, out val)) return val;
            throw new SwfMillXmlException(string.Format("{0}'s attribute '{1}' is not an unsigned short integer. Path: {2}", node.Name, attributeName, BuildNodePath(node)));
        }

        /// <summary>
        /// Reads required Short attribute.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attributeName">Attribute name.</param>
        /// <returns></returns>
        public static short RequiredShortAttribute(this XElement node, string attributeName) {
            var str = node.RequiredAttribute(attributeName);
            short val;
            if (short.TryParse(str, out val)) return val;
            throw new SwfMillXmlException(string.Format("{0}'s attribute '{1}' is not a signed short integer. Path: {2}", node.Name, attributeName, BuildNodePath(node)));
        }

        /// <summary>
        /// Reads required byte attribute.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attributeName">Attribute name.</param>
        /// <returns></returns>
        public static byte RequiredByteAttribute(this XElement node, string attributeName) {
            var str = node.RequiredAttribute(attributeName);
            byte val;
            if (byte.TryParse(str, out val)) return val;
            throw new SwfMillXmlException(string.Format("{0}'s attribute '{1}' is not a byte. Path: {2}", node.Name, attributeName, BuildNodePath(node)));
        }

        /// <summary>
        /// Reads required bool attribute.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attributeName">Attribute name.</param>
        /// <returns></returns>
        public static bool RequiredBoolAttribute(this XElement node, string attributeName) {
            var str = node.RequiredAttribute(attributeName);
            switch (str) {
                case "0":
                case "false":
                    return false;
                case "1":
                case "true":
                    return true;
                default:
                    throw new SwfMillXmlException(string.Format("{0}'s attribute '{1}' is not a bool value. Path: {2}", node.Name, attributeName, BuildNodePath(node)));
            }
        }

        public static string BuildNodePath(XElement node) {
            string res = "";
            var child = node;
            while (node != null) {
                if (!string.IsNullOrEmpty(res)) res = "/" + res;
                var nodeName = node.Name.LocalName;
                if (nodeName == "tags" || nodeName == "actions" || nodeName == "items" || nodeName == "strings" || nodeName == "glyphs") {
                    var index = GetNodeIndex(child);
                    res = "[" + index + "]" + res;
                }
                res = node.Name.LocalName + res;
                child = node;
                node = node.Parent;
            }
            return res;
        }

        private static int GetNodeIndex(XElement node) {
            var parent = node.Parent;
            if (parent == null) return -1;
            var res = 0;
            foreach (var xSub in parent.Elements()) {
                if (xSub == node) return res;
                res++;
            }
            return -1;
        }
    }
}
