using System;
using System.Collections.Generic;

namespace FlowR.Library.Node.Collections
{
    /// <summary>
    ///     Collection Events class that filter to only essential method
    /// </summary>
    public class DomNodeCollectionEvent : DomNodeCollection<List<EventHandler>>
    {
        /// <inheritdoc />
        /// summary>
        public DomNodeCollectionEvent(DomNode owner) : base(owner)
        {
        }

        /// <inheritdoc cref="DomNode.On" />
        /// summary>
        public void On(string eventName, EventHandler handler)
        {
            if (!Exists(eventName)) Set(eventName, new List<EventHandler>());

            Get(eventName).Add(handler);
        }

        /// <inheritdoc cref="DomNode.Off" />
        /// summary>
        public void Off(string eventName, EventHandler handler)
        {
            Get(eventName).Remove(handler);
        }

        /// <inheritdoc cref="DomNode.OnClientEventTriggered" />
        public void OnClientEventTriggered(string eventName, EventArgs eventArgs)
        {
            Get(eventName).ForEach(observerDelegate => observerDelegate.Invoke(Owner, eventArgs));
        }
    }
}