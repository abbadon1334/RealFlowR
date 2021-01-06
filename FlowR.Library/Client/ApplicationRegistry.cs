using System.Collections.Generic;
using FlowR.Library.Node;

namespace FlowR.Library.Client
{
    public class ApplicationRegistry
    {
        private readonly Dictionary<string, DomNode> _registerComponents = new();

        public void RegisterComponent(DomNode node)
        {
            _registerComponents[node.GetUuid()] = node;
        }

        public void UnregisterComponent(DomNode node)
        {
            _registerComponents.Remove(node.GetUuid());
        }

        public DomNode Get(string uuid)
        {
            return _registerComponents[uuid];
        }
    }
}