using System.IO;
using System.Text;
using System.Xml.Linq;
using NUnit.Framework;

namespace Code.SwfLib.SwfMill.Tests {
    [TestFixture]
    public class SwfMillFacadeTest {

        [Test]
        [Ignore]
        public void SwfToXmlTest() {
            var source = this.GetType().Assembly.GetManifestResourceStream("Code.SwfLib.SwfMill.Tests.FlashTest.swf");
            var file = SwfFile.ReadFrom(source);
            var doc = new SwfMillFacade().ConvertToXml(file);
            doc.Declaration = new XDeclaration("1", "utf-8", "yes");
            var res = doc.ToString();
            using (StreamWriter writer = new StreamWriter(@"d:\Sergey\test.xml", false, Encoding.UTF8)) {
                doc.Save(writer);
            }
        }

        [Test]
        [Ignore]
        public void ReadHugeXml() {
            var sourceStream = OpenEmbeddedResource("HugeSwfXml.xml");
            var xml = XDocument.Load(new StreamReader(sourceStream));
            var file = new SwfMillFacade().ReadFromXml(xml);
            var mem = new MemoryStream();
            file.WriteTo(mem);
        }

        [Test]
        [Ignore]
        public void ReadHugeXml2() {
            var sourceStream = OpenEmbeddedResource("HugeSwfXml2.xml");
            var xml = XDocument.Load(new StreamReader(sourceStream));
            var file = new SwfMillFacade().ReadFromXml(xml);
            var mem = new MemoryStream();
            file.WriteTo(mem);
        }

        private static Stream OpenEmbeddedResource(string name) {
            return typeof(SwfMillFacadeTest).Assembly.GetManifestResourceStream("Code.SwfLib.SwfMill.Tests.Resources." + name);
        }

    }
}