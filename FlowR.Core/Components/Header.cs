namespace FlowR.Core.Components
{
    /// <summary>
    ///     Tag div
    /// </summary>
    public class Header : ComponentElement<Header>
    {
        /// <inheritdoc cref="Node.TagName" />
        public override string TagName { get; protected set; } = "header";
    }
}