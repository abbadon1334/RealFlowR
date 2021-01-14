using System;
using System.Threading.Tasks;
using FlowR.Library.Client;
using FlowR.Library.Client.Message;
using Microsoft.AspNetCore.SignalR;

namespace FlowR.Library
{
    /// <summary>
    ///     FlowR Hub Service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FlowRHub<T> : Hub where T : Application
    {
        private readonly FlowRService<T> _applicationFlowRService;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="applicationFlowRService"></param>
        public FlowRHub(FlowRService<T> applicationFlowRService)
        {
            _applicationFlowRService = applicationFlowRService;
        }

        /// <summary>
        ///     Called from client whenever an event fires on a Node which are listen for that specific event.
        /// </summary>
        /// <see cref="Node.DomNode.On(string, EventHandler)" />
        /// <param name="message"></param>
        public void ClientEventTriggered(string message)
        {
            _applicationFlowRService.Get(Context.ConnectionId).OnClientEventTriggered(
                MessageEvent.FromJson(message)
            );
        }

        /// <summary>
        ///     Called from client when a previous message request a response
        /// </summary>
        /// <see cref="Node.DomNode.CallClientMethodWaitResponse(string, string[])" />
        /// <see cref="ApplicationCommunication.CallGlobalMethodWaitResponse(string, string[])" />
        /// <param name="message"></param>
        public void ClientMessageResponse(string message)
        {
            _applicationFlowRService.Get(Context.ConnectionId).Communication.OnWaitingMessageResponse(
                MessageWithResponse.FromJson(message)
            );
        }

        /// <inheritdoc />
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            _applicationFlowRService.Add(Context.ConnectionId, Clients.Caller);
        }

        /// <inheritdoc />
        public override async Task OnDisconnectedAsync(Exception e)
        {
            await base.OnDisconnectedAsync(e);
            _applicationFlowRService.Remove(Context.ConnectionId);
        }
    }
}