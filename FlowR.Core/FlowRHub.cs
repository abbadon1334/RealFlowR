using System;
using System.Threading.Tasks;
using FlowR.Core.Message;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace FlowR.Core
{
    /// <summary>
    ///     FlowR Hub Service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FlowRHub<T> : Hub where T : Application
    {
        private readonly FlowRService<T> _applicationFlowRService;
        private readonly ILogger<Application> _logger;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="applicationFlowRService"></param>
        public FlowRHub(FlowRService<T> applicationFlowRService, ILogger<Application> logger)
        {
            _applicationFlowRService = applicationFlowRService;
            _logger = logger;
        }

        /// <summary>
        ///     Called from client whenever an event fires on a Node which are listen for that specific event.
        /// </summary>
        /// <see cref="INode.On(string, EventHandler)" />
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
        /// <see cref="ApplicationCommunication.SendMessageWaitResponse" />
        /// <param name="message"></param>
        public void ClientMessageResponse(string message)
        {
            _applicationFlowRService.Get(Context.ConnectionId).Communication.OnWaitingMessageResponse(
                MessageResponse.FromJson(message)
            );
        }

        /// <inheritdoc />
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            _applicationFlowRService.Add(Context.ConnectionId, Clients.Caller, _logger);
        }

        /// <inheritdoc />
        public override async Task OnDisconnectedAsync(Exception e)
        {
            await base.OnDisconnectedAsync(e);
            _applicationFlowRService.Remove(Context.ConnectionId);
        }
    }
}