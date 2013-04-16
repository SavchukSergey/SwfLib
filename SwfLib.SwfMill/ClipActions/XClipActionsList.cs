using System.Xml.Linq;
using SwfLib.ClipActions;

namespace SwfLib.SwfMill.ClipActions {
    public static class XClipActionsList {

        public static XElement ToXml(ClipActionsList clipActions) {
            var res = new XElement("events");
            foreach (var clipAction in clipActions.Records) {
                res.Add(XClipActionRecord.ToXml(clipAction));
            }
            return res;
        }

        public static void FromXml(XElement xClipActions, ClipActionsList clipActions) {
            foreach (var xClipAction in xClipActions.Elements()) {
                clipActions.Records.Add(XClipActionRecord.FromXml(xClipAction));
            }
        }
    }
}
