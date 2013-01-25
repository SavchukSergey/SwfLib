﻿using System;
using System.Xml.Linq;
using Code.SwfLib.Data;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class DefineSceneAndFrameLabelDataTagFormatter : TagFormatterBase<DefineSceneAndFrameLabelDataTag> {
        protected override XElement FormatTagElement(DefineSceneAndFrameLabelDataTag tag, XElement xTag) {
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

            return xTag;
        }

        protected override void AcceptTagAttribute(DefineSceneAndFrameLabelDataTag tag, XAttribute attrib) {
            throw new NotImplementedException();
        }

        protected override void AcceptTagElement(DefineSceneAndFrameLabelDataTag tag, XElement element) {
            var xScenes = element.Element("scenes");
            foreach (var xScene in xScenes.Elements()) {
                var xOffset = xScene.Attribute("offset");
                var xName = xScene.Attribute("name");
                var scene = new SceneOffsetData {
                    Offset = uint.Parse(xOffset.Value),
                    Name = xName.Value
                };
                tag.Scenes.Add(scene);
            }

            var xFrames = element.Element("frames");
            foreach (var xFrame in xFrames.Elements()) {
                var xNumber = xFrame.Attribute("number");
                var xLabel = xFrame.Attribute("label");
                var frame = new FrameLabelData() {
                    FrameNumber = uint.Parse(xNumber.Value),
                    Label = xLabel.Value
                };
                tag.Frames.Add(frame);
            }
        }

        public override string TagName {
            get { return "DefineSceneAndFrameLabelData"; }
        }
    }
}
