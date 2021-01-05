using System;
using System.Linq;
using System.Threading.Tasks;
using FlowR.Library;
using Microsoft.AspNetCore.SignalR;

namespace FlowR.Hubs
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class FlowRHub : Hub
    {
        private readonly FlowRService _applicationFlowRService;

        public FlowRHub(FlowRService applicationFlowRService)
        {
            _applicationFlowRService = applicationFlowRService;
        }

        public void ClientEventTriggered(string message)
        {
            _applicationFlowRService.Get(Context.ConnectionId).OnClientEventTriggered(message);
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