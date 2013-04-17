namespace SwfLib.Tags {
    /// <summary>
    /// Represents swf tag data
    /// </summary>
    public class SwfTagData {

        /// <summary>
        /// Gets or sets swf tag type.
        /// </summary>
        public SwfTagType Type { get; set; }

        /// <summary>
        /// Gets or sets tag binary data.
        /// </summary>
        public byte[] Data { get; set; }
    }
}