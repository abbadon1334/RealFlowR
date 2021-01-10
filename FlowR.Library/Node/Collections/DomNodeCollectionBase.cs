using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowR.Library.Node.Collections
{
    public abstract class DomNodeCollection<T> : DomNodeOwner
    {
        protected readonly Dictionary<string, T> Collection = new();

        public EventHandler AfterAdded;
        public EventHandler AfterChanged;
        public EventHandler AfterRemoved;

        public EventHandler BeforeAdded;
        public EventHandler BeforeChanged;
        public EventHandler BeforeRemoved;

        protected DomNodeCollection(DomNode owner)
        {
            SetOwner(owner);
        }

        protected void Set(string name, T value)
        {
            var oldValue = value;
            var exists = Exists(name);

            if (!exists)
                BeforeAdded?.Invoke(GetOwner(), new CollectionAddedEventArgs<T>
                {
                    Name = name,
                    Value = value
                });

            if (!exists)
                BeforeChanged?.Invoke(GetOwner(), new CollectionChangedEventArgs<T>
                {
                    Name = name,
                    Value = value,
                    OldValue = oldValue
                });

            Collection[name] = value;

            if (!exists)
                AfterAdded?.Invoke(GetOwner(), new CollectionAddedEventArgs<T>
                {
                    Name = name,
                    Value = value
                });

            AfterChanged?.Invoke(GetOwner(), new CollectionChangedEventArgs<T>
            {
                Name = name,
                Value = value,
                OldValue = oldValue
            });
        }

        protected void Unset(string name)
        {
            var el = Get(name);

            BeforeRemoved?.Invoke(GetOwner(), new CollectionRemovedEventArgs<T>
            {
                Name = name,
                Value = el
            });

            Collection.Remove(name);

            AfterRemoved?.Invoke(GetOwner(), new CollectionRemovedEventArgs<T>
            {
                Name = name,
                Value = el
            });
        }

        protected bool Exists(string name)
        {
            return Collection.ContainsKey(name);
        }

        protected T Get(string name)
        {
            return Collection[name];
        }

        public int Count()
        {
            return Collection.Count();
        }

        public T GetFirst()
        {
            return Collection.First().Value;
        }

        public T GetLast()
        {
            return Collection.Last().Value;
        }

        protected KeyValuePair<string, T>[] ToArray()
        {
            return Collection.ToArray();
        }

        public Dictionary<string, T> ToDictionary()
        {
            return Collection;
        }
    }

    public class CollectionAddedEventArgs<T> : EventArgs
    {
        public string Name;
        public T Value;
    }

    internal class CollectionRemovedEventArgs<T> : CollectionAddedEventArgs<T>
    {
    }

    public class CollectionChangedEventArgs<T> : CollectionAddedEventArgs<T>
    {
        public T OldValue;
    }
}