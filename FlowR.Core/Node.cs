using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlowR.Core.Message;

namespace FlowR.Core
{
    /// <summary>
    ///     DomNode base class
    /// </summary>
    public abstract class Node
    {

        private NodeCollectionAttribute _attributes;

        private NodeCollectionNode _children;

        private NodeCollectionEvent _events;

        private NodeCollectionProperty _properties;

        private string _uuid = string.Empty;

        /// <summary>
        ///     Constructor
        /// </summary>
        protected Node()
        {
            SetupAttributes();
            SetupChildren();
            SetupEvents();
            SetupProperties();
        }
        /// <summary>
        ///     TagName of the Node : any HTML valid tag name is permitted.
        /// </summary>
        public abstract string TagName { get; }

        /// <summary>
        ///     The Client Application.
        /// </summary>
        public Application Application { get; set; }

        /// <summary>
        ///     DomNode parent
        /// </summary>
        public Node Owner { get; set; }

        /// <summary>
        ///     Unique identifier of the Node
        /// </summary>
        /// <exception cref="Exception"></exception>
        public string Uuid
        {
            get
            {
                if (_uuid == string.Empty) Uuid = Guid.NewGuid().ToString();
                return _uuid;
            }
            set
            {
                if (_uuid != string.Empty) throw new Exception($"Element Uuid is not empty (actual : '{_uuid}'))");

                _uuid = value;
                if (!HasAttribute("id")) _SetAttribute("id", value);
            }
        }

        #region Setup

        private void SetupProperties()
        {
            _properties = new NodeCollectionProperty(this);
            _properties.AfterChanged += (o, args) =>
            {
                var prop = (CollectionChangedEventArgs<string>)args;
                SendMessage(Factory.MessageSetProperty(this, prop.Name, prop.Value));
            };
        }

        private void SetupEvents()
        {
            _events = new NodeCollectionEvent(this);
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
            _children = new NodeCollectionNode(this);
            _children.AfterAdded += (o, args) =>
            {
                SendMessage(Factory.MessageCreate(((CollectionAddedEventArgs<Node>)args).Value));
            };
            _children.AfterRemoved += (o, args) =>
            {
                SendMessage(Factory.MessageRemove(((CollectionRemovedEventArgs<Node>)args).Value));
            };
        }

        private void SetupAttributes()
        {
            _attributes = new NodeCollectionAttribute(this);
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

        #endregion

        #region Property

        /// <summary>
        ///     Set Node property on client side.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        protected void _SetProperty(string name, string value)
        {
            _properties.SetProperty(name, value);
        }

        /// <summary>
        ///     Get Node property from client.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<string> GetProperty(string path)
        {
            var message = Factory.MessageGetProperty(this, path);
            return await Application.Communication.SendMessageWaitResponse(message);
        }

        #endregion

        #region Event Listen

        /// <summary>
        ///     Start Listen for specified eventName.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="handler"></param>
        protected void _On(string eventName, EventHandler handler)
        {
            _events.On(eventName, handler);
        }

        /// <summary>
        ///     Stop Listen for specified eventName.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="handler"></param>
        protected void _Off(string eventName, EventHandler handler)
        {
            _events.Off(eventName, handler);
        }

        /// <summary>
        ///     Handle incoming Node Event fired from client.
        /// </summary>
        /// <remarks>Never use this. This is called from application on incoming events</remarks>
        /// <param name="eventName"></param>
        /// <param name="eventArgs"></param>
        public void OnClientEventTriggered(string eventName, MessageEventArgs eventArgs)
        {
            // @todo find a way to lower the visibility 
            _events.OnClientEventTriggered(eventName, eventArgs);
        }

        #endregion

        #region Message

        /// <summary>
        ///     Send a message to client side
        /// </summary>
        /// <param name="message"></param>
        private void SendMessage(IMessage message)
        {
            if (!IsInitialized()) return;

            Application?.Communication.SendMessage(message);
        }

        /// <summary>
        ///     Add a method to the node, don't wait for response.
        ///     Later can be called via CallClientMethod and CallClientMethodWaitResponse
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="jsStatement"></param>
        public void AddClientJavascriptMethod(string methodName, string jsStatement)
        {
            SendMessage(Factory.MessageAddMethod(this, methodName, jsStatement));
        }

        /// <summary>
        ///     Call a method on client side on this node with arguments, don't wait for response.
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="arguments"></param>
        public void CallClientMethod(string methodName, params string[] arguments)
        {
            SendMessage(Factory.MessageGlobalMethodCall(methodName, arguments));
        }

        /// <summary>
        ///     Return Response after call a method on client side on this node with arguments.
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public async Task<string> CallClientMethodWaitResponse(string methodName, params string[] arguments)
        {
            var message = Factory.MessageGlobalMethodCallWaitResponse(methodName, arguments);
            return await Application.Communication.SendMessageWaitResponse(message);
        }

        #endregion

        #region Children

        /// <summary>
        ///     Return count of children node attached.
        /// </summary>
        /// <returns></returns>
        public int GetChildrenCount()
        {
            return _children.Count();
        }

        /// <summary>
        ///     Get first child node from attached children.
        /// </summary>
        /// <returns></returns>
        public Node GetFirstChild()
        {
            return _children.GetFirst();
        }

        /// <summary>
        ///     Get last child node from attached children.
        /// </summary>
        /// <returns></returns>
        public Node GetLastChild()
        {
            return _children.GetLast();
        }

        /// <summary>
        ///     Attach a node to children.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected Node Add(Node node)
        {
            if (!IsInitialized()) throw new Exception("Cannot add Child, Node must be initialized first");

            return _children.Add(node);
        }

        /// <summary>
        ///     Remove children from node children.
        /// </summary>
        /// <param name="node"></param>
        public void Remove(Node node)
        {
            _children.Remove(node);
        }

        /// <summary>
        ///     Attach a node to children.
        /// </summary>
        /// <returns></returns>
        public TNode Add<TNode>(params KeyValuePair<string, string>[] attributes)
            where TNode : ComponentElement<TNode>
            , new()
        {
            var cmp = new TNode();
            cmp.SetAttributes(attributes);
            Add(cmp);

            return cmp;
        }

        /// <summary>
        ///     Attach a node to children.
        /// </summary>
        /// <returns></returns>
        public TNode Add<TNode>(string name, params KeyValuePair<string, string>[] attributes)
            where TNode : ComponentControl<TNode>, IComponentControl
            , new()
        {
            var cmp = new TNode();
            cmp.SetControlName(name);
            cmp.SetAttributes(attributes);

            Add(cmp);

            return cmp;
        }

        #endregion

        #region Attributes

        /// <summary>
        ///     Set Attribute of the node.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected Node _SetAttribute(string name, string value)
        {
            _attributes.SetAttribute(name, value);

            return this;
        }

        /// <summary>
        ///     Return if Attribute already exists.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool HasAttribute(string name)
        {
            return _attributes.HasAttribute(name);
        }

        /// <summary>
        ///     Remove an Attribute.
        /// </summary>
        /// <param name="name"></param>
        protected void _RemoveAttribute(string name)
        {
            _attributes.RemoveAttribute(name);
        }

        /// <summary>
        ///     Return Attributes as Dictionary.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetAttributeDictionary()
        {
            return _attributes.ToDictionary();
        }

        #endregion

        #region initialization

        private bool _initialized;

        /// <summary>
        ///     Starting point of every component.
        ///     Will be called after attach to Parent.
        ///     This is the method you are looking for if you want to make a component
        /// </summary>
        /// <exception cref="Exception">Cannot be called multiple times</exception>
        public virtual void Init()
        {
            if (IsInitialized()) throw new Exception("Already initialized");

            _initialized = true;
        }

        /// <summary>
        ///     Return if the DomNode is initialized.
        /// </summary>
        /// <returns></returns>
        protected bool IsInitialized()
        {
            return _initialized;
        }

        #endregion

        #region Text

        private string _text = string.Empty;
        /// <summary>
        ///     Content Text of the element
        /// </summary>
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                SendMessage(Factory.MessageSetText(this, _text));
            }
        }

        /// <summary>
        ///     Fluent Set Text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected Node _SetText(string text)
        {
            Text = text;

            return this;
        }

        #endregion

        #region Value

        private string _value = string.Empty;
        /// <summary>
        ///     Value
        /// </summary>
        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                _SetProperty("value", value);
            }
        }

        #endregion

    }
}