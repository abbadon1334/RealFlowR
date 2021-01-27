using System.Collections.Generic;
using FlowR.Core;

namespace FlowR.UI.Layout.Containers
{
    /// <summary>
    ///     Row of container
    /// </summary>
    public class Row : NodeComponent
    {
        /// <inheritdoc />
        protected override string TagName => "div";

        /// <inheritdoc />
        protected override Dictionary<string, string> DefaultAttributes { get; set; } = new()
        {
            { "class", "row" },
        };

        private Column AddCol()
        {
            return Add<Column>();
        }
    }
}