using System.Collections.Generic;
using FlowR.Core;
using FlowR.Core.Tags;
using FlowR.UI.Layout;

namespace FlowR.UI.Components
{
    /// <summary>
    ///     Navbar Bootstrap element
    /// </summary>
    public class Navbar : NodeComponent
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
            Container.setResponsive(ResponsiveViewports.FLUID);
        }

        /// <summary>
        ///     Add navbar brand.
        /// </summary>
        /// <returns></returns>
        public Div AddBrand()
        {
            var div = Container.Add<Div>();
            div.AddCSSClass("navbar-brand me-md-auto");

            return div;
        }

        /// <summary>
        ///     Add Toggler button.
        /// </summary>
        /// <returns></returns>
        public Button AddToggler()
        {
            var Button = Container.Add<Button>();
            Button.AddCSSClass("navbar-toggler btn btn-outline-primary");

            Container = Container.Add<Container>();
            Container.AddCSSClass("collapse navbar-collapse");

            Button.SetAttribute(new Dictionary<string, string>
            {
                { "type", "button" },
                { "data-bs-toggle", "collapse" },
                { "data-bs-target", "#" + Container.GetUuid() },
                { "aria-controls", Container.GetUuid() },
                { "aria-expanded", "false" },
                { "aria-label", "Toggle navigation" }
            });

            Button.Add<Span>().AddCSSClass("navbar-toggler-icon");

            return Button;
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