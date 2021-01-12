using FlowR.Library.Node;
using System.Collections.Generic;

namespace FlowR.Library.Client
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationRegistry' visibile pubblicamente
    public class ApplicationRegistry
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationRegistry' visibile pubblicamente
    {
        private readonly Dictionary<string, DomNode> _registerComponents = new();

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationRegistry.RegisterComponent(DomNode)' visibile pubblicamente
        public void RegisterComponent(DomNode node)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationRegistry.RegisterComponent(DomNode)' visibile pubblicamente
        {
            _registerComponents[node.GetUuid()] = node;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationRegistry.UnregisterComponent(DomNode)' visibile pubblicamente
        public void UnregisterComponent(DomNode node)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationRegistry.UnregisterComponent(DomNode)' visibile pubblicamente
        {
            _registerComponents.Remove(node.GetUuid());
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationRegistry.Get(string)' visibile pubblicamente
        public DomNode Get(string uuid)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationRegistry.Get(string)' visibile pubblicamente
        {
            return _registerComponents[uuid];
        }
    }
}