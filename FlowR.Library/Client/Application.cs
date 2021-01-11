using System;
using System.Threading.Tasks;
using FlowR.Library.Client.Message;
using FlowR.Library.Client.Tags;
using FlowR.Library.Node;
using Microsoft.AspNetCore.SignalR;

namespace FlowR.Library.Client
{
    public abstract class Application
    {
        private readonly ApplicationRegistry _registry = new();
        private readonly ApplicationResponses _responses = new();
        private readonly ApplicationTimers _timers = new();

        protected readonly Root RootElement;

        /// <summary>
        ///     Element ID of the master container for the application
        /// </summary>
        protected readonly string RootElementId = "flow-root";

        protected Application(string connectionId, IClientProxy client)
        {
            ConnectionId = connectionId;
            Client = client;
            RootElement = new Root(RootElementId);
            RootElement.SetApplication(this);
            RootElement.Init();
            _registry.RegisterComponent(RootElement);

            //NotifyClient(new ApplicationEvent(OnInit))
            client.SendAsync("OnInit", RootElementId);

            OnStart(RootElement);
        }

        /// <summary>
        ///     UUID of the Context.ConnectionId.
        /// </summary>
        private string ConnectionId { get; }

        /// <summary>
        ///     SignalR Client reference
        /// </summary>
        private IClientProxy Client { get; }

        protected virtual void OnStart(Root rootElement)
        {
            throw new Exception("You need to override Application::OnStart");
        }

        public void RegisterComponent(DomNode node)
        {
            _registry.RegisterComponent(node);
        }

        private DomNode GetRegisterComponent(string uuid)
        {
            return _registry.Get(uuid);
        }

        public void UnregisterComponent(DomNode node)
        {
            _registry.UnregisterComponent(node);
        }

        public void OnClientEventTriggered(MessageEvent message)
        {
            GetRegisterComponent(message.Uuid).OnClientEventTriggered(
                message.EventName,
                new MessageEventArgs {Data = message.EventArgs}
            );
        }

        public void AddTimer(int delay, EventHandler callback, bool infinite = true)
        {
            _timers.AddTimer(delay, callback, infinite);
        }

        public void Remove(ApplicationTimer timer)
        {
            _timers.Remove(timer);
        }

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

        public async Task<string> SendMessageWaitResponse(MessageWithResponse message)
        {
            return await _responses.WaitResponse(this, message);
        }

        public void OnWaitingMessageResponse(MessageWithResponse message)
        {
            _responses.SetResponse(message);
        }

        public void CallGlobalMethod(string methodName, params string[] arguments)
        {
            SendMessage(Factory.MessageGlobalMethodCall(methodName, arguments));
        }

        public async Task<string> CallGlobalMethodWaitResponse(string methodName, params string[] arguments)
        {
            var message = Factory.MessageGlobalMethodCallWaitResponse(methodName, arguments);
            return await _responses.WaitResponse(this, message);
        }
    }
}