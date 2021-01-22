namespace FlowR.Core.Components
{
    /// <summary>
    ///     Tag div
    /// </summary>
    public class Nav : ComponentElement<Nav>
    {
        /// <inheritdoc cref="Node.TagName" />
        public override string TagName { get; protected set; } = "nav";
    }
}