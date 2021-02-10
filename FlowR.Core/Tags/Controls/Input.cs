using System.Collections.Generic;

namespace FlowR.Core.Tags.Controls
{
    /// <summary>
    ///     Defines an input control.
    /// </summary>
    public class Input : NodeControl
    {
        /// <inheritdoc />
        protected override Dictionary<string, string> DefaultAttributes => new()
        {
            { "type", "text" },
        };

        /// <inheritdoc />
        protected override string TagName => "input";
    }
}