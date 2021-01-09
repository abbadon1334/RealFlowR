using FlowR.Library.Client.Message;
using FlowR.Library.Node.Collections;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FlowR.Library.Node
{
    public abstract class DomNode : DomNodeApplication
    {
        private DomNodeCollectionAttribute _attributes;
        private DomNodeCollectionDomNode _children;
        private DomNodeCollectionEvent _events;
        private DomNodeCollectionProperty _properties;

        public DomNode()
        {
            SetupAttributes();
            SetupChildren();
            SetupEvents();
            SetupProperties();
        }

        private void SetupProperties()
        {
            _properties = new DomNodeCollectionProperty(this);
            _properties.AfterChanged += (o, args) =>
            {
                var prop = (CollectionChangedEventArgs<string>) args;
                SendMessage(Factory.MessageSetProperty(this, prop.Name, prop.Value));
            };
        }

        public void SetProperty(string name, string value)
        {
            this._properties.SetProperty(name, value);
        }

        public async Task GetProperty(string name)
        {
            Message msg = Factory.MessageGetProperty(this, name);
            return await GetApplication().Client.SendAsync(Factory.MessageGetProperty(this, name));
        }

        protected abstract string TagName { get; }

        private void SetupEvents()
        {
            _events = new DomNodeCollectionEvent(this);
            _events.AfterAdded += (o, args) =>
            {
                SendMessage(Factory.MessageStartListenEvent(this, ((CollectionAddedEventArgs<List<EventHandler>>) args).Name));
            };
            _events.AfterRemoved += (o, args) =>
            {
                SendMessage(Factory.MessageStopListenEvent(this, ((CollectionAddedEventArgs<List<EventHandler>>) args).Name));
            };
        }

        private void SetupChildren()
        {
            _children = new DomNodeCollectionDomNode(this);
            _children.AfterAdded += (o, args) =>
            {
                SendMessage(Factory.MessageCreate(((CollectionAddedEventArgs<DomNode>) args).Value));
            };
            _children.AfterRemoved += (o, args) =>
            {
                SendMessage(Factory.MessageRemove(((CollectionRemovedEventArgs<DomNode>) args).Value));
            };
        }
        
        private void SetupAttributes()
        {
            _attributes = new DomNodeCollectionAttribute(this);
            _attributes.AfterChanged += (o, args) =>
            {
                var attr = (CollectionChangedEventArgs<string>) args;
                SendMessage(Factory.MessageSetAttribute(this, attr.Name, attr.Value));
            };
            _attributes.AfterRemoved += (o, args) =>
            {
                var attr = (CollectionAddedEventArgs<string>) args;
                SendMessage(Factory.MessageRemoveAttribute(this, attr.Name));
            };
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

        public override void SetUuid(string uuid)
        {
            base.SetUuid(uuid);
            if (!this.HasAttribute("id"))
            {
                this.SetAttribute("id", uuid);
            }
        }

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
                    case 5:
                        GetApplication().Client.SendAsync(message.Method, args[0], args[1], args[2], args[3], args[4]);
                        return;
                    case 6:
                        GetApplication().Client.SendAsync(message.Method, args[0], args[1], args[2], args[3], args[4], args[5]);
                        return;
                }

                throw new Exception("Message Arguments Array to long");
            }
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

        public DomNode Add(DomNode node)
        {
            if (!IsInitialized()) throw new Exception("Cannot add Child, Node must be initialized first");

            return _children.Add(node);
        }

        public void Remove(DomNode node)
        {
            _children.Remove(node);
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

        public void RemoveAttribute(string name)
        {
            _attributes.RemoveAttribute(name);
        }

        public Dictionary<string, string> GetAttributeDictionary()
        {
            return _attributes.ToDictionary();
        }
    }
}