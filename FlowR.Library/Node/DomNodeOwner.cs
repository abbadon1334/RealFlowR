namespace FlowR.Library.Node
{
    public class DomNodeOwner : DomNodeText
    {
        private DomNode _owner;

        public DomNode GetOwner()
        {
            return _owner;
        }

        public void SetOwner(DomNode owner)
        {
            _owner = owner;
        }
    }
}