using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill {
    public class SwfTagParser : ISwfTagVisitor {
        private readonly ushort _version;
        private XElement _currentXml;
        public SwfTagParser(ushort version) {
            _version = version;
        }

        public SwfTagBase Parse(XElement xml) {
            lock (this) {
                this._currentXml = xml;
                var tag = SwfTagNameMapping.CreateTagByXmlName(xml.Name.LocalName);
                tag.AcceptVistor(this);
                return tag;
            }
        }

        #region ISwfTagVisitor Members

        object ISwfTagVisitor.Visit(CSMTextSettingsTag tag) {
            throw new NotImplementedException();
        }

        object ISwfTagVisitor.Visit(DefineFontNameTag tag) {
            throw new NotImplementedException();
        }

        object ISwfTagVisitor.Visit(DefineSpriteTag tag) {
            throw new NotImplementedException();
        }

        object ISwfTagVisitor.Visit(DefineTextTag tag) {
            throw new NotImplementedException();
        }

        object ISwfTagVisitor.Visit(EndTag tag) {
            throw new NotImplementedException();
        }

        object ISwfTagVisitor.Visit(ExportTag tag) {
            throw new NotImplementedException();
        }

        object ISwfTagVisitor.Visit(FileAttributesTag tag) {
            throw new NotImplementedException();
        }

        object ISwfTagVisitor.Visit(MetadataTag tag) {
            throw new NotImplementedException();
        }

        object ISwfTagVisitor.Visit(PlaceObject2Tag tag) {
            throw new NotImplementedException();
        }

        object ISwfTagVisitor.Visit(SetBackgroundColorTag tag) {
            throw new NotImplementedException();
        }

        object ISwfTagVisitor.Visit(ShowFrameTag tag) {
            throw new NotImplementedException();
        }

        object ISwfTagVisitor.Visit(SwfTagBase tag) {
            throw new NotImplementedException();
        }

        object ISwfTagVisitor.Visit(UnknownTag tag) {
            throw new NotImplementedException();
        }

        #endregion
    }
}
