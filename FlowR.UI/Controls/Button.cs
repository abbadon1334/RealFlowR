using FlowR.Core;

namespace FlowR.UI.Controls
{
    /// <summary>
    ///     Tag button
    /// </summary>
    public class Button : ComponentElement<Button>
    {
        /// <inheritdoc cref="Node.TagName" />
        public override string TagName { get; } = "button";
    }
}