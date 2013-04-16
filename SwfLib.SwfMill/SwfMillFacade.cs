using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags;
using SwfLib;
using SwfLib.SwfMill.Utils;
using SwfLib.Tags;

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
            SwfFile.Decompress(source, target);
        }

        public void Compress(Stream source, Stream target) {
            SwfFile.Compress(source,  target);
        }

        public SwfFile ReadFromXml(XDocument doc) {
            var root = doc.Root;
            var file = new SwfFile();
            SwfFileInfo fileInfo;
            if (root == null || root.Name.LocalName != "swf") {
                throw new FormatException("Expected swf as root");
            }
            fileInfo.Version = root.RequiredByteAttribute("version");
            fileInfo.Format = root.RequiredBoolAttribute("compressed") ? "CWS" : "FWS";
            fileInfo.FileLength = 0;
            file.FileInfo = fileInfo;

            var hdr = root.RequiredElement("Header");
            file.Header.FrameRate = hdr.RequiredDoubleAttribute("framerate");
            file.Header.FrameCount = hdr.RequiredUShortAttribute("frames");
            file.Header.FrameSize = XRect.FromXml(hdr.RequiredElement("size").Element("Rectangle"));

            var formatterFactory = new TagFormatterFactory(fileInfo.Version);
            var tags = hdr.RequiredElement("tags");
            foreach (var xTag in tags.Elements()) {
                var tag = SwfTagNameMapping.CreateTagByXmlName(xTag.Name.LocalName);
                var formatter = formatterFactory.GetFormatter(tag);
                tag = formatter.ParseTo(xTag, tag);
                file.Tags.Add(tag);
            }
            return file;
        }

        private XElement GetRoot(SwfFile file) {
            return new XElement("swf",
                                new XAttribute("version", file.FileInfo.Version),
                                new XAttribute("compressed", IsCompressed(file) ? "1" : "0"),
                                GetSwfHeaderXml(file)
                );
        }

        private XElement GetTagsXml(IEnumerable<SwfTagBase> tags) {
            return new XElement("tags", tags.Select(BuildTagXml));
        }

        private XElement BuildTagXml(SwfTagBase tag) {
            var formatter = _formatterFactory.GetFormatter(tag);
            return formatter.FormatTag(tag);
        }


        private XElement GetSwfHeaderXml(SwfFile file) {
            var header = file.Header;
            return new XElement("Header",
                                new XAttribute("framerate", header.FrameRate),
                                new XAttribute("frames", header.FrameCount),
                                new XElement("size", XRect.ToXml(header.FrameSize)),
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