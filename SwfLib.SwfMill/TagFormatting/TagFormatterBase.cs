using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.TagFormatting;
using Code.SwfLib.Tags;
using SwfLib.SwfMill.Data;

namespace SwfLib.SwfMill.TagFormatting {
    public abstract class TagFormatterBase<T> : ITagFormatter<T> where T : SwfTagBase {

        private const string OBJECT_ID_ATTRIB = "objectID";
        private const string DATA_TAG = "data";
        private const string REST_ELEM = "rest";

        protected const string NAME_ATTRIB = "name";
        protected const string WIDTH_ATTRIB = "width";
        protected const string HEIGHT_ATTRIB = "height";

        public T ParseTo(XElement xTag, T tag) {
            InitTag(tag, xTag);
            foreach (var attrib in xTag.Attributes()) {
                AcceptAttribute(tag, attrib);
            }
            foreach (var elem in xTag.Elements()) {
                AcceptElement(tag, elem);
            }
            return tag;
        }

        public XElement FormatTag(T tag) {
            var xTag = new XElement(TagName);
            var objectID = GetObjectID(tag);
            if (objectID.HasValue) {
                xTag.Add(new XAttribute(OBJECT_ID_ATTRIB, objectID.Value));
            }
            var data = GetData(tag);
            if (data != null) {
                xTag.Add(new XElement("data", XBinary.ToXml(data)));
            }

            FormatTagElement(tag, xTag);
            if (tag.RestData != null && tag.RestData.Length > 0) {
                xTag.Add(new XElement(REST_ELEM, Convert.ToBase64String(tag.RestData)));
            }
            return xTag;
        }


        protected virtual void InitTag(T tag, XElement element) {
        }

        protected void AcceptAttribute(T tag, XAttribute attrib) {
            switch (attrib.Name.LocalName) {
                case OBJECT_ID_ATTRIB:
                    SetObjectID(tag, ushort.Parse(attrib.Value));
                    break;
                default:
                    var handled = AcceptTagAttribute(tag, attrib);
                    if (!handled) throw new FormatException(string.Format("Unhandled attribute '{0}' in tag '{1}'", attrib.Name.LocalName, tag.TagType));
                    break;
            }
        }

        protected void AcceptElement(T tag, XElement element) {
            switch (element.Name.LocalName) {
                case REST_ELEM:
                    tag.RestData = Convert.FromBase64String(element.Value);
                    break;
                case DATA_TAG:
                    var data = XBinary.FromXml(element.Element("data"));
                    SetData(tag, data);
                    break;
                default:
                    var handled = AcceptTagElement(tag, element);
                    if (!handled) throw new FormatException("Invalid element " + element.Name.LocalName);
                    break;
            }
        }

        protected virtual bool AcceptTagAttribute(T tag, XAttribute attrib) {
            return false;
        }

        protected virtual bool AcceptTagElement(T tag, XElement element) {
            return false;
        }

        protected abstract void FormatTagElement(T tag, XElement xTag);

        #region ITagFormatter

        SwfTagBase ITagFormatter.ParseTo(XElement xTag, SwfTagBase tag) {
            return ParseTo(xTag, (T)tag);
        }

        XElement ITagFormatter.FormatTag(SwfTagBase tag) {
            return FormatTag((T)tag);
        }

        #endregion

        public abstract string TagName { get; }

        protected virtual ushort? GetObjectID(T tag) {
            return null;
        }

        protected virtual void SetObjectID(T tag, ushort value) {
        }

        protected virtual byte[] GetData(T tag) {
            return null;
        }

        protected virtual void SetData(T tag, byte[] data) {

        }

        protected byte[] FromBase64(XElement dataElement) {
            //TODO: why different depth??
            var data1 = dataElement.Element("data");
            if (data1 != null) dataElement = data1;
            data1 = dataElement.Element("data");
            if (data1 != null) dataElement = data1;
            return Convert.FromBase64String(dataElement.Value);
        }

        protected static byte[] ReadBase64(XElement data) {
            string val = data.Value
                .Replace(" ", "")
                .Replace("\r", "")
                .Replace("\n", "");
            return Convert.FromBase64String(val);
        }

        protected static XElement GetBinary(byte[] data) {
            return new XElement("data", Convert.ToBase64String(data));
        }

    }
}
