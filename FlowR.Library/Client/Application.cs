using System;
using System.Threading.Tasks;
using FlowR.Library.Client.Message;
using FlowR.Library.Client.Tags;
using FlowR.Library.Node;
using Microsoft.AspNetCore.SignalR;

namespace FlowR.Library.Client
{
    public class Application
    {
        private readonly ApplicationRegistry _registry = new();
        private readonly ApplicationResponses _responses = new();
        private readonly ApplicationTimers _timers = new();

        protected readonly Root RootElement;

        /// <summary>
        ///     Element ID of the master container for the application
        /// </summary>
        protected readonly string RootElementId = "flow-root";

        public Application(string connectionId, IClientProxy client)
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
        public string ConnectionId { get; }

        /// <summary>
        ///     SignalR Client reference
        /// </summary>
        public IClientProxy Client { get; }

        protected virtual void OnStart(Root rootElement)
        {
            throw new Exception("You need to override Application::OnStart");
        }

        public void RegisterComponent(DomNode node)
        {
            _registry.RegisterComponent(node);
        }

        public DomNode GetRegisterComponent(string uuid)
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

        public void AddTimer(ApplicationTimer timer)
        {
            _timers.Add(timer);
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

            switch (args.Length)
            {
                case 0:
                    return Client.SendAsync(message.Method);
                case 1:
                    return Client.SendAsync(message.Method, args[0]);
                case 2:
                    return Client.SendAsync(message.Method, args[0], args[1]);

                case 3:
                    return Client.SendAsync(message.Method, args[0], args[1], args[2]);

                case 4:
                    return Client.SendAsync(message.Method, args[0], args[1], args[2], args[3]);

                case 5:
                    return Client.SendAsync(message.Method, args[0], args[1], args[2], args[3], args[4]);

                case 6:
                    return Client.SendAsync(message.Method, args[0], args[1], args[2], args[3], args[4], args[5]);
            }

            throw new Exception("Message Arguments Array to long");
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