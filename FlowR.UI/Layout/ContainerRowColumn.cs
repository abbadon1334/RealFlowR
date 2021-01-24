using System.Collections.Generic;
using FlowR.Core;

namespace FlowR.UI.Layout
{
    /// <summary>
    ///     Column of row container
    /// </summary>
    public class ContainerRowColumn : NodeComponent
    {
        /// <inheritdoc />
        protected override string TagName => "div";

        /// <inheritdoc />
        protected override Dictionary<string, string> DefaultAttributes { get; set; } = new()
        {
            { "class", "col" }
        };
    }
}