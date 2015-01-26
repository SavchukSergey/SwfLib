using NUnit.Framework;
using SwfLib.Avm2.Opcodes;

namespace SwfLib.Tests.Avm2 {
    [TestFixture]
    public class OpcodesTest {

        [Test]
        public void BaseClassTest() {
            var baseType = typeof(BaseAvm2Opcode);
            var ns = baseType.Namespace ?? "";

            var allTypes = baseType.Assembly.GetTypes();
            foreach (var type in allTypes) {
                if (type.FullName.StartsWith(ns) && type.IsClass && !type.IsAbstract) {
                    Assert.IsTrue(type.Name.EndsWith("Opcode"), type.FullName);
                    Assert.IsTrue(baseType.IsAssignableFrom(type), type.FullName);
                }
            }
        }
    }
}
