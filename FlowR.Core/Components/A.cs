using System.Collections.Generic;

namespace FlowR.Core.Components
{
    /// <summary>
    ///     Tag div
    /// </summary>
    public class A : ComponentElement<A>
    {
        /// <inheritdoc cref="Node.TagName" />
        public override string TagName { get; protected set; } = "a";

        protected override Dictionary<string, string> defaultAttributes { get; set; } = new()
        {
            { "href", "#" }
        };
    }
}