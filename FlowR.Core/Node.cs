using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using FlowR.Core.Message;
using Microsoft.Extensions.Logging;

namespace FlowR.Core
{
    /// <summary>
    ///     INode implementation class
    /// </summary>
    public abstract class Node : INode
    {
        private readonly ObservableDictionary<string, string> _attributes = new();

        private readonly ObservableDictionary<string, INode> _children = new();

        private readonly ObservableDictionary<string, List<EventHandler>> _events = new();

        private readonly ObservableDictionary<string, string> _properties = new();

        private Application _application;

        private bool _initialized;

        private INode _owner;

        private string _text = "";

        private string _uuid;

        /// <summary>
        ///     Constructor
        /// </summary>
        public Node()
        {
            SetupCollections();
            SetAttribute(DefaultAttributes);
        }

        /// <summary>
        ///     Setup default Component attributes
        /// </summary>
        protected virtual Dictionary<string, string> DefaultAttributes { get; set; } = new();

        /// <summary>
        ///     Stored HTML Tag name.
        /// </summary>
        protected virtual string TagName => "div";

        /// <inheritdoc />
        public string GetTagName()
        {
            return TagName;
        }

        /// <inheritdoc />
        public INode GetOwner()
        {
            return _owner;
        }

        /// <inheritdoc />
        public void SetOwner(INode owner)
        {
            _owner = owner;
        }
        /// <inheritdoc />
        public string GetUuid()
        {
            if (string.IsNullOrEmpty(_uuid)) SetUuid(Guid.NewGuid().ToString());
            return _uuid;
        }

        /// <inheritdoc />
        public ObservableDictionary<string, string> GetAttributes()
        {
            return _attributes;
        }

        /// <inheritdoc />
        public ObservableDictionary<string, string> GetProperties()
        {
            return _properties;
        }

        /// <inheritdoc />
        public ObservableDictionary<string, List<EventHandler>> GetEventHandlers()
        {
            return _events;
        }

        /// <inheritdoc />
        public Application GetApplication()
        {
            return _application;
        }

        /// <inheritdoc />
        public ApplicationCommunication GetCommunication()
        {
            return _application.Communication;
        }

        /// <inheritdoc />
        public ObservableDictionary<string, INode> GetChildren()
        {
            return _children;
        }

        /// <inheritdoc />
        public virtual string GetText()
        {
            return _text;
        }

        /// <inheritdoc />
        public virtual INode SetText(string text)
        {
            _text = text;

            MessageElement.Factory.MessageSetText(
                this,
                text
            ).SendMessageAsync(GetCommunication());

            return this;
        }

        /// <inheritdoc />
        public virtual void Init()
        {
            ValidateNode();

            _application ??= GetOwner().GetApplication();
            _initialized = true;
        }

        /// <inheritdoc />
        public virtual INode SetAttribute(string name, string value)
        {
            value = (value ?? "").Trim();

            switch (name)
            {
                case "class":
                    value = string.Join(" ", GetCssClassesFromStringAsList(value).Distinct()).Trim();
                    break;
            }

            GetAttributes()[name] = value;

            return this;
        }

        /// <inheritdoc />
        public string GetAttribute(string name)
        {
            GetAttributes().TryGetValue(name, out var value);

            return value;
        }

        /// <inheritdoc />
        public virtual INode RemoveAttribute(string name)
        {
            GetAttributes().Remove(name);

            return this;
        }

        /// <summary>
        ///     Short hand to set multiple attributes
        /// </summary>
        /// <param name="attributes"></param>
        public virtual INode SetAttribute(Dictionary<string, string> attributes = null)
        {
            attributes ??= new Dictionary<string, string>();

            foreach (var (key, value) in attributes) SetAttribute(key, value);

            return this;
        }

        /// <inheritdoc />
        public bool HasAttribute(string name)
        {
            return GetAttributes().ContainsKey(name);
        }

        /// <inheritdoc />
        public virtual INode SetProperty(string name, string value)
        {
            GetProperties().TryAdd(name, value);

            return this;
        }

        /// <inheritdoc />
        public string GetProperty(string path)
        {
            GetProperties().TryGetValue(path, out var result);

            return result;
        }

        /// <inheritdoc />
        public async Task<string> GetPropertyAsync(string path)
        {
            var result = await MessageElementWithResponse.Factory
                .MessageGetProperty(this, path)
                .SendMessageAsync(GetCommunication());

            GetProperties().TryAdd(path, result);

            return result;
        }

        /// <inheritdoc />
        public TNodeComponent Add<TNodeComponent>(Dictionary<string, string> attributes = null) where TNodeComponent : INodeComponent, new()
        {
            TNodeComponent el = new();

            Add(el, attributes);

            el.Init();

            return el;
        }

        /// <inheritdoc />
        public TNodeControl Add<TNodeControl>(string controlName, Dictionary<string, string> attributes = null) where TNodeControl : INodeControl, new()
        {
            TNodeControl el = new();

            el.SetControlName(controlName);

            Add(el, attributes);

            el.Init();

            return el;
        }

        /// <inheritdoc />
        public void Remove(INode child)
        {
            GetChildren().Remove(child.GetUuid());
        }

        /// <inheritdoc />
        public virtual INode On(string eventName, EventHandler handler)
        {
            GetEventHandlers().TryGetValue(eventName, out var handlers);

            if (handlers == null)
            {
                handlers = new List<EventHandler>();
                GetEventHandlers().Add(eventName, handlers);
            }


            handlers.Add(handler);

            GetEventHandlers()[eventName] = handlers;

            return this;
        }

        /// <inheritdoc />
        public virtual INode Off(string eventName, EventHandler handler)
        {
            GetEventHandlers().TryGetValue(eventName, out var handlers);

            if (handlers != null)
            {
                handlers.Remove(handler);

                if (handlers.Count == 0) Off(eventName);
            }

            return this;
        }

        /// <inheritdoc />
        public virtual INode Off(string eventName)
        {
            GetEventHandlers().Remove(eventName);

            return this;
        }

        /// <inheritdoc />
        public void OnClientEventTriggered(string eventName, EventArgs eventArgs)
        {
            GetEventHandlers().TryGetValue(eventName, out var handlers);

            handlers?.ForEach(del => del.Invoke(this, eventArgs));
        }

        /// <inheritdoc />
        public virtual INode AddJavascriptMethod(string methodName, string jsStatement)
        {
            MessageElement.Factory.MessageAddMethod(
                this,
                methodName,
                jsStatement
            ).SendMessageAsync(GetCommunication());

            return this;
        }

        /// <inheritdoc />
        public virtual INode CallClientMethod(string methodName, params string[] arguments)
        {
            MessageElement.Factory.MessageCallMethod(
                this,
                methodName,
                arguments
            ).SendMessageAsync(GetCommunication());

            return this;
        }

        /// <inheritdoc />
        public async Task<string> CallClientMethodAsync(string methodName, params string[] arguments)
        {
            return await MessageElementWithResponse.Factory
                .MessageMethodCallWaitResponse(
                    this,
                    methodName,
                    arguments
                ).SendMessageAsync(GetCommunication());
        }

        /// <inheritdoc />
        public T GetFirstOwnerOfType<T>() where T : INode
        {
            var owner = GetOwner();

            while (true)
            {
                if (owner == null || owner.GetType() == typeof(NodeComponentRoot)) return default;

                if (owner.GetType() == typeof(T)) break;

                owner = owner.GetOwner();
            }

            return (T)owner;
        }

        /// <inheritdoc />
        public List<T> GetChildrenOfType<T>() where T : INode
        {
            List<T> children = new();
            foreach (var (key, value) in GetChildren()) children.Add((T)value);

            return children;
        }

        /// <inheritdoc />
        public virtual INode AddCssClass(string className)
        {
            var css = GetCssClassesFromStringAsList(GetAttribute("class") ?? "");
            var cssAdd = GetCssClassesFromStringAsList(className.Trim());
            foreach (var c in cssAdd) css.Add(c.Trim());
            SetAttribute("class", string.Join(" ", css).Trim());

            return this;
        }

        /// <inheritdoc />
        public virtual INode RemoveCssClass(string className)
        {
            var css = GetCssClassesFromStringAsList(GetAttribute("class") ?? "");
            var cssRemove = GetCssClassesFromStringAsList(className.Trim());

            foreach (var cr in cssRemove) css.Remove(cr.Trim());

            SetAttribute("class", string.Join(" ", css).Trim());

            return this;
        }

        /// <summary>
        ///     Set Uuid, under the hood will call SetAttribute(id, Uuid) 
        /// </summary>
        /// <param name="uuid"></param>
        /// <exception></exception>
        protected void SetUuid(string uuid)
        {
            if (!string.IsNullOrEmpty(_uuid)) throw new Exception($"Element Uuid is not empty (actual : '{_uuid}'))");

            _uuid = uuid;

            SetAttribute("id", uuid);
        }

        /// <summary>
        /// [internal use] Set Application from owner on init. 
        /// </summary>
        /// <param name="app"></param>
        /// <exception></exception>
        protected void SetApplication(Application app)
        {
            if (_application != null) throw new Exception("Application already set");

            _application = app;
        }

        private void SetupCollections()
        {
            GetAttributes().CollectionChanged += (sender, args) =>
            {
                if (!IsInitialized()) return;

                switch (args.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                    case NotifyCollectionChangedAction.Replace:
                        foreach (KeyValuePair<string, string> kvp in args.NewItems)
                            MessageElement.Factory.MessageSetAttribute(
                                this,
                                kvp.Key,
                                kvp.Value
                            ).SendMessageAsync(GetCommunication());
                        break;

                    case NotifyCollectionChangedAction.Remove:
                        foreach (KeyValuePair<string, string> kvp in args.OldItems)
                            MessageElement.Factory.MessageRemoveAttribute(
                                this,
                                kvp.Key
                            ).SendMessageAsync(GetCommunication());
                        break;
                }
            };

            GetChildren().CollectionChanged += (sender, args) =>
            {
                if (!IsInitialized()) return;

                switch (args.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (KeyValuePair<string, INode> kvp in args.NewItems)
                        {
                            GetApplication().RegisterComponent(kvp.Value);
                            MessageElement.Factory.MessageCreate(
                                kvp.Value
                            ).SendMessageAsync(GetCommunication());
                        }
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        foreach (KeyValuePair<string, INode> kvp in args.OldItems)
                        {
                            GetApplication().UnregisterComponent(kvp.Value);
                            MessageElement.Factory.MessageRemove(
                                kvp.Value
                            ).SendMessageAsync(GetCommunication());
                        }
                        break;
                }
            };

            GetProperties().CollectionChanged += (sender, args) =>
            {
                if (!IsInitialized()) return;

                switch (args.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                    case NotifyCollectionChangedAction.Replace:
                        foreach (KeyValuePair<string, string> kvp in args.NewItems)
                            MessageElement.Factory.MessageSetProperty(
                                this,
                                kvp.Key,
                                kvp.Value
                            ).SendMessageAsync(GetCommunication());
                        break;
                }
            };

            GetEventHandlers().CollectionChanged += (sender, args) =>
            {
                if (!IsInitialized()) return;

                switch (args.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (KeyValuePair<string, List<EventHandler>> kvp in args.NewItems)
                            MessageElement.Factory.MessageStartListenEvent(
                                this,
                                kvp.Key
                            ).SendMessageAsync(GetCommunication());
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        foreach (KeyValuePair<string, List<EventHandler>> kvp in args.OldItems)
                            MessageElement.Factory.MessageStopListenEvent(
                                this,
                                kvp.Key
                            ).SendMessageAsync(GetCommunication());
                        break;
                }
            };
        }

        /// <summary>
        ///     Return if the INode is initialized.
        /// </summary>
        /// <returns></returns>
        private bool IsInitialized()
        {
            return _initialized;
        }


        /// <summary>
        ///     Validate Node before call init
        /// </summary>
        /// <exception></exception>
        protected virtual void ValidateNode()
        {
            if (IsInitialized()) throw new Exception("Cannot initialized twice");

            if (GetOwner() == null) throw new Exception("Missing Owner");

            if (GetOwner().GetApplication() == null) throw new Exception("Missing Application");
        }

        /// <summary>
        ///     Get Application logger
        /// </summary>
        /// <returns></returns>
        public ILogger<Application> GetLogger()
        {
            return GetApplication().GetLogger();
        }

        private void Add(INode node, Dictionary<string, string> attributes = null)
        {
            if (!IsInitialized()) throw new Exception("Node must be a Owner, you need to add it to the tree");

            node.SetOwner(this);
            node.SetAttribute(attributes);

            GetChildren().Add(node.GetUuid(), node);
        }

        private static List<string> GetCssClassesFromStringAsList(string css = "")
        {
            return css.Split(" ").Distinct().ToList();
        }
    }
}