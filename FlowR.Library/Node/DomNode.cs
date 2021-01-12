using FlowR.Library.Client.Message;
using FlowR.Library.Node.Collections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowR.Library.Node
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNode' visibile pubblicamente
    public abstract class DomNode : DomNodeApplication
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNode' visibile pubblicamente
    {
        private DomNodeCollectionAttribute _attributes;
        private DomNodeCollectionDomNode _children;
        private DomNodeCollectionEvent _events;
        private DomNodeCollectionProperty _properties;

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNode.DomNode()' visibile pubblicamente
        protected DomNode()
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNode.DomNode()' visibile pubblicamente
        {
            SetupAttributes();
            SetupChildren();
            SetupEvents();
            SetupProperties();
        }

        /// <summary>
        /// TagName of the Node : any HTML valid tag name is permitted.
        /// </summary>
        protected abstract string TagName { get; }

        private void SetupProperties()
        {
            _properties = new DomNodeCollectionProperty(this);
            _properties.AfterChanged += (o, args) =>
            {
                var prop = (CollectionChangedEventArgs<string>)args;
                SendMessage(Factory.MessageSetProperty(this, prop.Name, prop.Value));
            };
        }


        private void SetupEvents()
        {
            _events = new DomNodeCollectionEvent(this);
            _events.AfterAdded += (o, args) =>
            {
                SendMessage(Factory.MessageStartListenEvent(this,
                    ((CollectionAddedEventArgs<List<EventHandler>>)args).Name));
            };
            _events.AfterRemoved += (o, args) =>
            {
                SendMessage(Factory.MessageStopListenEvent(this,
                    ((CollectionAddedEventArgs<List<EventHandler>>)args).Name));
            };
        }

        private void SetupChildren()
        {
            _children = new DomNodeCollectionDomNode(this);
            _children.AfterAdded += (o, args) =>
            {
                SendMessage(Factory.MessageCreate(((CollectionAddedEventArgs<DomNode>)args).Value));
            };
            _children.AfterRemoved += (o, args) =>
            {
                SendMessage(Factory.MessageRemove(((CollectionRemovedEventArgs<DomNode>)args).Value));
            };
        }

        private void SetupAttributes()
        {
            _attributes = new DomNodeCollectionAttribute(this);
            _attributes.AfterChanged += (o, args) =>
            {
                var attr = (CollectionChangedEventArgs<string>)args;
                SendMessage(Factory.MessageSetAttribute(this, attr.Name, attr.Value));
            };
            _attributes.AfterRemoved += (o, args) =>
            {
                var attr = (CollectionAddedEventArgs<string>)args;
                SendMessage(Factory.MessageRemoveAttribute(this, attr.Name));
            };
        }

        /// <summary>
        /// Set Node property on client side.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetProperty(string name, string value)
        {
            _properties.SetProperty(name, value);
        }

        /// <summary>
        /// Get Node property from client.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<string> GetProperty(string path)
        {
            var message = Factory.MessageGetProperty(this, path);
            return await GetApplication().SendMessageWaitResponse(message);
        }

        /// <summary>
        /// Get TagName of the Node.
        /// </summary>
        /// <returns></returns>
        public string GetTagName()
        {
            return TagName;
        }


        /// <inheritdoc/>
        public override DomNode SetText(string text)
        {
            base.SetText(text);
            SendMessage(Factory.MessageSetText(this, text));

            return this;
        }

        /// <inheritdoc/>
        public override void SetUuid(string uuid)
        {
            base.SetUuid(uuid);
            if (!HasAttribute("id")) SetAttribute("id", uuid);
        }

        /// <summary>
        /// Start Listen for specified eventName.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="handler"></param>
        public void On(string eventName, EventHandler handler)
        {
            _events.On(eventName, handler);
        }

        /// <summary>
        /// Stop Listen for specified eventName.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="handler"></param>
        public void Off(string eventName, EventHandler handler)
        {
            _events.Off(eventName, handler);
        }

        /// <summary>
        /// Handle incoming Node Event fired from client.
        /// </summary>
        /// <remarks>Never use this. This is called from application on incoming events</remarks>
        /// <param name="eventName"></param>
        /// <param name="eventArgs"></param>
        public void OnClientEventTriggered(string eventName, MessageEventArgs eventArgs)
        {
            // @todo find a way to lower the visibility 
            _events.OnClientEventTriggered(eventName, eventArgs);
        }

        /// <summary>
        /// Send a message to client side
        /// </summary>
        /// <param name="message"></param>
        private void SendMessage(Message message)
        {
            if (IsInitialized() && null != GetApplication()) GetApplication().SendMessage(message);
        }

        /// <summary>
        /// Return count of children node attached.
        /// </summary>
        /// <returns></returns>
        public int GetChildrenCount()
        {
            return _children.Count();
        }

        /// <summary>
        /// Get first child node from attached children.
        /// </summary>
        /// <returns></returns>
        public DomNode GetFirstChild()
        {
            return _children.GetFirst();
        }

        /// <summary>
        /// Get last child node from attached children.
        /// </summary>
        /// <returns></returns>
        public DomNode GetLastChild()
        {
            return _children.GetLast();
        }

        /// <summary>
        /// Attach a node to children.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DomNode Add(DomNode node)
        {
            if (!IsInitialized()) throw new Exception("Cannot add Child, Node must be initialized first");

            return _children.Add(node);
        }

        /// <summary>
        /// Remove children from node children.
        /// </summary>
        /// <param name="node"></param>
        public void Remove(DomNode node)
        {
            _children.Remove(node);
        }

        /// <summary>
        /// Set Attribute of the node.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public DomNode SetAttribute(string name, string value)
        {
            _attributes.SetAttribute(name, value);

            return this;
        }

        /// <summary>
        /// Return if Attribute already exists.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool HasAttribute(string name)
        {
            return _attributes.HasAttribute(name);
        }

        /// <summary>
        /// Remove an Attribute.
        /// </summary>
        /// <param name="name"></param>
        public void RemoveAttribute(string name)
        {
            _attributes.RemoveAttribute(name);
        }

        /// <summary>
        /// Return Attributes as Dictionary.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetAttributeDictionary()
        {
            return _attributes.ToDictionary();
        }

        /// <summary>
        /// Call a method on client side on this node with arguments, don't wait for response.
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="arguments"></param>
        public void CallClientMethod(string methodName, params string[] arguments)
        {
            SendMessage(Factory.MessageGlobalMethodCall(methodName, arguments));
        }

        /// <summary>
        /// Return Response after Call a method on client side on this node with arguments.
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public async Task<string> CallClientMethodWaitResponse(string methodName, params string[] arguments)
        {
            var message = Factory.MessageGlobalMethodCallWaitResponse(methodName, arguments);
            return await GetApplication().SendMessageWaitResponse(message);
        }
    }
}