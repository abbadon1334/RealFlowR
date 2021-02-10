namespace FlowR.Core
{
    /// <summary>
    ///     Special internal Node as root of the composite tree
    /// </summary>
    public class NodeElementRoot : NodeElement
    {
        /// <summary>
        ///     [internal use]
        /// </summary>
        /// <param name="rootId"></param>
        /// <param name="app"></param>
        public NodeElementRoot(string rootId, Application app)
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