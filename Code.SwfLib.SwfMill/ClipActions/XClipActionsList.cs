using System;
using System.Xml.Linq;
using Code.SwfLib.ClipActions;

namespace Code.SwfLib.SwfMill.ClipActions {
    public static class XClipActionsList {

        public static XElement ToXml(ClipActionsList clipActions) {
            var res = new XElement("events");
            throw new NotImplementedException();
        }

        public static XElement FromXml(XElement xClipActions, ClipActionsList clipActions) {
            throw new NotImplementedException();
        }
    }
}
