using System.Xml.Linq;
using Code.SwfLib.Actions;
using Code.SwfLib.SwfMill.Actions;
using NUnit.Framework;
using SwfLib.Actions;

namespace Code.SwfLib.SwfMill.Tests.Actions {
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
