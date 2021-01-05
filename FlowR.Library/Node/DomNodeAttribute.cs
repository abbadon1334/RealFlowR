using System;

namespace FlowR.Library.Node
{
    public class DomNodeAttribute
    {
        private readonly string _name;
        private readonly DomNodeAttributes _collection;
        private string _value = String.Empty;
        private readonly EventHandler _collectionOnChange;

        public DomNodeAttribute(DomNodeAttributes collection, string name, EventHandler onChange)
        {
            _name = name;
            _collection = collection;
            _collectionOnChange += onChange;
        }

        public void Set(string value)
        {
            OnChangeEventArgs args = new OnChangeEventArgs();
            args.Name = this._name;
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

    public class OnCreatedEventArgs : EventArgs
    {
        public string Name;
    }

    public class OnRemoveEventArgs : EventArgs
    {
        public string Name;
    }

    public class OnChangeEventArgs : EventArgs
    {
        public string Name;
        public string Value;
        public string OldValue;
    }
}