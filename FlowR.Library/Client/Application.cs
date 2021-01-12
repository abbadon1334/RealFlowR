using FlowR.Library.Client.Message;
using FlowR.Library.Client.Tags;
using FlowR.Library.Node;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace FlowR.Library.Client
{
    /// <summary>
    /// Application container class.
    /// </summary>
    public abstract class Application
    {
        private readonly ApplicationRegistry _registry = new();
        private readonly ApplicationResponses _responses = new();
        private readonly ApplicationTimers _timers = new();
        
        /// <summary>
        /// Root element of the Application.
        /// The composition tree that draw client UI starts from here.
        /// </summary>
        protected readonly Root RootElement;

        /// <summary>
        /// Element ID of the master container for the application
        /// </summary>
        protected readonly string RootElementId = "flow-root";

        /// <summary>
        /// this will be called from the FlowRHub Service 
        /// </summary>
        /// <param name="connectionId">connectionId from Hub</param>
        /// <param name="client">SignalR client from Hub</param>
        protected Application(string connectionId, IClientProxy client)
        {
            ConnectionId = connectionId;
            Client = client;
            
            // Prepare the root element 
            RootElement = new Root(RootElementId);
            RootElement.SetApplication(this);
            RootElement.Init();

            // register component
            _registry.RegisterComponent(RootElement);

            // send async message to client, indicating the id of the starting HTMLElement
            client.SendAsync("OnInit", RootElementId);
        }

        /// <summary>
        /// UUID of the Context.ConnectionId.
        /// </summary>
        private string ConnectionId { get; }

        /// <summary>
        ///     SignalR Client reference
        /// </summary>
        private IClientProxy Client { get; }
        
        /// <summary>
        /// [internal use] Add Node to registry.
        /// Internally called after add to parent Node, usually there is no need to be called. 
        /// </summary>
        /// <param name="node"></param>
        public void RegisterComponent(DomNode node)
        {
            // @todo find a way to lower visibility of internal calls 
            _registry.RegisterComponent(node);
        }

        /// <summary>
        /// Internally called, is private and must remain.
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        private DomNode GetRegisterComponent(string uuid)
        {
            // @todo find a way to lower visibility of internal calls 
            return _registry.Get(uuid);
        }
        
        /// <summary>
        /// [internal use] Remove Node from registry.
        /// Internally called after removed from parent Node, usually there is no need to be called. 
        /// </summary>
        /// <param name="node"></param>
        public void UnregisterComponent(DomNode node)
        {
            _registry.UnregisterComponent(node);
        }

        /// <summary>
        /// [internal use] Called from FlowR Hub when a client event is triggered.
        /// </summary>
        /// <param name="message"></param>
        public void OnClientEventTriggered(MessageEvent message)
        {
            // @todo find a way to lower visibility of internal calls
            
            GetRegisterComponent(message.Uuid).OnClientEventTriggered(
                message.EventName,
                new MessageEventArgs { Data = message.EventArgs }
            );
        }

        /// <summary>
        /// Add a Timer with a callback 
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
        /// Remove a Timer. 
        /// </summary>
        /// <param name="timer"></param>
        public void CancelTimer(ApplicationTimer timer)
        {
            _timers.Remove(timer);
        }

        /// <summary>
        /// Send a message to SignalR Client, don't wait for response
        /// </summary>
        /// <param name="message"></param>
        public Task SendMessage(Message.Message message)
        {
            var args = message.GetArgumentValues();

            return args.Length switch
            {
                0 => Client.SendAsync(message.Method),
                1 => Client.SendAsync(message.Method, args[0]),
                2 => Client.SendAsync(message.Method, args[0], args[1]),
                3 => Client.SendAsync(message.Method, args[0], args[1], args[2]),
                4 => Client.SendAsync(message.Method, args[0], args[1], args[2], args[3]),
                5 => Client.SendAsync(message.Method, args[0], args[1], args[2], args[3], args[4]),
                6 => Client.SendAsync(message.Method, args[0], args[1], args[2], args[3], args[4], args[5]),
                _ => throw new Exception("Message Arguments Array to long")
            };
        }

        /// <summary>
        /// Send a message to SignalR Client and wait for response
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<string> SendMessageWaitResponse(MessageWithResponse message)
        {
            // @todo add parameter here to define timeout of waiting for response, in place of MessageResponse
            return await _responses.WaitResponse(this, message);
        }

        /// <summary>
        /// [internal use] Called from SignalR Client when a new response arrive.
        /// </summary>
        /// <param name="message"></param>
        public void OnWaitingMessageResponse(MessageWithResponse message)
        {
            _responses.SetResponse(message);
        }

        /// <summary>
        /// Call a global JS method, don't wait for response.
        /// </summary>
        /// <example>from a DomNode : GetApplication().CallGlobalMethod('alert',['this is an alert']);</example>
        /// <param name="methodName"></param>
        /// <param name="arguments"></param>
        public void CallGlobalMethod(string methodName, params string[] arguments)
        {
            SendMessage(Factory.MessageGlobalMethodCall(methodName, arguments));
        }
        
        /// <summary>
        /// Call a global JS method and wait for response
        /// </summary>
        /// <param name="methodName">window method or complete traversed path like document.location.reload </param>
        /// <param name="arguments"></param>
        public async Task<string> CallGlobalMethodWaitResponse(string methodName, params string[] arguments)
        {
            var message = Factory.MessageGlobalMethodCallWaitResponse(methodName, arguments);
            return await _responses.WaitResponse(this, message);
        }
        
        /// <summary>
        /// Get a global JS property and wait for response
        /// </summary>
        /// <param name="path">window method or complete traversed path like document.location.reload </param>
        public async Task<string> GetGlobalProperty(string path)
        {
            var message = Factory.MessageGlobalGetPropertyWaitResponse(path);
            return await _responses.WaitResponse(this, message);
        }
        
        /// <summary>
        /// Set a global JS property and wait for response
        /// </summary>
        /// <param name="path">window property or complete traversed path like document.body.scrollHeight </param>
        /// <param name="value"></param>
        public void SetGlobalProperty(string path, string value)
        {
            SendMessage(Factory.MessageSetGlobalProperty(path, value));
        }
    }
}