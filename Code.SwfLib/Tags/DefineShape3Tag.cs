using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code.SwfLib.Data;

namespace Code.SwfLib.Tags
{
    public class DefineShape3Tag : SwfTagBase
    {

        public ushort ObjectID;

        public SwfRect Bounds;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
