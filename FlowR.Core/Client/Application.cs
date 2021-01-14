using System;
using FlowR.Library.Client.Message;
using FlowR.Library.Client.Tags;
using FlowR.Library.Node;
using Microsoft.AspNetCore.SignalR;

namespace FlowR.Library.Client
{
    /// <summary>
    ///     Application container class.
    /// </summary>
    public abstract class Application
    {
        private readonly ApplicationRegistry _registry = new();
        private readonly ApplicationTimers _timers = new();

        /// <summary>
        ///     Root element of the Application.
        ///     The composition tree that draw client UI starts from here.
        /// </summary>
        protected readonly Root RootElement;

        /// <summary>
        ///     Element ID of the master container for the application
        /// </summary>
        protected readonly string RootElementId = "flow-root";

        /// <summary>
        ///     this will be called from the FlowRHub Service
        /// </summary>
        /// <param name="connectionId">connectionId from Hub</param>
        /// <param name="client">SignalR client from Hub</param>
        protected Application(string connectionId, IClientProxy client)
        {
            ConnectionId = connectionId;
            Communication = new ApplicationCommunication(this, client);

            // Prepare the root element 
            RootElement = new Root(RootElementId);
            RootElement.Application = this;
            RootElement.Init();

            // register component
            _registry.RegisterComponent(RootElement);

            // send async message to client, indicating the id of the starting HTMLElement
            client.SendAsync("OnInit", RootElementId);
        }

        /// <inheritdoc cref="ApplicationCommunication" />
        public ApplicationCommunication Communication { get; }

        /// <summary>
        ///     UUID of the Context.ConnectionId.
        /// </summary>
        private string ConnectionId { get; }

        /// <summary>
        ///     [internal use] Add Node to registry.
        ///     Internally called after add to parent Node, usually there is no need to be called.
        /// </summary>
        /// <param name="node"></param>
        public void RegisterComponent(DomNode node)
        {
            // @todo find a way to lower visibility of internal calls 
            _registry.RegisterComponent(node);
        }

        /// <summary>
        ///     Internally called, is private and must remain.
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        private DomNode GetRegisterComponent(string uuid)
        {
            // @todo find a way to lower visibility of internal calls 
            return _registry.Get(uuid);
        }

        /// <summary>
        ///     [internal use] Remove Node from registry.
        ///     Internally called after removed from parent Node, usually there is no need to be called.
        /// </summary>
        /// <param name="node"></param>
        public void UnregisterComponent(DomNode node)
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
    }
}