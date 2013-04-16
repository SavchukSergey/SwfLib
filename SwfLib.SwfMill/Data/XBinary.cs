using System;
using System.Xml.Linq;

namespace SwfLib.SwfMill.Data {
    public static class XBinary {

        public static byte[] FromXml(XElement element) {
            return Convert.FromBase64String(element.Value);
        }

        public static XElement ToXml(byte[] data) {
            return new XElement("data", Convert.ToBase64String(data));
        }
    }
}
