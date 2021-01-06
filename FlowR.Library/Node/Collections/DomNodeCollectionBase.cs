using System.Collections.Generic;
using System.Linq;

namespace FlowR.Library.Node.Collections
{
    public abstract class DomNodeCollection<T> : DomNodeOwner
    {
        private readonly IDictionary<string, T> _collection = new Dictionary<string, T>();

        protected DomNodeCollection(DomNode owner)
        {
            SetOwner(owner);
        }

        protected void Set(string name, T element)
        {
            _collection[name] = element;
        }

        protected void Unset(string name)
        {
            _collection.Remove(name);
        }

        protected bool Exists(string name)
        {
            return _collection.ContainsKey(name);
        }

        protected T Get(string name)
        {
            return _collection[name];
        }

        protected KeyValuePair<string, T>[] ToArray()
        {
            return _collection.ToArray();
        }
    }
}