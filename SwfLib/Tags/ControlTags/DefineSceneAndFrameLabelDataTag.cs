using System.Collections.Generic;
using Code.SwfLib.Data;

namespace Code.SwfLib.Tags.ControlTags {
    public class DefineSceneAndFrameLabelDataTag : ControlBaseTag {

        public readonly IList<SceneOffsetData> Scenes = new List<SceneOffsetData>();

        public readonly IList<FrameLabelData> Frames = new List<FrameLabelData>();

        public override SwfTagType TagType {
            get { return SwfTagType.DefineSceneAndFrameLabelData; }
        }

        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
