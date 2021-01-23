using System.Collections.Generic;
using FlowR.Core;

namespace FlowR.UI.Components
{
    /// <summary>
    ///     Tag div
    /// </summary>
    public class NavbarMenu : ComponentElement<NavbarMenu>
    {
        /// <inheritdoc cref="Node.TagName" />
        public override string TagName { get; protected set; } = "ul";

        /// <inheritdoc />
        protected override Dictionary<string, string> defaultAttributes { get; set; } = new()
        {
            { "class", "navbar-nav" }
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