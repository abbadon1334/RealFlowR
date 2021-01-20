using System;
using System.Collections.Generic;

namespace FlowR.Core
{
    /// <summary>
    ///     Collection Events class that filter to only essential method
    /// </summary>
    public class NodeCollectionEvent : NodeCollection<List<EventHandler>>
    {
        /// <inheritdoc />
        /// summary>
        public NodeCollectionEvent(Node owner) : base(owner)
        {
        }

        /// <inheritdoc cref="Component{T}.On" />
        /// summary>
        public void On(string eventName, EventHandler handler)
        {
            if (!Exists(eventName)) Set(eventName, new List<EventHandler>());

            Get(eventName).Add(handler);
        }

        /// <inheritdoc cref="Component{T}.On" />
        /// summary>
        public void Off(string eventName, EventHandler handler)
        {
            Get(eventName).Remove(handler);
        }

        /// <inheritdoc cref="Node.OnClientEventTriggered" />
        public void OnClientEventTriggered(string eventName, EventArgs eventArgs)
        {
            Get(eventName).ForEach(observerDelegate => observerDelegate.Invoke(Owner, eventArgs));
        }
    }
}