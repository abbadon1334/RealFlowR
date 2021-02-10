using System.Collections.Generic;
using FlowR.Core;

namespace FlowR.UI.Components
{
    /// <summary>
    ///     Tag div
    /// </summary>
    public class NavbarMenu : NodeElement
    {
        /// <inheritdoc />
        protected override string TagName => "ul";

        /// <inheritdoc />
        protected override Dictionary<string, string> DefaultAttributes { get; set; } = new()
        {
            { "class", "navbar-nav" },
        };

        /// <summary>
        ///     Add menu item.
        /// </summary>
        /// <returns></returns>
        public NavbarMenuItem AddMenuItem()
        {
            return Add<NavbarMenuItem>();
        }
    }
}