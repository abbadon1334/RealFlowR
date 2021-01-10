using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlowR.Library.Client.Message;
using FlowR.Library.Node.Collections;

namespace FlowR.Library.Node
{
    public abstract class DomNode : DomNodeApplication
    {
        private DomNodeCollectionAttribute _attributes;
        private DomNodeCollectionDomNode _children;
        private DomNodeCollectionEvent _events;
        private DomNodeCollectionProperty _properties;

        protected DomNode()
        {
            SetupAttributes();
            SetupChildren();
            SetupEvents();
            SetupProperties();
        }

        protected abstract string TagName { get; }

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
            _properties.SetProperty(name, value);
        }

        public async Task<string> GetProperty(string path)
        {
            var message = Factory.MessageGetProperty(this, path);
            return await GetApplication().SendMessageWaitResponse(message);
        }

        private void SetupEvents()
        {
            _events = new DomNodeCollectionEvent(this);
            _events.AfterAdded += (o, args) =>
            {
                SendMessage(Factory.MessageStartListenEvent(this,
                    ((CollectionAddedEventArgs<List<EventHandler>>) args).Name));
            };
            _events.AfterRemoved += (o, args) =>
            {
                SendMessage(Factory.MessageStopListenEvent(this,
                    ((CollectionAddedEventArgs<List<EventHandler>>) args).Name));
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
            if (!HasAttribute("id")) SetAttribute("id", uuid);
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
            if (IsInitialized() && null != GetApplication()) GetApplication().SendMessage(message);
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