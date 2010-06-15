namespace Code.SwfLib.Tags.DisplayListTags
{
    public class PlaceObject3Tag : DisplayListBaseTag
    {

        public ushort ObjectID;
        
        public string Name;

        public override object AcceptVistor(ISwfTagVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}