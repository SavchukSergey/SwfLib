﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.SwfLib.Tags
{
    public class DefineFontAlignZonesTag : SwfTagBase
    {

        public ushort ObjectID;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}