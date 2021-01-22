using System.Collections.Generic;
using System.Linq;
using FlowR.Core;
using FlowR.Core.Components;
using FlowR.Core.Components.Controls;

namespace FlowR.UI.Components
{
    public class Navbar : ComponentElement<Navbar>
    {

        public Div Container;
        /// <inheritdoc />
        public override string TagName { get; protected set; } = "navbar";

        protected override Dictionary<string, string> defaultAttributes { get; set; } = new()
        {
            { "class", "navbar navbar-expand-lg" }
        };

        /// <inheritdoc />
        public override void Init()
        {
            base.Init();
            Container = Add<Div>().SetAttribute("class", "container-fluid");
        }

        /// <summary>
        ///     Add navbar brand.
        /// </summary>
        /// <returns></returns>
        public Div AddBrand()
        {
            return Container.Add<Div>().AddCSSClass("navbar-brand");
        }

        /// <summary>
        ///     Add Toggler button.
        /// </summary>
        /// <returns></returns>
        public Button AddToggler()
        {
            var Button = Container.Add<Button>().AddCSSClass("navbar-toggler");

            Container = Container.Add<Div>().AddCSSClass("collapse navbar-collapse");

            Button.SetAttributes(new Dictionary<string, string>
            {
                { "type", "button" },
                { "data-bs-toggle", "collapse" },
                { "data-bs-target", "#" + Container.Uuid },
                { "aria-controls", Container.Uuid },
                { "aria-expanded", "false" },
                { "aria-label", "Toggle navigation" }
            }.ToArray());

            Button.Add<Span>().AddCSSClass("navbar-toggler-icon");

            return Button;
        }

        public NavbarMenu AddMenu()
        {
            return Container.Add<NavbarMenu>();
        }
    }
}