using FlowR.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowR.Hubs
{
    public class FlowRHub : Hub
    {

        private readonly ApplicationService _applicationService;

        public FlowRHub(ApplicationService applicationService)
        {
            if (applicationService == null)
            {
                throw new ArgumentNullException("applicationService");
            }
            _applicationService = applicationService;
        }

        public async Task SendMessage(string user, string message)
        {
            _applicationService.Increment();

            await Clients.All.SendAsync("ReceiveMessage", user, $"{Context.ConnectionId} : {message} {_applicationService.getCounter()}");
        }

        public override async Task OnConnectedAsync()
        {
            _applicationService.Increment();

            Console.WriteLine("Connect from: {0}", this.Context.ConnectionId);
            this.Context.GetHttpContext().Request.Headers.ToList().ForEach(item =>
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            });

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            Console.WriteLine("Dis from: {0}", this.Context.ConnectionId);
            await base.OnDisconnectedAsync(e);
        }
    }
}
