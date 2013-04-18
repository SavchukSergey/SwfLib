using System.Collections.Generic;
using SwfLib.Buttons;

namespace SwfLib.Tags.ButtonTags {
    /// <summary>
    /// Represents DefineButton2 tag.
    /// </summary>
    public class DefineButton2Tag : DefineButtonBaseTag {

        public byte ReservedFlags { get; set; }

        public bool TrackAsMenu { get; set; }

        public readonly IList<ButtonRecordEx> Characters = new List<ButtonRecordEx>();

        public readonly IList<ButtonCondition> Conditions = new List<ButtonCondition>();

        /// <summary>
        /// Gets swf tag type.
        /// </summary>
        public override SwfTagType TagType {
            get { return SwfTagType.DefineButton2; }
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
