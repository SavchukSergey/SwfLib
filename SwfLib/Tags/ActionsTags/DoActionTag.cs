using System.Collections.Generic;
using SwfLib.Actions;

namespace SwfLib.Tags.ActionsTags {
    /// <summary>
    /// Represents DoAction tag.
    /// </summary>
    public class DoActionTag : ActionsBaseTag {

        /// <summary>
        /// Gets list of actions.
        /// </summary>
        public readonly IList<ActionBase> ActionRecords = new List<ActionBase>();

        /// <summary>
        /// Gets swf tag type.
        /// </summary>
        public override SwfTagType TagType {
            get { return SwfTagType.DoAction; }
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