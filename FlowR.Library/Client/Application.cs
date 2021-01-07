using FlowR.Library.Client.Message;
using FlowR.Library.Client.Tags;
using FlowR.Library.Node;
using Microsoft.AspNetCore.SignalR;
using System;

namespace FlowR.Library.Client
{
    public class Application
    {
        private readonly ApplicationRegistry _registry = new();
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

        protected virtual void OnStart(Root rootElement)
        {
            throw new Exception("You need to override Application::OnStart");
        }

        /// <summary>
        ///     UUID of the Context.ConnectionId.
        /// </summary>
        public string ConnectionId { get; }

        /// <summary>
        ///     SignalR Client reference
        /// </summary>
        public IClientProxy Client { get; }

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
                new MessageEventArgs() { Data = message.EventArgs }
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
    }
}