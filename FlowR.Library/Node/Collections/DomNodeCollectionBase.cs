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

        /// <summary>
        /// Fire Before add to collection 
        /// </summary>
        public EventHandler BeforeAdded;

        
        /// <summary>
        /// Fire before a change in collection
        /// </summary>
        public EventHandler BeforeChanged;

        /// <summary>
        /// Fire before remove from collection
        /// </summary>
        public EventHandler BeforeRemoved;

        /// <summary>
        /// Fire after add to collection
        /// </summary>
        public EventHandler AfterAdded;
        
        /// <summary>
        /// Fire after a change in collection
        /// </summary>
        public EventHandler AfterChanged;

        /// <summary>
        /// Fire after remove from collection
        /// </summary>
        public EventHandler AfterRemoved;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="owner">The DomNode owner of the collection</param>
        protected DomNodeCollection(DomNode owner)
        {
            SetOwner(owner);
        }

        /// <summary>
        /// Set an item in collection
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
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

        /// <summary>
        /// Remove an item in collection
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        protected void Unset(string name)
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

        /// <summary>
        /// Return if an item is present in collection
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected bool Exists(string name)
        {
            return _collection.ContainsKey(name);
        }

        /// <summary>
        /// Return an item from collection
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected T Get(string name)
        {
            return _collection[name];
        }

        /// <summary>
        /// Return collection length
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _collection.Count();
        }

        /// <summary>
        /// Return first item of collection
        /// </summary>
        /// <returns></returns>
        public T GetFirst()
        {
            return _collection.First().Value;
        }

        /// <summary>
        /// Return last item of collection
        /// </summary>
        /// <returns></returns>
        public T GetLast()
        {
            return _collection.Last().Value;
        }

        /// <summary>
        /// Return Collection
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, T> ToDictionary()
        {
            // @todo return clone to break reference
            
            return _collection;
        }
    }

    /// <summary>
    /// Base EventArgs for event Add
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CollectionAddedEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Event Name
        /// </summary>
        public string Name;
        /// <summary>
        /// Item Add
        /// </summary>
        public T Value;
    }

    /// <summary>
    /// Base EventArgs for event Remove
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class CollectionRemovedEventArgs<T> : CollectionAddedEventArgs<T>
    {
    }

    /// <summary>
    /// Base EventArgs for event changed
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CollectionChangedEventArgs<T> : CollectionAddedEventArgs<T>
    {
        /// <summary>
        /// Item value before change @todo this is probably not correct for object due to referencing
        /// </summary>
        public T OldValue;
    }
}