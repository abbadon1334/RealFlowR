using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;

namespace FlowR.Library
{
    public class FlowRService
    {
        private readonly Dictionary<string, ClientApplication> applications = new();
        
        public ClientApplication get(string uid)
        {
            return applications[uid];
        }

        public ClientApplication add(string uid, IClientProxy client)
        {
            var application = new ClientApplication(uid, client);

            applications.Add(uid, application);

            return application;
        }

        public bool remove(string uid)
        {
            return applications.Remove(uid);
        }
    }
}