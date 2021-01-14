using System;
using System.Collections.Generic;
using FlowR.Library.Client;
using Microsoft.AspNetCore.SignalR;

namespace FlowR.Library
{
    /// <summary>
    /// Singleton service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FlowRService<T> where T : Application
    {
        private readonly Dictionary<string, T> _applications = new();

        /// <summary>
        /// Get application from application registry
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public T Get(string uid)
        {
            return _applications[uid];
        }

        /// <summary>
        /// Add Application to Registry
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="client"></param>
        public void Add(string uid, IClientProxy client)
        {
            var application = (T) Activator.CreateInstance(typeof(T), uid, client);

            _applications.Add(uid, application);
        }

        /// <summary>
        /// Remove Application from registry
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public bool Remove(string uid)
        {
            return _applications.Remove(uid);
        }
    }
}