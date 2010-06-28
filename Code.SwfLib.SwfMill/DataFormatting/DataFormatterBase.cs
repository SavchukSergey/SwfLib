using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Code.SwfLib.SwfMill.DataFormatting {
    public abstract class DataFormatterBase<T> where T : struct {

        protected const string OBJECT_ID_ATTRIB = "objectID";

        protected readonly DataFormatters _formatters;

        protected DataFormatterBase(DataFormatters formatters) {
            _formatters = formatters;
        }

        protected abstract void InitData(XElement element, out T data);

        protected abstract void AcceptElement(XElement element, ref T data);

        protected abstract void AcceptAttribute(XAttribute attrib, ref T data);

        public abstract XElement Format(ref T data);

        public void Parse(XElement element, out T obj) {
            InitData(element, out obj);
            foreach (var attrib in element.Attributes()) {
                AcceptAttribute(attrib, ref obj);
            }
            foreach (var elem in element.Elements()) {
                AcceptElement(elem, ref obj);
            }
        }

        protected void OnUnknownElementFound(XElement elem) {
            throw new FormatException("Unknown element " + elem.Name.LocalName);
        }

        protected void OnUnknownAttributeFound(XAttribute elem) {
            throw new FormatException("Unknown attribute " + elem.Name.LocalName);
        }

    }
}
