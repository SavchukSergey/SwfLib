using System.Xml.Linq;
using Code.SwfLib.Buttons;
using Code.SwfLib.SwfMill.Actions;
using Code.SwfLib.SwfMill.Data;

namespace Code.SwfLib.SwfMill.Buttons {
    public static class XButtonCondition {
        public static XElement ToXml(ButtonCondition condition) {
            var res = new XElement("Condition",
                new XAttribute("key", condition.KeyPress),
                new XAttribute("menuEnter", CommonFormatter.Format(condition.IdleToOverDown)),
                new XAttribute("pointerReleaseOutside", CommonFormatter.Format(condition.OutDownToIdle)),
                new XAttribute("pointerDragEnter", CommonFormatter.Format(condition.OutDownToOverDown)),
                new XAttribute("pointerDragLeave", CommonFormatter.Format(condition.OverDownToOutDown)),
                new XAttribute("pointerReleaseInside", CommonFormatter.Format(condition.OverDownToOverUp)),
                new XAttribute("pointerPush", CommonFormatter.Format(condition.OverUpToOverDown)),
                new XAttribute("pointerLeave", CommonFormatter.Format(condition.OverUpToIdle)),
                new XAttribute("pointerEnter", CommonFormatter.Format(condition.IdleToOverUp)),
                new XAttribute("menuLeave", CommonFormatter.Format(condition.IdleToOverDown))
                );

            var xActions = new XElement("actions");
            foreach (var action in condition.Actions) {
                xActions.Add(XAction.ToXml(action));
            }
            res.Add(xActions);
            return res;
        }
    }
}
