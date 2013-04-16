using Code.SwfLib.Data;
using Code.SwfLib.SwfMill.TagFormatting.ControlTags;
using Code.SwfLib.Tags.ControlTags;
using NUnit.Framework;
using SwfLib.Tests.Asserts.Tags;

namespace Code.SwfLib.SwfMill.Tests.TagFormatting.ControlTags {
    [TestFixture]
    public class DefineSceneAndFrameLabelDataTagTest : BaseTagFormattingTest<DefineSceneAndFrameLabelDataTag, DefineSceneAndFrameLabelDataTagFormatter> {

        [Test]
        public void FormatTest() {
            var tag = GetDefineSceneAndFrameLabelDataTag();
            ConvertToXmlAndCompare(tag, "ControlTags.DefineSceneAndFrameLabelDataTag.xml");
        }

        [Test]
        public void ParseTest() {
            var tag = ParseTagFromResource("ControlTags.DefineSceneAndFrameLabelDataTag.xml");
            AssertTag.AreEqual(GetDefineSceneAndFrameLabelDataTag(), tag, "DefineSceneAndFrameLabelDataTag");
        }

        private static DefineSceneAndFrameLabelDataTag GetDefineSceneAndFrameLabelDataTag() {
            return new DefineSceneAndFrameLabelDataTag {
                Scenes = {
                    new SceneOffsetData { Name = "abc", Offset = 20},
                    new SceneOffsetData { Name = "abcdef", Offset = 30},
                },
                Frames = {
                    new FrameLabelData {Label = "qwe", FrameNumber = 2},
                    new FrameLabelData {Label = "qwerty", FrameNumber = 5},
                }
            };
        }

    }
}
