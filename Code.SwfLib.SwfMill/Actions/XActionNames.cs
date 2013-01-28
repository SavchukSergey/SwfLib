using System.Collections.Generic;
using Code.SwfLib.Actions;

namespace Code.SwfLib.SwfMill.Actions {
    public static class XActionNames {

        private static readonly IDictionary<ActionCode, string> _codeToNodeName = new Dictionary<ActionCode, string>();
        private static readonly IDictionary<string, ActionCode> _nodeNameToCode = new Dictionary<string, ActionCode>();

        static XActionNames() {
            Register(ActionCode.End, "EndAction");
            RegisterSWF3();
            RegisterSWF4();
        }

        private static void RegisterSWF3() {
            Register(ActionCode.GotoFrame, "GoToFrame");
            Register(ActionCode.GetURL, "GetURL");
            Register(ActionCode.NextFrame, "NextFrame");
            Register(ActionCode.PreviousFrame, "PreviousFrame");
            Register(ActionCode.Play, "Play");
            Register(ActionCode.Stop, "Stop");
            Register(ActionCode.ToggleQuality, "ToggleQuality");

        }

        private static void RegisterSWF4() {
            Register(ActionCode.Not, "LogicalNOT");

            Register(ActionCode.Push, "PushData");
            Register(ActionCode.If, "BranchIfTrue");
            Register(ActionCode.SetVariable, "SetVariable");
        }

        private static void Register(ActionCode actionCode, string nodeName) {
            _codeToNodeName[actionCode] = nodeName;
            _nodeNameToCode[nodeName] = actionCode;
        }

        public static ActionCode FromNodeName(string tagName) {
            return _nodeNameToCode[tagName];
        }

        public static string FromActionCode(ActionCode code) {
            return _codeToNodeName[code];
        }

        public static string FromAction(ActionBase action) {
            return FromActionCode(action.ActionCode);
        }
    }
}
