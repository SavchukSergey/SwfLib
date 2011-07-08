using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Code.SwfLib.SwfMill.Console {
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
                    return;
                case "swf2xml":
                    SwfToXml(args);
                    return;
                case "xml2swf":
                    XmlToSwf(args);
                    return;
            }
            System.Console.WriteLine(command);
        }

        static void SwfToXml(string[] args) {
            if (args.Length < 2) {
                System.Console.WriteLine("Source file wasn't specified");
                ShowUsage();
                return;
            }
            if (args.Length < 3) {
                System.Console.WriteLine("target file wasn't specified");
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
                System.Console.WriteLine("Source file wasn't specified");
                ShowUsage();
                return;
            }
            if (args.Length < 3) {
                System.Console.WriteLine("target file wasn't specified");
                ShowUsage();
                return;
            }
            using (var file = File.Open(args[1], FileMode.Open, FileAccess.Read)) {
                var facade = new SwfMillFacade();
                var doc = XDocument.Load(new StreamReader(file));
                var swf = facade.ReadFromXml(doc);
                using (var target = File.Open(args[2], FileMode.Create, FileAccess.ReadWrite)) {
                    swf.WriteTo(target);
                }
            }
        }

        static void ShowUsage() {
            System.Console.WriteLine("codeswfmill is swf-xml and xml-swf conversion utility.");
            System.Console.WriteLine("Usage:");
            System.Console.WriteLine("\tcodeswfmill.exe [swf2xml | xml2swf | help] {sourcePath targetPath}");
        }
    }
}
