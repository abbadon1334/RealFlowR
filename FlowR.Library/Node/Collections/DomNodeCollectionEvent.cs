using System;
using System.Collections.Generic;

namespace FlowR.Library.Node.Collections
{
    public class DomNodeCollectionEvent : DomNodeCollection<List<DomNodeEvent>>
    {
        public DomNodeCollectionEvent(DomNode owner) : base(owner)
        {
        }

        public event EventHandler StartEventListen;
        public event EventHandler StopEventListen;

        public void On(string eventName, DomNodeEvent handler)
        {
            if (!Exists(eventName)) StartEventListen?.Invoke(GetOwner(), new ListenerEventArgs {Name = eventName});

            Get(eventName).Add(handler);
        }

        public void Off(string eventName, DomNodeEvent handler)
        {
            Get(eventName).Remove(handler);
            StopEventListen?.Invoke(GetOwner(), new ListenerEventArgs {Name = eventName});
        }

        public void OnClientEventTriggered(string eventName, EventArgs eventArgs)
        {
            Get(eventName).ForEach(observerDelegate => observerDelegate.Invoke(GetOwner(), eventArgs));
        }
    }

    public delegate void DomNodeEvent(DomNode source, EventArgs eventArgs);

    public class ListenerEventArgs : EventArgs
    {
        public string Name;
    }
}