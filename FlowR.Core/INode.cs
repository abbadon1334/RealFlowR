using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowR.Core
{
    /// <summary>
    ///     The Node
    /// </summary>
    public interface INode
    {
        /// <summary>
        ///     Get HTML Tag name.
        /// </summary>
        /// <returns></returns>
        public string GetTagName();

        /// <summary>
        ///     Get INode Owner, the parent INode.
        /// </summary>
        /// <returns></returns>
        public INode GetOwner();

        /// <summary>
        ///     Set Inode Owner, the parent INode.
        /// </summary>
        /// <param name="owner"></param>
        public void SetOwner(INode owner);

        /// <summary>
        ///     Get the linked Application Client.
        /// </summary>
        /// <returns></returns>
        public Application GetApplication();

        /// <summary>
        ///     Get Uuid. if not defined will be generated on first request.
        /// </summary>
        /// <returns></returns>
        public string GetUuid();

        /// <summary>
        ///     Get the Dictionary attributes of the Inode
        /// </summary>
        /// <returns></returns>
        public ObservableDictionary<string, string> GetAttributes();

        /// <summary>
        ///     Get the Dictionary properties of the Inode
        /// </summary>
        /// <returns></returns>
        public ObservableDictionary<string, string> GetProperties();

        /// <summary>
        ///     Get the Dictionary properties of the Inode
        /// </summary>
        /// <returns></returns>
        public ObservableDictionary<string, List<EventHandler>> GetEventHandlers();

        /// <summary>
        ///     Get the ApplicationCommunication of the Inode
        /// </summary>
        /// <returns></returns>
        public ApplicationCommunication GetCommunication();

        /// <summary><![CDATA[
        ///     Get Children Inodes
        /// ]]></summary>
        /// <returns></returns>
        public ObservableDictionary<string, INode> GetChildren();

        /// <summary>
        ///     Get Node Text.
        /// </summary>
        /// <returns></returns>
        public string GetText();

        /// <summary>
        ///     Set Node Text.
        /// </summary>
        /// <param name="text"></param>
        public void SetText(string text);

        /// <summary>
        ///     Starting point of every component.
        ///     Will be called after attach to Owner.
        ///     This is the method you are looking for if you want to make a new component
        /// </summary>
        /// <exception>Cannot be called multiple times</exception>
        public void Init();

        /// <summary>
        ///     Set Attribute of INode
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetAttribute(string name, string value);

        /// <summary>
        ///     Set multiple attributes.
        /// </summary>
        /// <param name="attributes"></param>
        public void SetAttribute(Dictionary<string, string> attributes = null);

        /// <summary>
        ///     Get Attribute of Inode by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetAttribute(string name);

        /// <summary>
        ///     Remove Attribute of Inode by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public void RemoveAttribute(string name);

        /// <summary>
        ///     Return if Has Attribute with name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool HasAttribute(string name);

        /// <summary>
        ///     Set Node property on client side.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetProperty(string name, string value);

        /// <summary>
        ///     Get Node property from memory.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetProperty(string path);

        /// <summary>
        ///     Async request INode property from client.
        ///     Wait for response, update in memory and return result.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Task<string> GetPropertyAsync(string path);

        /// <summary>
        ///     Fluid Add Element
        /// </summary>
        /// <param name="attributes"></param>
        /// <typeparam name="TNodeComponent"></typeparam>
        /// <returns></returns>
        public TNodeComponent Add<TNodeComponent>(Dictionary<string, string> attributes = null) where TNodeComponent : INodeComponent, new();

        /// <summary>
        ///     Fluid Add Element
        /// </summary>
        /// <param name="controlName"></param>
        /// <param name="attributes"></param>
        /// <typeparam name="TNodeControl"></typeparam>
        /// <returns></returns>
        public TNodeControl Add<TNodeControl>(string controlName, Dictionary<string, string> attributes = null) where TNodeControl : INodeControl, new();

        /// <summary>
        ///     Remove child.
        /// </summary>
        /// <param name="child"></param>
        public void Remove(INode child);

        /// <summary>
        ///     Start Listen for specified eventName.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="handler"></param>
        public void On(string eventName, EventHandler handler);

        /// <summary>
        ///     Stop Listen for specified eventName and handler.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="handler"></param>
        public void Off(string eventName, EventHandler handler);

        /// <summary>
        ///     Stop Listen for specified eventName.
        /// </summary>
        /// <param name="eventName"></param>
        public void Off(string eventName);

        /// <summary>
        ///     Handle incoming Node Event fired from client.
        /// </summary>
        /// <remarks>Never use this. This is called from application on incoming events</remarks>
        /// <param name="eventName"></param>
        /// <param name="eventArgs"></param>
        public void OnClientEventTriggered(string eventName, EventArgs eventArgs);


        /// <summary>
        ///     Add a method to the node, don't wait for response.
        ///     Later can be called via CallClientMethod and CallClientMethodWaitResponse
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="jsStatement"></param>
        public void AddJavascriptMethod(string methodName, string jsStatement);

        /// <summary>
        ///     Call a method on client side on this node with arguments, don't wait for response.
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="arguments"></param>
        public void CallClientMethod(string methodName, params string[] arguments);

        /// <summary>
        ///     Return Response after call a method on client side on this node with arguments.
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public Task<string> CallClientMethodAsync(string methodName, params string[] arguments);

        /// <summary>
        ///     Get First INode of a specific type
        ///     (eg. A Control get first Form Owner)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetFirstOwnerOfType<T>() where T : INode;

        /// <summary>
        ///     Get All children of a specific type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetChildrenOfType<T>() where T : INode;

        /// <summary>
        ///     Add a classname to class attribute
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public void AddCSSClass(string className);

        /// <summary>
        ///     Remove a classname from class attribute
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public void RemoveCSSClass(string className);
    }
}