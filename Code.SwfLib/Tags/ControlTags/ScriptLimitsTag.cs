namespace Code.SwfLib.Tags.ControlTags
{
    public class ScriptLimitsTag : ControlBaseTag
    {

        public ushort MaxRecursionDepth;

        public ushort ScriptTimeoutSeconds;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}