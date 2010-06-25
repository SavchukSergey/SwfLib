using Code.SwfLib.Tags.ControlTags;
using NUnit.Framework;

namespace Code.SwfLib.Tests.TagSerialization
{
    [TestFixture]
    public class EndTagTest : TagSerializationTestBase
    {

        [Test]
        public void SerializeTest()
        {
            var tag = new EndTag();
            SerializeAndCheck(tag, "00.000000", "00000000");
        }

        [Test]
        public void DeserializeTest()
        {
            DeserializeTag<EndTag>("00.00000000000000");
        }
    }
}
