using FlowR.Library.Client.Message;
using FlowR.Library.Client.Tags;
using FlowR.Library.Node;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace FlowR.Library.Client
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Application' visibile pubblicamente
    public abstract class Application
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Application' visibile pubblicamente
    {
        private readonly ApplicationRegistry _registry = new();
        private readonly ApplicationResponses _responses = new();
        private readonly ApplicationTimers _timers = new();

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Application.RootElement' visibile pubblicamente
        protected readonly Root RootElement;
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Application.RootElement' visibile pubblicamente

        /// <summary>
        ///     Element ID of the master container for the application
        /// </summary>
        protected readonly string RootElementId = "flow-root";

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Application.Application(string, IClientProxy)' visibile pubblicamente
        protected Application(string connectionId, IClientProxy client)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Application.Application(string, IClientProxy)' visibile pubblicamente
        {
            ConnectionId = connectionId;
            Client = client;
            RootElement = new Root(RootElementId);
            RootElement.SetApplication(this);
            RootElement.Init();

            _registry.RegisterComponent(RootElement);

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

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Application.OnStart(Root)' visibile pubblicamente
        protected virtual void OnStart(Root rootElement)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Application.OnStart(Root)' visibile pubblicamente
        {
            throw new Exception("You need to override Application::OnStart");
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Application.RegisterComponent(DomNode)' visibile pubblicamente
        public void RegisterComponent(DomNode node)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Application.RegisterComponent(DomNode)' visibile pubblicamente
        {
            _registry.RegisterComponent(node);
        }

        private DomNode GetRegisterComponent(string uuid)
        {
            return _registry.Get(uuid);
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Application.UnregisterComponent(DomNode)' visibile pubblicamente
        public void UnregisterComponent(DomNode node)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Application.UnregisterComponent(DomNode)' visibile pubblicamente
        {
            _registry.UnregisterComponent(node);
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Application.OnClientEventTriggered(MessageEvent)' visibile pubblicamente
        public void OnClientEventTriggered(MessageEvent message)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Application.OnClientEventTriggered(MessageEvent)' visibile pubblicamente
        {
            GetRegisterComponent(message.Uuid).OnClientEventTriggered(
                message.EventName,
                new MessageEventArgs { Data = message.EventArgs }
            );
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Application.AddTimer(int, EventHandler, bool)' visibile pubblicamente
        public void AddTimer(int delay, EventHandler callback, bool infinite = true)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Application.AddTimer(int, EventHandler, bool)' visibile pubblicamente
        {
            _timers.AddTimer(delay, callback, infinite);
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Application.Remove(ApplicationTimer)' visibile pubblicamente
        public void Remove(ApplicationTimer timer)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Application.Remove(ApplicationTimer)' visibile pubblicamente
        {
            _timers.Remove(timer);
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Application.SendMessage(Message)' visibile pubblicamente
        public Task SendMessage(Message.Message message)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Application.SendMessage(Message)' visibile pubblicamente
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

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Application.SendMessageWaitResponse(MessageWithResponse)' visibile pubblicamente
        public async Task<string> SendMessageWaitResponse(MessageWithResponse message)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Application.SendMessageWaitResponse(MessageWithResponse)' visibile pubblicamente
        {
            return await _responses.WaitResponse(this, message);
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Application.OnWaitingMessageResponse(MessageWithResponse)' visibile pubblicamente
        public void OnWaitingMessageResponse(MessageWithResponse message)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Application.OnWaitingMessageResponse(MessageWithResponse)' visibile pubblicamente
        {
            _responses.SetResponse(message);
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Application.CallGlobalMethod(string, params string[])' visibile pubblicamente
        public void CallGlobalMethod(string methodName, params string[] arguments)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Application.CallGlobalMethod(string, params string[])' visibile pubblicamente
        {
            SendMessage(Factory.MessageGlobalMethodCall(methodName, arguments));
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Application.CallGlobalMethodWaitResponse(string, params string[])' visibile pubblicamente
        public async Task<string> CallGlobalMethodWaitResponse(string methodName, params string[] arguments)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Application.CallGlobalMethodWaitResponse(string, params string[])' visibile pubblicamente
        {
            var message = Factory.MessageGlobalMethodCallWaitResponse(methodName, arguments);
            return await _responses.WaitResponse(this, message);
        }
    }
}