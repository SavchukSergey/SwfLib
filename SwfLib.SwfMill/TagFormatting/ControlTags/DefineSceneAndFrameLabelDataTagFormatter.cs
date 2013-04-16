using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.SwfMill.Utils;
using Code.SwfLib.Tags.ControlTags;
using SwfLib.SwfMill.TagFormatting;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class DefineSceneAndFrameLabelDataTagFormatter : TagFormatterBase<DefineSceneAndFrameLabelDataTag> {
        protected override void FormatTagElement(DefineSceneAndFrameLabelDataTag tag, XElement xTag) {
            var xScenes = new XElement("scenes");
            foreach (var scene in tag.Scenes) {
                var xScene = new XElement("Scene",
                    new XAttribute("offset", scene.Offset),
                    new XAttribute("name", scene.Name));
                xScenes.Add(xScene);
            }
            xTag.Add(xScenes);

            var xFrames = new XElement("frames");
            foreach (var frame in tag.Frames) {
                var xFrame = new XElement("Frame",
                    new XAttribute("number", frame.FrameNumber),
                    new XAttribute("label", frame.Label));
                xFrames.Add(xFrame);
            }
            xTag.Add(xFrames);

        }

        protected override bool AcceptTagElement(DefineSceneAndFrameLabelDataTag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "scenes":
                    var xScenes = element;
                    foreach (var xScene in xScenes.Elements()) {
                        var scene = new SceneOffsetData {
                            Offset = xScene.RequiredUIntAttribute("offset"),
                            Name = xScene.RequiredStringAttribute("name")
                        };
                        tag.Scenes.Add(scene);
                    }
                    break;
                case "frames":
                    var xFrames = element;
                    foreach (var xFrame in xFrames.Elements()) {
                        var frame = new FrameLabelData {
                            FrameNumber = xFrame.RequiredUIntAttribute("number"),
                            Label = xFrame.RequiredStringAttribute("label")
                        };
                        tag.Frames.Add(frame);
                    }
                    break;
                default:
                    return false;
            }
            return true;
        }

        public override string TagName {
            get { return "DefineSceneAndFrameLabelData"; }
        }
    }
}
