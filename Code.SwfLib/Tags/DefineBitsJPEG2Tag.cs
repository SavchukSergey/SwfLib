﻿namespace Code.SwfLib.Tags
{
    public class DefineBitsJPEG2Tag : SwfTagBase
    {

        public ushort ObjectID;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
