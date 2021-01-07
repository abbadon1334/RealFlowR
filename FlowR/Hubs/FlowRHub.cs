using FlowR.Library;
using FlowR.Library.Client;
using FlowR.Library.Client.Message;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace FlowR.Hubs
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class FlowRHub<T> : Hub where T : Application
    {
        private readonly FlowRService<T> _applicationFlowRService;

        public FlowRHub(FlowRService<T> applicationFlowRService)
        {
            _applicationFlowRService = applicationFlowRService;
        }

        public void ClientEventTriggered(string message)
        {
            _applicationFlowRService.Get(Context.ConnectionId).OnClientEventTriggered(
                MessageEvent.FromJson(message)
            );
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            _applicationFlowRService.Add(Context.ConnectionId, Clients.Caller);
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            await base.OnDisconnectedAsync(e);
            _applicationFlowRService.Remove(Context.ConnectionId);
        }
    }
}