using System.Xml.Linq;
using Code.SwfLib.Actions;

namespace Code.SwfLib.SwfMill.Actions {
    public static class XAction {

        private static readonly XActionReader _reader = new XActionReader();
        private static readonly XActionWriter _writer = new XActionWriter();

        public static XElement ToXml(ActionBase action) {
            return _writer.Serialize(action);
        }

        public static ActionBase FromXml(XElement xAction) {
            return _reader.Deserialize(xAction);
        }
    }
}
