using System.Collections.Generic;
using System.Xml.Linq;
using SwfLib.Actions;

namespace SwfLib.SwfMill.Actions {
    /// <summary>
    /// Represents ActionScript actions xml formatter.
    /// </summary>
    public static class XAction {

        private static readonly XActionReader _reader = new XActionReader();
        private static readonly XActionWriter _writer = new XActionWriter();

        /// <summary>
        /// Formats action to xml representation.
        /// </summary>
        /// <param name="action">Action to format.</param>
        /// <returns>Action xml representation.</returns>
        public static XElement ToXml(ActionBase action) {
            return _writer.Serialize(action);
        }

        /// <summary>
        /// Parses action from xml representation.
        /// </summary>
        /// <param name="xAction">Action xml to parse.</param>
        /// <returns>Parsed action.</returns>
        public static ActionBase FromXml(XElement xAction) {
            return _reader.Deserialize(xAction);
        }

        /// <summary>
        /// Formats list of actions to xml representation.
        /// </summary>
        /// <param name="actions">List of actions to format.</param>
        /// <param name="xActions">Xml container where to put formatted actions.</param>
        /// <returns>Xml container where formatted action was put.</returns>
        public static XElement ToXml(IList<ActionBase> actions, XElement xActions) {
            foreach (var action in actions) {
                xActions.Add(ToXml(action));
            }
            return xActions;
        }

        /// <summary>
        /// Parses actions from xml representation.
        /// </summary>
        /// <param name="xActions">Xml container with formatted actions.</param>
        /// <param name="actions">List object where to put parsed actions.</param>
        public static void FromXml(XElement xActions, IList<ActionBase> actions) {
            foreach (var xAction in xActions.Elements()) {
                actions.Add(FromXml(xAction));
            }
        }
    }
}
