using System;
using System.Collections.Generic;

namespace FlowR.Library.Node
{
    public class DomNodeAttributes : DomNodeCollection<DomNodeAttribute>
    {
        public event EventHandler AttributeAdded;
        public event EventHandler AttributeChanged;
        public event EventHandler AttributeRemoved;
        
        public DomNodeAttributes(DomNode owner) : base(owner)
        {
        }

        public DomNodeAttribute AddAttribute(string name)
        {
            var attr = new DomNodeAttribute(this, name, AttributeChanged);

            Set(name, attr);
            AttributeAdded?.Invoke(attr , EventArgs.Empty);

            return attr;
        }

        public void SetAttribute(string name, string value)
        {
            var attr = Exists(name)
                    ? Get(name)
                    : AddAttribute(name)
                ;

            attr.Set(value);
        }

        public bool HasAttribute(string name)
        {
            return Exists(name);
        }

        public void RemoveAttribute(string name)
        {
            var attr = Get(name);
            Unset(name);
            AttributeRemoved?.Invoke(attr , EventArgs.Empty);
        }

        public Dictionary<string, string> ToDictionary()
        {
            var dict = new Dictionary<string, string>();
            foreach (var keyValuePair in ToArray()) dict.Add(keyValuePair.Key, keyValuePair.Value.Get());

            return dict;
        }

        protected virtual void OnAttributeChanged(OnChangeEventArgs e)
        {
            AttributeChanged?.Invoke(this, e);
        }
    }
}