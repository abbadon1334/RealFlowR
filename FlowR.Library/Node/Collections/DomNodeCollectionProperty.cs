namespace FlowR.Library.Node.Collections
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionProperty' visibile pubblicamente
    public class DomNodeCollectionProperty : DomNodeCollection<string>
    {
        /// <inheritdoc/>
        public DomNodeCollectionProperty(DomNode owner) : base(owner)
        {
        }

        /// <summary>
        /// Set a DomNode property
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetProperty(string name, string value)
        {
            Set(name, value);
        }
    }
}