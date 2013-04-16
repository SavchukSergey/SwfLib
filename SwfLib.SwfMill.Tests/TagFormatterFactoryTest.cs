using System;
using Code.SwfLib.Tags;
using NUnit.Framework;
using SwfLib.Tags;

namespace Code.SwfLib.SwfMill.Tests {
    [TestFixture]
    public class TagFormatterFactoryTest {

        [Test]
        public void CreateTest() {
            var factory = new TagFormatterFactory(10);
            var tagFactroy = new SwfTagsFactory();
            var vals = Enum.GetValues(typeof(SwfTagType));
            foreach (SwfTagType type in vals) {
                var tag = tagFactroy.Create(type);
                var formatter = factory.GetFormatter(tag);
                Assert.IsNotNull(formatter);
                if (formatter.GetType().Name != tag.GetType().Name + "Formatter") {
                    Console.WriteLine("Warning: Incosistent naming, Tag type: {0}, Class: {1}", type,
                                      formatter.GetType().Name);
                }
                var formatterType = formatter.GetType();
                Assert.AreEqual(tag.GetType(), formatterType.BaseType.GetGenericArguments()[0]);
            }
        }
    }
}
