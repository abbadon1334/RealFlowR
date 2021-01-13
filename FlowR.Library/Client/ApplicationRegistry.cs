using System.Collections.Generic;
using FlowR.Library.Node;

namespace FlowR.Library.Client
{
    /// <summary>
    ///     Application DomNode registry, used to fast access uuid->DomNode
    /// </summary>
    public class ApplicationRegistry
    {
        private readonly Dictionary<string, DomNode> _registerComponents = new();

        /// <summary>
        ///     Add to Registry
        /// </summary>
        /// <param name="node"></param>
        public void RegisterComponent(DomNode node)
        {
            _registerComponents[node.GetUuid()] = node;
        }

        /// <summary>
        ///     Remove from Registry
        /// </summary>
        /// <param name="node"></param>
        public void UnregisterComponent(DomNode node)
        {
            _registerComponents.Remove(node.GetUuid());
        }

        /// <summary>
        ///     Get a DomNode from registry
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public DomNode Get(string uuid)
        {
            return _registerComponents[uuid];
        }
    }
}