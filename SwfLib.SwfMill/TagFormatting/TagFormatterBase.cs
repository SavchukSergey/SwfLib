using System;
using System.Xml.Linq;
using SwfLib.SwfMill.Data;
using SwfLib.Tags;

namespace SwfLib.SwfMill.TagFormatting {
    /// <summary>
    /// Represents base swf tag formatter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class TagFormatterBase<T> : ITagFormatter<T> where T : SwfTagBase {

        private const string OBJECT_ID_ATTRIB = "objectID";
        private const string DATA_TAG = "data";
        private const string REST_ELEM = "rest";

        protected const string NAME_ATTRIB = "name";
        protected const string WIDTH_ATTRIB = "width";
        protected const string HEIGHT_ATTRIB = "height";

        /// <summary>
        /// Parses tag from xml node
        /// </summary>
        /// <param name="xTag"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Formats tag into xml
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
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
                xTag.Add(new XElement(REST_ELEM, FormatBase64(tag.RestData)));
            }
            return xTag;
        }


        /// <summary>
        /// Initilizaes tag before parsing xml node.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="element"></param>
        protected virtual void InitTag(T tag, XElement element) {
        }

        /// <summary>
        /// Accepts xml attribute during parsing.
        /// </summary>
        /// <param name="tag">Tag to accept attribute</param>
        /// <param name="attrib">Atribute to be accepted.</param>
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

        /// <summary>
        /// Accepts xml element during parsing.
        /// </summary>
        /// <param name="tag">Tag to accept element</param>
        /// <param name="element">Element to be accepted.</param>
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

        /// <summary>
        /// Accepts xml attribute during parsing.
        /// </summary>
        /// <param name="tag">Tag to accept attribute</param>
        /// <param name="attrib">Atribute to be accepted.</param>
        protected virtual bool AcceptTagAttribute(T tag, XAttribute attrib) {
            return false;
        }

        /// <summary>
        /// Accepts xml element during parsing.
        /// </summary>
        /// <param name="tag">Tag to accept element</param>
        /// <param name="element">Element to be accepted.</param>
        protected virtual bool AcceptTagElement(T tag, XElement element) {
            return false;
        }

        /// <summary>
        /// Formats tag into xml
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        protected abstract void FormatTagElement(T tag, XElement xTag);

        #region ITagFormatter

        SwfTagBase ITagFormatter.ParseTo(XElement xTag, SwfTagBase tag) {
            return ParseTo(xTag, (T)tag);
        }

        XElement ITagFormatter.FormatTag(SwfTagBase tag) {
            return FormatTag((T)tag);
        }

        #endregion

        /// <summary>
        /// Gets xml element name.
        /// </summary>
        public abstract string TagName { get; }

        /// <summary>
        /// Gets tag object id.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        protected virtual ushort? GetObjectID(T tag) {
            return null;
        }

        /// <summary>
        /// Sets tag object id.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="value"></param>
        protected virtual void SetObjectID(T tag, ushort value) {
        }

        protected virtual byte[] GetData(T tag) {
            return null;
        }

        protected virtual void SetData(T tag, byte[] data) {

        }

        protected string FormatBase64(byte[] data) {
            return Convert.ToBase64String(data);
        }

        protected byte[] ParseBase64(string val) {
            return Convert.FromBase64String(val);
        }

    }
}
