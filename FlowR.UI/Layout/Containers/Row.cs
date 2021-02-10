using System.Collections.Generic;
using FlowR.Core;

namespace FlowR.UI.Layout.Containers
{
    /// <summary>
    ///     Row of container
    /// </summary>
    public class Row : NodeElement
    {
        /// <inheritdoc />
        protected override string TagName => "div";

        /// <inheritdoc />
        protected override Dictionary<string, string> DefaultAttributes { get; set; } = new()
        {
            { "class", "row" },
        };

        /// <summary>
        ///     Add a column
        /// </summary>
        /// <returns></returns>
        public Column AddCol()
        {
            return Add<Column>();
        }
    }
}