using System.Collections.Generic;
using SwfLib.Avm2.Opcodes;

namespace SwfLib.Avm2 {
    public class AbcMethodBody {

        private readonly IList<AbcTrait> _traits = new List<AbcTrait>();
        private readonly IList<AbcExceptionBlock> _exceptions = new List<AbcExceptionBlock>();
        private readonly IList<AbcMethodBodyInstruction> _code = new List<AbcMethodBodyInstruction>();

        public uint MaxStack { get; set; }

        public uint LocalCount { get; set; }

        public uint InitScopeDepth { get; set; }

        public uint MaxScopeDepth { get; set; }

        public IList<AbcExceptionBlock> Exceptions {
            get { return _exceptions; }
        }

        public IList<AbcTrait> Traits {
            get { return _traits; }
        }

        public IList<AbcMethodBodyInstruction> Code {
            get { return _code; }
        }
    }

    public struct AbcMethodBodyInstruction {

        public uint Offset { get; set; }

        public BaseAvm2Opcode Opcode { get; set; }

        public override string ToString() {
            return string.Format("{0:x6}: {1}", Offset, Opcode);
        }
    }
}
