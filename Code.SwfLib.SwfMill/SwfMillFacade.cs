using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill {
    public class SwfMillFacade {

        private TagFormatterFactory _formatterFactory;

        public XDocument ConvertToXml(SwfFile file) {
            _formatterFactory = new TagFormatterFactory(file.FileInfo.Version);
            var doc = new XDocument(GetRoot(file));
            doc.Declaration = new XDeclaration("1.0", "utf-8", "yes");
            return doc;
        }

        public void Decompress(Stream source, Stream target) {
            var file = SwfFile.ReadFrom(source);
            file.WriteTo(target);
        }

        public Stream Compress(Stream source, Stream target) {
            throw new NotImplementedException();
        }

        public SwfFile ReadFromXml(XDocument doc) {
            var root = doc.Root;
            var file = new SwfFile();
            SwfFileInfo fileInfo;
            if (root == null || root.Name.LocalName != "swf") {
                throw new FormatException("Expected swf as root");
            }
            fileInfo.Version = byte.Parse(root.Attribute(XName.Get("version")).Value);
            fileInfo.Format = root.Attribute(XName.Get("compressed")).Value == "1" ? "CWS" : "FWS";
            fileInfo.FileLength = 0;
            file.FileInfo = fileInfo;

            var hdr = root.Element(XName.Get("Header"));
            file.Header.FrameRate = double.Parse(hdr.Attribute(XName.Get("framerate")).Value);
            file.Header.FrameCount = ushort.Parse(hdr.Attribute(XName.Get("frames")).Value);
            file.Header.FrameSize = XRect.FromXml(hdr.Element(XName.Get("size")).Element("Rectangle"));

            var formatterFactory = new TagFormatterFactory(fileInfo.Version);
            var tags = hdr.Element(XName.Get("tags"));
            foreach (var tagElem in tags.Elements()) {
                var tag = SwfTagNameMapping.CreateTagByXmlName(tagElem.Name.LocalName);
                var formatter = formatterFactory.GetFormatter(tag);
                formatter.InitTag(tag, tagElem);
                foreach (var attrib in tagElem.Attributes()) {
                    formatter.AcceptAttribute(tag, attrib);
                }
                foreach (var elem in tagElem.Elements()) {
                    formatter.AcceptElement(tag, elem);
                }
                file.Tags.Add(tag);
            }
            return file;
        }

        private XElement GetRoot(SwfFile file) {
            return new XElement(XName.Get("swf"),
                                new XAttribute(XName.Get("version"), file.FileInfo.Version),
                                new XAttribute(XName.Get("compressed"), IsCompressed(file) ? "1" : "0"),
                                GetSwfHeaderXml(file)
                );
        }

        private XElement GetTagsXml(IEnumerable<SwfTagBase> tags) {
            return new XElement(XName.Get("tags"), tags.Select(BuildTagXml));
        }

        private XElement BuildTagXml(SwfTagBase tag) {
            var formatter = _formatterFactory.GetFormatter(tag);
            return formatter.FormatTag(tag);
        }


        private XElement GetSwfHeaderXml(SwfFile file) {
            var header = file.Header;
            return new XElement(XName.Get("Header"),
                                new XAttribute(XName.Get("framerate"), header.FrameRate),
                                new XAttribute(XName.Get("frames"), header.FrameCount),
                                new XElement(XName.Get("size"), XRect.ToXml(header.FrameSize)),
                                GetTagsXml(file.Tags));
        }

        private static bool IsCompressed(SwfFile file) {
            switch (file.FileInfo.Format) {
                case "CWS":
                    return true;
                case "FWS":
                    return false;
                default:
                    throw new InvalidOperationException();
            }
        }

    }
}