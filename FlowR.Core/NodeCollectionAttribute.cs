namespace FlowR.Core
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionAttribute' visibile pubblicamente
    /// <summary>
    ///     Collection Attribute class that filter to only essential method
    /// </summary>
    public class NodeCollectionAttribute : NodeCollection<string>
    {
        /// <inheritdoc />
        public NodeCollectionAttribute(Node owner) : base(owner)
        {
        }

        /// <inheritdoc cref="NodeCollection{T}.Set" />
        /// summary>
        public void SetAttribute(string name, string value)
        {
            Set(name, value);
        }

        /// <inheritdoc cref="NodeCollection{T}.Exists" />
        /// summary>
        public bool HasAttribute(string name)
        {
            return Exists(name);
        }

        /// <inheritdoc cref="NodeCollection{T}.Unset" />
        /// summary>
        public void RemoveAttribute(string name)
        {
            Unset(name);
        }
    }
}