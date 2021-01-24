using System.Collections.Generic;
using FlowR.Core;

namespace FlowR.UI.Layout
{
    /// <summary>
    ///     Row of container
    /// </summary>
    public class ContainerRow : NodeComponent
    {
        /// <inheritdoc />
        protected override string TagName => "div";

        /// <inheritdoc />
        protected override Dictionary<string, string> defaultAttributes { get; set; } = new()
        {
            { "class", "row" }
        };

        private ContainerRowColumn AddCol()
        {
            return Add<ContainerRowColumn>();
        }
    }
}