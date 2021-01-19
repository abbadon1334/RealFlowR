namespace FlowR.Core
{
    /// <summary>
    ///     DomNode children Collection that filter to only essential method
    /// </summary>
    public class NodeCollectionNode : NodeCollection<Node>
    {
        /// <inheritdoc />
        public NodeCollectionNode(Node owner) : base(owner)
        {
        }

        /// <summary>
        ///     Add DomNode to collection.
        /// </summary>
        /// <remarks>Here happens the composition between child and parent elements</remarks>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node Add(Node node)
        {
            node.Application = Owner.Application;
            node.Owner = Owner;

            Set(node.Uuid, node);

            node.Application.RegisterComponent(node);
            node.Init();

            return node;
        }

        /// <inheritdoc cref="NodeCollection{T}.Unset" />
        /// summary>
        public void Remove(Node node)
        {
            node.Owner = null;
            node.Application = null;
            Unset(node.Uuid);

            Owner.Application.UnregisterComponent(node);
        }
    }
}