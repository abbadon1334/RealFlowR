using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Timers;
using Microsoft.AspNetCore.SignalR;

namespace FlowR.Library.Client
{
    public class Application
    {
        /// <summary>
        /// UUID of the Context.ConnectionId.
        /// </summary>
        public string ConnectionId { get; }

        /// <summary>
        /// SignalR Client reference
        /// </summary>
        public IClientProxy Client { get; }

        /// <summary>
        /// Element ID of the master container for the application 
        /// </summary>
        private string RootElementId = "flow-root";

        public Application(string connectionId, IClientProxy client)
        {
            ConnectionId = connectionId;
            Client = client;

            //NotifyClient(new ApplicationEvent(OnInit))
            client.SendAsync("OnInit", RootElementId);
        }

        public void OnTimer(Object source, ElapsedEventArgs e)
        {
            //Client.SendAsync("OnTimer", "From server Timer " + counter).GetAwaiter().GetResult();
        }

        public async void OnClientEventTriggered(string s)
        {
            await Client.SendAsync("OnTest", s);
        }
    }
}