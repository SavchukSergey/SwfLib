using Code.SwfLib.Tags.ControlTags;
using NUnit.Framework;

namespace Code.SwfLib.Tests.TagSerialization
{
    [TestFixture]
    public class FileAttributesTagTest : TagSerializationTestBase
    {

        [Test]
        public void SerializeTest()
        {
            var tag = new FileAttributesTag();
            tag.HasMetadata = true;
            tag.UseNetwork = true;
            SerializeAndCheck(tag, "01.000100", "00010001", "00010001.00000000.00000000.00000000");
        }

        [Test]
        public void DeserializeTest()
        {
            var tag = DeserializeTag<FileAttributesTag>("01.000100", "00010001", "00010001.00000000.00000000.00000000");
            Assert.IsTrue(tag.HasMetadata);
            Assert.IsTrue(tag.UseNetwork);
            Assert.IsFalse(tag.AllowAbc);
        }


    }
}
