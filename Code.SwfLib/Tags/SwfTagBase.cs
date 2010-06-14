namespace Code.SwfLib.Tags
{
    public abstract class SwfTagBase
    {

        public SwfTagData RawData;

        public abstract object AcceptVistor(ISwfTagVisitor visitor);

    }
}
