using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Tags;

namespace Code.SwfLib.SwfMill {
    public class SwfMillFacade {

        private ISwfTagVisitor _tag2XmlBuilder;

        public XDocument ConvertToXml(SwfFile file) {
            _tag2XmlBuilder = new Tag2XmlVisitor(file.FileInfo.Version);
            XDocument doc = new XDocument(GetRoot(file));
            return doc;
        }

        public SwfFile ReadFromXml(XDocument doc) {
            var root = doc.Root;
            SwfFile file = new SwfFile();
            SwfFileInfo fileInfo;
            if (root == null || root.Name.LocalName != "swf") {
                throw new FormatException("Expected swf as root");
            }
            fileInfo.Version = byte.Parse(root.Attribute(XName.Get("version")).Value);
            fileInfo.Format = root.Attribute(XName.Get("compressed")).Value == "1" ? "CWS" : "FWS";
            fileInfo.FileLength = 0;
            file.FileInfo = fileInfo;
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
            return new XElement(XName.Get("tags"), tags.Select(item => BuildTagXml(item)));
        }

        private XElement BuildTagXml(SwfTagBase tag) {
            return (XElement)tag.AcceptVistor(_tag2XmlBuilder);
        }


        private XElement GetSwfHeaderXml(SwfFile file) {
            //TODO: This is strange that swfmill wants tags to be inside header... 
            var header = file.Header;
            return new XElement(XName.Get("Header"),
                                new XAttribute(XName.Get("framerate"), header.FrameRate),
                                new XAttribute(XName.Get("frames"), header.FrameCount),
                                new XElement(XName.Get("size"), GetRectangleXml(header.FrameSize)),
                                GetTagsXml(file.Tags));
        }

        private static XElement GetRectangleXml(SwfRect rect) {
            return new XElement(XName.Get("Rectangle"),
                                new XAttribute(XName.Get("left"), rect.XMin),
                                new XAttribute(XName.Get("right"), rect.XMax),
                                new XAttribute(XName.Get("top"), rect.YMin),
                                new XAttribute(XName.Get("bottom"), rect.YMax));
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