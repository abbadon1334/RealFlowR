using System.Collections.Generic;
using FlowR.Core.Tags;
using FlowR.UI.Layout;

namespace FlowR.UI.Components
{
    /// <summary>
    ///     Navbar Bootstrap element
    /// </summary>
    public class Navbar : BootstrapComponent<Navbar>
    {
        /// <summary>
        ///     Internal container
        /// </summary>
        public Container Container;
        /// <inheritdoc />
        protected override string TagName => "navbar";

        /// <inheritdoc />
        protected override Dictionary<string, string> DefaultAttributes { get; set; } = new()
        {
            { "class", "navbar navbar-expand-lg" }
        };

        /// <inheritdoc />
        public override void Init()
        {
            base.Init();
            Container = Add<Container>();
            Container.SetResponsive(ResponsiveViewports.FLUID);
        }

        /// <summary>
        ///     Add navbar brand.
        /// </summary>
        /// <returns></returns>
        public Div AddBrand()
        {
            var div = Container.Add<Div>();
            div.AddCssClass("navbar-brand me-md-auto");

            return div;
        }

        /// <summary>
        ///     Add Toggler button.
        /// </summary>
        /// <returns></returns>
        public Button AddToggler()
        {
            var button = Container.Add<Button>();
            button.AddCssClass("navbar-toggler btn btn-outline-primary");

            Container = Container.Add<Container>();
            Container.AddCssClass("collapse navbar-collapse");

            button.SetAttribute(new Dictionary<string, string>
            {
                { "type", "button" },
                { "data-bs-toggle", "collapse" },
                { "data-bs-target", "#" + Container.GetUuid() },
                { "aria-controls", Container.GetUuid() },
                { "aria-expanded", "false" },
                { "aria-label", "Toggle navigation" }
            });

            button.Add<Span>().AddCssClass("navbar-toggler-icon");

            return button;
        }

        /// <summary>
        ///     Add menu to navbar
        /// </summary>
        /// <returns></returns>
        public NavbarMenu AddMenu()
        {
            return Container.Add<NavbarMenu>();
        }
    }
}