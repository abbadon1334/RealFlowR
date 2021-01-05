namespace FlowR.Library.Node
{
    public class DomNodeChildren : DomNodeCollection<DomNode>
    {
        public DomNodeChildren(DomNode owner) : base(owner)
        {
        }

        public void Add(DomNode node)
        {
            node.SetApplication(GetOwner().GetApplication());
            node.SetOwner(GetOwner());
            Set(node.GetUuid(), node);
            node.Init();
        }

        public void Remove(DomNode node)
        {
            node.SetOwner(null);
            node.SetApplication(null);
            Unset(node.GetUuid());
        }
    }
}