using FlowR.Library.Client;
using FlowR.Library.Client.Message;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace FlowR.Library
{
    // ReSharper disable once ClassNeverInstantiated.Global
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'FlowRHub<T>' visibile pubblicamente
    public class FlowRHub<T> : Hub where T : Application
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'FlowRHub<T>' visibile pubblicamente
    {
        private readonly FlowRService<T> _applicationFlowRService;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="applicationFlowRService"></param>
        public FlowRHub(FlowRService<T> applicationFlowRService)
        {
            _applicationFlowRService = applicationFlowRService;
        }

        /// <summary>
        /// Called from client whenever an event fires on a Node which are listen for that specific event.
        /// </summary>
        /// <see cref="Node.DomNode.On(string, EventHandler)"/>
        /// <param name="message"></param>
        public void ClientEventTriggered(string message)
        {
            _applicationFlowRService.Get(Context.ConnectionId).OnClientEventTriggered(
                MessageEvent.FromJson(message)
            );
        }

        /// <summary>
        /// Called from client when a previous message request a response 
        /// </summary>
        /// <see cref="Node.DomNode.CallClientMethodWaitResponse(string, string[])"/>
        /// <see cref="Application.CallGlobalMethodWaitResponse(string, string[])"/>
        /// <param name="message"></param>
        public void ClientMessageResponse(string message)
        {
            _applicationFlowRService.Get(Context.ConnectionId).OnWaitingMessageResponse(
                MessageWithResponse.FromJson(message)
            );
        }

        /// <inheritdoc/>
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            _applicationFlowRService.Add(Context.ConnectionId, Clients.Caller);
        }

        /// <inheritdoc/>
        public override async Task OnDisconnectedAsync(Exception e)
        {
            await base.OnDisconnectedAsync(e);
            _applicationFlowRService.Remove(Context.ConnectionId);
        }
    }
}