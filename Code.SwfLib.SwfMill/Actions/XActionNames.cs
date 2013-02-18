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
            RegisterSWF6();
            RegisterSWF7();
        }

        private static void RegisterSWF3() {
            Register(ActionCode.GotoFrame, "GotoFrame");
            Register(ActionCode.GetURL, "GetURL");
            Register(ActionCode.NextFrame, "NextFrame");
            Register(ActionCode.PreviousFrame, "PreviousFrame");
            Register(ActionCode.Play, "Play");
            Register(ActionCode.Stop, "Stop");
            Register(ActionCode.ToggleQuality, "ToggleQuality");
            Register(ActionCode.StopSounds, "StopSounds");
            Register(ActionCode.WaitForFrame, "WaitForFrame");
            Register(ActionCode.SetTarget, "SetTarget");
            Register(ActionCode.GoToLabel, "GoToLabel");
        }

        private static void RegisterSWF4() {
            Register(ActionCode.Add, "Add");
            Register(ActionCode.Divide, "Divide");
            Register(ActionCode.Multiply, "Mulitply");
            Register(ActionCode.Subtract, "Substract");

            Register(ActionCode.Equals, "Equals");
            Register(ActionCode.Less, "Less");

            Register(ActionCode.And, "LogicalAND");
            Register(ActionCode.Not, "LogicalNOT");
            Register(ActionCode.Or, "LogicalOR");

            Register(ActionCode.StringAdd, "StringAdd");
            Register(ActionCode.StringEquals, "StringEquals");
            Register(ActionCode.StringExtract, "StringExtract");
            Register(ActionCode.StringLength, "StringLength");
            Register(ActionCode.MBStringExtract, "MBStringExtract");
            Register(ActionCode.MBStringLength, "MBStringLength");
            Register(ActionCode.StringLess, "StringLess");

            Register(ActionCode.Pop, "Pop");
            Register(ActionCode.Push, "PushData");

            Register(ActionCode.AsciiToChar, "AsciiToChar");
            Register(ActionCode.CharToAscii, "CharToAscii");
            Register(ActionCode.ToInteger, "ToInteger");
            Register(ActionCode.MBAsciiToChar, "MBAsciiToChar");
            Register(ActionCode.MBCharToAscii, "MBCharToAscii");

            Register(ActionCode.Call, "Call");
            Register(ActionCode.If, "BranchIfTrue");
            Register(ActionCode.Jump, "BranchAlways");

            Register(ActionCode.GetVariable, "GetVariable");
            Register(ActionCode.SetVariable, "SetVariable");
            Register(ActionCode.GetURL2, "GetURL2");
            Register(ActionCode.GetProperty, "GetProperty");
            Register(ActionCode.GotoFrame2, "GotoExpression");
            Register(ActionCode.RemoveSprite, "RemoveSprite");
            Register(ActionCode.SetProperty, "SetProperty");
            Register(ActionCode.SetTarget2, "SetTargetDynamic");
            Register(ActionCode.StartDrag, "StartDrag");
            Register(ActionCode.WaitForFrame2, "WaitForFrame2");
            Register(ActionCode.CloneSprite, "CloneSprite");
            Register(ActionCode.EndDrag, "EndDrag");

            Register(ActionCode.GetTime, "GetTimer");
            Register(ActionCode.RandomNumber, "Random");
            Register(ActionCode.Trace, "Trace");
        }

        private static void RegisterSWF5() {
            Register(ActionCode.CallFunction, "CallFunction");
            Register(ActionCode.CallMethod, "CallMethod");
            Register(ActionCode.ConstantPool, "Dictionary");
            Register(ActionCode.DefineFunction, "DeclareFunction");
            Register(ActionCode.DefineLocal, "SetLocalVariable");
            Register(ActionCode.DefineLocal2, "DeclareLocalVariable");
            Register(ActionCode.Delete, "Delete");
            Register(ActionCode.Delete2, "Delete2");
            Register(ActionCode.Enumerate, "Enumerate");
            Register(ActionCode.Equals2, "EqualTyped");
            Register(ActionCode.GetMember, "GetMember");
            Register(ActionCode.InitArray, "DeclareArray");
            Register(ActionCode.InitObject, "InitObject");
            Register(ActionCode.NewMethod, "NewMethod");
            Register(ActionCode.NewObject, "New");
            Register(ActionCode.SetMember, "SetMember");
            Register(ActionCode.TargetPath, "TargetPath");
            Register(ActionCode.With, "With");

            Register(ActionCode.ToNumber, "DefineNumber");
            Register(ActionCode.ToString, "DefineString");
            Register(ActionCode.TypeOf, "TypeOf");

            Register(ActionCode.Add2, "AddTyped");
            Register(ActionCode.Less2, "LessThanTyped");
            Register(ActionCode.Modulo, "Modulo");

            Register(ActionCode.BitAnd, "BitAnd");
            Register(ActionCode.BitLShift, "BitLShift");
            Register(ActionCode.BitOr, "BitOr");
            Register(ActionCode.BitRShift, "BitRShift");
            Register(ActionCode.BitURShift, "BitURShift");
            Register(ActionCode.BitXor, "BitXor");
            Register(ActionCode.Decrement, "Decrement");
            Register(ActionCode.Increment, "Increment");
            Register(ActionCode.PushDuplicate, "Duplicate");
            Register(ActionCode.Return, "Return");
            Register(ActionCode.StackSwap, "StackSwap");
            Register(ActionCode.StoreRegister, "StoreRegister");
        }

        private static void RegisterSWF6() {
            Register(ActionCode.InstanceOf, "InstanceOf");
            Register(ActionCode.Enumerate2, "Enumerate2");
            Register(ActionCode.StrictEquals, "StrictEquals");
            Register(ActionCode.Greater, "GreaterThanTyped");
            Register(ActionCode.StringGreater, "StringGreater");
        }

        private static void RegisterSWF7() {
            Register(ActionCode.DefineFunction2, "DeclareFunction2");
            Register(ActionCode.Extends, "Extends");
            Register(ActionCode.CastOp, "CastOp");
            Register(ActionCode.ImplementsOp, "ImplementsOp");
            Register(ActionCode.Try, "Try");
            Register(ActionCode.Throw, "Throw");
        }

        private static void Register(ActionCode actionCode, string nodeName) {
            ActionCode testCode;
            if (_nodeNameToCode.TryGetValue(nodeName, out testCode)) throw new InvalidOperationException("Node " + nodeName + " is already registered");

            string testNodeName;
            if (_codeToNodeName.TryGetValue(actionCode, out testNodeName)) throw new InvalidOperationException("Action " + actionCode + " is already registered");

            _codeToNodeName[actionCode] = nodeName;
            _nodeNameToCode[nodeName] = actionCode;
        }

        public static ActionCode FromNodeName(string tagName) {
            ActionCode code;
            if (_nodeNameToCode.TryGetValue(tagName, out code)) return code;
            throw new NotSupportedException("Action " + tagName + " is not recognized");
        }

        public static string FromActionCode(ActionCode code) {
            string tagName;
            if (_codeToNodeName.TryGetValue(code, out tagName)) return tagName;
            throw new NotSupportedException("Action " + code + " is not recognized");
        }

        public static string FromAction(ActionBase action) {
            return FromActionCode(action.ActionCode);
        }
    }
}
