namespace FlowR.Core
{
    /// <summary>
    ///     Special internal Node as root of the composite tree
    /// </summary>
    public class ComponentRoot : Node
    {

        /// <summary>
        ///     [internal use]
        /// </summary>
        /// <param name="rootId"></param>
        public ComponentRoot(string rootId)
        {
            Uuid = rootId;
        }
        /// <inheritdoc cref="Node.TagName" />
        public override string TagName => "body";
    }
}