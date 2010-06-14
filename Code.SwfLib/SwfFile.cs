using System.Collections.Generic;
using Code.SwfLib.Data;
using Code.SwfLib.Tags;

namespace Code.SwfLib {
    public class SwfFile {

        public SwfFileInfo FileInfo;

        public SwfHeader Header;

        public readonly IList<SwfTagBase> Tags = new List<SwfTagBase>();

    }
}
