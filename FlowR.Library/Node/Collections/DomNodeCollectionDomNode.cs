namespace FlowR.Library.Node.Collections
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionDomNode' visibile pubblicamente
    public class DomNodeCollectionDomNode : DomNodeCollection<DomNode>
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionDomNode' visibile pubblicamente
    {
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionDomNode.DomNodeCollectionDomNode(DomNode)' visibile pubblicamente
        public DomNodeCollectionDomNode(DomNode owner) : base(owner)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionDomNode.DomNodeCollectionDomNode(DomNode)' visibile pubblicamente
        {
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionDomNode.Add(DomNode)' visibile pubblicamente
        public DomNode Add(DomNode node)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionDomNode.Add(DomNode)' visibile pubblicamente
        {
            node.SetApplication(GetOwner().GetApplication());
            node.SetOwner(GetOwner());

            Set(node.GetUuid(), node);

            node.GetApplication().RegisterComponent(node);
            node.Init();

            return node;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionDomNode.Remove(DomNode)' visibile pubblicamente
        public void Remove(DomNode node)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionDomNode.Remove(DomNode)' visibile pubblicamente
        {
            node.SetOwner(null);
            node.SetApplication(null);
            Unset(node.GetUuid());

            GetOwner().GetApplication().UnregisterComponent(node);
        }
    }
}