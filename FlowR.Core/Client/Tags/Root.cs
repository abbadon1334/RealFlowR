using FlowR.Library.Node;

namespace FlowR.Library.Client.Tags
{
    /// <summary>
    ///     Special internal Tag as root of the composite tree
    /// </summary>
    public class Root : DomNode
    {
        /// <summary>
        ///     [internal use]
        /// </summary>
        /// <param name="rootId"></param>
        public Root(string rootId)
        {
            Uuid = rootId;
        }

        /// <inheritdoc cref="DomNode.TagName" />
        public new readonly string TagName = "body";
    }
}