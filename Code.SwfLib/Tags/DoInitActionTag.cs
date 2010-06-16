﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.SwfLib.Tags
{
    public class DoInitActionTag : SwfTagBase
    {
        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}