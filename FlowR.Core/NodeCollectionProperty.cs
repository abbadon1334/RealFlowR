namespace FlowR.Core
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionProperty' visibile pubblicamente
    public class NodeCollectionProperty : NodeCollection<string>
    {
        /// <inheritdoc />
        public NodeCollectionProperty(Node owner) : base(owner)
        {
        }

        /// <summary>
        ///     Set a DomNode property
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetProperty(string name, string value)
        {
            Set(name, value);
        }
    }
}