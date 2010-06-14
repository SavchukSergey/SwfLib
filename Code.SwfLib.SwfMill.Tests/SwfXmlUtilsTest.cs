using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using NUnit.Framework;

namespace Code.SwfLib.SwfMill.Tests {
    [TestFixture]
    public class SwfXmlUtilsTest {

        [Test]
        public void SwfToXmlTest() {
            var source = this.GetType().Assembly.GetManifestResourceStream("Code.SwfLib.SwfMill.Tests.FlashTest.swf");
            var file = SwfModel.LoadSwf(source);
            var doc = new SwfXmlUtils().ToXml(file);
            doc.Declaration = new XDeclaration("1", "utf-8", "yes");
            var res = doc.ToString();
            using (StreamWriter writer = new StreamWriter(@"d:\Sergey\test.xml", false, Encoding.UTF8)) {
                doc.Save(writer);
            }
        }

        [Test]
        public void BgTest() {
            var source = this.GetType().Assembly.GetManifestResourceStream("Code.SwfLib.SwfMill.Tests.BackgroundTest.swf");
            var file = SwfModel.LoadSwf(source);
            var doc = new SwfXmlUtils().ToXml(file);
            var res = doc.ToString();
            using (StreamWriter writer = new StreamWriter(@"d:\Sergey\testbg.xml")) {
                writer.Write(res);
            }
        }

    }
}