﻿using System;
using System.IO;
using System.Xml.Linq;
using SwfLib.SwfMill.Utils;

namespace SwfLib.SwfMill {
    class Program {
        static void Main(string[] args) {
            if (args.Length < 1) {
                ShowUsage();
                return;
            }
            var command = args[0];
            switch (command) {
                case "help":
                    ShowUsage();
                    break;
                case "swf2xml":
                    SwfToXml(args);
                    break;
                case "xml2swf":
                    XmlToSwf(args);
                    break;
                case "decompress":
                    Decompress(args);
                    break;
                case "compress":
                    Compress(args);
                    break;
                default:
                    Console.WriteLine("Unknown command {0}", command);
                    break;
            }
        }

        static void SwfToXml(string[] args) {
            if (args.Length < 2) {
                Console.WriteLine("Source file wasn't specified");
                ShowUsage();
                return;
            }
            if (args.Length < 3) {
                Console.WriteLine("target file wasn't specified");
                ShowUsage();
                return;
            }
            using (var file = File.Open(args[1], FileMode.Open, FileAccess.Read)) {
                var swf = SwfFile.ReadFrom(file);
                var facade = new SwfMillFacade();
                var doc = facade.ConvertToXml(swf);
                doc.Save(args[2]);
            }
        }

        static void XmlToSwf(string[] args) {
            if (args.Length < 2) {
                Console.WriteLine("Source file wasn't specified");
                ShowUsage();
                return;
            }
            if (args.Length < 3) {
                Console.WriteLine("target file wasn't specified");
                ShowUsage();
                return;
            }
            using (var file = File.Open(args[1], FileMode.Open, FileAccess.Read)) {
                var facade = new SwfMillFacade();
                var doc = XDocument.Load(new StreamReader(file));
                SwfFile swf;
                try {
                    swf = facade.ReadFromXml(doc);
                } catch (SwfMillXmlException exc) {
                    Console.Error.Write(exc.Message);
                    return;
                }
                using (var target = File.Open(args[2], FileMode.Create, FileAccess.ReadWrite)) {
                    swf.WriteTo(target);
                }
            }
        }

        static void Decompress(string[] args) {
            if (args.Length < 2) {
                Console.WriteLine("Source file wasn't specified");
                ShowUsage();
                return;
            }
            var source = args[1];
            var target = args.Length < 3 ? source : args[2];
            var mem = new MemoryStream();
            using (var file = File.Open(source, FileMode.Open, FileAccess.Read)) {
                var facade = new SwfMillFacade();
                facade.Decompress(file, mem);
            }
            mem.Seek(0, SeekOrigin.Begin);
            using (var file = File.Open(target, FileMode.Create, FileAccess.ReadWrite)) {
                mem.WriteTo(file);
            }
        }

        static void Compress(string[] args) {
            if (args.Length < 3) {
                Console.WriteLine("Invalid number of arguments");
                ShowUsage();
                return;
            }
            SwfFormat format;
            if (!Enum.TryParse(args.Length < 4 ? args[2] : args[3], true, out format))
            {
                Console.WriteLine("Invalid output format signature");
                ShowUsage();
                return;
            }
            if (format == SwfFormat.FWS)
            {
                Console.WriteLine("FWS is an uncompressed format signature");
                ShowUsage();
                return;
            }
            var source = args[1];
            var target = args.Length < 4 ? source : args[2];

            var mem = new MemoryStream();
            using (var file = File.Open(source, FileMode.Open, FileAccess.Read)) {
                var facade = new SwfMillFacade();
                facade.Compress(file, mem, format);
            }
            mem.Seek(0, SeekOrigin.Begin);
            using (var file = File.Open(target, FileMode.Create, FileAccess.ReadWrite)) {
                mem.WriteTo(file);
            }
        }

        static void ShowUsage() {
            Console.WriteLine("codeswfmill is swf-xml and xml-swf conversion utility.");
            Console.WriteLine("Usage:");
            Console.WriteLine("codeswfmill.exe <command> <options>");
            Console.WriteLine("\tswf2xml <sourcePath> <targetPath>");
            Console.WriteLine("\t\tconverts swf to xml");
            Console.WriteLine("\txml2swf <sourcePath> <targetPath>");
            Console.WriteLine("\t\tconverts xml to swf");
            Console.WriteLine("\tdecompress <sourcePath> [<targetPath>]");
            Console.WriteLine("\t\tdecompresses swf file");
            Console.WriteLine("\tcompress <sourcePath> [<targetPath>] <flashSignature>");
            Console.WriteLine("\t\tcompresses swf file");
            Console.WriteLine("help show this information");
        }
    }
}
