using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using NUnit.Framework;

namespace Code.SwfLib.SwfMill.Tests
{
    [TestFixture]
    public class SwfMillFacadeTest
    {

        [Test]
        public void SwfToXmlTest()
        {
            var source = this.GetType().Assembly.GetManifestResourceStream("Code.SwfLib.SwfMill.Tests.FlashTest.swf");
            var file = SwfFile.ReadFrom(source);
            var doc = new SwfMillFacade().ConvertToXml(file);
            doc.Declaration = new XDeclaration("1", "utf-8", "yes");
            var res = doc.ToString();
            using (StreamWriter writer = new StreamWriter(@"d:\Sergey\test.xml", false, Encoding.UTF8))
            {
                doc.Save(writer);
            }
        }

        [Test]
        public void SimpleBackgroundToXmlTest()
        {
            var sourceStream = OpenEmbeddedResource("SimpleBackground.swf");
            var file = SwfFile.ReadFrom(sourceStream);
            var doc = new SwfMillFacade().ConvertToXml(file);
            new XmlComparision(XmlDifferenceHandler).Compare(doc, XDocument.Load(new StreamReader(OpenEmbeddedResource("SimpleBackground.xml"))));
        }

        private static void XmlDifferenceHandler(string message)
        {
            Assert.Fail(message);
        }

        private static Stream OpenEmbeddedResource(string name)
        {
            return typeof(SwfMillFacadeTest).Assembly.GetManifestResourceStream("Code.SwfLib.SwfMill.Tests.Resources." + name);
        }

    }
}