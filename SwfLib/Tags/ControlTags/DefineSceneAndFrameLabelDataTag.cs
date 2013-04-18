using System.Collections.Generic;
using SwfLib.Data;

namespace SwfLib.Tags.ControlTags {
    public class DefineSceneAndFrameLabelDataTag : ControlBaseTag {

        public readonly IList<SceneOffsetData> Scenes = new List<SceneOffsetData>();

        public readonly IList<FrameLabelData> Frames = new List<FrameLabelData>();

        /// <summary>
        /// Gets swf tag type.
        /// </summary>
        public override SwfTagType TagType {
            get { return SwfTagType.DefineSceneAndFrameLabelData; }
        }

        /// <summary>
        /// Accept visitor.
        /// </summary>
        /// <typeparam name="TArg">Type of argument to be passed to visitor.</typeparam>
        /// <typeparam name="TResult">Type of result.</typeparam>
        /// <param name="visitor">Visitor.</param>
        /// <param name="arg">Argument to be passed to visitor.</param>
        /// <returns></returns>
        public override TResult AcceptVistor<TArg, TResult>(ISwfTagVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

    }
}
