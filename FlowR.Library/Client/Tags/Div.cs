using FlowR.Library.Node;

namespace FlowR.Library.Client.Tags
{
    /// <summary>
    /// Tag div
    /// </summary>
    public class Div : DomNode
    {
        /// <inheritdoc cref="DomNode.TagName"/>
        protected override string TagName => "div";
    }
}