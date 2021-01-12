namespace FlowR.Library.Node.Collections
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionProperty' visibile pubblicamente
    public class DomNodeCollectionProperty : DomNodeCollection<string>
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionProperty' visibile pubblicamente
    {
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionProperty.DomNodeCollectionProperty(DomNode)' visibile pubblicamente
        public DomNodeCollectionProperty(DomNode owner) : base(owner)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionProperty.DomNodeCollectionProperty(DomNode)' visibile pubblicamente
        {
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionProperty.SetProperty(string, string)' visibile pubblicamente
        public void SetProperty(string name, string value)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionProperty.SetProperty(string, string)' visibile pubblicamente
        {
            Set(name, value);
        }
    }
}