namespace Code.SwfLib.Tags
{
    public class ScriptLimitsTag : SwfTagBase{

        public ushort MaxRecursionDepth;

        public ushort ScriptTimeoutSeconds;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}