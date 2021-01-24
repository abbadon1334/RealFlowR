using System.Collections.Generic;

namespace FlowR.Core
{
    /// <summary>
    ///     Application DomNode registry, used to fast access uuid->DomNode
    /// </summary>
    public class ApplicationRegistry
    {
        private readonly Dictionary<string, INode> _registerComponents = new();

        /// <summary>
        ///     Add to Registry
        /// </summary>
        /// <param name="node"></param>
        public void RegisterComponent(INode node)
        {
            _registerComponents[node.GetUuid()] = node;
        }

        /// <summary>
        ///     Remove from Registry
        /// </summary>
        /// <param name="node"></param>
        public void UnregisterComponent(INode node)
        {
            _registerComponents.Remove(node.GetUuid());
        }

        /// <summary>
        ///     Get a DomNode from registry
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public INode Get(string uuid)
        {
            return _registerComponents[uuid];
        }
    }
}