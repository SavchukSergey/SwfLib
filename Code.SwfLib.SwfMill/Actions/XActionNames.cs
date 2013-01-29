using System;
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
            RegisterSWF5();
            RegisterSWF7();

            //Unsorted
            Register(ActionCode.InitArray, "DeclareArray");
            Register(ActionCode.Greater, "GreaterThanTyped");
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
            Register(ActionCode.Add, "Add");
            Register(ActionCode.Multiply, "Mulitply");
            Register(ActionCode.Subtract, "Substract");

            Register(ActionCode.Not, "LogicalNOT");

            Register(ActionCode.Pop, "Pop");
            Register(ActionCode.Push, "PushData");
            Register(ActionCode.If, "BranchIfTrue");
            Register(ActionCode.Jump, "BranchAlways");
            Register(ActionCode.GetVariable, "GetVariable");
            Register(ActionCode.SetVariable, "SetVariable");

            Register(ActionCode.GetTime, "GetTimer");
        }

        private static void RegisterSWF5() {
            Register(ActionCode.CallFunction, "CallFunction");
            Register(ActionCode.CallMethod, "CallMethod");
            Register(ActionCode.ConstantPool, "Dictionary");
            Register(ActionCode.ToString, "DefineString");
            Register(ActionCode.Add2, "AddTyped");
            Register(ActionCode.Less2, "LessThanTyped");
            Register(ActionCode.Equals2, "EqualTyped");
            Register(ActionCode.NewObject, "New");
            Register(ActionCode.PushDuplicate, "Duplicate");
            Register(ActionCode.StoreRegister, "StoreRegister");
        }

        public static void RegisterSWF7() {
            Register(ActionCode.DefineFunction2, "DeclareFunction2");
        }

        private static void Register(ActionCode actionCode, string nodeName) {
            _codeToNodeName[actionCode] = nodeName;
            _nodeNameToCode[nodeName] = actionCode;
        }

        public static ActionCode FromNodeName(string tagName) {
            ActionCode code;
            if (_nodeNameToCode.TryGetValue(tagName, out code)) return code;
            throw new NotSupportedException("Action " + tagName + " is not recognized");
        }

        public static string FromActionCode(ActionCode code) {
            return _codeToNodeName[code];
        }

        public static string FromAction(ActionBase action) {
            return FromActionCode(action.ActionCode);
        }
    }
}
