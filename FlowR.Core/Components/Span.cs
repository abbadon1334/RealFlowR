namespace FlowR.Core.Components
{
    /// <summary>
    ///     Tag div
    /// </summary>
    public class Span : ComponentElement<Span>
    {
        /// <inheritdoc cref="Node.TagName" />
        public override string TagName { get; protected set; } = "span";
    }
}