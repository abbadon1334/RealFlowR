using System;
using FlowR.Library.Node.Collections;

namespace FlowR.Library.Node
{
    public class DomNodeAttribute
    {
        private readonly DomNodeCollectionAttribute _collection;
        private readonly EventHandler _collectionOnChange;
        private readonly string _name;
        private string _value = string.Empty;

        public DomNodeAttribute(DomNodeCollectionAttribute collection, string name, EventHandler onChange)
        {
            _name = name;
            _collection = collection;
            _collectionOnChange += onChange;
        }

        public void Set(string value)
        {
            var args = new ChangeEventArgs();
            args.Name = _name;
            args.OldValue = _value;
            args.Value = value;
            _value = value;
            _collectionOnChange?.Invoke(this, args);
        }

        public string Get()
        {
            return _value;
        }
    }

    public class AddEventArgs : EventArgs
    {
        public string Name;
    }

    public class RemoveEventArgs : EventArgs
    {
        public string Name;
    }

    public class ChangeEventArgs : EventArgs
    {
        public string Name;
        public string OldValue;
        public string Value;
    }
}