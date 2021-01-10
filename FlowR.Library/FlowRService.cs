using System;
using System.Collections.Generic;
using FlowR.Library.Client;
using Microsoft.AspNetCore.SignalR;

namespace FlowR.Library
{
    public class FlowRService<T> where T : Application
    {
        private readonly Dictionary<string, T> _applications = new();

        public T Get(string uid)
        {
            return _applications[uid];
        }

        public T Add(string uid, IClientProxy client)
        {
            var application = (T) Activator.CreateInstance(typeof(T), uid, client);

            _applications.Add(uid, application);

            return application;
        }

        public bool Remove(string uid)
        {
            return _applications.Remove(uid);
        }
    }
}