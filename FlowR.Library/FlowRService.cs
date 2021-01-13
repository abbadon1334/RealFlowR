using System;
using System.Collections.Generic;
using FlowR.Library.Client;
using Microsoft.AspNetCore.SignalR;

namespace FlowR.Library
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'FlowRService<T>' visibile pubblicamente
    public class FlowRService<T> where T : Application
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'FlowRService<T>' visibile pubblicamente
    {
        private readonly Dictionary<string, T> _applications = new();

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'FlowRService<T>.Get(string)' visibile pubblicamente
        public T Get(string uid)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'FlowRService<T>.Get(string)' visibile pubblicamente
        {
            return _applications[uid];
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'FlowRService<T>.Add(string, IClientProxy)' visibile pubblicamente
        public void Add(string uid, IClientProxy client)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'FlowRService<T>.Add(string, IClientProxy)' visibile pubblicamente
        {
            var application = (T) Activator.CreateInstance(typeof(T), uid, client);

            _applications.Add(uid, application);
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'FlowRService<T>.Remove(string)' visibile pubblicamente
        public bool Remove(string uid)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'FlowRService<T>.Remove(string)' visibile pubblicamente
        {
            return _applications.Remove(uid);
        }
    }
}