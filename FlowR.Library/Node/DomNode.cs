using FlowR.Library.Client.Message;
using FlowR.Library.Node.Collections;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowR.Library.Node
{
    public abstract class DomNode : DomNodeApplication
    {
        private readonly DomNodeCollectionAttribute _attributes;
        private readonly DomNodeCollectionDomNode _children;
        private readonly DomNodeCollectionEvent _events;
        protected abstract string TagName { get; }

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
                SendMessage(Factory.MessageStartListenEvent(this, ((ListenerEventArgs)args).Name));
            _events.StopEventListen += (o, args) =>
                SendMessage(Factory.MessageStartListenEvent(this, ((ListenerEventArgs)args).Name));
        }

        private void OnChildrenRemoved(object sender, EventArgs e)
        {
            SendMessage(Factory.MessageRemove((DomNode)sender));
        }

        private void OnChildrenAdd(object sender, EventArgs e)
        {
            SendMessage(Factory.MessageCreate((DomNode)sender));
        }

        public int GetChildrenCount()
        {
            return _children.Count();
        }

        public DomNode GetFirstChild()
        {
            return _children.GetFirst();
        }

        public DomNode GetLastChild()
        {
            return _children.GetLast();
        }

        public string GetTagName()
        {
            return TagName;
        }

        public override DomNode SetText(string text)
        {
            base.SetText(text);
            SendMessage(Factory.MessageSetText(this, text));

            return this;
        }

        public DomNode SetAttribute(string name, string value)
        {
            _attributes.SetAttribute(name, value);

            return this;
        }

        public bool HasAttribute(string name)
        {
            return _attributes.HasAttribute(name);
        }

        public override void SetUuid(string uuid)
        {
            base.SetUuid(uuid);
            if (!this.HasAttribute("id"))
            {
                this.SetAttribute("id", uuid);
            }
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

        public DomNode Add(DomNode node)
        {
            if (!IsInitialized()) throw new Exception("Cannot add Child, Node must be initialized first");

            return _children.Add(node);
        }

        public void Remove(DomNode node)
        {
            _children.Remove(node);
        }

        // events

        public void On(string eventName, EventHandler handler)
        {
            _events.On(eventName, handler);
        }

        public void Off(string eventName, EventHandler handler)
        {
            _events.Off(eventName, handler);
        }

        public void OnClientEventTriggered(string eventName, MessageEventArgs eventArgs)
        {
            _events.OnClientEventTriggered(eventName, eventArgs);
        }

        protected void SendMessage(Message message)
        {
            if (IsInitialized() && null != GetApplication())
            {
                var args = message.Arguments.Values.ToArray();

                switch (args.Length)
                {
                    case 0:
                        GetApplication().Client.SendAsync(message.Method);
                        return;
                    case 1:
                        GetApplication().Client.SendAsync(message.Method, args[0]);
                        return;
                    case 2:
                        GetApplication().Client.SendAsync(message.Method, args[0], args[1]);
                        return;
                    case 3:
                        GetApplication().Client.SendAsync(message.Method, args[0], args[1], args[2]);
                        return;
                    case 4:
                        GetApplication().Client.SendAsync(message.Method, args[0], args[1], args[2], args[3]);
                        return;
                }

                throw new Exception("Message Arguments Array to long");
            }
        }
    }
}