using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.SwfMill.DataFormatting;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public abstract class TagFormatterBase<T> : ITagFormatter<T> where T : SwfTagBase {

        private const string OBJECT_ID_ATTRIB = "objectID";
        private const string DATA_TAG = "data";
        private const string REST_ELEM = "rest";

        protected const string NAME_ATTRIB = "name";
        protected const string WIDTH_ATTRIB = "width";
        protected const string HEIGHT_ATTRIB = "height";


        protected const string TRANSFORM_TYPE_ELEM = "Transform";
        protected const string COLOR_TRANSFORM_TYPE_ELEM = "ColorTransform";

        protected readonly static DataFormatters _formatters = new DataFormatters();

        #region ITagFormatter

        public void InitTag(SwfTagBase tag, XElement element) {
            InitTag((T)tag, element);
        }

        XElement ITagFormatter.FormatTag(SwfTagBase tag) {
            return FormatElement((T)tag);
        }

        void ITagFormatter.AcceptAttribute(SwfTagBase tag, XAttribute attrib) {
            AcceptAttribute((T)tag, attrib);
        }

        void ITagFormatter.AcceptElement(SwfTagBase tag, XElement element) {
            AcceptElement((T)tag, element);
        }

        public virtual void InitTag(T tag, XElement element) {
        }

        public XElement FormatElement(T tag) {
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

        public void AcceptAttribute(T tag, XAttribute attrib) {
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

        public void AcceptElement(T tag, XElement element) {
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

        protected abstract void FormatTagElement(T tag, XElement xTag);

        protected virtual bool AcceptTagAttribute(T tag, XAttribute attrib) {
            return false;
        }

        protected virtual bool AcceptTagElement(T tag, XElement element) {
            return false;
        }

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

        #endregion

        protected byte[] FromBase64(XElement dataElement) {
            //TODO: why different depth??
            var data1 = dataElement.Element("data");
            if (data1 != null) dataElement = data1;
            data1 = dataElement.Element("data");
            if (data1 != null) dataElement = data1;
            return Convert.FromBase64String(dataElement.Value);
        }

        protected bool ParseBoolFromDigit(XAttribute attrib) {
            switch (attrib.Value) {
                case "1":
                    return true;
                case "0":
                    return false;
                default:
                    throw new FormatException("Invalid attribute value");
            }
        }

        protected string FormatBoolToDigit(bool val) {
            return val ? "1" : "0";
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
