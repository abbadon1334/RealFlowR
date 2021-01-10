using FlowR.Library;
using FlowR.Library.Client;
using FlowR.Library.Client.Message;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace FlowR
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class FlowRHub<T> : Hub where T : Application
    {
        private readonly FlowRService<T> _applicationFlowRService;
        
        public string ConnectionId() => Context.ConnectionId;

        public FlowRHub(FlowRService<T> applicationFlowRService)
        {
            _applicationFlowRService = applicationFlowRService;
        }

        public void ClientEventTriggered(string message)
        {
            _applicationFlowRService.Get(ConnectionId()).OnClientEventTriggered(
                MessageEvent.FromJson(message)
            );
        }

        public void ClientMessageResponse(string message)
        {
            _applicationFlowRService.Get(ConnectionId()).OnWaitingMessageResponse(
                MessageWithResponse.FromJson(message)
            );
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            _applicationFlowRService.Add(ConnectionId(), Clients.Caller);
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            await base.OnDisconnectedAsync(e);
            _applicationFlowRService.Remove(ConnectionId());
        }
    }
}