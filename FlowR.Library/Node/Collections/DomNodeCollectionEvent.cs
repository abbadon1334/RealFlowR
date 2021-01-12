using System;
using System.Collections.Generic;

namespace FlowR.Library.Node.Collections
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionEvent' visibile pubblicamente
    public class DomNodeCollectionEvent : DomNodeCollection<List<EventHandler>>
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionEvent' visibile pubblicamente
    {
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionEvent.DomNodeCollectionEvent(DomNode)' visibile pubblicamente
        public DomNodeCollectionEvent(DomNode owner) : base(owner)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionEvent.DomNodeCollectionEvent(DomNode)' visibile pubblicamente
        {
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionEvent.On(string, EventHandler)' visibile pubblicamente
        public void On(string eventName, EventHandler handler)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionEvent.On(string, EventHandler)' visibile pubblicamente
        {
            if (!Exists(eventName)) Set(eventName, new List<EventHandler>());

            Get(eventName).Add(handler);
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionEvent.Off(string, EventHandler)' visibile pubblicamente
        public void Off(string eventName, EventHandler handler)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionEvent.Off(string, EventHandler)' visibile pubblicamente
        {
            Get(eventName).Remove(handler);
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionEvent.OnClientEventTriggered(string, EventArgs)' visibile pubblicamente
        public void OnClientEventTriggered(string eventName, EventArgs eventArgs)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeCollectionEvent.OnClientEventTriggered(string, EventArgs)' visibile pubblicamente
        {
            Get(eventName).ForEach(observerDelegate => observerDelegate.Invoke(GetOwner(), eventArgs));
        }
    }
}