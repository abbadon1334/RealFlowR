namespace FlowR.Library.Node.Collections
{
    /// <summary>
    ///     DomNode children Collection that filter to only essential method
    /// </summary>
    public class DomNodeCollectionDomNode : DomNodeCollection<DomNode>
    {
        /// <inheritdoc />
        public DomNodeCollectionDomNode(DomNode owner) : base(owner)
        {
        }

        /// <summary>
        ///     Add DomNode to collection.
        /// </summary>
        /// <remarks>Here happens the composition between child and parent elements</remarks>
        /// <param name="node"></param>
        /// <returns></returns>
        public DomNode Add(DomNode node)
        {
            node.Application = Owner.Application;
            node.Owner = Owner;

            Set(node.Uuid, node);

            node.Application.RegisterComponent(node);
            node.Init();

            return node;
        }

        /// <inheritdoc cref="DomNodeCollection{T}.Unset" />
        /// summary>
        public void Remove(DomNode node)
        {
            node.Owner = null;
            node.Application = null;
            Unset(node.Uuid);

            Owner.Application.UnregisterComponent(node);
        }
    }
}