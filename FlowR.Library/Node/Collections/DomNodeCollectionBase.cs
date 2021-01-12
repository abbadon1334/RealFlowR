using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowR.Library.Node.Collections
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>' visibile pubblicamente
    public abstract class DomNodeCollection<T> : DomNodeOwner
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>' visibile pubblicamente
    {
        private readonly Dictionary<string, T> _collection = new();

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.AfterAdded' visibile pubblicamente
        public EventHandler AfterAdded;
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.AfterAdded' visibile pubblicamente
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.AfterChanged' visibile pubblicamente
        public EventHandler AfterChanged;
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.AfterChanged' visibile pubblicamente
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.AfterRemoved' visibile pubblicamente
        public EventHandler AfterRemoved;
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.AfterRemoved' visibile pubblicamente

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.BeforeAdded' visibile pubblicamente
        public EventHandler BeforeAdded;
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.BeforeAdded' visibile pubblicamente
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.BeforeChanged' visibile pubblicamente
        public EventHandler BeforeChanged;
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.BeforeChanged' visibile pubblicamente
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.BeforeRemoved' visibile pubblicamente
        public EventHandler BeforeRemoved;
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.BeforeRemoved' visibile pubblicamente

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.DomNodeCollection(DomNode)' visibile pubblicamente
        protected DomNodeCollection(DomNode owner)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.DomNodeCollection(DomNode)' visibile pubblicamente
        {
            SetOwner(owner);
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.Set(string, T)' visibile pubblicamente
        protected void Set(string name, T value)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.Set(string, T)' visibile pubblicamente
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

            _collection[name] = value;

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

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.Unset(string)' visibile pubblicamente
        protected void Unset(string name)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.Unset(string)' visibile pubblicamente
        {
            var el = Get(name);

            BeforeRemoved?.Invoke(GetOwner(), new CollectionRemovedEventArgs<T>
            {
                Name = name,
                Value = el
            });

            _collection.Remove(name);

            AfterRemoved?.Invoke(GetOwner(), new CollectionRemovedEventArgs<T>
            {
                Name = name,
                Value = el
            });
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.Exists(string)' visibile pubblicamente
        protected bool Exists(string name)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.Exists(string)' visibile pubblicamente
        {
            return _collection.ContainsKey(name);
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.Get(string)' visibile pubblicamente
        protected T Get(string name)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.Get(string)' visibile pubblicamente
        {
            return _collection[name];
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.Count()' visibile pubblicamente
        public int Count()
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.Count()' visibile pubblicamente
        {
            return _collection.Count();
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.GetFirst()' visibile pubblicamente
        public T GetFirst()
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.GetFirst()' visibile pubblicamente
        {
            return _collection.First().Value;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.GetLast()' visibile pubblicamente
        public T GetLast()
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.GetLast()' visibile pubblicamente
        {
            return _collection.Last().Value;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.ToDictionary()' visibile pubblicamente
        public Dictionary<string, T> ToDictionary()
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollection<T>.ToDictionary()' visibile pubblicamente
        {
            return _collection;
        }
    }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'CollectionAddedEventArgs<T>' visibile pubblicamente
    public class CollectionAddedEventArgs<T> : EventArgs
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'CollectionAddedEventArgs<T>' visibile pubblicamente
    {
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'CollectionAddedEventArgs<T>.Name' visibile pubblicamente
        public string Name;
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'CollectionAddedEventArgs<T>.Name' visibile pubblicamente
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'CollectionAddedEventArgs<T>.Value' visibile pubblicamente
        public T Value;
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'CollectionAddedEventArgs<T>.Value' visibile pubblicamente
    }

    internal class CollectionRemovedEventArgs<T> : CollectionAddedEventArgs<T>
    {
    }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'CollectionChangedEventArgs<T>' visibile pubblicamente
    public class CollectionChangedEventArgs<T> : CollectionAddedEventArgs<T>
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'CollectionChangedEventArgs<T>' visibile pubblicamente
    {
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'CollectionChangedEventArgs<T>.OldValue' visibile pubblicamente
        public T OldValue;
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'CollectionChangedEventArgs<T>.OldValue' visibile pubblicamente
    }
}