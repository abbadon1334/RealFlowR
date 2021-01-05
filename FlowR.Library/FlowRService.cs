using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using FlowR.Library.Client;

namespace FlowR.Library
{
    public class FlowRService
    {
        private readonly Dictionary<string, Application> _applications = new();
        
        public Application Get(string uid)
        {
            return _applications[uid];
        }

        public Application Add(string uid, IClientProxy client)
        {
            var application = new Application(uid, client);

            _applications.Add(uid, application);

            return application;
        }

        public bool Remove(string uid)
        {
            return _applications.Remove(uid);
        }
    }
}