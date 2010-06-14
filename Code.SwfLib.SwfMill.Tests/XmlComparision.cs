using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Code.SwfLib.SwfMill.Tests
{
    public class XmlComparision
    {
        private readonly Action<string> _diffHandler;

        public XmlComparision(Action<string> diffHandler)
        {
            _diffHandler = diffHandler;
        }

        public void Compare(string first, string second)
        {
            Compare(XDocument.Parse(first), XDocument.Parse(second));
        }

        public void Compare(XDocument first, XDocument second)
        {
            Compare(first.Root, second.Root);
        }

        public void Compare(Stream first, Stream second)
        {
            string firstXml, secondXml;
            using (var reader = new StreamReader(first))
            {
                firstXml = reader.ReadToEnd();
            }
            using (var reader = new StreamReader(second))
            {
                secondXml = reader.ReadToEnd();
            }
            Compare(firstXml, secondXml);
        }

        public void Compare(XElement first, XElement second)
        {
            if (!Compare(first.Name, second.Name)) OnElementNameDifference(first, second);

            Compare(first.Attributes(), second.Attributes());

            var elements1 = first.Elements().ToArray();
            var elements2 = second.Elements().ToArray();
            var max = Math.Max(elements1.Length, elements2.Length);
            for (var i = 0; i < max; i++)
            {
                var firstElement = (i < elements1.Length) ? elements1[i] : null;
                var secondElement = (i < elements2.Length) ? elements2[i] : null;
                if ((firstElement == null && secondElement != null) || (firstElement != null && secondElement == null))
                {
                    OnElementCountDifference(firstElement, secondElement);
                }
                Compare(firstElement, secondElement);
            }
        }

        public void Compare(IEnumerable<XAttribute> first, IEnumerable<XAttribute> second)
        {
            var comparision = first.FullOuterJoin(second, item => item.Name, item => item.Name,
                                (item1, item2) => new { First = item1, Second = item2 })
                                .ToArray();
            foreach (var item in comparision)
            {
                if ((item.First == null && item.Second != null) || (item.First != null && item.Second == null))
                {
                    OnAttributeCountDifference(item.First, item.Second);
                }
                Compare(item.First, item.Second);
            }
        }

        public void Compare(XAttribute first, XAttribute second)
        {
            if (first.Value != second.Value) OnAttributeValueDifference(first, second);
        }

        private static bool Compare(XName first, XName second)
        {
            return first.Equals(second);
        }

        protected void OnElementCountDifference(XElement first, XElement second)
        {
            var elem = first ?? second;
            var path = GetElementPath(elem);
            OnDifference("Elements differs at " + path);
        }

        protected void OnElementNameDifference(XElement first, XElement second)
        {
            var path = GetElementPath(first);
            OnDifference("Elements differs at " + path);
        }

        protected void OnAttributeCountDifference(XAttribute first, XAttribute second)
        {
            var attrib = first ?? second;
            var path = GetAttributePath(attrib);
            OnDifference("Attributes differs at " + path);
        }

        protected void OnAttributeValueDifference(XAttribute first, XAttribute second)
        {
            var path = GetAttributePath(first);
            OnDifference("Attribute value differs at " + path + ". First is " + first.Value + ", Second is " + second.Value);
        }

        protected void OnDifference(string message)
        {
            _diffHandler(message);
        }

        protected string GetElementPath(XElement el)
        {
            string res = "";
            while (el != null)
            {
                if (!string.IsNullOrEmpty(res)) res += "/";
                res += el.Name.LocalName;
                el = el.Parent;
            }
            return res;
        }

        protected string GetAttributePath(XAttribute el)
        {
            return GetElementPath(el.Parent) + "/@" + el.Name.LocalName;
        }
    }
}


