using System;
using System.Threading.Tasks;
using FlowR.Core.Messages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace FlowR.Core
{
    /// <summary>
    ///     Application container class.
    /// </summary>
    public abstract class Application
    {

        private readonly ILogger<Application> _logger;
        private readonly ApplicationRegistry _registry = new();
        private readonly ApplicationTimers _timers = new();

        /// <summary>
        ///     Root element of the Application.
        ///     The composition tree that draw client UI starts from here.
        /// </summary>
        protected readonly NodeElementRoot RootElement;

        /// <summary>
        ///     Element ID of the master container for the application
        /// </summary>
        protected readonly string RootElementId = "flow-root";

        /// <summary>
        ///     this will be called from the FlowRHub Service
        /// </summary>
        /// <param name="connectionId">connectionId from Hub</param>
        /// <param name="client">SignalR client from Hub</param>
        /// <param name="logger">ILogger</param>
        public Application(string connectionId, IClientProxy client, ILogger<Application> logger)
        {
            _logger = logger;

            ConnectionId = connectionId;
            Communication = new ApplicationCommunication(this, client);

            // Prepare the root element 
            RootElement = new NodeElementRoot(RootElementId, this);
            RootElement.Init();

            // register component
            _registry.RegisterComponent(RootElement);

            // send async message to client, indicating the id of the starting HTMLElement
            client.SendAsync("OnInit", RootElementId);

            GetLogger().LogInformation("Application initialized");
        }

        /// <summary>
        ///     Client Communications
        /// </summary>
        public ApplicationCommunication Communication { get; }

        /// <summary>
        ///     UUID of the Context.ConnectionId.
        /// </summary>
        private string ConnectionId { get; }

        /// <summary>
        ///     Get Application logger
        /// </summary>
        /// <returns></returns>
        public ILogger<Application> GetLogger()
        {
            return _logger;
        }

        /// <summary>
        ///     [internal use] Add Node to registry.
        ///     Internally called after add to parent Node, usually there is no need to be called.
        /// </summary>
        /// <param name="node"></param>
        public void RegisterComponent(INode node)
        {
            // @todo find a way to lower visibility of internal calls 
            _registry.RegisterComponent(node);
        }

        /// <summary>
        ///     Internally called, is private and must remain.
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        private INode GetRegisterComponent(string uuid)
        {
            return _registry.Get(uuid);
        }

        /// <summary>
        ///     [internal use] Remove Node from registry.
        ///     Internally called after removed from parent Node, usually there is no need to be called.
        /// </summary>
        /// <param name="node"></param>
        public void UnregisterComponent(INode node)
        {
            _registry.UnregisterComponent(node);
        }

        /// <summary>
        ///     [internal use] Called from FlowR Hub when a client event is triggered.
        /// </summary>
        /// <param name="message"></param>
        public void OnClientEventTriggered(MessageEvent message)
        {
            // @todo find a way to lower visibility of internal calls

            GetRegisterComponent(message.GetUuid()).OnClientEventTriggered(
                message.EventName,
                new MessageEventArgs { Data = message.EventArgs }
            );
        }

        /// <summary>
        ///     Add a Timer with a callback
        /// </summary>
        /// <param name="delay">delay in millisec</param>
        /// <param name="callback">The Callback</param>
        /// <param name="infinite">is a timeout or an interval</param>
        /// <remarks>Timer will be passed as first argument of every callback call, so you can stop it anytime</remarks>
        public void AddTimer(int delay, EventHandler callback, bool infinite = true)
        {
            _timers.AddTimer(delay, callback, infinite);
        }

        /// <summary>
        ///     Remove a Timer.
        /// </summary>
        /// <param name="timer"></param>
        public void CancelTimer(ApplicationTimer timer)
        {
            _timers.Remove(timer);
        }

        /// <summary>
        ///     Call a global JS method, don't wait for response.
        /// </summary>
        /// <example>from a DomNode : GetApplication().CallGlobalMethod('alert',['this is an alert']);</example>
        /// <param name="methodName"></param>
        /// <param name="arguments"></param>
        public void CallGlobalMethod(string methodName, params string[] arguments)
        {
            MessageGlobal.Factory.MessageGlobalMethodCall(
                methodName,
                arguments
            ).SendMessageAsync(Communication);
        }
        /// <summary>
        ///     Call a global JS method and wait for response
        /// </summary>
        /// <param name="methodName">window method or complete traversed path like document.location.reload </param>
        /// <param name="arguments"></param>
        public async Task<string> CallGlobalMethodWaitResponse(string methodName, params string[] arguments)
        {
            return await MessageGlobalWithResponse.Factory.MessageGlobalCallMethodWaitResponse(
                methodName,
                arguments
            ).SendMessageAsync(Communication);
        }
        /// <summary>
        ///     Get a global JS property and wait for response
        /// </summary>
        /// <param name="path">window method or complete traversed path like document.location.reload </param>
        public async Task<string> GetGlobalProperty(string path)
        {
            return await MessageGlobalWithResponse.Factory.MessageGlobalGetPropertyWaitResponse(
                path
            ).SendMessageAsync(Communication);
        }
        /// <summary>
        ///     Set a global JS property and wait for response
        /// </summary>
        /// <param name="path">window property or complete traversed path like document.body.scrollHeight </param>
        /// <param name="value"></param>
        public void SetGlobalProperty(string path, string value)
        {
            MessageGlobal.Factory.MessageSetGlobalProperty(
                path,
                value
            ).SendMessageAsync(Communication);
        }

        /// <summary>
        ///     Inject Javascript file in document
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> AddJavascriptResource(string url)
        {
            return await MessageGlobalWithResponse.Factory.MessageGlobalAddScriptWaitLoad(url)
                .SendMessageAsync(Communication);
        }

        /// <summary>
        ///     Inject Stylesheet file in document
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> AddStylesheetResource(string url)
        {
            return await MessageGlobalWithResponse.Factory.MessageGlobalAddStylesheetWaitLoad(url)
                .SendMessageAsync(Communication);
        }
    }
}