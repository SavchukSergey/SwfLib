using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.TagFormatting;
using Code.SwfLib.Tags;
using NUnit.Framework;

namespace Code.SwfLib.SwfMill.Tests.TagFormatting {
    public abstract class BaseTagFormattingTest<T, F>
        where T : SwfTagBase
        where F : TagFormatterBase<T>, new() {

        private readonly F _formatter = new F();

        protected void ConvertToXmlAndCompare(T tag, string resourceXml) {
            var doc =_formatter.FormatTag(tag);
            new XmlComparision(XmlDifferenceHandler).Compare(doc, XDocument.Load(new StreamReader(OpenEmbeddedResource(resourceXml))).Root);
        }

        private Stream OpenEmbeddedResource(string name) {
            return GetType().Assembly.GetManifestResourceStream("Code.SwfLib.SwfMill.Tests.Resources.TagFormatting." + name);
        }

        private static void XmlDifferenceHandler(string message) {
            Assert.Fail(message);
        }
    }
}
