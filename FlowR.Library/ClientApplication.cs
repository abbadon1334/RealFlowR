using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Timers;
using Microsoft.AspNetCore.SignalR;

namespace FlowR.Library
{
    public class ClientApplication
    {
        private string Uid;
        private IClientProxy Client;
        
        private int counter = 0;

        protected const string RootElementId = "flow-root";


        public ClientApplication(string id, IClientProxy client)
        {
            Uid = id;
            Client = client;

            // Create a timer with a two second interval.
            Timer aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimer;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            client.SendAsync("OnInit", RootElementId);
        }

        public void OnTimer(Object source, ElapsedEventArgs e)
        {
            counter++;
            Client.SendAsync("OnTimer", "From server Timer " + counter).GetAwaiter().GetResult();
        }

        public async void OnClientEventTriggered(string s)
        {
            await Client.SendAsync("OnTest", s);
        }
    }
}