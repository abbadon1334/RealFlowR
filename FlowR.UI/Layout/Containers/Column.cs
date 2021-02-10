using System.Collections.Generic;
using FlowR.Core;

namespace FlowR.UI.Layout.Containers
{
    /// <summary>
    ///     Column of row container
    /// </summary>
    public class Column : NodeElement
    {
        /// <inheritdoc />
        protected override string TagName => "div";

        /// <inheritdoc />
        protected override Dictionary<string, string> DefaultAttributes { get; set; } = new()
        {
            { "class", "col" },
        };
    }
}