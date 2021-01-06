using System;
using System.Collections.Generic;
using FlowR.Library.Client.Message;
using FlowR.Library.Node.Collections;
using Microsoft.AspNetCore.SignalR;

namespace FlowR.Library.Node
{
    public abstract class DomNode : DomNodeApplication
    {
        private readonly DomNodeCollectionAttribute _attributes;
        private readonly DomNodeCollectionDomNode _children;
        private readonly DomNodeCollectionEvent _events;
        protected string TagName = "div";

        public DomNode()
        {
            _attributes = new DomNodeCollectionAttribute(this);
            _attributes.AttributeAdded += (o, args) => OnAttributeAdded(o as Attribute, args as AddEventArgs);
            _attributes.AttributeChanged += (o, args) => OnAttributeChanged(o as Attribute, args as ChangeEventArgs);
            _attributes.AttributeRemoved += (o, args) => OnAttributeRemoved(o as Attribute, args as RemoveEventArgs);

            _children = new DomNodeCollectionDomNode(this);
            _children.ChildAdded += OnChildrenAdd;
            _children.ChildRemoved += OnChildrenRemoved;

            _events = new DomNodeCollectionEvent(this);
            _events.StartEventListen += (o, args) =>
                SendMessage(Factory.MessageAddListener(this, ((ListenerEventArgs) args).Name));
            _events.StopEventListen += (o, args) =>
                SendMessage(Factory.MessageAddListener(this, ((ListenerEventArgs) args).Name));
        }

        private void OnChildrenRemoved(object sender, EventArgs e)
        {
            SendMessage(Factory.MessageCreate(this));
        }

        private void OnChildrenAdd(object sender, EventArgs e)
        {
            SendMessage(Factory.MessageRemove(this));
        }

        public string GetTagName()
        {
            return TagName;
        }

        public void SetAttribute(string name, string value)
        {
            _attributes.SetAttribute(name, value);
        }

        public void RemoveAttribute(string name)
        {
            _attributes.RemoveAttribute(name);
        }

        public Dictionary<string, string> GetAttributeDictionary()
        {
            return _attributes.ToDictionary();
        }

        private void OnAttributeRemoved(Attribute o, RemoveEventArgs e)
        {
            SendMessage(Factory.MessageRemoveAttribute(this, e.Name));
        }

        private void OnAttributeChanged(Attribute o, ChangeEventArgs e)
        {
            SendMessage(Factory.MessageSetAttribute(this, e.Name, e.Value));
        }

        private void OnAttributeAdded(Attribute o, AddEventArgs e)
        {
            SendMessage(Factory.MessageSetAttribute(this, e.Name, string.Empty));
        }

        public void Add(DomNode node)
        {
            if (!IsInitialized()) throw new Exception("Cannot add Child, Node must be initialized first");

            _children.Add(node);
        }

        public void Remove(DomNode node)
        {
            _children.Remove(node);
        }

        // events

        public void On(string eventName, DomNodeEvent handler)
        {
            _events.On(eventName, handler);
        }

        public void Off(string eventName, DomNodeEvent handler)
        {
            _events.Off(eventName, handler);
        }

        public void OnClientEventTriggered(string eventName, MessageEventArgs eventArgs)
        {
            _events.OnClientEventTriggered(eventName, eventArgs);
        }

        protected void SendMessage(Message message)
        {
            if (IsInitialized()) GetApplication().Client.SendAsync(message.ToJson());
        }
    }
}