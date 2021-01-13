namespace FlowR.Library.Node.Collections
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionAttribute' visibile pubblicamente
    /// <summary>
    ///     Collection Attribute class that filter to only essential method
    /// </summary>
    public class DomNodeCollectionAttribute : DomNodeCollection<string>
    {
        /// <inheritdoc />
        public DomNodeCollectionAttribute(DomNode owner) : base(owner)
        {
        }

        /// <inheritdoc cref="DomNodeCollection{T}.Set" />
        /// summary>
        public void SetAttribute(string name, string value)
        {
            Set(name, value);
        }

        /// <inheritdoc cref="DomNodeCollection{T}.Exists" />
        /// summary>
        public bool HasAttribute(string name)
        {
            return Exists(name);
        }

        /// <inheritdoc cref="DomNodeCollection{T}.Unset" />
        /// summary>
        public void RemoveAttribute(string name)
        {
            Unset(name);
        }
    }
}