using System.Collections.Generic;
using FlowR.Core;

namespace FlowR.UI.Layout
{
    /// <inheritdoc />
    public class Container : NodeComponent
    {
        /// <inheritdoc />
        protected override string TagName => "div";

        /// <inheritdoc />
        protected override Dictionary<string, string> DefaultAttributes { get; set; } = new()
        {
            { "class", "container" },
        };

        /// <summary>
        ///     Set responsive class
        /// </summary>
        /// <param name="breakpoint"></param>
        /// <returns></returns>
        public Container SetResponsive(ResponsiveViewports breakpoint)
        {
            AddCssClass("container-" + breakpoint.ToString().ToLower());
            return this;
        }

        /// <summary>
        ///     Add Row to container
        /// </summary>
        /// <returns></returns>
        public ContainerRow AddRow()
        {
            return Add<ContainerRow>();
        }
    }
}