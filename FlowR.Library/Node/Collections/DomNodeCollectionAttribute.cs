namespace FlowR.Library.Node.Collections
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionAttribute' visibile pubblicamente
    public class DomNodeCollectionAttribute : DomNodeCollection<string>
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionAttribute' visibile pubblicamente
    {
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionAttribute.DomNodeCollectionAttribute(DomNode)' visibile pubblicamente
        public DomNodeCollectionAttribute(DomNode owner) : base(owner)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionAttribute.DomNodeCollectionAttribute(DomNode)' visibile pubblicamente
        {
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionAttribute.SetAttribute(string, string)' visibile pubblicamente
        public void SetAttribute(string name, string value)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionAttribute.SetAttribute(string, string)' visibile pubblicamente
        {
            Set(name, value);
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionAttribute.HasAttribute(string)' visibile pubblicamente
        public bool HasAttribute(string name)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionAttribute.HasAttribute(string)' visibile pubblicamente
        {
            return Exists(name);
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionAttribute.RemoveAttribute(string)' visibile pubblicamente
        public void RemoveAttribute(string name)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionAttribute.RemoveAttribute(string)' visibile pubblicamente
        {
            Unset(name);
        }
    }
}