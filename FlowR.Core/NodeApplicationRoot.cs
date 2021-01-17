namespace FlowR.Core
{
    /// <summary>
    ///     Special internal Node as root of the composite tree
    /// </summary>
    public class NodeApplicationRoot : Node
    {
        /// <inheritdoc cref="Node.TagName" />
        public new readonly string TagName = "body";
        /// <summary>
        ///     [internal use]
        /// </summary>
        /// <param name="rootId"></param>
        public NodeApplicationRoot(string rootId)
        {
            Uuid = rootId;
        }
    }
}