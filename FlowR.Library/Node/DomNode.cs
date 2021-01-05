using System;
using System.Collections.Generic;
using FlowR.Library.Client.Message;
using Microsoft.AspNetCore.SignalR;

namespace FlowR.Library.Node
{
    public abstract class DomNode : DomNodeInitialize
    {
        protected string TagName = "div";
        
        private readonly DomNodeAttributes _attributes;
        private readonly DomNodeChildren _children;
        public DomNode()
        {
            _attributes = new DomNodeAttributes(this);
            _attributes.AttributeAdded += OnAttributeAdded;
            _attributes.AttributeChanged += OnAttributeChanged;
            _attributes.AttributeRemoved += OnAttributeRemoved;

            _children = new DomNodeChildren(this);
        }

        public string GetTagName()
        {
            return TagName;
        }

        public void SetAttribute(string name, string value)
        {
            _attributes.SetAttribute(name,value);
        }
        
        public void RemoveAttribute(string name)
        {
            _attributes.RemoveAttribute(name);
        }

        public Dictionary<string, string> GetAttributeDictionary()
        {
            return _attributes.ToDictionary();
        }

        private void OnAttributeRemoved(object o, EventArgs e)
        {
            GetApplication().Client.SendAsync(Factory.MessageCreate(this).ToJson());
        }

        private void OnAttributeChanged(object o, EventArgs e)
        {
            
        }

        private void OnAttributeAdded(object o, EventArgs e)
        {
            
        }
        
        public void Add(DomNode node)
        {
            this._children.Add(node);
        }

        public void Remove(DomNode node)
        {
            this._children.Remove(node);
        }
    }
}