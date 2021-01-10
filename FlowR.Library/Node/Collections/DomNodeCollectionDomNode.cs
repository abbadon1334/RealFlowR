namespace FlowR.Library.Node.Collections
{
    public class DomNodeCollectionDomNode : DomNodeCollection<DomNode>
    {
        public DomNodeCollectionDomNode(DomNode owner) : base(owner)
        {
        }

        public DomNode Add(DomNode node)
        {
            node.SetApplication(GetOwner().GetApplication());
            node.SetOwner(GetOwner());

            Set(node.GetUuid(), node);

            node.GetApplication().RegisterComponent(node);
            node.Init();

            return node;
        }

        public void Remove(DomNode node)
        {
            node.SetOwner(null);
            node.SetApplication(null);
            Unset(node.GetUuid());

            GetOwner().GetApplication().UnregisterComponent(node);
        }
    }
}