using System.Collections.Generic;

namespace FlowR.Core
{
    /// <summary>
    ///     Application DomNode registry, used to fast access uuid->DomNode
    /// </summary>
    public class ApplicationRegistry
    {
        private readonly Dictionary<string, Node> _registerComponents = new();

        /// <summary>
        ///     Add to Registry
        /// </summary>
        /// <param name="node"></param>
        public void RegisterComponent(Node node)
        {
            _registerComponents[node.Uuid] = node;
        }

        /// <summary>
        ///     Remove from Registry
        /// </summary>
        /// <param name="node"></param>
        public void UnregisterComponent(Node node)
        {
            _registerComponents.Remove(node.Uuid);
        }

        /// <summary>
        ///     Get a DomNode from registry
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public Node Get(string uuid)
        {
            return _registerComponents[uuid];
        }
    }
}