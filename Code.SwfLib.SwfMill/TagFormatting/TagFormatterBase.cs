using System;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.SwfMill.DataFormatting;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill.TagFormatting {
    public abstract class TagFormatterBase<T> : ITagFormatter<T> where T : SwfTagBase {

        private const string REST_ELEM = "rest";
        protected const string DATA_TAG = "data";
        protected const string OBJECT_ID_ATTRIB = "objectID";
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
            return FormatTagElement((T)tag);
        }

        void ITagFormatter.AcceptAttribute(SwfTagBase tag, XAttribute attrib) {
            AcceptTagAttribute((T)tag, attrib);
        }

        void ITagFormatter.AcceptElement(SwfTagBase tag, XElement element) {
            AcceptTagElement((T)tag, element);
        }

        public virtual void InitTag(T tag, XElement element) {
        }

        public XElement FormatElement(T tag) {
            var res = FormatTagElement(tag);
            if (tag.RestData != null && tag.RestData.Length > 0) {
                res.Add(new XElement(REST_ELEM, Convert.ToBase64String(tag.RestData)));
            }
            return res;
        }

        public void AcceptAttribute(T tag, XAttribute attrib) {
            AcceptTagAttribute(tag, attrib);
        }

        public void AcceptElement(T tag, XElement element) {
            switch (element.Name.LocalName) {
                case REST_ELEM:
                    tag.RestData = Convert.FromBase64String(element.Value);
                    break;
                default:
                    AcceptTagElement(tag, element);
                    break;
            }
        }

        protected abstract XElement FormatTagElement(T tag);
        protected abstract void AcceptTagAttribute(T tag, XAttribute attrib);
        protected abstract void AcceptTagElement(T tag, XElement element);

        #endregion

        protected string FormatFloat(double value) {
            string res = value.ToString();
            return res;
        }

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

        protected SwfRGB ParseRGBFromFirstChild(XElement elem) {
            var colorElem = elem.Element(XName.Get("Color"));
            SwfRGB rgb;
            rgb.Red = byte.Parse(colorElem.Attribute(XName.Get("red")).Value);
            rgb.Green = byte.Parse(colorElem.Attribute(XName.Get("green")).Value);
            rgb.Blue = byte.Parse(colorElem.Attribute(XName.Get("blue")).Value);
            return rgb;
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
