using FlowR.Library.Node;

namespace FlowR.Library.Client.Tags
{
    /// <summary>
    /// Tag button
    /// </summary>
    public class Button : DomNode
    {
        /// <inheritdoc cref="DomNode.TagName"/>
        protected override string TagName => "button";
    }
}