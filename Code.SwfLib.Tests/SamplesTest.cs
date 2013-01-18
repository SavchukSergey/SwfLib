using System;
using System.IO;
using NUnit.Framework;

namespace Code.SwfLib.Tests {
    [TestFixture]
    public class SamplesTest {

        [Test]
        [Ignore]
        public void GrabAllSwfsFromMachine() {
            var source = @"C:\";
            var dirInfo = new DirectoryInfo(source);
            Grab(dirInfo);
        }

        public void Grab(DirectoryInfo source) {
            foreach (var subdir in source.GetDirectories()) {
                Grab(subdir);
            }
            foreach (var file in source.GetFiles("*.swf")) {
                try {
                    using (var stream = File.Open(file.FullName, FileMode.Open)) {
                        var swf = SwfFile.ReadFrom(stream);
                    }
                } catch {
                    Console.WriteLine("Couldn't grab {0}", file.FullName);
                }
            }
        }
    }
}
