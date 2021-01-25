namespace FlowR.Core
{
    /// <summary>
    ///     Special internal Node as root of the composite tree
    /// </summary>
    public class NodeComponentRoot : NodeComponent
    {
        /// <summary>
        ///     [internal use]
        /// </summary>
        /// <param name="rootId"></param>
        /// <param name="app"></param>
        public NodeComponentRoot(string rootId, Application app)
        {
            SetUuid(rootId);
            SetApplication(app);
        }
        /// <inheritdoc />
        protected override string TagName => "root";

        /// <inheritdoc />
        protected override void ValidateNode()
        {
        }
    }
}