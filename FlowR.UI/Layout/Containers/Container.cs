using System.Collections.Generic;
using FlowR.Core;

namespace FlowR.UI.Layout.Containers
{
    /// <inheritdoc />
    public class Container : NodeElement
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
        public Container SetResponsiveBreakpoint(Enums.BreakpointsEnum breakpoint)
        {
            AddCssClass("container-" + breakpoint.ToString().ToLower());
            return this;
        }

        /// <summary>
        ///     Add Row to container
        /// </summary>
        /// <returns></returns>
        public Row AddRow()
        {
            return Add<Row>();
        }
    }
}