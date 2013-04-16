using System.Xml.Linq;
using SwfLib.Buttons;
using SwfLib.SwfMill.Actions;
using SwfLib.SwfMill.Data;

namespace SwfLib.SwfMill.Buttons {
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
                new XAttribute("menuLeave", CommonFormatter.Format(condition.OverDownToIdle))
                );

            var xActions = new XElement("actions");
            foreach (var action in condition.Actions) {
                xActions.Add(XAction.ToXml(action));
            }
            res.Add(xActions);
            return res;
        }

        public static ButtonCondition FromXml(XElement xCondition) {
            var xKeyPress = xCondition.Attribute("key");
            var xIdleToOverDown = xCondition.Attribute("menuEnter");
            var xOutDownToIdle = xCondition.Attribute("pointerReleaseOutside");
            var xOutDownToOverDown = xCondition.Attribute("pointerDragEnter");
            var xOverDownToOutDown = xCondition.Attribute("pointerDragLeave");
            var xOverDownToOverUp = xCondition.Attribute("pointerReleaseInside");
            var xOverUpToOverDown = xCondition.Attribute("pointerPush");
            var xOverUpToIdle = xCondition.Attribute("pointerLeave");
            var xIdleToOverUp = xCondition.Attribute("pointerEnter");
            var xOverDownToIdle = xCondition.Attribute("menuLeave");

            var res = new ButtonCondition {
                KeyPress = byte.Parse(xKeyPress.Value),
                IdleToOverDown = CommonFormatter.ParseBool(xIdleToOverDown.Value),
                OutDownToIdle = CommonFormatter.ParseBool(xOutDownToIdle.Value),
                OutDownToOverDown = CommonFormatter.ParseBool(xOutDownToOverDown.Value),
                OverDownToOutDown = CommonFormatter.ParseBool(xOverDownToOutDown.Value),
                OverDownToOverUp = CommonFormatter.ParseBool(xOverDownToOverUp.Value),
                OverUpToOverDown = CommonFormatter.ParseBool(xOverUpToOverDown.Value),
                OverUpToIdle = CommonFormatter.ParseBool(xOverUpToIdle.Value),
                IdleToOverUp = CommonFormatter.ParseBool(xIdleToOverUp.Value),
                OverDownToIdle = CommonFormatter.ParseBool(xOverDownToIdle.Value)
            };

            var xActions = xCondition.Elements("actions");
            foreach (var xAction in xActions.Elements()) {
                res.Actions.Add(XAction.FromXml(xAction));
            }
            return res;
        }

    }
}
