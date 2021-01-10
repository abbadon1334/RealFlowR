using System;
using System.Collections.Generic;

namespace FlowR.Library.Node.Collections
{
    public class DomNodeCollectionEvent : DomNodeCollection<List<EventHandler>>
    {
        public DomNodeCollectionEvent(DomNode owner) : base(owner)
        {
        }

        public void On(string eventName, EventHandler handler)
        {
            if (!Exists(eventName)) Set(eventName, new List<EventHandler>());

            Get(eventName).Add(handler);
        }

        public void Off(string eventName, EventHandler handler)
        {
            Get(eventName).Remove(handler);
        }

        public void OnClientEventTriggered(string eventName, EventArgs eventArgs)
        {
            Get(eventName).ForEach(observerDelegate => observerDelegate.Invoke(GetOwner(), eventArgs));
        }
    }
}