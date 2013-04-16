using System.Xml.Linq;
using Code.SwfLib.SwfMill.Tests;
using NUnit.Framework;
using SwfLib.Actions;
using SwfLib.SwfMill.Actions;

namespace SwfLib.SwfMill.Tests.Actions {
    public abstract class BaseXActionTest {

        protected T ReadAction<T>(string source) where T : ActionBase {
            var xAction = XElement.Parse(source);
            var action = XAction.FromXml(xAction);
            return (T)action;
        }

        protected void WriteAction<T>(T action, string etalon) where T : ActionBase {
            var xAction = XAction.ToXml(action);
            var xEtalon = XElement.Parse(etalon);
            new XmlComparision(Assert.Fail).Compare(xAction, xEtalon);
        }
    }
}
