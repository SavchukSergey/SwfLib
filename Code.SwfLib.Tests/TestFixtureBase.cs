using System;
using System.IO;

namespace Code.SwfLib.Tests {
    public class TestFixtureBase {

        protected Stream OpenEmbeddedResource(string resourceName) {
            var fullPath = "Code.SwfLib.Tests.Resources.";
            if (!string.IsNullOrEmpty(EmbeddedResourceFolder)) fullPath += EmbeddedResourceFolder + ".";
            fullPath += resourceName;
            var stream = GetType().Assembly.GetManifestResourceStream(fullPath);
            if (stream == null)
                throw new InvalidOperationException("Embedded resource " + resourceName + " is not found");
            return stream;
        }

        protected byte[] GetEmbeddedResourceData(string resourceName) {
            using (var stream = OpenEmbeddedResource(resourceName)) {
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
                return data;
            }
        }

        protected virtual string EmbeddedResourceFolder { get { return ""; } }
    }
}