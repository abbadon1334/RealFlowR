using System;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace FlowR.Core
{
    /// <summary>
    ///     Singleton service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FlowRService<T> where T : Application
    {
        private readonly ConcurrentDictionary<string, T> _applications = new();

        /// <summary>
        ///     Get application from application registry
        /// </summary>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        public T Get(string connectionId)
        {
            return _applications[connectionId];
        }

        /// <summary>
        ///     Add Application to Registry
        /// </summary>
        /// <param name="connectionId"></param>
        /// <param name="client"></param>
        /// <param name="logger"></param>
        public void Add(string connectionId, IClientProxy client, ILogger<Application> logger)
        {
            var application = (T)Activator.CreateInstance(typeof(T), connectionId, client, logger);

            logger.LogDebug("new App : " + connectionId);

            _applications.TryAdd(connectionId, application);
        }

        /// <summary>
        ///     Remove Application from registry
        /// </summary>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        public bool Remove(string connectionId)
        {
            return _applications.TryRemove(connectionId, out var app);
        }
    }
}