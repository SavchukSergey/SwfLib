using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code.SwfLib.Data.Actions;

namespace Code.SwfLib {
    public static class ActionsStreamExt {

        private static void AssertActionCode(this SwfStreamReader reader, ActionCode code, out ushort length) {
            var actual = (ActionCode)reader.ReadByte();
            if (actual != code) throw new InvalidOperationException("Expected " + code + " but was " + actual);
            if ((byte)code >= 0x80) {
                length = reader.ReadUInt16();
            } else {
                length = 0;
            }
        }

        public static ActionBase ReadAction(this SwfStreamReader reader) {
            var code = (ActionCode)reader.ReadByte();
            reader.GoBack(1);
            switch (code) {
                case ActionCode.Empty:
                    return null;
                case ActionCode.GetURL:
                    return reader.ReadActionGetURL();
                case ActionCode.GotoFrame:
                    return reader.ReadActionGotoFrame();
                case ActionCode.GoToLabel:
                    return reader.ReadActionGoToLabel();
                case ActionCode.NextFrame:
                    return reader.ReadActionNextFrame();
                case ActionCode.Play:
                    return reader.ReadActionPlay();
                case ActionCode.PreviousFrame:
                    return reader.ReadActionPreviousFrame();
                case ActionCode.SetTarget:
                    return reader.ReadActionSetTarget();
                case ActionCode.Stop:
                    return reader.ReadActionStop();
                case ActionCode.StopSounds:
                    return reader.ReadActionStopSounds();
                case ActionCode.ToggleQuality:
                    return reader.ReadActionToggleQuality();
                case ActionCode.WaitForFrame:
                    return reader.ReadActionWaitForFrame();
                default:
                    throw new NotSupportedException("ActionCode is " + code);
            }
            //TODO: other actions
        }
        public static ActionGetURL ReadActionGetURL(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.GetURL, out length);
            return new ActionGetURL { UrlString = reader.ReadString(), TargetString = reader.ReadString() };
        }

        public static ActionGotoFrame ReadActionGotoFrame(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.GotoFrame, out length);
            return new ActionGotoFrame { Frame = reader.ReadUInt16() };
        }

        public static ActionGoToLabel ReadActionGoToLabel(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.GoToLabel, out length);
            return new ActionGoToLabel { Label = reader.ReadString() };
        }

        public static ActionNextFrame ReadActionNextFrame(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.NextFrame, out length);
            return new ActionNextFrame();
        }

        public static ActionPlay ReadActionPlay(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.Play, out length);
            return new ActionPlay();
        }

        public static ActionPreviousFrame ReadActionPreviousFrame(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.PreviousFrame, out length);
            return new ActionPreviousFrame();
        }

        public static ActionSetTarget ReadActionSetTarget(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.SetTarget, out length);
            return new ActionSetTarget { TargetName = reader.ReadString()};
        }

        public static ActionStop ReadActionStop(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.Stop, out length);
            return new ActionStop();
        }

        public static ActionStopSounds ReadActionStopSounds(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.StopSounds, out length);
            return new ActionStopSounds();
        }

        public static ActionToggleQuality ReadActionToggleQuality(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.ToggleQuality, out length);
            return new ActionToggleQuality();
        }

        public static ActionWaitForFrame ReadActionWaitForFrame(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.WaitForFrame, out length);
            return new ActionWaitForFrame {Frame = reader.ReadUInt16(), SkipCount = reader.ReadByte()};
        }
    }
}
