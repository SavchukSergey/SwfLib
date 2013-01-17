using System;
using Code.SwfLib.Tags;
using NUnit.Framework;

namespace Code.SwfLib.Tests.Tags {
    [TestFixture]
    public class SwfTagsFactoryTest {

        [Test]
        public void AllTagsBuildTest() {
            var factory = new SwfTagsFactory();
            var vals = Enum.GetValues(typeof(SwfTagType));
            foreach (SwfTagType type in vals) {
                var tag = factory.Create(type);
                Assert.IsNotNull(tag);
                if (tag.GetType().Name != type.ToString() + "Tag") {
                    Console.WriteLine("Warning: Incosistent naming, Tag type: {0}, Class: {1}", type, tag.GetType().Name);
                }
                var actualType = tag.TagType;
                Assert.AreEqual(type, actualType);
            }
        }
    }
}
