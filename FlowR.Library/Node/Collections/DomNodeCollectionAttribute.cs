namespace FlowR.Library.Node.Collections
{
    public class DomNodeCollectionAttribute : DomNodeCollection<string>
    {
        public DomNodeCollectionAttribute(DomNode owner) : base(owner)
        {
        }

        public void SetAttribute(string name, string value)
        {
            Set(name, value);
        }

        public bool HasAttribute(string name)
        {
            return Exists(name);
        }

        public void RemoveAttribute(string name)
        {
            Unset(name);
        }
    }
}